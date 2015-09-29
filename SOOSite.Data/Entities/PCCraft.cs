namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCCraft
    {
        public long PCCraftID { get; set; }

        [Required]
        [StringLength(60)]
        public string PlayerID { get; set; }

        public long CraftID { get; set; }

        public int Level { get; set; }

        public int Experience { get; set; }

        public virtual Craft Craft { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}
