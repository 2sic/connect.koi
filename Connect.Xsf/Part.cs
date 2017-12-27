using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Connect.Koi.Helpers;

namespace Connect.Koi
{
    public class Part
    {

        public const string Initial = Css.Unknown;
        public const string All = Css.All;

        public string Default = Initial;

        public string Current => _current ?? Default;
        private readonly string _current;

        public Part(string selected)
        {
            _current = selected.ToLowerInvariant();
        }

        public bool Is(string compare) => string.Equals(Current, compare, StringComparison.InvariantCultureIgnoreCase);

        public string Pick(string list)
        {
            var parts = ClassesRegEx.Matches(list).AsEnumerable().SelectMany(m =>

                    m.Groups["Name"].Value.Split(',')
                    .Select(k => new {Key = k, m.Groups["Classes"].Value})
                )
                .ToDictionary(s => s.Key, s => s.Value);
                //.ToDictionary(m => m.Groups["Name"].Value, m => m.Groups["Classes"].Value);

            return Pick(parts);
        }

        public string Pick(IDictionary<string, string> list)
        {
            var all = list.ContainsKey(Css.All) ? list[Css.All] : null;
            var best = list.ContainsKey(Current) ? list[Current] : null;
            var preferred = best ?? (list.ContainsKey(Css.Unknown)
                                ? list[Css.Unknown]
                                : null);

            return $"{all} {preferred}".Trim();
        }


        private static Regex ClassesRegEx => new Regex(@"(?<Name>[a-z0-9,]*)[:=][\['""](?<Classes>[^\]'""]*)[\]'""]");

        private const string ClassWrapper= "class=\"{0}\"";

        //private const string StyleWrapper = "style=\"{0}\"";

        public string Class(string list) => Classify(() => Pick(list));
        public string Class(IDictionary<string, string> list) => Classify(() => Pick(list));



        private static string Classify(Func<string> pick) => string.Format(ClassWrapper, pick());
        //private string Styleify(Func<string> pick) => string.Format(StyleWrapper, pick());
    }
}
