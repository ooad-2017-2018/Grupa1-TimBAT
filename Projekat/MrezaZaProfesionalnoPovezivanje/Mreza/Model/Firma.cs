using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace Mreza.Model
{
    public class Firma : Korisnik
    {
        private String nazivFirme;
        private DateTime datumOsnivanja;
        private String website;

        public Firma(int id, string eMail, string korisnickoIme, string password, List<Korisnik> kontakti, List<Projekat> projekti, String imeFirme) : base(id, eMail, korisnickoIme, password, kontakti, projekti)
        {
            NazivFirme = imeFirme;
            DatumOsnivanja = DateTime.Now;
            Website = "";
        }

        public Firma(string eMail, string korisnickoIme, string password, ImageSource slika, string nazivFirme, DateTime datumOsnivanja, bool obrisan) : base(eMail, korisnickoIme, password, slika)
        {
            NazivFirme = nazivFirme;
            DatumOsnivanja = datumOsnivanja;
            Website = "";
            Obrisan = obrisan;
        }

        public Firma(string eMail, string password, ImageSource slika, string nazivFirme, DateTime datumOsnivanja) : base(eMail, password, slika)
        {
            NazivFirme = nazivFirme;
            DatumOsnivanja = datumOsnivanja;
            Website = "";
        }

        public string NazivFirme { get => nazivFirme; set => nazivFirme = value; }
        public DateTime DatumOsnivanja { get => datumOsnivanja; set => datumOsnivanja = value; }
        public string Website { get => website; set => website = value; }
    }
}
