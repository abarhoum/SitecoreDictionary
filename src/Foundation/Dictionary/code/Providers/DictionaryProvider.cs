using Sitecore.Foundation.Dictionary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.Foundation.SitecoreCache.Interfaces;
using Sitecore.Data;
using Sitecore.Foundation.Indexing.Models;
using Sitecore.Foundation.SitecoreCache;
using Sitecore.Foundation.Indexing.Interfaces;
using Sitecore.Foundation.DependencyInjection.Attributes;
using Sitecore.Links;

namespace Sitecore.Foundation.Dictionary.Providers
{
    [Service(Lifetime = DependencyInjection.Enums.Lifetime.Singleton)]
    public class DictionaryProvider : IDictionaryProvider
    {

        private readonly ICacheProvider cacheProvider;
        private readonly ISearchServiceRepository searchServiceRepository;
        private readonly Item siteRootItem;

        private ID DictionaryFolderId
        {
            get
            {
                var dictionaryFolderId = string.Empty;
                if (siteRootItem != null)
                {
                    dictionaryFolderId = siteRootItem["Dictionary Folder"];
                }
                return ID.Parse(dictionaryFolderId);
            }
        }

        private string DictionaryCacheKey
        {
            get
            {
                var dictionaryCacheKey = string.Empty;
                if (siteRootItem != null)
                {
                    dictionaryCacheKey = siteRootItem["Dictionary Cache Key"];
                }

                return dictionaryCacheKey;
            }
        }
        private string DictionaryCacheName
        {
            get
            {
                return string.Format("{0}.{1}.{2}", "Sitecore.Foundation.SitecoreCache.DictionaryItems", DictionaryCacheKey, Sitecore.Context.Language.CultureInfo.Name);
            }
        }
        public DictionaryProvider(ICacheProvider cacheProvider, ISearchServiceRepository searchServiceRepository)
        {
            siteRootItem = Context.Site.Database.GetItem(Context.Site.RootPath);
            this.cacheProvider = cacheProvider;
            this.searchServiceRepository = searchServiceRepository;


        }
        public Item Get(string key)
        {
            var dictionaryItems = GetAll();

            Item item = null;

            if (dictionaryItems != null && dictionaryItems.Count() > 0)
            {
                item = dictionaryItems.Where(p => p["Key"] == key)
                                      .FirstOrDefault();
            }

            return item;
        }

        /// <summary>
        /// Get dictionaries from cache.
        /// </summary>
        /// <returns>Dictionary Items</returns>
        public List<Item> GetAll()
        {
            List<Item> dictionaries = new List<Item>();
            var dictionaryCache = cacheProvider.Get(DictionaryCacheName);

            if (dictionaryCache == null)
            {
                var dictionaryFolderItem = Sitecore.Context.Database.GetItem(DictionaryFolderId);
                var searchSettings = new SearchSettings();
                searchSettings.Templates = new[] { Templates.Dictionary.ID };
                searchSettings.Root = dictionaryFolderItem;
                var searchService = searchServiceRepository.Get(searchSettings);

                var results = searchService.FindAll();
                dictionaries = results.Results.Select(x => x.Item).Where(x => x != null).ToList();
                cacheProvider.Set(DictionaryCacheName, dictionaries);
            }
            else
            {
                dictionaries = (List<Item>)dictionaryCache;
            }

            return dictionaries;
        }
    }
}
