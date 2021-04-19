using Connect.Koi.Detectors;
using Connect.Koi.Html;
#if NET451
using HtmlString = System.Web.HtmlString;
#else
// TODO: @STV - pls change system to
// - compile as .net451 and .net standard 2 and .net core 5
// If this causes trouble, then only .net 451 and .net core 5
// Then make sure these types here return a MarkupString in .net core 5
using HtmlString = Microsoft.AspNetCore.Html.HtmlString;
#endif


namespace Connect.Koi
{

    public class KoiCss : ICssInfo, ICssBuilder
    {
        /// <summary>
        /// Dependencies class - to ensure that inheriting classes don't need to worry about signature changes. 
        /// </summary>
        public class Dependencies
        {
            public ICssFrameworkDetector CssDetector { get; }

            public Dependencies(ICssFrameworkDetector cssDetector)
            {
                CssDetector = cssDetector;
            }
        }
        
        /// <summary>
        /// Constructor for DI
        /// </summary>
        public KoiCss(Dependencies dependencies)
        {
            _css = new Css(dependencies.CssDetector.AutoDetect());
        }

        /// <summary>
        /// Get or create a current/cached state within the current HttpContext
        /// </summary>
        private Css _css;
        

        /// <summary>
        /// The name of the CSS framework in use. 
        /// </summary>
        public string Css => _css.Current ?? CssFrameworks.Unknown;

        public string PickCss(string list, string alternative = "")
            => _css.PickCss(list, alternative);

        /// <summary>
        /// A quick helper to generate a class-attribute
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        public HtmlString Class(string classes) => new HtmlString(_css.Class(classes));

        /// <summary>
        /// Show something if the CSS framework matches what you want
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="htmlToShow"></param>
        /// <param name="alternative"></param>
        /// <returns></returns>
        public HtmlString If(string expected, string htmlToShow, string alternative = "")
            => new HtmlString(_css.If(expected, htmlToShow, alternative));

        /// <summary>
        /// Show something if the CSS framework is unknown
        /// </summary>
        /// <param name="htmlToShow"></param>
        /// <param name="alternative"></param>
        /// <returns></returns>
        public HtmlString IfUnknown(string htmlToShow, string alternative = "") 
            => new HtmlString(_css.IfUnknown(htmlToShow, alternative));

        /// <summary>
        /// True if the framework isn't known
        /// </summary>
        public bool IsUnknown => _css.IsUnknown;

        /// <summary>
        /// check if the current css framework is the expected css
        /// </summary>
        /// <param name="expectedCss">a key like bs3 or combination of keys like bs3,bs4</param>
        /// <returns></returns>
        public bool Is(string expectedCss) => _css.Is(expectedCss);

    }
}
