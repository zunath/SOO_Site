namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StructureBlueprint
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StructureBlueprint()
        {
            ConstructionSites = new HashSet<ConstructionSite>();
            PCTerritoryFlags = new HashSet<PCTerritoryFlag>();
            PCTerritoryFlagsStructures = new HashSet<PCTerritoryFlagsStructure>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StructureBlueprintID { get; set; }

        public int StructureCategoryID { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(16)]
        public string Resref { get; set; }

        public bool IsActive { get; set; }

        public bool IsTerritoryFlag { get; set; }

        public bool IsUseable { get; set; }

        public int WoodRequired { get; set; }

        public int MetalRequired { get; set; }

        public int NailsRequired { get; set; }

        public int ClothRequired { get; set; }

        public int LeatherRequired { get; set; }

        public int ItemStorageCount { get; set; }

        public int MaxStructuresCount { get; set; }

        public double MaxBuildDistance { get; set; }

        public int StoneRequired { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConstructionSite> ConstructionSites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCTerritoryFlag> PCTerritoryFlags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCTerritoryFlagsStructure> PCTerritoryFlagsStructures { get; set; }

        public virtual StructureCategory StructureCategory { get; set; }
    }
}
