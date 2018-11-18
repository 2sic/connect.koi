using System.Collections.Generic;

namespace Connect.Koi.Polymorphing.Detection
{
    /// <summary>
    /// This is the base class for all detectors. 
    /// </summary>
    public abstract class AutoDetectBase
    {
        private readonly Dictionary<string, object> _configuration;

        protected AutoDetectBase(Dictionary<string, object> configuration)
        {
            _configuration = configuration;
        }

        protected T Config<T>(string key, T fallback)
        {
            if (!_configuration.ContainsKey(key))
                return fallback;

            var val = _configuration[key];
            if (val is T) return (T)val;
            return fallback;
        }


        public bool IsConfigured => !string.IsNullOrWhiteSpace(Value);

        public string Value => _value ?? (_value = GetValue());
        private string _value;

        protected abstract string GetValue();

    }
}
