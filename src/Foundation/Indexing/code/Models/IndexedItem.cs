using System.Collections.Generic;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace Sitecore.Foundation.Indexing.Models
{
    public class IndexedItem : SearchResultItem
    {
        [IndexField(Constants.IndexFields.HasPresentation)]
        public bool HasPresentation { get; set; }

        //[IndexField(Templates.IndexedItem.Fields.IncludeInSearchResults_FieldName)]
        //public bool ShowInSearchResults { get; set; }

        [IndexField(Constants.IndexFields.BaseTemplateIds)]
        public List<string> BaseTemplateIds { get; set; }

        //[IndexField(Constants.IndexFields.HasSearchResultFormatter)]
        //public bool HasSearchResultFormatter { get; set; }

        [IndexField(Constants.IndexFields.IsLatestVersion)]
        public bool IsLatestVersion { get; set; }
    }
}