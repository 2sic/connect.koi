#if NET451
using UniversalContext = System.Web.HttpContext;
#else
using UniversalContext = Microsoft.AspNetCore.Http.HttpContext;
#endif


namespace Connect.Koi.Internals
{
    internal class HttpContext
    {
        internal static UniversalContext Current
        {
            get
            {
#if NET451
                return UniversalContext.Current;
#else
                // when running in .net standard / .net core, 
                // it will probably need to go through dependency injection
                // but for now it's not implemented yet
                throw new System.NotImplementedException();
#endif
            }
        }
    }
}
