using Sitecore.Configuration;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Foundation.Dictionary
{
   public class Templates
    {
        public struct Dictionary
        {
            public static ID ID = new ID(Settings.GetSetting("Sitecore.Foundation.Dictionary.DictionaryTemplateId"));
        }
    }
}
