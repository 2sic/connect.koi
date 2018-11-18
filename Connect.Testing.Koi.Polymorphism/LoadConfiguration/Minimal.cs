using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Connect.Testing.Koi.Polymorphism.LoadConfiguration
{
    [TestClass]
    public class LoadMinimal: LoadBase
    {
        private const string NoPolymorph = @"{
'default': {
'cssFramework': 'bs3',
}
}";

        [TestMethod]
        public void TestMethod1()
        {
            var obj = Deserialize(NoPolymorph);
            Assert.AreEqual("bs3", obj.Default.CssFramework);
            Assert.AreEqual(null, obj.Default.Polymorph);
        }
    }

}
