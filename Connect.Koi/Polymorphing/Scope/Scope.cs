using System.Collections.Generic;
using System.Linq;
using Connect.Koi.Configuration.Json;
using Connect.Koi.Polymorphing.Configuration;
using Connect.Koi.Polymorphing.Detection;

namespace Connect.Koi.Polymorphing.Scope
{
    /// <summary>
    /// A scope is a thing the polymorph is tied to. 
    /// This can be a theme, an app or another thing
    /// Scopes usually have a indetifier - which will be used in cookies etc.
    /// and also a configuration - usually from a json in a folder belonging to the scope
    /// </summary>
    public class Scope
    {
        public const string ScopeIdKey = "scopeId";
        public string Identifier;
        public PolymorphConfiguration Configuration;

        public Scope(string identifier, Root jsonConfig)
        {
            Identifier = identifier;
            Configuration = ImportJson(jsonConfig, identifier);
        }

        private static PolymorphConfiguration ImportJson(Root jsonConfig, string identifier)
        {
            var pmSet = jsonConfig.Default.Polymorph;

            // build detectors
            var detectors = BuildAutoDetectors(pmSet.Detectors, identifier);

            // default edition
            var defaultName = pmSet.DefaultName;

            // values
            var values = pmSet.Names;

            // todo partsmap
            var partMaps = pmSet.Parts;

            var config = new PolymorphConfiguration(detectors, defaultName, values, partMaps, pmSet.AllowAny);
            return config;
        }

        private static AutoDetectBase[] BuildAutoDetectors(Dictionary<string, Dictionary<string, object>> detectors, string identifier)
        {
            return detectors.Select(dt =>
            {
                dt.Value.Add(ScopeIdKey, identifier);
                switch (dt.Key)
                {
                    case "cookie":
                        return new CookieDetection(dt.Value) as AutoDetectBase;
                        break;
                    case "test":
                        return new TestDetection(dt.Value);
                    default:
                        return null;
                }
                
            })
            .ToArray();

            
        }
    }
}
