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
    }
}
