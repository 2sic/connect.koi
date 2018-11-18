using System.Collections.Generic;
using Newtonsoft.Json;

namespace Connect.Koi.Configuration.Json
{
    public class Polymorph
    {
        /// <summary>
        /// CSV list of names known/supported. 
        /// If "parts" are provided, this list is extended by those names as well
        /// </summary>
        [JsonProperty("names")] public string Names;

        /// <summary>
        /// Allow any kind of name
        /// </summary>
        [JsonProperty("allowAny")] public bool AllowAny;
        [JsonProperty("default")] public string DefaultName;

        [JsonProperty("parts")] public Dictionary<string, Dictionary<string, string>> Parts;

        [JsonProperty("detection")] public Dictionary<string, Dictionary<string, string>> Detectors;
    }
}
