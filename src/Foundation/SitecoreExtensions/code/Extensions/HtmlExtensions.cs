using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Foundation.SitecoreExtensions.Extensions
{
    public static class HtmlExtensions
    {
        /// <summary>
        /// Generates Google Recaptcha
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="siteKey"></param>
        /// <returns></returns>
        public static IHtmlString ReCaptcha(this HtmlHelper helper, string siteKey)
        {
            string apiUrl = string.Format("<script src=\"https://www.google.com/recaptcha/api.js?hl={0}\" async defer></script>", Sitecore.Context.Language.Name.ToLower());
            string captchaDiv = string.Format("<div class=\"g-recaptcha\" data-sitekey=\"{0}\"></div>", siteKey);
            StringBuilder output = new StringBuilder();
            output.AppendLine(apiUrl);
            output.AppendLine(captchaDiv);
            return MvcHtmlString.Create(output.ToString());
        }
        
        /// <summary>
        /// Provides alternate links available for same content in other languages
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static IHtmlString AlternateLinks(this HtmlHelper helper)
        {
            StringBuilder output = new StringBuilder();
            var languageUrls = new Dictionary<Language, string>();
            var languages = new List<Language>();

            #region GET LANGUAGES OF CURRENT ITEM

            foreach (var language in Sitecore.Context.Item.Languages)
            {
                if (Sitecore.Context.Item.Language.Name != language.Name)
                {
                    var languageSpecificItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Item.ID, language);
                    if (languageSpecificItem != null && languageSpecificItem.Versions.Count > 0)
                    {
                        languages.Add(language);
                    }
                }
            }

            #endregion

            #region GET LINKS FOR EACH LANGUAGE

            foreach (var language in languages)
            {
                var option = new UrlOptions()
                {
                    AlwaysIncludeServerUrl = true,
                    LowercaseUrls = true,
                    Language = language,
                    LanguageEmbedding = LanguageEmbedding.Always
                };

                var url = LinkManager.GetItemUrl(Sitecore.Context.Item, option);
                languageUrls.Add(language, url);
            }

            #endregion

            foreach (var language in languageUrls)
            {
                output.AppendFormat("<link rel=\"alternate\" href=\"{0}\" hreflang=\"{1}\"/>", language.Value, language.Key.Name);
            }

            return MvcHtmlString.Create(output.ToString());
        }

        /// <summary>
        /// Provides a preferred link to help search engines prevent duplicate content issues
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static IHtmlString CanonicalLink(this HtmlHelper helper)
        {
            var request = HttpContext.Current.Request;
            var tag = "<link rel=\"canonical\" href=\"{0}\"/>";
            var uri = new Uri(request.Url, request.RawUrl);
            var url = uri.AbsolutePath;
            var baseUrl = uri.GetComponents(UriComponents.Scheme | UriComponents.Host, UriFormat.Unescaped);

            if (Settings.AliasesActive && Sitecore.Context.Database.Aliases.Exists(url))
            {
                var targetItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Database.Aliases.GetTargetID(url));
                var link = string.Format("{0}{1}", baseUrl, LinkManager.GetItemUrl(targetItem));
                return MvcHtmlString.Create(string.Format(tag, link));
            }

            string itemUrl = LinkManager.GetItemUrl(Sitecore.Context.Item);
            if (url != itemUrl)
            {
                var link = string.Format("{0}{1}", baseUrl, itemUrl);
                return MvcHtmlString.Create(string.Format(tag, link));
            }

            return null;
        }
    }
}