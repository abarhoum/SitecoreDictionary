using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace Sitecore.Foundation.Indexing.Infrastructure.Fields
{
    public class HasPresentationComputedField : IComputedIndexField
    {
        public string FieldName { get; set; }

        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Item item = indexable as SitecoreIndexableItem;
            if (item.HasLayout())
            {
                return true;
            }
            return null;
        }
    }
}