using System.Collections.Generic;

namespace Connect.Koi.Polymorphing.Configuration
{
    public class PartMaps : Dictionary<string, EditionMap>
    {
        public string DefaultMap;
        private readonly EditionMap _emptyMap = new EditionMap();

        public PartMaps(string defaultMap)
        {
            DefaultMap = defaultMap.ToLowerInvariant();
        }

        public EditionMap Get(string edition)
        {
            return GetFromDictionaryOrDefault(this, edition, DefaultMap, _emptyMap);
            //if(ContainsKey(key)) return this[key];

            //if (ContainsKey(DefaultMap)) return this[DefaultMap];

            //return _emptyMap ?? (_emptyMap = new EditionMap());
        }

        public string Value(string edition, string partName)
        {
            var result = TryToGet(edition, partName);
            if (result != null) return result;
            result = TryToGet(DefaultMap, partName);
            if (result != null) return result;
            return edition;
        }

        private static T GetFromDictionaryOrDefault<T>(Dictionary<string, T> dic, string key, string defaultKey, T defaultValue)
        {
            if(dic.ContainsKey(key)) return dic[key];

            if (dic.ContainsKey(defaultKey)) return dic[defaultKey];

            return defaultValue;            
        }

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
