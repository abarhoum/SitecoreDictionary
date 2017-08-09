using Sitecore.Foundation.Dictionary.Interfaces;
using Sitecore.Foundation.Dictionary.Providers;
using Sitecore.Foundation.SitecoreExtensions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Foundation.Dictionary.Extensions
{
    public static class SitecoreExtensions
    {

        public static HtmlString Translate(this HtmlHelper helper, string key)
        {
            var dictionaryProvider = DependencyResolver.Current.GetService<DictionaryProvider>();
            var dictionaryItem = dictionaryProvider.Get(key);
            if (dictionaryItem == null)
                return null;
            return new HtmlString(FieldRendererService.RenderField(dictionaryItem, "Phrase"));
        }
    }
}