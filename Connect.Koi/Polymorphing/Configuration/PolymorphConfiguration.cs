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
        public PartMaps Map { get; private set; }

        public PolymorphConfiguration(AutoDetectBase detector, string defaultEdition = null, string values = null, PartMaps partMaps = null, bool allowAnyName = false)
        {
            InitDefaultEdition(defaultEdition);
            InitMaps(partMaps, defaultEdition);
            var valArray = values?.ToLowerInvariant().Split(',').Select(o => o.Trim()).ToArray();
            Constructor(new []{detector}, valArray, allowAnyName);
        }

        public PolymorphConfiguration(AutoDetectBase[] detectors, string defaultEdition = null, string[] names = null, PartMaps partMaps = null, bool allowAnyName = false)
        {
            InitDefaultEdition(defaultEdition);
            InitMaps(partMaps, defaultEdition);
            Constructor(detectors, names, allowAnyName);
        }

        private void InitDefaultEdition(string defaultEdition)
        {
            DefaultName = (defaultEdition ?? DefaultNameIfUndefined).ToLowerInvariant();
            
        }

        private void InitMaps(PartMaps partMaps, string defaultEdition)
        {
            // if no partmap was supplied, create empty to prevent null-errors
            if (partMaps == null)
                partMaps = new PartMaps(defaultEdition);
            Map = partMaps;
        }

        //private void InitValues(stringval)

        private void Constructor(AutoDetectBase[] detectors, string[] names, bool allowAnyName)
        {
            // if no values were provided, try to use the list given by the parts
            // don't do this if values were given, because that would restrict which parts are used
            if (names == null || names.Length == 0)
            {
                var partMapNames = Map.Keys.Select(o => o.ToLowerInvariant().Trim()).ToArray();
                names = partMapNames;
            }

            Detectors = detectors;
            Names = names.ToList().AsReadOnly();
            AllowAnyName = allowAnyName;
        }
    }
}
