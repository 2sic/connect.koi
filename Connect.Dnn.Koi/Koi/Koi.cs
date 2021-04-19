using System;
using Connect.Koi.Context;
using Connect.Koi.Internals;
using System.Web;
using HtmlString = System.Web.HtmlString;


namespace Connect.Koi
{
    [Obsolete("Shouldn't be used any more - please get ICssInfo or ICssBuilder as a Dependency Injection service")]
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

        public static string PickCss(string list, string alternative = "")
            => Tools.Css.PickCss(list, alternative);

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

        /// <summary>
        /// True if the framework isn't known
        /// </summary>
        public static bool IsUnknown => Tools.Css.IsUnknown;

        /// <summary>
        /// check if the current css framework is the expected css
        /// </summary>
        /// <param name="expectedCss">a key like bs3 or combination of keys like bs3,bs4</param>
        /// <returns></returns>
        public static bool Is(string expectedCss) => Tools.Css.Is(expectedCss);



    }
}
