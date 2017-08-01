using Sitecore.Configuration;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Foundation.SitecoreCache
{
   public class Templates
    {
        public struct CommonText
        {
            public static ID ID = new ID(Settings.GetSetting("Indivirtual.Sitecore.CommonTextTemplateId"));
        }
    }
}
