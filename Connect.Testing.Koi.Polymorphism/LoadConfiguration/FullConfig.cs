using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Connect.Testing.Koi.Polymorphism.LoadConfiguration
{
    [TestClass]
    public class FullConfig: LoadBase
    {
        private const string BasicJson = @"{ 'default': {
'cssFramework': 'bs3',
'polymorph': {
    'names': 'dev,live,staging',
    'default': 'live',
    'allowAny': true,
    'detection': {
        'cookie': {
            'key': 'xyz'
        },
        'time': {
        },
        'a': {
        }
    },
    'parts': {
        'dev': {
            'folder': 'dev/',
            'logo': 'dev.jpg',
            'color': 'blue'
        }
    }
}
}}";

        [TestMethod]
        public void TestMethod1()
        {
            var obj = Deserialize(BasicJson);
            Assert.AreEqual("bs3", obj.Default.CssFramework);
            Assert.AreEqual(true, obj.Default.Polymorph.AllowAny);
            Assert.AreEqual("dev,live,staging", obj.Default.Polymorph.Names);
            Assert.AreEqual(1, obj.Default.Polymorph.Parts.Count);

        }
    }

}
