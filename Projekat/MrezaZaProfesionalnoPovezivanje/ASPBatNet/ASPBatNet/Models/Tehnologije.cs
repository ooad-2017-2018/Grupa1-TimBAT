namespace ASPBatNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tehnologije")]
    public partial class Tehnologije
    {
        [StringLength(255)]
        public string id { get; set; }

        public string naziv { get; set; }
<<<<<<< HEAD

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] version { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public DateTimeOffset updatedAt { get; set; }

        public bool deleted { get; set; }
=======
>>>>>>> 45dffc5a8043da3768f2ab4f342d4af552579fbc
    }
}
