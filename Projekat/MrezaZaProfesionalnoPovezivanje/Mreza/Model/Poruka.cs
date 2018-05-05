using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mreza.Model
{
    public class Poruka
    {
        private String sadrzajPoruke;
        private Korisnik autor;
        private DateTime datumSlanja;

        public Poruka(string sadrzajPoruke, Korisnik autor, DateTime datumSlanja)
        {
            SadrzajPoruke = sadrzajPoruke;
            Autor = autor;
            DatumSlanja = datumSlanja;
        }

        public string SadrzajPoruke { get => sadrzajPoruke; set => sadrzajPoruke = value; }
        public Korisnik Autor { get => autor; set => autor = value; }
        public DateTime DatumSlanja { get => datumSlanja; set => datumSlanja = value; }
    }
}
