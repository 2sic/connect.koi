using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Connect.Testing.Dnn.Koi.Polymorphism
{
    [TestClass]
    public class LoadJson
    {
        private const string BasicJson = @"
{
    'cssFramework': 'bs3',
    'polymorph': {
        'names': 'dev,live,staging',
        'allowAnyName': true,
        'parts': {
            'dev': {
                
            }
        }
    }
}
";

        [TestMethod]
        public void TestMethod1()
        {
            var json = BasicJson.Replace("'", "\"");
            var obj = JsonConvert.DeserializeObject<Connect.Koi.>(json);
            Assert.AreEqual("bs3", obj.CssFramework);
            Assert.AreEqual(true, obj.Polymorph.AllowAny);
            Assert.AreEqual("dev,live,staging", obj.Polymorph.Names);
            Assert.AreEqual(1, obj.Polymorph.Parts.Count);

        }
    }
    //internal class JsonKoiConfig
    //{
    //    [JsonProperty("cssFramework")]
    //    public string CssFramework;

    //}
    //internal class JsonKoiPolymorph: JsonKoiConfig
    //{
    //    [JsonProperty("polymorph")]
    //    public JsonKoiConfigPolymorph Polymorph;


    //}

    //internal class JsonKoiConfigPolymorph
    //{
    //    [JsonProperty("names")] public string Names;
    //    [JsonProperty("allowAnyName")] public bool AllowAny;

    //    [JsonProperty("parts")] public Dictionary<string, Dictionary<string, string>> Parts;

    //}
}
