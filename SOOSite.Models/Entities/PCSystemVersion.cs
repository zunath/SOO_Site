namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCSystemVersion
    {
        [Key]
        [StringLength(60)]
        public string PlayerID { get; set; }

        public int ClassSystemVersion { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}
