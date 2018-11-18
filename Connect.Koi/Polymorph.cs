using Connect.Koi.Polymorphing;
using Connect.Koi.Polymorphing.Configuration;
using Connect.Koi.Polymorphing.Detection;

namespace Connect.Koi
{
    public static class Polymorph
    {
        public static string Edition => "live";


        /// <summary>
        /// Very basic implementation - the final API should be much nicer and auto-load from JSON
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <param name="defaultEdition"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string Detect(string source, string key, string defaultEdition, string options)
        {
            if (source != "cookie") return defaultEdition;

            var detector = new CookieDetection(key);

            var config = new PolymorphConfiguration(detector, defaultEdition, options);
            var instance = new Instance(config);
            return instance.Name;
        }
    }
}

