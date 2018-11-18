using System;
using System.IO;
using System.Runtime.Caching;
using Connect.Koi.Configuration.Json;
using Connect.Koi.Polymorphing.Scope;
using Newtonsoft.Json;

namespace Connect.Dnn.Koi
{
    public class DnnSkinPolymorph
    {
        private const string CacheKeyPrefixPolymorphSkin = "connect-koi-polymorph-";

        public /*override*/ Scope AutoBuild()
        {

            try
            {
                var koiPath = Helpers.SkinKoiPath();
                var cacheKey = CacheKeyPrefixPolymorphSkin + koiPath.ToLower();

                var config = MemoryCache.Default[cacheKey] as Scope;

                if (config != null)
                    return config;

                // todo: generate instance key, as we'll need to add it to the config dictionaries of the detectors
                var scopeDefaultKey = "theme-{todo-theme-name}";

                try
                {
                    if (File.Exists(koiPath))
                    {
                        var json = JsonConvert.DeserializeObject<Root>(File.ReadAllText(koiPath));
                        // todo: build config
                        config = new Scope(scopeDefaultKey, json);
                    }
                }
                catch (Exception e)
                {
                    DotNetNuke.Services.Exceptions.Exceptions.LogException(new Exception("Connect.Koi: Error while reading css framework from koi.json", e));
                }

                var policy = new CacheItemPolicy();
                policy.ChangeMonitors.Add(new HostFileChangeMonitor(new[] { koiPath }));
                MemoryCache.Default.Set(cacheKey, config, policy);

                return config;
            }
            catch (Exception e)
            {
                DotNetNuke.Services.Exceptions.Exceptions.LogException(new Exception("Connect.Koi: Error while loading framework settings from koi.json", e));
            }

            return null;
        }
    }
}