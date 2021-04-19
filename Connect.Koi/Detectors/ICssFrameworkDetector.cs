namespace Connect.Koi.Detectors
{
    /// <summary>
    /// Inherit from this class to add a css framework resolver
    /// </summary>
    public interface ICssFrameworkDetector
    {
        string AutoDetect();
    }
}
