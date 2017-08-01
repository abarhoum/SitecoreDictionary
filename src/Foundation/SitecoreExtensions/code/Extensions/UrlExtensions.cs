using Sitecore.Configuration;
using Sitecore.Links;
using System;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Foundation.SitecoreExtensions.Extensions
{
    public static class UrlExtensions
    {
        /// <summary>
        /// Provides the absolute link for current page
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static string ShareLink(this UrlHelper helper)
        {
            string link = string.Empty;
            var request = HttpContext.Current.Request;
            var uri = new Uri(request.Url, request.RawUrl);
            var url = uri.AbsolutePath;
            var baseUrl = uri.GetComponents(UriComponents.Scheme | UriComponents.Host, UriFormat.Unescaped);

            if (Settings.AliasesActive && Sitecore.Context.Database.Aliases.Exists(url))
            {
                var targetItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Database.Aliases.GetTargetID(url));
                link = string.Format("{0}{1}", baseUrl, LinkManager.GetItemUrl(targetItem));
            }
            else
            {
                string itemUrl = LinkManager.GetItemUrl(Sitecore.Context.Item);
                link = string.Format("{0}{1}", baseUrl, itemUrl);
            }

            return link;
        }

        /// <summary>
        /// Provides resource link relative or absolute
        /// </summary>
        /// <param name="urlHelper"></param>
        /// <param name="contentPath"></param>
        /// <param name="toAbsolute"></param>
        /// <returns></returns>
        public static string Content(this UrlHelper urlHelper, string contentPath, bool toAbsolute = false)
        {
            var path = urlHelper.Content(contentPath);
            var url = new Uri(HttpContext.Current.Request.Url, path);

            return toAbsolute ? url.AbsoluteUri : path;
        }
    }
}