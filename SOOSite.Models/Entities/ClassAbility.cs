namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ClassAbility
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassAbilityID { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        public int FeatID { get; set; }

        public int EssenceCost { get; set; }

        [Required]
        [StringLength(64)]
        public string ScriptClassName { get; set; }

        public int CastingTime { get; set; }

        public int CooldownTime { get; set; }
    }
}
