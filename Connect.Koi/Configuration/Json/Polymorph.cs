using System.Collections.Generic;
using Newtonsoft.Json;

namespace Connect.Koi.Configuration.Json
{
    public class Polymorph
    {
        [JsonProperty("names")] public string Names;
        [JsonProperty("allowAny")] public bool AllowAny;
        [JsonProperty("default")] public string DefaultName;

        [JsonProperty("parts")] public Dictionary<string, Dictionary<string, string>> Parts;

        [JsonProperty("detectors")] public Dictionary<string, Dictionary<string, string>> Detectors;
    }
}
