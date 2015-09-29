namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PlayerCharacter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlayerCharacter()
        {
            PCBlueprints = new HashSet<PCBlueprint>();
            PCClasses = new HashSet<PCClass>();
            PCCrafts = new HashSet<PCCraft>();
            PCFactionReputations = new HashSet<PCFactionReputation>();
            PCKeyItems = new HashSet<PCKeyItem>();
            PCOverflowItems = new HashSet<PCOverflowItem>();
            PCTerritoryFlags = new HashSet<PCTerritoryFlag>();
            PCTerritoryFlagsPermissions = new HashSet<PCTerritoryFlagsPermission>();
        }

        [Key]
        [StringLength(60)]
        public string PlayerID { get; set; }

        public string CharacterName { get; set; }

        public int HitPoints { get; set; }

        [Required]
        [StringLength(64)]
        public string LocationAreaTag { get; set; }

        public double LocationX { get; set; }

        public double LocationY { get; set; }

        public double LocationZ { get; set; }

        public double LocationOrientation { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateTimestamp { get; set; }

        public int VersionNumber { get; set; }

        [Required]
        [StringLength(64)]
        public string BindLocationAreaTag { get; set; }

        public double BindLocationOrientation { get; set; }

        public double BindLocationX { get; set; }

        public double BindLocationY { get; set; }

        public double BindLocationZ { get; set; }

        public int ActiveClassID { get; set; }

        public int CurrentEssence { get; set; }

        public virtual CharacterClass CharacterClass { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCBlueprint> PCBlueprints { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCClass> PCClasses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCCraft> PCCrafts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCFactionReputation> PCFactionReputations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCKeyItem> PCKeyItems { get; set; }

        public virtual PCOutfit PCOutfit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCOverflowItem> PCOverflowItems { get; set; }

        public virtual PCSystemVersion PCSystemVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCTerritoryFlag> PCTerritoryFlags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCTerritoryFlagsPermission> PCTerritoryFlagsPermissions { get; set; }
    }
}
