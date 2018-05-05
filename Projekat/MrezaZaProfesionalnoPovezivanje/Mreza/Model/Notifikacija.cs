using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mreza.Model
{
    public class Notifikacija
    {
        private String sadrzaj;
        private DateTime datum;

        public Notifikacija(string sadrzaj, DateTime datum)
        {
            Sadrzaj = sadrzaj;
            Datum = datum;
        }

        public string Sadrzaj { get => sadrzaj; set => sadrzaj = value; }
        public DateTime Datum { get => datum; set => datum = value; }
    }
}
