using System.Collections.Generic;

namespace Sitecore.Foundation.Indexing.Interfaces
{
    public interface ISearchResultFacet
    {
        IQueryFacet Definition { get; set; }
        IEnumerable<ISearchResultFacetValue> Values { get; set; }
    }
}