namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCTerritoryFlagsPermission
    {
        [Key]
        public int PCTerritoryFlagPermissionID { get; set; }

        public int PCTerritoryFlagID { get; set; }

        [Required]
        [StringLength(60)]
        public string PlayerID { get; set; }

        public int TerritoryFlagPermissionID { get; set; }

        public virtual PCTerritoryFlag PCTerritoryFlag { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }

        public virtual TerritoryFlagPermission TerritoryFlagPermission { get; set; }
    }
}
