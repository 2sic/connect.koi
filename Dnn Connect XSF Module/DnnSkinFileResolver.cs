using System;
using System.Web;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Host;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.UI.Skins;
using System.IO;
using System.Web.Helpers;
using System.Runtime.Caching;
using System.Collections.Generic;

namespace Connect.XSF
{
    /// <summary>
    /// Picks up a file named koi.json in the skin file which declares the skin's CSS framework
    /// </summary>
    internal class DnnSkinFileResolver : Koi.FrameworkResolver
    {
        private const string KoiJsonFile = "koi.json";
        private const string DnnSettingDefaultPortalSkin = "DefaultPortalSkin";
        private const string CacheKey = "connect-koi-json-";
        private const string SkinSrcParameter = "SkinSrc";

        public override string GetCSSFramework()
        {
            try
            {
                var skin = HttpContext.Current?.Request.QueryString[SkinSrcParameter]
                    ?? PortalSettings.Current.ActiveTab.SkinSrc;

                if (String.IsNullOrEmpty(skin))
                    skin = PortalController.GetPortalSetting(DnnSettingDefaultPortalSkin, PortalSettings.Current.PortalId,
                                Host.DefaultPortalSkin);

                skin = SkinController.FormatSkinSrc(skin, PortalSettings.Current);
                skin = skin.Substring(0, skin.LastIndexOf("/") + 1);
                
                var koiPath = System.Web.Hosting.HostingEnvironment.MapPath(Path.Combine(skin, KoiJsonFile));
                ObjectCache cache = MemoryCache.Default;
                var cssFramework = cache[CacheKey + koiPath.ToLower()] as string;
                
                if (cssFramework != null)
                    return cssFramework == "" ? null : cssFramework;

                try {
                    if (File.Exists(koiPath))
                        cssFramework = Json.Decode(File.ReadAllText(koiPath))["default"]?.cssFramework;
                } catch(Exception e)
                {
                    DotNetNuke.Services.Exceptions.Exceptions.LogException(new Exception("Connect.Koi: Error while reading css framework from koi.json", e));
                }

                CacheItemPolicy policy = new CacheItemPolicy();
                policy.ChangeMonitors.Add(new HostFileChangeMonitor(new[] { koiPath }));
                cache.Set(CacheKey + koiPath.ToLower(), cssFramework ?? "", policy);

                return cssFramework;
            }
            catch (Exception e)
            {
                DotNetNuke.Services.Exceptions.Exceptions.LogException(new Exception("Connect.Koi: Error while loading framework settings from koi.json", e));
            }
            
            return null;
        }

    }
}
