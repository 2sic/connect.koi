using System.Linq;

namespace Connect.Koi.Html
{
    public class BuilderBase
    {

        public string Current => _current ?? CssFrameworks.Unknown;
        private readonly string _current = CssFrameworks.Unknown;

        public BuilderBase(string selected)
        {
            _current = selected.ToLowerInvariant();
        }


        /// <summary>
        /// 
        /// </summary>
        public bool IsUnknown => Current == CssFrameworks.Unknown;

        public bool Is(string expectedCss) 
            => expectedCss.PickOrCheckOther(Current) != null;



        public string If(string expectedCss, string htmlToShow, string alternative = "") 
            => Is(expectedCss) ? htmlToShow : alternative;

        public string IfUnknown(string htmlToShow, string alternative = "") 
            => If(CssFrameworks.Unknown, htmlToShow, alternative);

        public string PickCss(string expectedCss, string alternative = "")
            => expectedCss.PickOrCheckOther(Current) ?? alternative;


    }

    internal static class Helpers
    {


        private static string[] SplitComma(this string source)
            => source.ToLowerInvariant().Split(',');

        internal static string PickOrCheckOther(this string list, string current)
            => list.SplitComma().PickOrCheckOther(current);

        internal static string PickOrCheckOther(this string[] list, string current)
        {
            if (list.Contains(current)) return current;

            // if it's known, check if the list contains the "oth" (other) code
            return current != CssFrameworks.Unknown && list.Contains(CssFrameworks.Other)
                ? CssFrameworks.Other
                : null;
        }
    }
}
