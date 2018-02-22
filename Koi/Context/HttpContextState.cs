using System;
using System.Collections.Generic;
using System.Linq;
using Connect.Koi.Detectors;
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
                var items = HttpContext.Current.Items;

                if (items[Keys.CssFramework] == null)
                    TryToDetectTheCssFramework();

                return items[Keys.CssFramework]?.ToString();
            }

            set
            {
                // prevent duplicate set, to catch common errors
                var previous = CssFramework;

                // trying to set to same value as before, so just skip
                if (previous == value) return;

                // there was already a value, and it's different
                if(previous != null)
                    throw new Exception($"trying to set css framework:'{value}', but it was already set:'{previous}'");

                // all ok, just set
                HttpContext.Current.Items.Add(Keys.CssFramework, value);

            }
        }

        private static void TryToDetectTheCssFramework()
        {
            var items = HttpContext.Current.Items;

            var framework = CssFrameworks.Unknown;
            var type = AssemblyHandling.FindInherited(typeof(CssFramework)).FirstOrDefault();
            if (type != null)
            {
                var resolver = (CssFramework) Activator.CreateInstance(type);
                framework = resolver.AutoDetect();
            }
            items.Add(Keys.CssFramework, framework ?? CssFrameworks.Unknown);
        }
    }
}
