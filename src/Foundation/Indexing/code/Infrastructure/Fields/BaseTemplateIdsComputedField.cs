using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;

namespace Sitecore.Foundation.Indexing.Infrastructure.Fields
{
    public class BaseTemplateIdsComputedField : IComputedIndexField
    {
        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            var indexItem = indexable as SitecoreIndexableItem;
            if (indexItem == null)
            {
                return null;
            }
            var item = indexItem.Item;

            var templates = new List<ID>();
            this.GetBaseTemplateIds(item.Template, templates);

            return templates.AsEnumerable();
        }

        public void GetBaseTemplateIds(TemplateItem baseTemplate, List<ID> list)
        {
            list.Add(baseTemplate.ID);

            if (baseTemplate.ID == TemplateIDs.StandardTemplate)
            {
                return;
            }

            foreach (var item in baseTemplate.BaseTemplates)
            {
                this.GetBaseTemplateIds(item, list);
            }
        }
    }
}