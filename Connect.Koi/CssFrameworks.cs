namespace Connect.Koi
{
    /// <summary>
    /// Commonly agreed upon keys / identifications for css frameworks
    /// </summary>
    /// <remarks>
    /// Please adhere to the basic convention as follows:
    /// - each key is always 3 characters long (a-z only)
    /// - each framework gets a 2 character general code which is used in all keys of that framework
    /// - additionally, we add the version in a 1-2 digit syntax, to support frameworks like bulma
    /// - if you're using a semantic-versioned 
    /// </remarks>
    /// <remarks>
    /// Please don't add any ultra-old CSS Frameworks, like
    /// anybody can still support it, but we don't want to clutter our "standard" names
    /// with almost unused frameworks
    /// - 1140 Grid - very dead
    /// - 960 GS - dead since 2014
    /// - Skeleton - dead since 2014
    /// - YUI - dead
    /// </remarks>
    public class CssFrameworks
    {
        // Note about static Readonly instead of const
        // It's important that all constants are NOT const, but static readonly
        // This is because if external code accesses a value here, it would compile the value into it's code
        // but with static readonly it will continue to access these variables
        
        // code for all-frameworks
        public static readonly string All = "all";

        // The unknown-framework 
        public static readonly string Unknown = "unk";

        /// <summary>
        /// any other framework - used to detect if it has a framework, but not one of the provided
        /// </summary>
        public static readonly string Other = "oth";

        // Bootstrap
        public static readonly string BootstrapPrefix = "bs";
        public static readonly string Bootstrap3 = BootstrapPrefix + V3;
        public static readonly string Bootstrap4 = BootstrapPrefix + V4;
        public static readonly string Bootstrap5 = BootstrapPrefix + V5;
        public static readonly string Bootstrap6 = BootstrapPrefix + V6;
        public static readonly string Bootstrap7 = BootstrapPrefix + V7;


        // Bulma - https://bulma.io/
        // Note: Bulma uses a version which is 0.x, so ATM it's not a good fit yet
        // ...WIP
        public static readonly string BulmaPrefix = "blm";
        public static readonly string Bulma0 = BulmaPrefix + V0;
        public static readonly string Bulma1 = BulmaPrefix + V1;


        // Foundation
        public static readonly string FoundationPrefix = "fnd";
        public static readonly string Foundation5 = FoundationPrefix + V5;
        public static readonly string Foundation6 = FoundationPrefix + V6;
        public static readonly string Foundation7 = FoundationPrefix + V7;


        // Materialize
        public static readonly string MaterializePrefix = "mtz";
        public static readonly string Materialize0 = MaterializePrefix + V0;
        public static readonly string Materialize1 = MaterializePrefix + V1;
        public static readonly string Materialize2 = MaterializePrefix + V2;

        // SemanticUI
        public static readonly string SemanticUiPrefix = "sui";
        public static readonly string SemanticUi1 = SemanticUiPrefix + V1;
        public static readonly string SemanticUi2 = SemanticUiPrefix + V2;
        public static readonly string SemanticUi3 = SemanticUiPrefix + V3;


        // Dummy / testing
        public static readonly string ForTestingOnlyPrefix = "fto";
        public static readonly string ForTestingOnly1 = ForTestingOnlyPrefix + V1;
        public static readonly string ForTestingOnly2 = ForTestingOnlyPrefix + V2;
        public static readonly string ForTestingOnly3 = ForTestingOnlyPrefix + V3;
        public static readonly string ForTestingOnly4 = ForTestingOnlyPrefix + V4;
        public static readonly string ForTestingOnly5 = ForTestingOnlyPrefix + V5;
        public static readonly string ForTestingOnly6 = ForTestingOnlyPrefix + V6;
        public static readonly string ForTestingOnly7 = ForTestingOnlyPrefix + V7;
        public static readonly string ForTestingOnly8 = ForTestingOnlyPrefix + V8;
        public static readonly string ForTestingOnly9 = ForTestingOnlyPrefix + V9;

        // UIKit - https://getuikit.com/
        public static readonly string UiKitPrefix = "uik";
        public static readonly string UiKit2 = UiKitPrefix + V2;
        public static readonly string UiKit3 = UiKitPrefix + V3;
        public static readonly string UiKit4 = UiKitPrefix + V4;

        // YAML - http://www.yaml.de/
        public static readonly string YamlPrefix = "yml";
        public static readonly string Yaml3 = YamlPrefix + V3;
        public static readonly string Yaml4 = YamlPrefix + V4;


        private const string V0 = "0";
        private const string V1 = "1";
        private const string V2 = "2";
        private const string V3 = "3";
        private const string V4 = "4";
        private const string V5 = "5";
        private const string V6 = "6";
        private const string V7 = "7";
        private const string V8 = "8";
        private const string V9 = "9";
    }
}
