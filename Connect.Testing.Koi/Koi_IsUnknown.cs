using Connect.Koi;
using Connect.Koi.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C = Connect.Testing.Koi.Constants;

namespace Connect.Testing.Koi
{
    [TestClass]
    public class Koi_IsUnknown
    {

        [TestMethod]
        public void IsUnknown()
        {
            var koi = new Css(C.Bs3);
            Assert.IsFalse(koi.IsUnknown);

        }

        [TestMethod]
        public void IsUnknownWhenUnknown()
        {
            var unk = new Css(CssFrameworks.Unknown);
            Assert.IsTrue(unk.IsUnknown);
        }
        
    }
}
