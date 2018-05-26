namespace ASPBatNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Projekti")]
    public partial class Projekti
    {
        [StringLength(255)]
        public string id { get; set; }

        public string naslov { get; set; }

        public double? autor_id { get; set; }

<<<<<<< HEAD
=======
        public double? kolaboratori_id { get; set; }

>>>>>>> 45dffc5a8043da3768f2ab4f342d4af552579fbc
        public string opis { get; set; }

        public DateTimeOffset? datum_kreiranja { get; set; }

        public DateTimeOffset? datum_zavrsetka { get; set; }

<<<<<<< HEAD
        public bool? aktivan { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] version { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public DateTimeOffset updatedAt { get; set; }

        public bool deleted { get; set; }

        public bool? obrisan { get; set; }

        public string kolaboratori_id { get; set; }

        public string tehnologije_id { get; set; }
=======
        public DateTimeOffset? tehnologije_id { get; set; }

        public bool? aktivan { get; set; }
>>>>>>> 45dffc5a8043da3768f2ab4f342d4af552579fbc
    }
}
