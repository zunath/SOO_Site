namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FactionRelationshipType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FactionRelationshipType()
        {
            FactionRelationships = new HashSet<FactionRelationship>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FactionRelationshipDomainID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactionRelationship> FactionRelationships { get; set; }
    }
}
