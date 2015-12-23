namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCAuthorizedCDKey
    {
        [Key]
        [StringLength(255)]
        public string AccountID { get; set; }

        public bool IsAddingKey { get; set; }

        [Required]
        [StringLength(20)]
        public string CDKey1 { get; set; }

        [Required]
        [StringLength(20)]
        public string CDKey2 { get; set; }

        [Required]
        [StringLength(20)]
        public string CDKey3 { get; set; }

        [Required]
        [StringLength(20)]
        public string CDKey4 { get; set; }

        [Required]
        [StringLength(20)]
        public string CDKey5 { get; set; }

        [Required]
        [StringLength(20)]
        public string CDKey6 { get; set; }

        [Required]
        [StringLength(20)]
        public string CDKey7 { get; set; }

        [Required]
        [StringLength(20)]
        public string CDKey8 { get; set; }

        [Required]
        [StringLength(20)]
        public string CDKey9 { get; set; }

        [Required]
        [StringLength(20)]
        public string CDKey10 { get; set; }
    }
}
