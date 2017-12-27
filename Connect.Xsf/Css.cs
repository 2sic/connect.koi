namespace Connect.Koi.Frameworks
{
    /// <summary>
    /// Commonly agreed upon keys / identifications for css frameworks
    /// </summary>
    /// <remarks>
    /// Please adhere to the basic convention as follows:
    /// - each key is always 3 characters long (a-z only)
    /// - each framework gets a 2 character general code which is used in all keys of that framework
    /// - additionaly, we add the version in a 3 digit syntax, to support frameworks like bulma
    /// - if you're using a semantic-versioned 
    /// </remarks>
    /// <remarks>
    /// Please don't add any ultra-old CSS Frameworks, like
    /// - 1140 Grid - very dead
    /// - 960 GS - dead since 2014
    /// - Skelleton - dead since 2014
    /// - YUI - dead
    /// </remarks>
    public class Css
    {
        // As 960GS is a number, we must use a text-variable
        public const string NineSixtyGsPrefix = "nsg";
        public const string NineSixtyGs = NineSixtyGsPrefix;


        // Bootstrap
        public const string BootstrapPrefix = "bst";
        public const string Bootstrap2 = BootstrapPrefix + V2;
        public const string Bootstrap3 = BootstrapPrefix + V3;
        public const string Bootstrap4 = BootstrapPrefix + V4;
        public const string Bootstrap5 = BootstrapPrefix + V5;

        // Bulma - https://bulma.io/
        // Note: Bulma uses a version which is 0.x, so ATM it's not a good fit yet
        // ...WIP
        public const string BulmaPrefix = "blm";
        public const string Bulma0 = BulmaPrefix + V0;
        public const string Bulma1 = BulmaPrefix + V1;


        // Foundation
        public const string FoundationPrefix = "fnd";
        public const string Foundation5 = FoundationPrefix + V5;
        public const string Foundation6 = FoundationPrefix + V6;
        public const string Foundation7 = FoundationPrefix + V7;


        // Materialize
        public const string MaterializePrefix = "mtz";
        public const string Materialize0 = MaterializePrefix + V0;
        public const string Materialize1 = MaterializePrefix + V1;
        public const string Materialize2 = MaterializePrefix + V2;

        // SemanticUI
        public const string SemanticUiPrefix = "sui";
        public const string SemanticUi1 = SemanticUiPrefix + V1;
        public const string SemanticUi2 = SemanticUiPrefix + V2;
        public const string SemanticUi3 = SemanticUiPrefix + V3;


        // Dummy / testing
        public const string ForTestingOnlyPrefix = "fto";
        public const string ForTestingOnly1 = ForTestingOnlyPrefix + V1;
        public const string ForTestingOnly2 = ForTestingOnlyPrefix + V2;
        public const string ForTestingOnly3 = ForTestingOnlyPrefix + V3;
        public const string ForTestingOnly4 = ForTestingOnlyPrefix + V4;
        public const string ForTestingOnly5 = ForTestingOnlyPrefix + V5;
        public const string ForTestingOnly6 = ForTestingOnlyPrefix + V6;
        public const string ForTestingOnly7 = ForTestingOnlyPrefix + V7;
        public const string ForTestingOnly8 = ForTestingOnlyPrefix + V8;
        public const string ForTestingOnly9 = ForTestingOnlyPrefix + V9;

        // UIKit - https://getuikit.com/
        public const string UiKitPrefix = "uik";
        public const string UiKit2 = UiKitPrefix + V2;
        public const string UiKit3 = UiKitPrefix + V3;
        public const string UiKit4 = UiKitPrefix + V4;

        // YAML
        public const string YamlPrefix = "yml";
        public const string Yaml3 = YamlPrefix + V3;
        public const string Yaml4 = YamlPrefix + V4;


        private const string V0 = "00";
        private const string V1 = "01";
        private const string V2 = "02";
        private const string V3 = "03";
        private const string V4 = "04";
        private const string V5 = "05";
        private const string V6 = "06";
        private const string V7 = "07";
        private const string V8 = "08";
        private const string V9 = "09";
    }
}
