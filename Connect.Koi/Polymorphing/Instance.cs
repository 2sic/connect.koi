using System.Linq;
using Connect.Koi.Polymorphing.Configuration;

namespace Connect.Koi.Polymorphing
{
    public class Instance
    {
        public PolymorphConfiguration Configuration;

        /// <summary>
        /// Empty constructor for inheriting objects which know what they are doing
        /// </summary>
        protected Instance() { }

        public Instance(PolymorphConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public Instance(AutoDetectBase detector, string defName = null, string values = "*", bool allowAny = false)
        //{
        //    Configuration = new FullConfig(
        //        detector,
        //        defName,
        //        values,//.ToLowerInvariant().Split(',').Select(o => o.Trim()).ToArray(),
        //        null,
        //        allowAny || values == "*"
        //        );  
        //}


        /// <summary>
        /// Find the current edition
        /// </summary>
        /// <remarks>
        /// caches the result for follow-up calls
        /// </remarks>
        public string Name => _selectedName ?? (_selectedName = DetectEdition());
        private string _selectedName;

        private string DetectEdition()
        {
            if (Configuration.Detectors.Length == 0) return Configuration.DefaultName;
            var detector = Configuration.Detectors.First();
            if (!detector.IsConfigured) return Configuration.DefaultName;
            var config = detector.Value?.ToLowerInvariant();

            if (string.IsNullOrWhiteSpace(config)) return Configuration.DefaultName;

            return Configuration.AllowAnyName 
                ? config 
                : (Configuration.Names.Contains(config) ? config : Configuration.DefaultName);
        }

        #region Parts

        public string Part(string partName) => Configuration.Map.Value(Name, partName);

        #endregion

    }
}
