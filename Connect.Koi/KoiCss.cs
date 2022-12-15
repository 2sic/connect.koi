using Connect.Koi.Detectors;
using Connect.Koi.Html;

namespace Connect.Koi
{

    public class KoiCss : ICss
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
        private readonly Css _css;
        

        /// <summary>
        /// The name of the CSS framework in use. 
        /// </summary>
        public string Framework => _css.Current ?? CssFrameworks.Unknown;


        /// <summary>
        /// True if the framework isn't known
        /// </summary>
        public bool IsUnknown => _css.IsUnknown;

        /// <summary>
        /// check if the current css framework is the expected css
        /// </summary>
        /// <param name="expectedFramework">a key like bs3 or combination of keys like bs3,bs4</param>
        /// <returns></returns>
        public bool Is(string expectedFramework) => _css.Is(expectedFramework);

    }
}
