using System.Collections.Generic;

namespace Sitecore.Foundation.Indexing.Interfaces
{
    public interface IQuery
    {
        string QueryText { get; set; }
        int NoOfResults { get; set; }
        Dictionary<string, string[]> Facets { get; set; }
        int Page { get; set; }
    }
}