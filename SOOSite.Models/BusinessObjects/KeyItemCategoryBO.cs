using SOOSite.Data.Entities;

namespace SOOSite.Models.BusinessObjects
{
    public class KeyItemCategoryBO
    {
        public int KeyItemCategoryID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public static KeyItemCategoryBO FromEntity(KeyItemCategory entity)
        {
            return new KeyItemCategoryBO
            {
                IsActive = entity.IsActive,
                KeyItemCategoryID = entity.KeyItemCategoryID,
                Name = entity.Name
            };
        }

        public KeyItemCategory ToEntity()
        {
            return new KeyItemCategory()
            {
                IsActive = IsActive,
                Name = Name,
                KeyItemCategoryID = KeyItemCategoryID
            };
        }
    }
}
