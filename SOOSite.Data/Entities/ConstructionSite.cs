namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConstructionSite
    {
        public int ConstructionSiteID { get; set; }

        public int? PCTerritoryFlagID { get; set; }

        [Required]
        [StringLength(60)]
        public string PlayerID { get; set; }

        public int StructureBlueprintID { get; set; }

        public int WoodRequired { get; set; }

        public int MetalRequired { get; set; }

        public int NailsRequired { get; set; }

        public int ClothRequired { get; set; }

        public int LeatherRequired { get; set; }

        [Required]
        [StringLength(64)]
        public string LocationAreaTag { get; set; }

        public double LocationX { get; set; }

        public double LocationY { get; set; }

        public double LocationZ { get; set; }

        public double LocationOrientation { get; set; }

        public int StoneRequired { get; set; }

        public virtual PCTerritoryFlag PCTerritoryFlag { get; set; }

        public virtual StructureBlueprint StructureBlueprint { get; set; }
    }
}
