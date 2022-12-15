
namespace Connect.Koi
{
    public interface ICss
    {
        /// <summary>
        /// The name of the CSS framework in use. 
        /// </summary>
        string Framework { get; }

        /// <summary>
        /// True if the framework isn't known
        /// </summary>
        bool IsUnknown { get; }

        /// <summary>
        /// check if the current css framework is the expected css
        /// </summary>
        /// <param name="expectedFramework">a key like bs3 or combination of keys like bs3,bs4</param>
        /// <returns></returns>
        bool Is(string expectedFramework);
    }
}
