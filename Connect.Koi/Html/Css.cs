using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Connect.Koi.Internals;

namespace Connect.Koi.Html
{
    public class Css : BuilderBase
    {
        public Css(string selected) : base(selected) { }

        private const string ClassWrapper = "class=\"{0}\"";


        public string Class(string list) => Classify(() => Pick(list));


        private static string Classify(Func<string> pick) => string.Format(ClassWrapper, pick());


        #region Pick and overloads
        public string Pick(string list, string separator = " ")
        {
            var parts = ClassesRegEx.Matches(list).AsEnumerable()
                .SelectMany(m => m.Groups["Name"].Value.Split(',')
                    .Select(k => new { Key = k, m.Groups["Classes"].Value })
                )
                // this will put all matches of the same partial key together
                // if we have the same key like bs3=... more than once
                .GroupBy(s => s.Key)
                .ToDictionary(s => s.Key, s => string.Join(separator, s.Select(v => v.Value)));

            return Pick(parts);
        }


        private static Regex ClassesRegEx => new Regex(@"(?<Name>[a-z0-9,]*)[:=][\['""](?<Classes>[^\]'""]*)[\]'""]");

        public string Pick(IDictionary<string, string> list)
        {
            var all = list.GetOrNull(CssFrameworks.All);

            var bestMatch = list.GetOrNull(Current) // if current is not known, it will already pick the "unk" key
                ?? list.GetOrNull(CssFrameworks.Other); // otherwise get the stuff for the other-key

            return $"{all} {bestMatch}".Trim();
        }
        #endregion

    }

    internal static class DicHelper
    {
        public static string GetOrNull(this IDictionary<string, string> dict, string key) 
            => dict.TryGetValue(key, out var value) ? value : null;
    }
}
