namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FactionRelationship
    {
        public int FactionRelationshipID { get; set; }

        public int FactionID { get; set; }

        public int RelationshipTowardsFactionID { get; set; }

        public int RelationshipTypeID { get; set; }

        public virtual Faction Faction { get; set; }

        public virtual Faction Faction1 { get; set; }

        public virtual FactionRelationshipType FactionRelationshipType { get; set; }
    }
}
