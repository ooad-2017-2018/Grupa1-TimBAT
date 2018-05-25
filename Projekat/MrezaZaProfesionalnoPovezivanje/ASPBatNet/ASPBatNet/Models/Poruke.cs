namespace ASPBatNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Poruke")]
    public partial class Poruke
    {
        [StringLength(255)]
        public string id { get; set; }

        public string sadrzaj_poruke { get; set; }

        public double? autor_id { get; set; }

        public DateTimeOffset? datum_slanja { get; set; }
    }
}
