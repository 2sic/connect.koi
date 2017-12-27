using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Connect.Testing.Koi
{
    [TestClass]
    public class TestKoi
    {
        public const string Bs3 = "bs3";
        public const string Bs3Caps = "BS3";
        public const string Bs4 = "bs4";
        public const string Fd6 = "fd6";
        public const string Unknown = "xyz";

        public const string Bs3Cls = "bs-xyz bs-min";
        public const string Bs4Cls = "bs4-xx bs4-yy";
        public const string Fd6Cls = "fd-xyz fd-min";
        public readonly string[,] Classes = {{Bs3, Bs3Cls}, {Fd6, Fd6Cls}};

        public readonly string ClassesString = $"{Bs3}:{Bs3Cls},{Bs4}:{Bs4Cls},{Fd6}:{Fd6Cls}";

        [TestMethod]
        public void Basic()
        {
            var koi = new Connect.Koi.Part(Bs3);
            Assert.AreEqual(Bs3, koi.Current);

            Assert.IsTrue(koi.Is(Bs3));
            Assert.IsTrue(koi.Is(Bs3Caps));
        }

        [TestMethod]
        public void Pick()
        {
            var result = new Connect.Koi.Part(Bs3).Pick(Classes);
            Assert.AreEqual(result, Bs3Cls);

            var resultfd = new Connect.Koi.Part(Fd6).Pick(Classes);
            Assert.AreEqual(resultfd, Fd6Cls);
        }

        [TestMethod]
        public void PickInline()
        {
            var result = new Connect.Koi.Part(Bs3).Pick(new[,] {{Bs3, Bs3Cls}, {Fd6, Fd6Cls}});
            Assert.AreEqual(result, Bs3Cls);

        }

        [TestMethod]
        public void PickStringNotation()
        {
            var result2 = new Connect.Koi.Part(Bs3).Pick(ClassesString);
            Assert.AreEqual(result2, Bs3Cls);
        }

        [TestMethod]
        public void PickNotFound()
        {
            var result2 = new Connect.Koi.Part(Unknown).Pick(ClassesString);
            Assert.IsNull(result2);
        }

        [TestMethod]
        public void ClassStringNotation()
        {
            var clsAttrib = new Connect.Koi.Part(Fd6).Class(ClassesString);
            Assert.AreEqual("class=\"" + Fd6Cls + "\"", clsAttrib);
        }
    }
}
