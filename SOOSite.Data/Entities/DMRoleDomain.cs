namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMRoleDomain")]
    public partial class DMRoleDomain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DMRoleDomainID { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }
    }
}
