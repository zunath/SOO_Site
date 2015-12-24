using SOOSite.Data.Entities;
using System;
using System.Collections.Generic;

namespace SOOSite.Interfaces.Repositories
{
    public interface IKeyItemRepository
    {
        IEnumerable<KeyItem> GetKeyItems();
        IEnumerable<KeyItemCategory> GetKeyItemCategories();
        Tuple<IEnumerable<KeyItemCategory>, IEnumerable<KeyItem>>
            SaveChanges(IEnumerable<KeyItemCategory> categories, IEnumerable<KeyItem> items);
    }
}
