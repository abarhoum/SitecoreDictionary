using Sitecore.Foundation.DependencyInjection.Attributes;
using Sitecore.Foundation.Indexing.Interfaces;
using Sitecore.Foundation.Indexing.Services;

namespace Sitecore.Foundation.Indexing.Repositories
{
    [Service(typeof(ISearchServiceRepository))]
    public class SearchServiceRepository : ISearchServiceRepository
    {
        public virtual SearchService Get(ISearchSettings settings)
        {
            return new SearchService(settings);
        }
    }
}