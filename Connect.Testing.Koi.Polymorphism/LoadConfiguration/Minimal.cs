using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Connect.Testing.Koi.Polymorphism.LoadConfiguration
{
    [TestClass]
    public class LoadMinimal: LoadBase
    {
        private const string Nothing = @"{'default': {} }";
        private const string NoPolymorph = @"{
'default': {
'cssFramework': 'bs3',
}
}";
        [TestMethod]
        public void NoSettings()
        {
            var obj = Deserialize(Nothing);
            Assert.IsNull(obj.Default.CssFramework);
            Assert.IsNull(obj.Default.Polymorph);
        }

        [TestMethod]
        public void NoPolymorphSettings()
        {
            var obj = Deserialize(NoPolymorph);
            Assert.AreEqual("bs3", obj.Default.CssFramework);
            Assert.AreEqual(null, obj.Default.Polymorph);
        }
    }

}
