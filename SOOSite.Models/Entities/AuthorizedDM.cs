namespace SOOSite.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class AuthorizedDM
    {
        [Key]
        public int AuthorizedDMID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string CDKey { get; set; }

        public int DMRole { get; set; }

        public bool IsActive { get; set; }
    }
}
