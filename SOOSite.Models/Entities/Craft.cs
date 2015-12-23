namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Craft
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Craft()
        {
            CraftBlueprints = new HashSet<CraftBlueprint>();
            CraftLevels = new HashSet<CraftLevel>();
            PCCrafts = new HashSet<PCCraft>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CraftID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CraftBlueprint> CraftBlueprints { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CraftLevel> CraftLevels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCCraft> PCCrafts { get; set; }
    }
}
