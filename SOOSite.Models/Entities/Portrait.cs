namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Portrait
    {
        public long PortraitID { get; set; }

        [Required]
        [StringLength(16)]
        public string Resref { get; set; }

        [Column("2DAID")]
        public long C2DAID { get; set; }
    }
}
