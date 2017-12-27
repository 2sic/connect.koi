using System.Web;

namespace Connect.Koi
{
    public static class Koi
    {
        /// <summary>
        /// Get or create a current Pond object
        /// </summary>
        private static Pond Pond =>
            (Pond) (HttpContext.Current.Items[Keys.Koi]
                    ?? (HttpContext.Current.Items[Keys.Koi] = new Pond()));


        /// <summary>
        /// The name of the CSS framework in use. 
        /// Set should only be called once, 
        /// ready can be used as often as you need
        /// </summary>
        public static string Css
        {
            get => Pond.State.CssFramework ?? Connect.Koi.Css.Unknown;
            set => Pond.State.CssFramework = value;
        }



        public static HtmlString Class(string classes) => new HtmlString(Pond.TemplateHelper.Class(classes));

    }
}
