namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CraftBlueprint
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CraftBlueprint()
        {
            CraftBlueprintComponents = new HashSet<CraftBlueprintComponent>();
            PCBlueprints = new HashSet<PCBlueprint>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CraftBlueprintID { get; set; }

        public long CraftID { get; set; }

        public long CraftCategoryID { get; set; }

        public int Level { get; set; }

        [Required]
        [StringLength(64)]
        public string ItemName { get; set; }

        [Required]
        [StringLength(16)]
        public string ItemResref { get; set; }

        public int Quantity { get; set; }

        public virtual CraftBlueprintCategory CraftBlueprintCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CraftBlueprintComponent> CraftBlueprintComponents { get; set; }

        public virtual Craft Craft { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCBlueprint> PCBlueprints { get; set; }
    }
}
