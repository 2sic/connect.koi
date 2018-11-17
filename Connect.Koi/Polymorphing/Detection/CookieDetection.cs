using HttpContext = Connect.Koi.Internals.HttpContext;

namespace Connect.Koi.Polymorphing.Detection
{
    /// <summary>
    /// This detector will verify if a cookie with the key is set
    /// </summary>
    // ReSharper disable once InheritdocConsiderUsage
    internal class CookieDetection: AutoDetectBase
    {
        public CookieDetection(string key) : base(key)
        {
        }

        protected override string GetValue()
        {
#if NET451
            var cookie = HttpContext.Current.Request.Cookies[Key];
            var val = cookie?.Value;
#else
            var cookie = HttpContext.Current.Request.Cookies[Key];
            var val = cookie;
#endif
            return string.IsNullOrWhiteSpace(val) ? null : val;
        }
    }
}
