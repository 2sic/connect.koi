using Connect.Koi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Connect.Testing.Koi
{
    [TestClass]
    public class TestKoi
    {
        public const string Bs3 = Css.Bootstrap3;
        public string Bs3Caps = Css.Bootstrap3.ToUpper();
        public const string Bs4 = Css.Bootstrap4;
        public const string Fd6 = Css.Foundation6;
        public const string Unknown = "xyz";

        public const string All = "all-classes";
        public const string Bs3Cls = "bs-xyz bs-min";
        public const string Bs4Cls = "bs4-xx bs4-yy";
        public const string Fd6Cls = "fd-xyz fd-min";
        public readonly string[,] Classes = {{Bs3, Bs3Cls}, {Fd6, Fd6Cls}};

        public readonly string ClassesString = $"{Bs3}:[{Bs3Cls}] {Bs4},{Css.Unknown}:[{Bs4Cls}] {Fd6}:[{Fd6Cls}]";
        public readonly string ClassesStringWithoutUnknown = $"{Bs3}:[{Bs3Cls}] {Bs4}:[{Bs4Cls}] {Fd6}:[{Fd6Cls}]";

        public string ClassesStringWithAll => $"{Css.All}='{All}' {ClassesString}";
        public string ClassesStringNoUnknownWithAll => $"{Css.All}='{All}' {ClassesStringWithoutUnknown}";

        [TestMethod]
        public void Basic()
        {
            var koi = new TemplateHelper(Bs3);
            Assert.AreEqual(Bs3, koi.Current);

            Assert.IsTrue(koi.Is(Bs3));
            Assert.IsTrue(koi.Is(Bs3Caps));
        }

        //[TestMethod]
        //public void Pick()
        //{
        //    var result = new Part(Bs3).Pick(Classes);
        //    Assert.AreEqual(result, Bs3Cls);

        //    var resultfd = new Part(Fd6).Pick(Classes);
        //    Assert.AreEqual(resultfd, Fd6Cls);
        //}

        //[TestMethod]
        //public void PickInline()
        //{
        //    var result = new Part(Bs3).Pick(new[,] {{Bs3, Bs3Cls}, {Fd6, Fd6Cls}});
        //    Assert.AreEqual(result, Bs3Cls);

        //}

        [TestMethod]
        public void PickStringNotation()
        {
            var result2 = new TemplateHelper(Bs3).Pick(ClassesString);
            Assert.AreEqual(result2, Bs3Cls);
        }

        [TestMethod]
        public void PickStringWithAll()
        {
            var result2 = new TemplateHelper(Bs3).Pick(ClassesStringWithAll);
            Assert.AreEqual(All + " " + Bs3Cls, result2);
        }

        [TestMethod]
        public void PickUnknownWithAll()
        {
            var result2 = new TemplateHelper(Css.Unknown).Pick(ClassesStringWithAll);
            Assert.AreEqual(All + " " + Bs4Cls, result2);
        }

        [TestMethod]
        public void PickNotFound()
        {
            var result2 = new TemplateHelper(Unknown).Pick(ClassesStringWithoutUnknown);
            Assert.IsTrue(string.IsNullOrEmpty(result2));
        }

        [TestMethod]
        public void PickNotFoundWithAll()
        {
            var result2 = new TemplateHelper(Unknown).Pick(ClassesStringNoUnknownWithAll);
            Assert.AreEqual(All, result2);
        }

        [TestMethod]
        public void ClassStringNotation()
        {
            var clsAttrib = new TemplateHelper(Fd6).Class(ClassesString);
            Assert.AreEqual("class=\"" + Fd6Cls + "\"", clsAttrib);
        }
    }
}
