using System.Collections.Generic;
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
            AddLiveToMap(i.Configuration.Parts);
            Assert.IsNull(i.Part(PartNotSpecified));
            Assert.AreEqual(DefaultEdition, i.Part(PartNotSpecified, i.Name));
            Assert.AreEqual("live/", i.Part(PartFolder));
        }

        [TestMethod]
        public void WithUnknownEditionAndNoLive()
        {
            var i = BuildTests("unknown-edition", false);
            Assert.AreEqual(DefaultEdition, i.Part(PartNotSpecified, i.Name), "unknown edition with unknown part");
            Assert.IsNull(i.Part(PartFolder), "unknown edition with known part, no fallback");
            Assert.AreEqual(DefaultEdition, i.Part(PartFolder, i.Name), "unknown edition with known part, fallback");
        }

        [TestMethod]
        public void WithUnknownEditionToLive()
        {
            var i = BuildTests("unknown-edition", false);
            AddLiveToMap(i.Configuration.Parts);
            Assert.IsNull(i.Part("notspecified"), "unknown edition with unknown part");
            Assert.AreEqual(DefaultEdition + "/", i.Part("folder"), "unknown edition with live-default & with known part");
        }

        private static Instance BuildTests(string expectedEdition, bool allowAny = false)
        {
            var d = PrepareTestDetector(expectedEdition);
            var c = new PolymorphConfiguration(d, DefaultEdition, null, BuildMap(Default), allowAny);
            var i = new Instance(c);
            return i;
        }

        private static Dictionary<string, PartsMap> BuildMap(string defaultMap)
        {
            var map = new Dictionary<string, PartsMap>
            {
                {
                    defaultMap, new PartsMap()
                },
                {
                    PartDev, new PartsMap
                    {
                        {PartFolder, PartDev + "/"},
                        {"logo", "dev-logo-pink"},
                        {"login", "true"}
                    }
                },
                {
                    PartStaging, new PartsMap
                    {
                        {PartFolder, PartStaging + "/"},
                        {"logo", "blue"},
                        {"login", "false"}
                    }
                }
            };
            return map;
        }

        private static void AddLiveToMap(PartMapReader parts)
        {
            parts.Maps.Add(DefaultEdition, new PartsMap
            {
                {PartFolder, DefaultEdition + "/"},
                {"logo", "live.jpg"},
                {"login", true.ToString()}
            });
        }
    }
}
