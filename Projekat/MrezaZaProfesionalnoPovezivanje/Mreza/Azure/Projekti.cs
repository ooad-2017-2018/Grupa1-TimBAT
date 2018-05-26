using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mreza.Azure
{
    class Projekti
    {
        public String id { get; set; }
        public String naslov { get; set; }
        public int autor_id { get; set; }
        public String kolaboratori_id { get; set; }
        public String opis { get; set; }
        public DateTime datum_kreiranja { get; set; }
        public DateTime datum_zavrsetka { get; set; }
        public Boolean aktivan { get; set; }
        public Boolean obrisan { get; set; }
        public String tehnologije_id { get; set; }
    }
}
