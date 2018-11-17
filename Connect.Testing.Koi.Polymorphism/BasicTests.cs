using Connect.Koi;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Connect.Testing.Koi.Polymorphism
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void Simple()
        {
            Connect.Koi.Polymorphing.Detection.TestDetection.Result = "live";
            var result = Polymorph.Detect("test", "xyz", "live", "live,staging,dev");
            Assert.AreEqual(result, "live");
        }
    }
}
