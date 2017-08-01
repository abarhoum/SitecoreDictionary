using System.Collections.Generic;

namespace Sitecore.Foundation.Indexing.Interfaces
{
    public interface IQueryFacet
    {
        string Title { get; set; }
        string FieldName { get; set; }
        string ViewName { get; set; }
    }
}