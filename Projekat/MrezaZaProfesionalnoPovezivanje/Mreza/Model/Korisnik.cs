using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Mreza.Model
{
    abstract public class Korisnik
    {
        private String eMail;
        private String korisnickoIme;
        private String password;
        private ImageSource slika;
        private String opisProfila;
        private List<String> kodovi;
        private String githubLink;
        private Int32 bodovi;
        private List<Korisnik> kontakti;
        private List<Tehnologija> tehnologije;
        private List<Notifikacija> notifikacije;
        private List<Poruka> poruke;
        private List<Projekat> projekti;
        
        protected Korisnik(string eMail, string korisnickoIme, string password, ImageSource slika)
        {
            EMail = eMail;
            KorisnickoIme = korisnickoIme;
            Password = password;
            Slika = slika;
            OpisProfila = "";
            Kodovi = new List<string>();
            GithubLink = "";
            Bodovi = 0;
            Kontakti = new List<Korisnik>();
            Tehnologije = new List<Tehnologija>();
            Notifikacije = new List<Notifikacija>();
            Poruke = new List<Poruka>();
            Projekti = new List<Projekat>();
        }

        protected Korisnik(string eMail, string password, ImageSource slika)
        {
            EMail = eMail;
            KorisnickoIme = EMail;
            Password = password;
            Slika = slika;
            OpisProfila = "";
            Kodovi = new List<string>();
            GithubLink = "";
            Bodovi = 0;
            Kontakti = new List<Korisnik>();
            Tehnologije = new List<Tehnologija>();
            Notifikacije = new List<Notifikacija>();
            Poruke = new List<Poruka>();
            Projekti = new List<Projekat>();
        }

        public string EMail { get => eMail; set => eMail = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Password { get => password; set => password = value; }
        public ImageSource Slika { get => slika; set => slika = value; }
        public string OpisProfila { get => opisProfila; set => opisProfila = value; }
        public List<string> Kodovi { get => kodovi; set => kodovi = value; }
        public string GithubLink { get => githubLink; set => githubLink = value; }
        public int Bodovi { get => bodovi; set => bodovi = value; }
        public List<Korisnik> Kontakti { get => kontakti; set => kontakti = value; }
        public List<Tehnologija> Tehnologije { get => tehnologije; set => tehnologije = value; }
        public List<Notifikacija> Notifikacije { get => notifikacije; set => notifikacije = value; }
        public List<Poruka> Poruke { get => poruke; set => poruke = value; }
        public List<Projekat> Projekti { get => projekti; set => projekti = value; }
    }
}
