using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Text;
using System.Web;

namespace Sitecore.Foundation.SitecoreExtensions.Helpers
{
    public class SiteHelper
    {
        /// <summary>
        /// GetCurrentSiteUrlWithoutLanguage
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentSiteUrlWithoutLanguage()
        {
            var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.ContentStartPath);
            var url = LinkManager.GetItemUrl(homeItem, new UrlOptions()
            {
                AlwaysIncludeServerUrl = true,
                LowercaseUrls = true,
                LanguageEmbedding = LanguageEmbedding.Never
            });

            return url;
        }

        /// <summary>
        /// Returns the context item url with domain name
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentItemUrl()
        {
            var url = LinkManager.GetItemUrl(Sitecore.Context.Item, new UrlOptions()
            {
                AlwaysIncludeServerUrl = true,
                LowercaseUrls = true,
                LanguageEmbedding = LanguageEmbedding.Always
            });

            return url;
        }

        /// <summary>
        /// Returns context site url with domain
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentSiteUrl()
        {
            var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.ContentStartPath);
            var url = LinkManager.GetItemUrl(homeItem, new UrlOptions()
            {
                AlwaysIncludeServerUrl = true,
                LowercaseUrls = true
            });

            return url;
        }

        /// <summary>
        /// Returns context relative item url
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentItemRelativeUrl()
        {
            var url = LinkManager.GetItemUrl(Sitecore.Context.Item, new UrlOptions()
            {
                AlwaysIncludeServerUrl = false,
                LowercaseUrls = true,
                LanguageEmbedding = LanguageEmbedding.Always
            });

            return url;
        }

        /// <summary>
        /// Get parameter template value
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static string GetRenderingParameterValue(string parameterName)
        {
            var context = RenderingContext.CurrentOrNull;

            if (context != null && context.Rendering != null)
            {
                var parametersAsString = context.Rendering.Properties["Parameters"];
                var parameters = HttpUtility.ParseQueryString(parametersAsString);

                return parameters[parameterName];
            }

            return (string)null;
        }
    }
}