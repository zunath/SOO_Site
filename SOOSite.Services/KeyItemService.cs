using System.Collections.Generic;
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
        private readonly IKeyItemRepository _repo;

        public KeyItemService(IKeyItemRepository repo)
        {
            _repo = repo;
        }

        public KeyItemVM CreateKeyItemViewModel()
        {
            List<KeyItemCategoryBO> categories = _repo.GetKeyItemCategories()
                                        .Select(KeyItemCategoryBO.FromEntity).ToList();

            KeyItemVM vm = new KeyItemVM
            {
                KeyItems = _repo.GetKeyItems().Select(KeyItemBO.FromEntity),
                KeyItemCategories = categories,
                ActiveKeyItemCategoryID = categories[0].KeyItemCategoryID
            };

            return vm;
        }

        public Tuple<IEnumerable<KeyItemCategoryBO>, IEnumerable<KeyItemBO>> 
            SaveChanges(IEnumerable<KeyItemCategoryBO> categories, IEnumerable<KeyItemBO> keyItems)
        {
            var results = _repo.SaveChanges(
                categories.Select(s => s.ToEntity()),
                keyItems.Select(s => s.ToEntity()));

            return new Tuple<IEnumerable<KeyItemCategoryBO>, IEnumerable<KeyItemBO>>(
                    results.Item1.Select(KeyItemCategoryBO.FromEntity),
                    results.Item2.Select(KeyItemBO.FromEntity)
                );
        }
    }
}
