using Connect.Koi;
using Connect.Koi.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C = Connect.Testing.Koi.Constants;

namespace Connect.Testing.Koi
{
    [TestClass]
    public class Koi_Pick
    {
        
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
