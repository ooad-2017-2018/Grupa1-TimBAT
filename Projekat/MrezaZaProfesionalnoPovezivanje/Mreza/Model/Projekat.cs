using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mreza.Model
{
    public class Projekat
    {
        private String naslov;
        private Korisnik autor;
        private List<Korisnik> kolaboratori;
        private String opis;
        private DateTime datumKreiranja;
        private DateTime datumZavrsetka;
        private List<Tehnologija> tehnologije;
        private Boolean aktivan;

        public Projekat(string naslov, Korisnik autor, List<Korisnik> kolaboratori, string opis, DateTime datumKreiranja, DateTime datumZavrsetka, List<Tehnologija> tehnologije, bool aktivan)
        {
            Naslov = naslov;
            Autor = autor;
            Kolaboratori = kolaboratori;
            Opis = opis;
            DatumKreiranja = datumKreiranja;
            DatumZavrsetka = datumZavrsetka;
            Tehnologije = tehnologije;
            Aktivan = aktivan;
        }

        public string Naslov { get => naslov; set => naslov = value; }
        public Korisnik Autor { get => autor; set => autor = value; }
        public List<Korisnik> Kolaboratori { get => kolaboratori; set => kolaboratori = value; }
        public string Opis { get => opis; set => opis = value; }
        public DateTime DatumKreiranja { get => datumKreiranja; set => datumKreiranja = value; }
        public DateTime DatumZavrsetka { get => datumZavrsetka; set => datumZavrsetka = value; }
        public List<Tehnologija> Tehnologije { get => tehnologije; set => tehnologije = value; }
        public bool Aktivan { get => aktivan; set => aktivan = value; }
    }
}
