using System;

namespace Connect.Koi.Html
{
    public class BuilderBase
    {

        public string Current => _current ?? CssFrameworks.Unknown;
        private readonly string _current;

        public BuilderBase(string selected)
        {
            _current = selected.ToLowerInvariant();
        }

        public bool Is(string compare) => string.Equals(Current, compare, StringComparison.InvariantCultureIgnoreCase);


        /// <summary>
        /// 
        /// </summary>
        public bool IsUnknown => Current == CssFrameworks.Unknown;

        public string If(string expectedCss, string htmlToShow, string alternative = "") 
            => Current == expectedCss ? htmlToShow : alternative;

        public string IfUnknown(string htmlToShow, string alternative = "") 
            => If(CssFrameworks.Unknown, htmlToShow, alternative); // IsUnknown ? htmlToShow : alternative;



    }
}
