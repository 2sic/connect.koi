using Connect.Koi;
using Connect.Koi.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C = Connect.Testing.Koi.Constants;

namespace Connect.Testing.Koi
{
    [TestClass]
    public class Koi_Is
    {


        [TestMethod]
        public void Basic()
        {
            var koi = new Css(C.Bs3);
            Assert.AreEqual(C.Bs3, koi.Current);

            Assert.IsTrue(koi.Is(C.Bs3));
            Assert.IsTrue(koi.Is(C.Bs3Caps));
        }

        [TestMethod]
        public void Is()
        {
            var koi = new Css(C.Bs3);
            Assert.IsTrue(koi.Is(C.Bs3));
            Assert.IsFalse(koi.Is(C.Bs4));
            Assert.IsTrue(koi.Is(C.Bs3 + "," + C.Bs4));
            Assert.IsTrue(koi.Is(C.Bs4 + "," + C.Bs3));
            Assert.IsFalse(koi.Is(C.Bs4 + "," + C.Fd6));
        }

        [TestMethod]
        public void IsOther()
        {
            var koi = new Css(C.Fd6);
            Assert.IsFalse(koi.Is(C.Bs3));
            Assert.IsTrue(koi.Is(C.Bs3 + "," + CssFrameworks.Other));
        }


    }
}
