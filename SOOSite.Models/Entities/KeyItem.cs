namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KeyItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KeyItem()
        {
            PCKeyItems = new HashSet<PCKeyItem>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KeyItemID { get; set; }

        public int KeyItemCategoryID { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public virtual KeyItemCategory KeyItemCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCKeyItem> PCKeyItems { get; set; }
    }
}
