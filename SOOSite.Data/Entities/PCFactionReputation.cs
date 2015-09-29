namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PCFactionReputation")]
    public partial class PCFactionReputation
    {
        public int PCFactionReputationID { get; set; }

        [Required]
        [StringLength(60)]
        public string PlayerID { get; set; }

        public int FactionID { get; set; }

        public int Reputation { get; set; }

        public virtual Faction Faction { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}
