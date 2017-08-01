using Sitecore.Foundation.Dictionary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.Foundation.SitecoreCache.Interfaces;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Data;
using Sitecore.Foundation.Indexing.Models;
using Sitecore.Foundation.SitecoreCache;
using Sitecore.Foundation.Indexing.Interfaces;

namespace Sitecore.Foundation.Dictionary.Providers
{
    public class DictionaryProvider : IDictionaryProvider
    {
        private readonly ICacheProvider cacheProvider;
        private readonly ISearchServiceRepository searchServiceRepository;
        private readonly Item siteRootItem;

        private ID CommonTextFolderId
        {
            get
            {
                var commonTextFolderId = string.Empty;
                if (siteRootItem != null)
                {
                    commonTextFolderId = siteRootItem["Common Text Folder"];
                }
                return ID.Parse(commonTextFolderId);
            }
        }

        private string CommonTextCacheKey
        {
            get
            {
                var commonTextCacheKey = string.Empty;
                if (siteRootItem != null)
                {
                    commonTextCacheKey = siteRootItem["Common Text Cache Key"];
                }
                return commonTextCacheKey;
            }
        }



        private string DictionaryCacheName
        {
            get
            {
                return string.Format("{0}.{1}.{2}", "Sitecore.Foundation.SitecoreCache.DictionaryItems", CommonTextCacheKey, Sitecore.Context.Language.CultureInfo.Name);
            }
        }

        public DictionaryProvider(ICacheProvider cacheProvider, ISearchServiceRepository searchServiceRepository)
        {
            siteRootItem = Context.Site.GetRootItem();
            this.cacheProvider = cacheProvider;
            this.searchServiceRepository = searchServiceRepository;
        }
        public Item Get(string key)
        {
            var commonTextItems = GetAll();

            Item item = null;

            if (commonTextItems != null && commonTextItems.Count() > 0)
            {
                item = commonTextItems.Where(p => p["Key"] == key)
                                      .FirstOrDefault();
            }

            return item;
        }

        public Item[] GetAll()
        {
            var listCommonTexts = cacheProvider.Get(DictionaryCacheName);


            if (listCommonTexts == null)
            {
                var dictionaryFolderItem = Sitecore.Context.Database.GetItem(CommonTextFolderId);
                var searchSettings = new SearchSettings();
                searchSettings.Templates = new[] { Templates.CommonText.ID };
                searchSettings.Root = dictionaryFolderItem;
                var searchService = searchServiceRepository.Get(searchSettings);

                var results = searchService.FindAll();
                cacheProvider.Set(DictionaryCacheName, listCommonTexts);

            }

            var filteredItems = (Item[])listCommonTexts;
            return filteredItems;
        }
    }
}
