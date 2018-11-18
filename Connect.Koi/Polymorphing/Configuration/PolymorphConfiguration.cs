using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Connect.Koi.Polymorphing.Detection;

namespace Connect.Koi.Polymorphing.Configuration
{
    public class PolymorphConfiguration
    {
        /// <summary>
        /// Default fallback name if none was provided - should usually not be necessary.
        /// </summary>
        public const string DefaultNameIfUndefined = "default";

        /// <summary>
        /// The default name for this configuration - so if detection doesn't match, this is used
        /// </summary>
        public string DefaultName { get; private set; }

        /// <summary>
        /// Array of detectors. Order is important, as first match will be used. 
        /// </summary>
        public AutoDetectBase[] Detectors { get; private set; }

        /// <summary>
        /// List of known names which can be used. Important if AllowAnyName is false (default)
        /// </summary>
        public ReadOnlyCollection<string> Names { get; private set; }

        /// <summary>
        /// Allow any name. This means detectors can deliver names which are not in the expected list.  
        /// </summary>
        public bool AllowAnyName { get; private set; }

        /// <summary>
        /// Maps terms like "live" etc. to another value
        /// </summary>
        public PartMapReader Parts { get; private set; }

        public PolymorphConfiguration(AutoDetectBase detector, string defaultName = null, string names = null, Dictionary<string, PartsMap> partsMapping = null, bool allowAnyName = false)
        {
            InitDefaultEdition(defaultName);
            InitMaps(partsMapping, defaultName);
            var nameArray = names?.ToLowerInvariant().Split(',').Select(o => o.Trim()).ToArray();
            Constructor(new []{detector}, nameArray, allowAnyName);
        }

        public PolymorphConfiguration(AutoDetectBase[] detectors, string defaultName = null, string names = null, Dictionary<string, PartsMap> partsMapping = null, bool allowAnyName = false)
        {
            InitDefaultEdition(defaultName);
            InitMaps(partsMapping, defaultName);
            var nameArray = names?.ToLowerInvariant().Split(',').Select(o => o.Trim()).ToArray();
            Constructor(detectors, nameArray, allowAnyName);
        }

        private void InitDefaultEdition(string defaultEdition)
        {
            DefaultName = (defaultEdition ?? DefaultNameIfUndefined).ToLowerInvariant();
            
        }

        private void InitMaps(Dictionary<string, PartsMap> partsMapping, string defaultEdition)
        {
            // if no partmap was supplied, create empty to prevent null-errors
            if (partsMapping == null)
                Parts = new PartMapReader(defaultEdition, new Dictionary<string, PartsMap>());
            else
                Parts = new PartMapReader(defaultEdition, partsMapping);
        }

        //private void InitValues(stringval)

        private void Constructor(AutoDetectBase[] detectors, string[] names, bool allowAnyName)
        {
            // if no values were provided, try to use the list given by the parts
            // don't do this if values were given, because that would restrict which parts are used
            if (names == null || names.Length == 0)
            {
                var partMapNames = Parts.Maps.Keys.Select(o => o.ToLowerInvariant().Trim()).ToArray();
                names = partMapNames;
            }

            Detectors = detectors;
            Names = names.ToList().AsReadOnly();
            AllowAnyName = allowAnyName;
        }
    }
}
