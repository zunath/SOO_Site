using System.Collections.Generic;
using SOOSite.Data.Entities;
using SOOSite.Interfaces.Repositories;
using SOOSite.Interfaces.Services;
using SOOSite.Models.ViewModels;
using System.Linq;
using SOOSite.Models.BusinessObjects;
using System;

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
                                        .Select(s => KeyItemCategoryBO.FromEntity(s)).ToList();

            KeyItemVM vm = new KeyItemVM
            {
                KeyItems = _repo.GetKeyItems().Select(s => KeyItemBO.FromEntity(s)),
                KeyItemCategories = categories
            };
            vm.ActiveKeyItemCategoryID = categories[0].KeyItemCategoryID;

            return vm;
        }

        public Tuple<IEnumerable<KeyItemCategoryBO>, IEnumerable<KeyItemBO>> 
            SaveChanges(IEnumerable<KeyItemCategoryBO> categories, IEnumerable<KeyItemBO> keyItems)
        {
            var results = _repo.SaveChanges(
                categories.Select(s => s.ToEntity()),
                keyItems.Select(s => s.ToEntity()));

            return new Tuple<IEnumerable<KeyItemCategoryBO>, IEnumerable<KeyItemBO>>(
                    results.Item1.Select(s => KeyItemCategoryBO.FromEntity(s)),
                    results.Item2.Select(s => KeyItemBO.FromEntity(s))
                );
        }
    }
}
