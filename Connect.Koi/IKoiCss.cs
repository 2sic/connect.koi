#if NET451
using HtmlString = System.Web.HtmlString;
#else
using HtmlString = Microsoft.AspNetCore.Html.HtmlString;
#endif

namespace Connect.Koi
{
    public interface IKoiCss
    {
        /// <summary>
        /// The name of the CSS framework in use. 
        /// </summary>
        string Css { get; }

        /// <summary>
        /// True if the framework isn't known
        /// </summary>
        bool IsUnknown { get; }

        string PickCss(string list, string alternative = "");

        /// <summary>
        /// A quick helper to generate a class-attribute
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        HtmlString Class(string classes);

        /// <summary>
        /// Show something if the CSS framework matches what you want
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="htmlToShow"></param>
        /// <param name="alternative"></param>
        /// <returns></returns>
        HtmlString If(string expected, string htmlToShow, string alternative = "");

        /// <summary>
        /// Show something if the CSS framework is unknown
        /// </summary>
        /// <param name="htmlToShow"></param>
        /// <param name="alternative"></param>
        /// <returns></returns>
        HtmlString IfUnknown(string htmlToShow, string alternative = "");

        /// <summary>
        /// check if the current css framework is the expected css
        /// </summary>
        /// <param name="expectedCss">a key like bs3 or combination of keys like bs3,bs4</param>
        /// <returns></returns>
        bool Is(string expectedCss);
    }
}
