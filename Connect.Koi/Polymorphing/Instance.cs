using System.Collections.ObjectModel;
using System.Linq;
using Connect.Koi.Polymorphing.Detection;

namespace Connect.Koi.Polymorphing
{
    public class Instance
    {
        public const string DefaultEdition = "default";

        /// <summary>
        /// Empty constructor for inheriting objects which know what they are doing
        /// </summary>
        protected Instance() { }

        public Instance(AutoDetectBase detector, string defaultEdition = DefaultEdition, string values = "*", bool allowAny = false)
        {
            Constructor(
                new[] { detector },
                defaultEdition,
                values.ToLowerInvariant().Split(',').Select(o => o.Trim()).ToArray(),
                allowAny || values == "*"
                );
            //_detectors = new[] {detector};
            //DefaultEdition = defaultEdition.ToLowerInvariant();
            //if (values == "*")
            //    AllowAny = true;
            //else
            //{
            //    Editions = values.ToLowerInvariant().Split(',').Select(o => o.Trim()).ToList().AsReadOnly();
            //    AllowAny = allowAny;
            //}
        }

        protected void Constructor(AutoDetectBase[] detectors, string defaultEdition, string[] values, bool allowAny)
        {
            _detectors = detectors;
            MainEdition = defaultEdition.ToLowerInvariant();
            //if (values == "*")
            //    AllowAny = true;
            //else
            //{
                Editions = values.ToList().AsReadOnly();
                AllowAny = allowAny;
            //}

        }

        public string MainEdition { get; private set; }

        public bool AllowAny { get; private set; }


        public ReadOnlyCollection<string> Editions;
        private AutoDetectBase[] _detectors;

        /// <summary>
        /// Find the current edition
        /// </summary>
        /// <remarks>
        /// caches the result for follow-up calls
        /// </remarks>
        public string Edition => _edition ?? (_edition = DetectEdition());

        private string _edition;

        private string DetectEdition()
        {
            if (_detectors.Length == 0) return MainEdition;
            var detector = _detectors.First();
            if (!detector.IsConfigured) return MainEdition;
            var config = detector.Value?.ToLowerInvariant();

            if (string.IsNullOrWhiteSpace(config)) return MainEdition;

            return AllowAny 
                ? config 
                : (Editions.Contains(config) ? config : MainEdition);
        }


    }
}
