namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCTerritoryFlagsStructuresItem
    {
        [Key]
        public long PCStructureItemID { get; set; }

        public long PCStructureID { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        [StringLength(64)]
        public string ItemTag { get; set; }

        [Required]
        [StringLength(16)]
        public string ItemResref { get; set; }

        [Required]
        public byte[] ItemObject { get; set; }

        public virtual PCTerritoryFlagsStructure PCTerritoryFlagsStructure { get; set; }
    }
}
