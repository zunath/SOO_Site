namespace SOOSite.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServerConfiguration")]
    public partial class ServerConfiguration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServerConfigurationID { get; set; }

        public int MaxLevel { get; set; }

        public int MaxExpAcquirable { get; set; }

        public double MaxExpGainDistance { get; set; }

        [Required]
        [StringLength(500)]
        public string MessageOfTheDay { get; set; }

        [Required]
        [StringLength(32)]
        public string ServerName { get; set; }
    }
}
