using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mreza.Model;
using Mreza.Helper;
using System.ComponentModel;
using System.Diagnostics;

namespace Mreza.ViewModel
{
    class AdministratorViewModel
    {
        //public RegistracijaViewModel parent; -- za povratak na register/login; tj. logout
        public ICommand ObrisiKorisnika { get; set; }
        public ICommand ObrisiProjekat { get; set; }
        public ICommand PosaljiPoruku { get; set; }
        public List<Korisnik> Korisnici { get; set; }
        public List<Projekat> Projekti { get; set; }
        public Korisnik Kor { get; set; }
        public Projekat Pro { get; set; }
        public Poruka Por { get; set; }

        public AdministratorViewModel()
        {
            ObrisiKorisnika = new RelayCommand<object>(obrisiKorisnika, mozeLiSeObrisatiKorisnik);
            ObrisiProjekat = new RelayCommand<object>(obrisiProjekat, mozeLiSeObrisatiProjekat);
            PosaljiPoruku = new RelayCommand<object>(posaljiPoruku, mozeLiSePoslatiPoruka);
            Korisnici = BatNet.Korisnici;
            Projekti = BatNet.Projekti;
        }

        public void obrisiKorisnika(object parametar)
        {
            for (int i = 0; i < BatNet.Projekti.Count; i++)
            {
                if (BatNet.Projekti.ElementAt(i).Autor.KorisnickoIme == Kor.KorisnickoIme)
                {
                    BatNet.Projekti.RemoveAt(i);
                }
            }

            for (int i = 0; i < BatNet.Korisnici.Count; i++)
            {
                if (BatNet.Korisnici.ElementAt(i).KorisnickoIme == Kor.KorisnickoIme)
                {
                    BatNet.Korisnici.RemoveAt(i);
                }
            }
        }

        public bool mozeLiSeObrisatiKorisnik(object parametar)
        {
            return true;
        }

        public void obrisiProjekat(object parametar)
        {
            for (int i = 0; i < BatNet.Projekti.Count; i++)
            {
                if (BatNet.Projekti.ElementAt(i) == Pro)
                {
                    BatNet.Projekti.RemoveAt(i);
                }
            }
        }

        public bool mozeLiSeObrisatiProjekat(object parametar)
        {
            return true;
        }

        public void posaljiPoruku(object parametar)
        {
            Kor.Poruke.Add(Por);
        }

        public bool mozeLiSePoslatiPoruka(object parametar)
        {
            return true;
        }
    }
}
