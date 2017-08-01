using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Foundation.Indexing.Interfaces;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using System.Collections.Generic;
using System.Configuration.Provider;

namespace Sitecore.Foundation.Indexing.Infrastructure.Providers
{
    public class FallbackSearchResultFormatter : ProviderBase, ISearchResultFormatter
    {
        public string ContentType => "[Unknown]";

        public IEnumerable<ID> SupportedTemplates => new ID[0];

        public void FormatResult(SearchResultItem item, ISearchResult formattedResult)
        {
            var scItem = item.GetItem();

            if (scItem == null)
                return;

            var title = scItem["Meta Title"];
            if (string.IsNullOrWhiteSpace(title))
            {
                title = scItem["Title"];
                if (string.IsNullOrWhiteSpace(title))
                {
                    title = scItem.DisplayName;
                    if (string.IsNullOrWhiteSpace(title))
                    {
                        title = scItem.Name;
                    }
                }
            }

            var description = scItem["Meta Description"];
            if (string.IsNullOrWhiteSpace(description))
            {
                description = scItem["Description"].TruncateHtml(length: 300);
            }

            formattedResult.Title = title;
            formattedResult.Description = description;
        }
    }
}