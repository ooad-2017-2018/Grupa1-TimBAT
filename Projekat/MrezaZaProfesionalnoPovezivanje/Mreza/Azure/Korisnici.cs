using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mreza.Azure
{
    class Korisnici
    {
        public string id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string sifra { get; set; }
        public int kodovi_id { get; set; }
        public string github_link { get; set; }
        public int bodovi { get; set; }
        public int kontakt_id { get; set; }
        public int tehnologije_id { get; set; }
        public int notifikacije_id { get; set; }
        public int poruka_id { get; set; }
        public int projekat_id { get; set; }
        public bool obrisan { get; set; }
        public string naziv { get; set; }
        public DateTime datum { get; set; }
        public string CV { get; set; }
        public string website { get; set; }

    }
}
