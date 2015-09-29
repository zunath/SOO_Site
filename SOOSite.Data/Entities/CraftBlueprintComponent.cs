namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CraftBlueprintComponent
    {
        [Key]
        public long CraftComponentID { get; set; }

        public long CraftBlueprintID { get; set; }

        [Required]
        [StringLength(16)]
        public string ItemResref { get; set; }

        public int Quantity { get; set; }

        public virtual CraftBlueprint CraftBlueprint { get; set; }
    }
}
