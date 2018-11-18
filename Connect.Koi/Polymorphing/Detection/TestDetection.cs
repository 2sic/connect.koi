using System;
using System.Collections.Generic;

namespace Connect.Koi.Polymorphing.Detection
{
    /// <summary>
    /// This is simply a test-detector, used for unit tests
    /// </summary>
    // ReSharper disable once InheritdocConsiderUsage
    public class TestDetection: AutoDetectBase//Typed<string>
    {
        //public static string Result;
        public const string ConfigKeyResult = "result";

        public TestDetection(Dictionary<string, object> configuration) : base(configuration)
        {
        }

        protected override string GetValue()
        {
            var result = Config<string>(ConfigKeyResult, null);
            if (result == null)
                throw new Exception("can't run tests - you must first set the static result value");
            return result;
        }
    }
}
