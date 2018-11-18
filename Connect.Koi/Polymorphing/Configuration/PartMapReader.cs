using System.Collections.Generic;

namespace Connect.Koi.Polymorphing.Configuration
{
    public class PartMapReader 
    {
        internal const string AutoReturnEdition = "%~*";
        public string DefaultMap;
        public string DefaultValue;

        public Dictionary<string, PartsMap> Maps;

        /// <summary>
        /// Initialize the map
        /// </summary>
        /// <param name="defaultMapName">default set - important for lookups when the current edition is not covered</param>
        /// <param name="maps">dictionary to map values around</param>
        // ReSharper disable once InheritdocConsiderUsage
        public PartMapReader(string defaultMapName, Dictionary<string, PartsMap> maps)
        {
            DefaultMap = defaultMapName.ToLowerInvariant();
            Maps = maps;
        }

        /// <summary>
        /// Look up a part. 
        /// </summary>
        /// <param name="edition"></param>
        /// <param name="partName"></param>
        /// <returns></returns>
        public string Value(string edition, string partName)
        {
            var result = TryToGet(edition, partName);
            if (result != null) return result;
            result = TryToGet(DefaultMap, partName);
            return result;
        }

        private string TryToGet(string edition, string key)
        {
            if (!Maps.ContainsKey(edition)) return null;
            var map = Maps[edition];
            if (!map.ContainsKey(key)) return null;
            var val = map[key];
            return string.IsNullOrWhiteSpace(val) 
                ? null 
                : val;
        }

    }
}
