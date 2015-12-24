using System;
using System.Collections.Generic;
using SOOSite.Data.Entities;
using SOOSite.Interfaces.Repositories;
using SOOSite.Data.Contexts;
using System.Linq;
using System.Data.Entity.Migrations;

namespace SOOSite.Data.Repositories
{
    public class KeyItemRepository : IKeyItemRepository
    {
        private SOOContext _context;

        public KeyItemRepository(SOOContext context)
        {
            _context = context;
        }

        public IEnumerable<KeyItemCategory> GetKeyItemCategories()
        {
            return _context.KeyItemCategories.Where(x => x.IsActive);
        }

        public IEnumerable<KeyItem> GetKeyItems()
        {
            return _context.KeyItems;
        }

        public void SaveChanges(IEnumerable<KeyItemCategory> categories, IEnumerable<KeyItem> items)
        {
            _context.KeyItemCategories.AddOrUpdate(categories.ToArray());
            _context.KeyItems.AddOrUpdate(items.ToArray());

            _context.SaveChanges();
        }
    }
}
