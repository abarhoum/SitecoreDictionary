using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Foundation.SitecoreCache.Interfaces
{
   public interface ICacheProvider
    {
        object Get(string key);
        void Set(string key, object value);
    }
}
