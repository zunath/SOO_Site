using SOOSite.Models.BusinessObjects;
using SOOSite.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace SOOSite.Interfaces.Services
{
    public interface IKeyItemService
    {
        KeyItemVM CreateKeyItemViewModel();
        Tuple<IEnumerable<KeyItemCategoryBO>, IEnumerable<KeyItemBO>>
            SaveChanges(IEnumerable<KeyItemCategoryBO> categories, IEnumerable<KeyItemBO> keyItems);
    }
}
