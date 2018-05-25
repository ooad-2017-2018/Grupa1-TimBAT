namespace ASPBatNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Korisnici")]
    public partial class Korisnici
    {
        [StringLength(255)]
        public string id { get; set; }

        public string email { get; set; }

        public string username { get; set; }

        public string sifra { get; set; }

        public double? kodovi_id { get; set; }

        public string github_link { get; set; }

        public double? bodovi { get; set; }

        public double? kontakt_id { get; set; }

        public double? tehnologije_id { get; set; }

        public double? notifikacije_id { get; set; }

        public double? poruka_id { get; set; }

        public double? projekat_id { get; set; }

        public bool? obrisan { get; set; }

        public string naziv { get; set; }

        public DateTimeOffset? datum { get; set; }

        public string CV { get; set; }

        public string website { get; set; }

        public DateTimeOffset updatedAt { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] version { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public bool deleted { get; set; }
    }
}
