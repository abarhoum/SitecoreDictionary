using System.Collections;
using System.Collections.Generic;

namespace Sitecore.Foundation.Indexing.Interfaces
{
    public interface IQueryFacetProvider
    {
        IEnumerable<IQueryFacet> GetFacets();
    }
}