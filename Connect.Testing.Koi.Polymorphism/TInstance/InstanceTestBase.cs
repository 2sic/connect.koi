using Connect.Koi.Polymorphing;
using Connect.Koi.Polymorphing.Detection;

namespace Connect.Testing.Koi.Polymorphism.TInstance
{
    public class InstanceTestBase
    {
        internal const string CurrentEdition = "live";
        internal const string UnknownEdition = "xyzabc";
        internal const string DefaultEdition = "live";
        internal const string TypicalEditions = "live,staging,dev";

        internal static AutoDetectBase PrepareTestDetector(string expectedEdition)
        {
            TestDetection.Result = expectedEdition;
            return new TestDetection("dummy");
        }

        internal static Instance BuildTypicalInstance(string edition, bool allowAny = false)
        {
            var d = PrepareTestDetector(edition);
            var i = new Instance(d, DefaultEdition, TypicalEditions, allowAny);
            return i;
        }

    }
}
