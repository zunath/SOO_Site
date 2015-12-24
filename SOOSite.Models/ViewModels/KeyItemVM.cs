using SOOSite.Models.BusinessObjects;
using System.Collections.Generic;

namespace SOOSite.Models.ViewModels
{
    public class KeyItemVM
    {
        public IEnumerable<KeyItemCategoryBO> KeyItemCategories { get; set; }
        public IEnumerable<KeyItemBO> KeyItems { get; set; }
        public int ActiveKeyItemCategoryID { get; set; }
    }
}
