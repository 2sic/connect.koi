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
    }
}
