using System.ComponentModel.DataAnnotations;

namespace SOOSite.Data.Entities
{
    public class NWLanguagesDomain
    {
        [Key]
        public int LanguageID { get; set; }
        public string Name { get; set; }
    }
}
