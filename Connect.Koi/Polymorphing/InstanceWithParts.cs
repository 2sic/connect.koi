using System.Linq;
using Connect.Koi.Polymorphing.Configuration;
using Connect.Koi.Polymorphing.Detection;

namespace Connect.Koi.Polymorphing
{
    public class InstanceWithParts: Instance
    {
        public InstanceWithParts(AutoDetectBase detector, string defaultEdition = null, PartMaps partMaps = null, bool allowAny = false)
        {
            if(partMaps == null)
                partMaps = new PartMaps(defaultEdition);

            Configuration = new FullConfig(
                new[] { detector },
                defaultEdition,
                partMaps.Keys.Select(o => o.ToLowerInvariant().Trim()).ToArray(),
                allowAny
            );

            Map = partMaps;
        }

        public bool UseMap;

        /// <summary>
        /// Maps terms like "live" etc. to another value
        /// </summary>
        public PartMaps Map;

        #region Properties

        public string Part(string partName) => Map.Value(Name, partName);

        #endregion

    }
}
