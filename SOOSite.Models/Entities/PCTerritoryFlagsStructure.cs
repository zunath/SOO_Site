namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCTerritoryFlagsStructure
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PCTerritoryFlagsStructure()
        {
            PCTerritoryFlagsStructuresItems = new HashSet<PCTerritoryFlagsStructuresItem>();
        }

        [Key]
        public long PCTerritoryFlagStructureID { get; set; }

        public int PCTerritoryFlagID { get; set; }

        public int StructureBlueprintID { get; set; }

        public bool IsUseable { get; set; }

        [Required]
        [StringLength(64)]
        public string LocationAreaTag { get; set; }

        public double LocationX { get; set; }

        public double LocationY { get; set; }

        public double LocationZ { get; set; }

        public double LocationOrientation { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        public virtual PCTerritoryFlag PCTerritoryFlag { get; set; }

        public virtual StructureBlueprint StructureBlueprint { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCTerritoryFlagsStructuresItem> PCTerritoryFlagsStructuresItems { get; set; }
    }
}
