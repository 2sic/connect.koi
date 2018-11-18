using Newtonsoft.Json;

namespace Connect.Koi.Configuration.Json
{
    public class ConfigurationSet
    {
        /// <summary>
        /// This determines the short-code used to specify what css-framework this components provides
        /// It's used in theme folders to mark the theme as being (and providing) that css-framework
        /// </summary>
        [JsonProperty("cssFramework")] public string CssFramework;

        /// <summary>
        /// This is the configuration for polymorphism
        /// </summary>
        [JsonProperty("polymorph", NullValueHandling = NullValueHandling.Ignore)] public Polymorph Polymorph;

    }
}
