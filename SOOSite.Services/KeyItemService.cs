using System.Collections.Generic;
using SOOSite.Data.Entities;
using SOOSite.Interfaces.Repositories;
using SOOSite.Interfaces.Services;
using SOOSite.Models.ViewModels;
using System.Linq;
using SOOSite.Models.BusinessObjects;

namespace SOOSite.Services
{
    public class KeyItemService: IKeyItemService
    {
        private IKeyItemRepository _repo;

        public KeyItemService(IKeyItemRepository repo)
        {
            _repo = repo;
        }

        public KeyItemVM CreateKeyItemViewModel()
        {
            List<KeyItemCategoryBO> categories = _repo.GetKeyItemCategories()
                                        .Select(s => new KeyItemCategoryBO()
                                        {
                                            IsActive = s.IsActive,
                                            Name = s.Name,
                                            KeyItemCategoryID = s.KeyItemCategoryID
                                        }).ToList();

            KeyItemVM vm = new KeyItemVM
            {
                KeyItems = _repo.GetKeyItems()
                                .Select(s => new KeyItemBO()
                                {
                                    Description = s.Description,
                                    KeyItemCategoryID = s.KeyItemCategoryID,
                                    Name = s.Name,
                                    KeyItemID = s.KeyItemID
                                }),
                KeyItemCategories = categories
            };
            vm.ActiveKeyItemCategoryID = categories[0].KeyItemCategoryID;

            return vm;
        }

        public void SaveChanges(IEnumerable<KeyItemCategoryBO> categories, IEnumerable<KeyItemBO> keyItems)
        {
            _repo.SaveChanges(
                categories.Select(s => new KeyItemCategory()
                {
                    IsActive = s.IsActive,
                    KeyItemCategoryID = s.KeyItemCategoryID,
                    Name = s.Name
                }),
                keyItems.Select(s => new KeyItem()
                {
                    Description = s.Description,
                    KeyItemCategoryID = s.KeyItemCategoryID,
                    KeyItemID = s.KeyItemID,
                    Name = s.Name
                }));
        }
    }
}
