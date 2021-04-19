namespace Connect.Koi.Internals
{
    public class Keys
    {
        /// <summary>
        /// Css Framework Key to be used in the global items dictionary
        /// </summary>
        public static readonly string CssFramework = "current-httpcontext-primary-css-framework";

        ///// <summary>
        ///// JS Framework Key to be used in the global items dictionary
        ///// ! not in use yet - don't use !
        ///// </summary>
        //public static readonly string JsFramework = "current-httpcontext-primary-js-framework";

        public static readonly string CurrentKoiInHttpContext = "a6eebc77-64a2-459a-bfee-7f441f2e2c62"; // use a guid to be really unique
    }
}
