using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Connect.Testing.Koi.Polymorphism.TInstance
{
    [TestClass]
    public class InstanceTest: InstanceTestBase
    {

        [TestMethod]
        public void TestNotSetEdition()
        {
            var e = BuildTypicalInstance("").Name;
            Assert.AreEqual(DefaultEdition, e, "should auto fallback to default");
        }

        [TestMethod]
        public void TestNotSetEditionWithAllowAny()
        {
            var i = BuildTypicalInstance("", true);
            var e = i.Name;
            Assert.AreEqual(DefaultEdition, e, "should auto fallback to default");
        }

        [TestMethod]
        public void TestUnknownEditionDefault()
        {
            var e = BuildTypicalInstance(UnknownEdition).Name;
            Assert.AreEqual(DefaultEdition, e, "should auto fallback to default");
        }

        [TestMethod]
        public void TestUnknownEditionAllowed()
        {
            var i = BuildTypicalInstance(UnknownEdition, true);
            var e = i.Name;
            Assert.AreEqual(UnknownEdition, e, "should auto use unknown edition");
        }

    }
}
