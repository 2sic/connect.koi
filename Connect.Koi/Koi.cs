using Connect.Koi.Context;
using Connect.Koi.Internals;
#if NET451
using HtmlString = System.Web.HtmlString;
#else
using HtmlString = Microsoft.AspNetCore.Html.HtmlString;
#endif


namespace Connect.Koi
{
    public static class Koi
    {
        /// <summary>
        /// Get or create a current/cached state within the current HttpContext
        /// </summary>
        private static ToolsForCurrentState Tools =>
            (ToolsForCurrentState) (HttpContext.Current.Items[Keys.CurrentKoiInHttpContext]
                    ?? (HttpContext.Current.Items[Keys.CurrentKoiInHttpContext] = new ToolsForCurrentState()));


        /// <summary>
        /// The name of the CSS framework in use. 
        /// </summary>
        public static string Css => Tools.State.CssFramework ?? CssFrameworks.Unknown;


        /// <summary>
        /// A quick helper to generate a class-attribute
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        public static HtmlString Class(string classes) => new HtmlString(Tools.Css.Class(classes));

        /// <summary>
        /// Show something if the CSS framework matches what you want
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="htmlToShow"></param>
        /// <param name="alternative"></param>
        /// <returns></returns>
        public static HtmlString If(string expected, string htmlToShow, string alternative = "")
            => new HtmlString(Tools.Css.If(expected, htmlToShow, alternative));

        /// <summary>
        /// Show something if the CSS framework is unknown
        /// </summary>
        /// <param name="htmlToShow"></param>
        /// <param name="alternative"></param>
        /// <returns></returns>
        public static HtmlString IfUnknown(string htmlToShow, string alternative = "") 
            => new HtmlString(Tools.Css.IfUnknown(htmlToShow, alternative));


    }
}
