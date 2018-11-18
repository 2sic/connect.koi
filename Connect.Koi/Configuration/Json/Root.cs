using System.Collections.Generic;
using Newtonsoft.Json;

namespace Connect.Koi.Configuration.Json
{
    public class Root: Dictionary<string, ConfigurationSet>
    {
        public const string DefaultKey = "default";

        [JsonIgnore]
        public ConfigurationSet Default => this[DefaultKey];
    }
}
