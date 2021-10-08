using System.Collections;
using System.Web;
using Connect.Koi.Dnn;
using Connect.Koi.Internals;

namespace Connect.Koi.Context
{
    /// <summary>
    /// This is the helper class for the full .net framework
    /// In .net core it will probably have to be a bit different
    /// </summary>
    internal class HttpContextState: StateBase
    {
        public override string CssFramework
        {
            get
            {
                if (HttpContext.Current?.Items == null) return null;

                var items = HttpContext.Current.Items;

                if (items[Keys.CssFramework] == null)
                    TryToDetectTheCssFramework(items);

                return items[Keys.CssFramework]?.ToString();
            }
        }

        private static void TryToDetectTheCssFramework(IDictionary items)
        {
            var resolver = new DetectKoiOfCurrentDnnTheme();
            var framework = resolver.AutoDetect() ?? CssFrameworks.Unknown;
            items.Add(Keys.CssFramework, framework ?? CssFrameworks.Unknown);
        }
    }
}
