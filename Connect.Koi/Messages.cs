namespace Connect.Koi
{
    public class Messages
    {
        public static string Link = "https://connect-koi.net/";
        public static string CssInformationMissing =
            $@"This component supports multiple CSS frameworks. 
It uses <a href='{Link}' target='_blank'>Koi</a> to detect the CSS framework of the theme/skin. 
Your page-theme doesn't broadcast it's CSS-Framework, so the output may look wrong. <br> 

To fix this, follow the instructions on <a href='{Link}'>Connect.Koi</a>.";

        public static string OnlyAdminsSeeThis =
            "Note: only admins see this message, and it will disappear when you configure your page-theme.";
    }
}
