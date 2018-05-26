using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace Mreza.Model
{
    public class ObicniKorisnik : Korisnik
    {
        private String ime;
        private DateTime datumRodjenja;
        private String CV;

        public ObicniKorisnik(int id, string eMail, string korisnickoIme, string password, List<Korisnik> kontakti, List<Projekat> projekti, String ime) : base(id, eMail, korisnickoIme, password, kontakti, projekti)
        {
            Ime = ime;
        }

        public ObicniKorisnik(string eMail, string korisnickoIme, string password, ImageSource slika, string ime, DateTime datumRodjenja, bool obrisan) : base(eMail, korisnickoIme, password, slika)
        {
            Ime = ime;
            DatumRodjenja = datumRodjenja;
            CV1 = "";
            Obrisan = obrisan;
        }

        public ObicniKorisnik(string eMail, string password, ImageSource slika, string ime, DateTime datumRodjenja) : base(eMail, password, slika)
        {
            Ime = ime;
            DatumRodjenja = datumRodjenja;
            CV1 = "";
        }

        public string Ime { get => ime; set => ime = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string CV1 { get => CV; set => CV = value; }
    }
}
