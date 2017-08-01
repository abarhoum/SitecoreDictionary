using System.Collections.Generic;

namespace Sitecore.Foundation.Indexing.Interfaces
{
    public interface ISearchResults
    {
        IEnumerable<ISearchResultFacet> Facets { get; }
        IEnumerable<ISearchResult> Results { get; }
        int TotalNumberOfResults { get; }
    }
}