namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCMigrationItem
    {
        public int PCMigrationItemID { get; set; }

        public int PCMigrationID { get; set; }

        [Required]
        [StringLength(16)]
        public string CurrentResref { get; set; }

        [Required]
        [StringLength(16)]
        public string NewResref { get; set; }

        public bool StripItemProperties { get; set; }

        public int BaseItemTypeID { get; set; }

        public virtual BaseItemType BaseItemType { get; set; }

        public virtual PCMigration PCMigration { get; set; }
    }
}
