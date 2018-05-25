namespace ASPBatNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notifikacije")]
    public partial class Notifikacije
    {
        [StringLength(255)]
        public string id { get; set; }

        public string sadrzaj { get; set; }

        public DateTimeOffset? datum { get; set; }
    }
}
