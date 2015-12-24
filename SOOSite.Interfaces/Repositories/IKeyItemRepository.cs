using SOOSite.Data.Entities;
using System.Collections.Generic;

namespace SOOSite.Interfaces.Repositories
{
    public interface IKeyItemRepository
    {
        IEnumerable<KeyItem> GetKeyItems();
        IEnumerable<KeyItemCategory> GetKeyItemCategories();
        void SaveChanges(IEnumerable<KeyItemCategory> categories, IEnumerable<KeyItem> items);
    }
}
