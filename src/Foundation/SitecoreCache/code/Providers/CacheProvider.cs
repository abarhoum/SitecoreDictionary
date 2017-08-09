using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Foundation.DependencyInjection.Attributes;
using Sitecore.Foundation.SitecoreCache.Interfaces;
using System;

namespace Sitecore.Foundation.SitecoreCache.Providers
{
    [Service(typeof(ICacheProvider))]
    public class CacheProvider : ICacheProvider
    {
        private readonly ISiteCacheProvider siteCacheProvider;
        
        private const string CacheName = "Sitecore.Foundation.SitecoreCache";

        public CacheProvider()
        {
            siteCacheProvider = new SiteCacheProvider(CacheName, StringUtil.ParseSizeString(Sitecore.Configuration.Settings.GetSetting("Sitecore.Foundation.SitecoreCache.CacheSize", "15MB")));
        }

        public object Get(string key)
        {
            return siteCacheProvider.GetCacheObject(key);
        }

        public void Set(string key, object value)
        {
            siteCacheProvider.AddCacheObject(key, value);
        }
        public void ClearCache(object sender, EventArgs args)
        {
            siteCacheProvider.ClearCache(sender,args);
        }
    }
}
