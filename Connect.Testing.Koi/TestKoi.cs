using Connect.Koi;
using Connect.Koi.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C = Connect.Testing.Koi.Constants;

namespace Connect.Testing.Koi
{
    [TestClass]
    public class TestKoi
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

        //[TestMethod]
        //public void Pick()
        //{
        //    var result = new Part(C.Bs3).Pick(Classes);
        //    Assert.AreEqual(result, C.Bs3Cls);

        //    var resultfd = new Part(Fd6).Pick(Classes);
        //    Assert.AreEqual(resultfd, Fd6Cls);
        //}

        //[TestMethod]
        //public void PickInline()
        //{
        //    var result = new Part(C.Bs3).Pick(new[,] {{C.Bs3, C.Bs3Cls}, {Fd6, Fd6Cls}});
        //    Assert.AreEqual(result, C.Bs3Cls);

        //}

        [TestMethod]
        public void PickStringNotation()
        {
            var result2 = new Css(C.Bs3).Pick(C.ClassesString);
            Assert.AreEqual(result2, C.Bs3Cls);
        }

        [TestMethod]
        public void PickStringWithAll()
        {
            var result2 = new Css(C.Bs3).Pick(C.ClassesStringWithAll);
            Assert.AreEqual(C.All + " " + C.Bs3Cls, result2);
        }

        [TestMethod]
        public void PickUnknownWithAll()
        {
            var result2 = new Css(CssFrameworks.Unknown).Pick(C.ClassesStringWithAll);
            Assert.AreEqual(C.All + " " + C.Bs4Cls, result2);
        }

        [TestMethod]
        public void PickNotFound()
        {
            var result2 = new Css(C.XyzFramework).Pick(C.ClassesStringWithoutUnknown);
            Assert.IsTrue(string.IsNullOrEmpty(result2));
        }

        [TestMethod]
        public void PickNotFoundWithAll()
        {
            var result2 = new Css(C.XyzFramework).Pick(C.ClassesStringNoUnknownWithAll);
            Assert.AreEqual(C.All, result2);
        }

    }
}
