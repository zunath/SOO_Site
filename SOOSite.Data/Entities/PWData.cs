namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PWData")]
    public partial class PWData
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(64)]
        public string player { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string tag { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(64)]
        public string name { get; set; }

        public string val { get; set; }

        public int? expire { get; set; }

        public DateTime last { get; set; }
    }
}
