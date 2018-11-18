using System.Collections.ObjectModel;
using System.Linq;
using Connect.Koi.Polymorphing.Detection;

namespace Connect.Koi.Polymorphing.Configuration
{
    public class FullConfig
    {
        public const string DefaultNameIfUndefined = "default";
        public string DefaultName { get; private set; }
        public AutoDetectBase[] Detectors;
        public bool AllowAny { get; private set; }


        public ReadOnlyCollection<string> Editions;

        // todo: keys

        // todo: possible values

        // todo: maps to resulting values

        public FullConfig(AutoDetectBase[] detectors, string defaultEdition, string[] values, bool allowAny)
        {
            Detectors = detectors;
            DefaultName = (defaultEdition ?? DefaultNameIfUndefined).ToLowerInvariant();
            Editions = values.ToList().AsReadOnly();
            AllowAny = allowAny;
        }
    }
}
