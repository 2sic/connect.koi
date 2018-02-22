using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Koi.Helpers;

namespace Koi
{
    public partial class TemplateHelper
    {
        private const string ClassWrapper = "class=\"{0}\"";


        public string Class(string list) => Classify(() => Pick(list));
        public string Class(IDictionary<string, string> list) => Classify(() => Pick(list));



        private static string Classify(Func<string> pick) => string.Format(ClassWrapper, pick());


        #region Pick and overloads
        public string Pick(string list)
        {
            var parts = ClassesRegEx.Matches(list).AsEnumerable()
                .SelectMany(m => m.Groups["Name"].Value.Split(',')
                    .Select(k => new { Key = k, m.Groups["Classes"].Value })
                )
                .ToDictionary(s => s.Key, s => s.Value);

            return Pick(parts);
        }
        private static Regex ClassesRegEx => new Regex(@"(?<Name>[a-z0-9,]*)[:=][\['""](?<Classes>[^\]'""]*)[\]'""]");

        public string Pick(IDictionary<string, string> list)
        {
            var all = list.ContainsKey(Css.All) ? list[Css.All] : null;
            var best = list.ContainsKey(Current) ? list[Current] : null;
            var preferred = best ?? (list.ContainsKey(Css.Unknown)
                                ? list[Css.Unknown]
                                : null);

            return $"{all} {preferred}".Trim();
        }
        #endregion
    }
}
