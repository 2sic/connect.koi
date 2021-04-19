
namespace Connect.Koi
{
    // TODO: Rename to ICssConditions or something
    public interface ICssBuilder
    {
        /// <summary>
        /// A quick helper to generate a class-attribute
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        string ClassAttribute(string classes);

        /// <summary>
        /// Show something if the CSS framework matches what you want
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="htmlToShow"></param>
        /// <param name="alternative"></param>
        /// <returns></returns>
        string If(string expected, string htmlToShow, string alternative = "");

        /// <summary>
        /// Show something if the CSS framework is unknown
        /// </summary>
        /// <param name="htmlToShow"></param>
        /// <param name="alternative"></param>
        /// <returns></returns>
        string IfUnknown(string htmlToShow, string alternative = "");

    }
}
