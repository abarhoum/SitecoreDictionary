using Sitecore.ContentSearch;
using Sitecore.Foundation.DependencyInjection.Attributes;

namespace Sitecore.Foundation.Indexing.Services
{
    [Service]
    public class SearchIndexResolver
    {
        public virtual ISearchIndex GetIndex(SitecoreIndexableItem contextItem)
        {
            return ContentSearchManager.GetIndex(contextItem);
        }
    }
}