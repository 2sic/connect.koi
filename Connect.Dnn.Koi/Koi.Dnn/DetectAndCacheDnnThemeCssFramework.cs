using Connect.Koi.Context;
using Connect.Koi.Detectors;

namespace Connect.Koi.Dnn
{
    public class DetectAndCacheDnnThemeCssFramework: ICssFrameworkDetector
    {
        public StateBase State = new HttpContextState();
        
        public string AutoDetect() => State.CssFramework;
    }
}