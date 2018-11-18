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
        private const string PartFolder = "folder";
        private const string PartNotSpecified = "notspecified";


        [TestMethod]
        public void Basic()
        {
            var i = BuildTests(DefaultEdition, false);
            AddLiveToMap(i.Configuration.Map);
            Assert.AreEqual(DefaultEdition, i.Part(PartNotSpecified));
            Assert.AreEqual("live/", i.Part(PartFolder));
        }

        [TestMethod]
        public void WithUnknownEdition()
        {
            var i = BuildTests("unknown-edition", false);
            Assert.AreEqual(DefaultEdition, i.Part(PartNotSpecified), "unknown edition with unknown part");
            Assert.AreEqual(DefaultEdition, i.Part(PartFolder), "unknown edition with known part");
        }

        [TestMethod]
        public void WithUnknownEditionToLive()
        {
            var i = BuildTests("unknown-edition", false);
            AddLiveToMap(i.Configuration.Map);
            Assert.AreEqual(DefaultEdition, i.Part("notspecified"), "unknown edition with unknown part");
            Assert.AreEqual(DefaultEdition + "/", i.Part("folder"), "unknown edition with known part");
        }

        private static Instance BuildTests(string expectedEdition, bool allowAny = false)
        {
            var d = PrepareTestDetector(expectedEdition);
            var c = new PolymorphConfiguration(d, DefaultEdition, null, BuildMap(Default), allowAny);
            var i = new Instance(c);
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
                        {PartFolder, PartDev + "/"},
                        {"logo", "dev-logo-pink"},
                        {"login", "true"}
                    }
                },
                {
                    PartStaging, new EditionMap
                    {
                        {PartFolder, PartStaging + "/" },
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
                {PartFolder, DefaultEdition + "/"},
                {"logo", "live.jpg"},
                {"login", true.ToString()}
            });
        }
    }
}
