namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCBlueprint
    {
        public long PCBlueprintID { get; set; }

        [Required]
        [StringLength(60)]
        public string PlayerID { get; set; }

        public long CraftBlueprintID { get; set; }

        public DateTime AcquiredDate { get; set; }

        public virtual CraftBlueprint CraftBlueprint { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}
