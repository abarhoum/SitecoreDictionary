using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Foundation.Dictionary.Interfaces
{
    public interface IDictionaryProvider
    {
        Item Get(string key);
        List<Item> GetAll();
    }
}
