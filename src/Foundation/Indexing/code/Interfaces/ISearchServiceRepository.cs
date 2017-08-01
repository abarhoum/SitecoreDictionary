using Sitecore.Foundation.Indexing.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Foundation.Indexing.Interfaces
{
    public interface ISearchServiceRepository
    {
        SearchService Get(ISearchSettings searchSettings);
    }
}