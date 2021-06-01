//using System;

//namespace Connect.Koi.Internals
//{
//    /// <summary>
//    /// Helper to ensure that commands with various overloads must use named parameters
//    /// </summary>
//    public class EnforceNamedParameters
//    {
//        /// <summary>
//        /// This is just a constant to give to the parameter "protecting" the others
//        /// Its value and type can be changed from time to time, as it's value is only checked internally. 
//        /// </summary>
//        public const string ProtectionKey = "Dummy-Parameter - don't provide this, but do name all other parameters in this call using paramName: value";

//        public static bool VerifyProtectionKey(string value, bool throwError = true)
//        {
//            var valid = value == ProtectionKey;
//            if (!valid && throwError)
//                throw new Exception("");
//            return valid;
//        }
//    }
//}