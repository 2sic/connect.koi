using System.Collections.Generic;
using HttpContext = Connect.Koi.Internals.HttpContext;

namespace Connect.Koi.Polymorphing.Detection
{
    /// <summary>
    /// This detector will verify if a cookie with the key is set
    /// </summary>
    // ReSharper disable once InheritdocConsiderUsage
    internal class CookieDetection: AutoDetectBase//Typed<string>
    {
        public const string ConfigKeyCookieName = "key";
        public const string DefaultCookieName = "polymorph-edition";
        public const string DefaultCookiePrefix = "polymorph-";

        public CookieDetection(Dictionary<string, object> configuration) : base(configuration)
        {
        }

        protected override string GetValue()
        {
            var key = Config(ConfigKeyCookieName, DefaultCookieName);
            var val = GetCookie(key);
            if (val != null) return val;

            // otherwise try scope-key
            key = Config<string>(Scope.Scope.ScopeIdKey, null);
            if (key == null) return null;
            val = GetCookie(DefaultCookiePrefix + key);
            return val;
        }

        private static string GetCookie(string key)
        {
#if NET451
            var cookie = HttpContext.Current.Request.Cookies[key];
            var val = cookie?.Value;
#else
            var cookie = HttpContext.Current.Request.Cookies[key];
            var val = cookie;
#endif
            return string.IsNullOrWhiteSpace(val) ? null : val;
        }
    }
}

