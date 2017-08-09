using Sitecore.Caching;
using Sitecore.Foundation.SitecoreCache.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Foundation.SitecoreCache.Providers
{
  public  class SiteCacheProvider : CustomCache, ISiteCacheProvider
    {
        public SiteCacheProvider(string name, long maxSize) : base(name, maxSize)
        {
          
        }
        public void AddCacheObject(string key, object value)
        {
            InnerCache.Add(key, value);
        }
        public object GetCacheObject(string key)
        {
            if (!InnerCache.ContainsKey(key)) return null;
            return InnerCache.GetValue(key);
        }
        public void ClearCache(object sender, EventArgs args)
        {
            this.Clear();
        }
    }
}
