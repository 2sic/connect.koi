using Connect.Koi.Polymorphing;
using Connect.Koi.Polymorphing.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Connect.Testing.Koi.Polymorphism.TInstance
{
    [TestClass]
    public class InstanceWithPartsTests: InstanceTestBase
    {
        private const string Default = "default";
        private const string PartDev = "dev";
        private const string PartStaging = "staging";


        [TestMethod]
        public void Basic()
        {
            var i = BuildTests(DefaultEdition, false);
            AddLiveToMap(i.Map);
            Assert.AreEqual(DefaultEdition, i.Part("notspecified"));
            Assert.AreEqual("live/", i.Part("folder"));
        }

        [TestMethod]
        public void WithUnknownEdition()
        {
            var i = BuildTests("unknown-edition", false);
            Assert.AreEqual(DefaultEdition, i.Part("notspecified"), "unknown edition with unknown part");
            Assert.AreEqual(DefaultEdition, i.Part("folder"), "unknown edition with known part");
        }

        [TestMethod]
        public void WithUnknownEditionToLive()
        {
            var i = BuildTests("unknown-edition", false);
            AddLiveToMap(i.Map);
            Assert.AreEqual(DefaultEdition, i.Part("notspecified"), "unknown edition with unknown part");
            Assert.AreEqual(DefaultEdition + "/", i.Part("folder"), "unknown edition with known part");
        }

        private static InstanceWithParts BuildTests(string expectedEdition, bool allowAny = false)
        {
            var d = PrepareTestDetector(expectedEdition);
            var i = new InstanceWithParts(d, DefaultEdition, BuildMap(Default), allowAny);
            return i;
        }

        private static PartMaps BuildMap(string defaultMap)
        {
            var map = new PartMaps(defaultMap)
            {
                {
                    defaultMap, new EditionMap()
                },
                {
                    PartDev, new EditionMap
                    {
                        {"folder", PartDev + "/"},
                        {"logo", "dev-logo-pink"},
                        {"login", "true"}
                    }
                },
                {
                    PartStaging, new EditionMap
                    {
                        {"folder", PartStaging + "/" },
                        {"logo", "blue"},
                        {"login", "false"}
                    }
                }
            };

            return map;
        }

        private static void AddLiveToMap(PartMaps parts)
        {
            parts.Add(DefaultEdition, new EditionMap
            {
                {"folder", DefaultEdition + "/"},
                {"logo", "live.jpg"},
                {"login", true.ToString()}
            });
        }
    }
}
