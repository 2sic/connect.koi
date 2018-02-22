using System;
using System.Web;
using System.Linq;

namespace Koi.Web
{
    /// <summary>
    /// This is the helper class for the full .net framework
    /// In .net core it will probably have to be a bit different
    /// </summary>
    internal class HttpContextState: State
    {
        public override string CssFramework
        {
            get {
                // Type of HttpContext.Current.Items differs for netstandard2.0 and net451
                // if we want to support netstandard2.0 we must solve this
#if NET451
                if (!HttpContext.Current.Items.Contains(Keys.CssFramework)) {
                    var framework = Css.Unknown;
                    var type = Helpers.AssemblyHandling.FindInherited(typeof(FrameworkResolver)).FirstOrDefault();
                    if(type != null)
                    {
                        var resolver = (FrameworkResolver)Activator.CreateInstance(type);
                        framework = resolver.GetCSSFramework();
                    }
                    HttpContext.Current.Items.Add(Keys.CssFramework, framework ?? Css.Unknown);
                }
#endif

                return HttpContext.Current.Items[Keys.CssFramework].ToString();
            }

            set
            {
                // prevent duplicate set, to catch common errors
                var previous = CssFramework;

                // trying to set to same value as before, so just skip
                if (previous == value)
                    return;

                // there was already a value, and it's different
                if(previous != null)
                    throw new Exception($"trying to set the css framework to '{value}', but it has already been set to '{previous}'");

                // all ok, just set
                HttpContext.Current.Items.Add(Keys.CssFramework, value);

            }
        }
    }
}
