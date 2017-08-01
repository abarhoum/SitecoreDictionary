using Sitecore.Data.Items;

namespace Sitecore.Foundation.Indexing.Interfaces
{
    public interface IQueryRoot
    {
        Item Root { get; set; }
    }
}