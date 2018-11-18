using System;
using System.IO;
using System.Web;
using System.Web.Hosting;
using Connect.Koi;
using DotNetNuke.Entities.Host;
using DotNetNuke.Entities.Portals;
using DotNetNuke.UI.Skins;

namespace Connect.Dnn.Koi
{
    internal class Helpers
    {
        private const string DnnSettingDefaultPortalSkin = "DefaultPortalSkin";
        private const string SkinSrcParameter = "SkinSrc";

        internal static string GetSkinPath()
        {
            var skin = HttpContext.Current?.Request.QueryString[SkinSrcParameter]
                       ?? PortalSettings.Current.ActiveTab.SkinSrc;

            if (string.IsNullOrEmpty(skin))
                skin = PortalController.GetPortalSetting(DnnSettingDefaultPortalSkin, PortalSettings.Current.PortalId,
                    Host.DefaultPortalSkin);

            skin = SkinController.FormatSkinSrc(skin, PortalSettings.Current);
            return skin.Substring(0, skin.LastIndexOf("/", StringComparison.Ordinal) + 1);
        }

        internal static string SkinKoiPath()
            => HostingEnvironment.MapPath(Path.Combine(GetSkinPath(), Constants.DefaultConfigFileName));



    }
}