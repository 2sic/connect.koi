using Connect.Koi.Polymorphing;
using Connect.Koi.Polymorphing.Detection;

namespace Connect.Koi
{
    public static class Polymorph
    {
        public static string Edition => "live";



        public static string Detect(string source, string key, string defaultEdition, string options)
        {
            if (source != "cookie") return defaultEdition;

            var detector = new CookieDetection(key);

            var instance = new Instance(detector, defaultEdition, options);
            return instance.Edition;

            //if (!detector.IsConfigured) return defaultEdition;

            //var config = detector.Value?.ToLowerInvariant();

            //var opts = options.ToLowerInvariant().Split(',').Select(o => o.Trim()).ToArray();

            //return opts.Contains(config) ? config : defaultEdition;
        }
    }
}

