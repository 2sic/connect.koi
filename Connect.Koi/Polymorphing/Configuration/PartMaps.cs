using System.Collections.Generic;

namespace Connect.Koi.Polymorphing.Configuration
{
    public class PartMaps : Dictionary<string, PartsMap>
    {
        internal const string AutoReturnEdition = "%~*";
        public string DefaultMap;
        public string DefaultValue;

        /// <summary>
        /// Initialize the map
        /// </summary>
        /// <param name="defaultMap">default set - important for lookups when the current edition is not covered</param>
        // ReSharper disable once InheritdocConsiderUsage
        public PartMaps(string defaultMap)
        {
            DefaultMap = defaultMap.ToLowerInvariant();
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

        //private static T GetFromDictionaryOrDefault<T>(Dictionary<string, T> dic, string key, string defaultKey, T defaultValue)
        //{
        //    if(dic.ContainsKey(key)) return dic[key];

        //    if (dic.ContainsKey(defaultKey)) return dic[defaultKey];

        //    return defaultValue;            
        //}

        private string TryToGet(string edition, string key)
        {
            if (!ContainsKey(edition)) return null;
            var map = this[edition];
            if (!map.ContainsKey(key)) return null;
            var val = map[key];
            return string.IsNullOrWhiteSpace(val) 
                ? null 
                : val;
        }

    }
}
