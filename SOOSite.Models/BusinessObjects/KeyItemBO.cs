using SOOSite.Data.Entities;

namespace SOOSite.Models.BusinessObjects
{
    public class KeyItemBO
    {
        public int KeyItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int KeyItemCategoryID { get; set; }

        public static KeyItemBO FromEntity(KeyItem entity)
        {
            return new KeyItemBO()
            {
                KeyItemID = entity.KeyItemID,
                KeyItemCategoryID = entity.KeyItemCategoryID,
                Name = entity.Name,
                Description = entity.Description
            };
        }

        public KeyItem ToEntity()
        {
            return new KeyItem()
            {
                Description = Description,
                KeyItemCategoryID = KeyItemCategoryID,
                Name = Name,
                KeyItemID = KeyItemID
            };
        }
    }
}
