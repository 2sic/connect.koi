
namespace Connect.Koi
{
    public interface ICssInfo
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
        /// check if the current css framework is the expected css
        /// </summary>
        /// <param name="expectedCss">a key like bs3 or combination of keys like bs3,bs4</param>
        /// <returns></returns>
        bool Is(string expectedCss);
    }
}
