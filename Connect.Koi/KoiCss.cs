﻿using Connect.Koi.Context;
using Connect.Koi.Internals;
#if NET451
using HtmlString = System.Web.HtmlString;
#else
using HtmlString = Microsoft.AspNetCore.Html.HtmlString;
#endif


namespace Connect.Koi
{

    public class KoiCss : IKoiCss
    {
        /// <summary>
        /// Dependencies class - to ensure that inheriting classes don't need to worry about signature changes. 
        /// </summary>
        public class Dependencies
        {

        }
        
        /// <summary>
        /// Constructor for DI
        /// </summary>
        public KoiCss(Dependencies dependencies)
        {

        }
        
        /// <summary>
        /// Get or create a current/cached state within the current HttpContext
        /// </summary>
        private static ToolsForCurrentState Tools =>
            (ToolsForCurrentState) (HttpContext.Current.Items[Keys.CurrentKoiInHttpContext]
                    ?? (HttpContext.Current.Items[Keys.CurrentKoiInHttpContext] = new ToolsForCurrentState()));


        /// <summary>
        /// The name of the CSS framework in use. 
        /// </summary>
        public string Css => Tools.State.CssFramework ?? CssFrameworks.Unknown;

        public string PickCss(string list, string alternative = "")
            => Tools.Css.PickCss(list, alternative);

        /// <summary>
        /// A quick helper to generate a class-attribute
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        public HtmlString Class(string classes) => new HtmlString(Tools.Css.Class(classes));

        /// <summary>
        /// Show something if the CSS framework matches what you want
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="htmlToShow"></param>
        /// <param name="alternative"></param>
        /// <returns></returns>
        public HtmlString If(string expected, string htmlToShow, string alternative = "")
            => new HtmlString(Tools.Css.If(expected, htmlToShow, alternative));

        /// <summary>
        /// Show something if the CSS framework is unknown
        /// </summary>
        /// <param name="htmlToShow"></param>
        /// <param name="alternative"></param>
        /// <returns></returns>
        public HtmlString IfUnknown(string htmlToShow, string alternative = "") 
            => new HtmlString(Tools.Css.IfUnknown(htmlToShow, alternative));

        /// <summary>
        /// True if the framework isn't known
        /// </summary>
        public bool IsUnknown => Tools.Css.IsUnknown;

        /// <summary>
        /// check if the current css framework is the expected css
        /// </summary>
        /// <param name="expectedCss">a key like bs3 or combination of keys like bs3,bs4</param>
        /// <returns></returns>
        public bool Is(string expectedCss) => Tools.Css.Is(expectedCss);

    }
}
