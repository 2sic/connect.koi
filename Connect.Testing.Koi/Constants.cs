using Connect.Koi;

namespace Connect.Testing.Koi
{
    public class Constants
    {
        public static string Bs3 = CssFrameworks.Bootstrap3;
        public static string Bs4 = CssFrameworks.Bootstrap4;
        public static string Fd6 = CssFrameworks.Foundation6;
        public static string XyzFramework = "xyz";

        public static string All = "all-classes";
        public static string Bs3Cls = "bs-xyz bs-min";
        public static string Bs4Cls = "bs4-xx bs4-yy";
        public static string Fd6Cls = "fd-xyz fd-min";

        public static string Bs3Caps = CssFrameworks.Bootstrap3.ToUpper();
        public static readonly string[,] Classes = { { Bs3, Bs3Cls }, { Fd6, Fd6Cls } };

        public static readonly string ClassesString = $"{Bs3}:[{Bs3Cls}] {Bs4},{CssFrameworks.Unknown}:[{Bs4Cls}] {Fd6}:[{Fd6Cls}]";
        public static readonly string ClassesStringWithoutUnknown = $"{Bs3}:[{Bs3Cls}] {Bs4}:[{Bs4Cls}] {Fd6}:[{Fd6Cls}]";

        public static string ClassesStringWithAll => $"{CssFrameworks.All}='{All}' {ClassesString}";
        public static string ClassesStringNoUnknownWithAll => $"{CssFrameworks.All}='{All}' {ClassesStringWithoutUnknown}";

    }
}
