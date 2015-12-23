namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCClass
    {
        public int PCClassID { get; set; }

        [Required]
        [StringLength(60)]
        public string PlayerID { get; set; }

        public int CharacterClassID { get; set; }

        public int LevelID { get; set; }

        public int Experience { get; set; }

        public virtual CharacterClass CharacterClass { get; set; }

        public virtual ClassLevel ClassLevel { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}
