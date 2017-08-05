using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Foundation.SitecoreCache.Interfaces
{
   public interface ISiteCacheProvider
    {
        void AddCacheObject(string key, object value);
        object GetCacheObject(string key);
        void ClearCache(object sender, EventArgs args);
    }
}
