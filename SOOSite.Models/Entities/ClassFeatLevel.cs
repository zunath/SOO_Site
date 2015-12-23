namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ClassFeatLevel
    {
        public int ClassFeatLevelID { get; set; }

        public int CharacterClassID { get; set; }

        public int ClassLevelID { get; set; }

        public int FeatID { get; set; }

        public virtual CharacterClass CharacterClass { get; set; }

        public virtual ClassLevel ClassLevel { get; set; }

        public virtual ClassLevel ClassLevel1 { get; set; }

        public virtual ClassLevel ClassLevel2 { get; set; }
    }
}
