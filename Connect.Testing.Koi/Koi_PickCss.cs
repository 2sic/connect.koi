using System;
using Connect.Koi.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C = Connect.Testing.Koi.Constants;
using Fw = Connect.Koi.CssFrameworks;

namespace Connect.Testing.Koi
{
    [TestClass]
    public class Koi_PickCss
    {
        [TestMethod]
        public void PickCssBs3OfUnknown()
        {
            Assert.IsTrue(new Css(Fw.Unknown).PickCss(C.Bs3) == "");
            Assert.IsTrue(new Css(Fw.Unknown).PickCss(C.Bs3, "") == "");
            Assert.IsTrue(new Css(Fw.Unknown).PickCss(C.Bs3, null) == null);
        }

        [TestMethod]
        public void PickCssBs3AndUnkOfUnknown()
        {
            Assert.IsTrue(new Css(Fw.Unknown).PickCss("bs3,unk", "") == "unk");
            Assert.IsTrue(new Css(Fw.Unknown).PickCss("bs3,unk") == "unk");
            Assert.IsTrue(new Css(Fw.Unknown).PickCss("bs3,unk", null) == "unk");
        }

        [TestMethod]
        public void PickCssBs34OfUnknown()
        {
            Assert.IsTrue(new Css(Fw.Unknown).PickCss("bs3,bs4,unk") == "unk");
            Assert.IsTrue(new Css(Fw.Unknown).PickCss("bs3,bs4") == "");
        }

        [TestMethod]
        public void PickCssBs34Fallback3OfUnknown() 
            => Assert.IsTrue(new Css(Fw.Unknown).PickCss("bs3,bs4", "bs3") == "bs3");
    }
}
