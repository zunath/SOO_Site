namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCKeyItem
    {
        public int PCKeyItemID { get; set; }

        [Required]
        [StringLength(60)]
        public string PlayerID { get; set; }

        public int KeyItemID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AcquiredDate { get; set; }

        public virtual KeyItem KeyItem { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}
