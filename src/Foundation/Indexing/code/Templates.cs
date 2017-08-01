using Sitecore.Configuration;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Foundation.Indexing
{
    internal struct Templates
    {
        internal struct IndexedItem
        {
            public static ID ID = new ID(Settings.GetSetting("Sitecore.Foundation.Indexing.IndexedItemFoundationTemplateId"));

            //public struct Fields
            //{
                //public static readonly ID IncludeInSearchResults = new ID("{8D5C486E-A0E3-4DBE-9A4A-CDFF93594BDA}");
                //public const string IncludeInSearchResults_FieldName = "IncludeInSearchResults";
            //}
        }
    }
}