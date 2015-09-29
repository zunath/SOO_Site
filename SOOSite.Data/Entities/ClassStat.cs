namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ClassStat
    {
        public int ClassStatID { get; set; }

        public int CharacterClassID { get; set; }

        public int LevelID { get; set; }

        public int HitPoints { get; set; }

        public int Essence { get; set; }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Constitution { get; set; }

        public int Wisdom { get; set; }

        public int Intelligence { get; set; }

        public int Charisma { get; set; }

        public virtual CharacterClass CharacterClass { get; set; }

        public virtual ClassLevel ClassLevel { get; set; }
    }
}
