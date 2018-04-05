using Connect.Koi.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Connect.Testing.Koi
{
    [TestClass]
    public class Koi_Class
    {

        [TestMethod]
        public void ClassStringNotation()
        {
            var clsAttrib = new Css(Constants.Fd6).Class(Constants.ClassesString);
            Assert.AreEqual("class=\"" + Constants.Fd6Cls + "\"", clsAttrib);
        }

        [TestMethod]
        public void ClassStringMulti()
        {
            var clsAttrib = new Css(Constants.Bs3).Class(Constants.ClassesMulti);
            Assert.AreEqual("class=\"" + Constants.Bs34SharedCls + " " + Constants.Bs3Cls + "\"", clsAttrib);
        }

        public string Bs3Other = "all='all' bs3='xyz' oth='other', unk='unknown'";
        [TestMethod]
        public void ClassStringOtherFound()
        {
            var clsAttrib = new Css(Constants.Bs3).Class(Bs3Other);
            Assert.AreEqual("class=\"all xyz\"", clsAttrib);
        }

        [TestMethod]
        public void ClassStringOtherUnknown()
        {
            var clsAttrib = new Css(Connect.Koi.CssFrameworks.Unknown).Class(Bs3Other);
            Assert.AreEqual("class=\"all unknown\"", clsAttrib);
        }

        [TestMethod]
        public void ClassStringOtherOther()
        {
            var clsAttrib = new Css(Connect.Koi.CssFrameworks.Foundation5).Class(Bs3Other);
            Assert.AreEqual("class=\"all other\"", clsAttrib);
        }
    }
}
