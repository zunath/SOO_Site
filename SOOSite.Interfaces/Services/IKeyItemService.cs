using SOOSite.Models.BusinessObjects;
using SOOSite.Models.ViewModels;
using System.Collections.Generic;

namespace SOOSite.Interfaces.Services
{
    public interface IKeyItemService
    {
        KeyItemVM CreateKeyItemViewModel();
        void SaveChanges(IEnumerable<KeyItemCategoryBO> categories, IEnumerable<KeyItemBO> keyItems);
    }
}
