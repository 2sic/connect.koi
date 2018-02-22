#if NET451
using HContext = System.Web.HttpContext;
#else
using HContext = Microsoft.AspNetCore.Http.HttpContext;
#endif


namespace Koi
{
    class HttpContext
    {
        public static HContext Current
        {
            get
            {
#if NET451
                return HContext.Current;
#else
                throw new System.NotImplementedException();
#endif
            }
        }
    }
}
