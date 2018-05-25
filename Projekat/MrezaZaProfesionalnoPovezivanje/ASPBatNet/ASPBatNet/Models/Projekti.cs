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

        public double? kolaboratori_id { get; set; }

        public string opis { get; set; }

        public DateTimeOffset? datum_kreiranja { get; set; }

        public DateTimeOffset? datum_zavrsetka { get; set; }

        public DateTimeOffset? tehnologije_id { get; set; }

        public bool? aktivan { get; set; }
    }
}
