using Connect.Koi.Detectors;
using System;
using System.IO;
using System.Runtime.Caching;
using System.Web.Helpers;
using Connect.Koi.Configuration.Json;

namespace Connect.Dnn.Koi
{
    /// <inheritdoc />
    /// <summary>
    /// Picks up a file named koi.json in the skin file which declares the skin's CSS framework
    /// </summary>
    internal class DnnSkinFile : CssFramework
    {
        private const string CacheKeyPrefixCssFramework = "connect-koi-json-";

        public override string AutoDetect()
        {
            
            try
            {
                var koiPath = Helpers.SkinKoiPath();
                var cacheKey = CacheKeyPrefixCssFramework + koiPath.ToLower();

                var cssFramework = MemoryCache.Default[cacheKey] as string;
                
                if (cssFramework != null)
                    return cssFramework == "" ? null : cssFramework;

                try
                {
                    if (File.Exists(koiPath))
                        cssFramework = Json.Decode(File.ReadAllText(koiPath))[Root.DefaultKey]?.cssFramework;
                }
                catch (Exception e)
                {
                    DotNetNuke.Services.Exceptions.Exceptions.LogException(new Exception("Connect.Koi: Error while reading css framework from koi.json", e));
                }

                var policy = new CacheItemPolicy();
                policy.ChangeMonitors.Add(new HostFileChangeMonitor(new[] { koiPath }));
                MemoryCache.Default.Set(cacheKey, cssFramework ?? "", policy);

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
