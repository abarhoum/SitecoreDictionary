using System.Collections.Generic;
using Sitecore.Data;

namespace Sitecore.Foundation.Indexing.Interfaces
{
    public interface ISearchSettings : IQueryRoot
    {
        IEnumerable<ID> Templates { get; }
        bool MustHaveFormatter { get; }
    }
}