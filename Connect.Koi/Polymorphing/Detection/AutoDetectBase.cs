namespace Connect.Koi.Polymorphing.Detection
{
    /// <summary>
    /// This is the base class for all detectors. 
    /// </summary>
    public abstract class AutoDetectBase
    {


        public bool IsConfigured => !string.IsNullOrWhiteSpace(Value);

        public string Value => _value ?? (_value = GetValue());
        private string _value;

        protected abstract string GetValue();

    }
}
