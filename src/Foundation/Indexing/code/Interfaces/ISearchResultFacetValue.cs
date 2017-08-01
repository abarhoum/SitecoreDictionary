using System;

namespace Sitecore.Foundation.Indexing.Interfaces
{
    public interface ISearchResultFacetValue
    {
        string Title { get; set; }
        object Value { get; }
        int Count { get; }
        bool Selected { get; set; }
    }
}