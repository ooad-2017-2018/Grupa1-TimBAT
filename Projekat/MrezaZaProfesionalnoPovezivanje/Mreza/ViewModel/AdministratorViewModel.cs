using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mreza.Model;
using Mreza.Helper;
using Mreza.Azure;
using System.ComponentModel;
using System.Diagnostics;

using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;

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
            ObrisiKorisnika = new RelayCommand<object>(obrisiKorisnikaAsync, mozeLiSeObrisatiKorisnik);
            ObrisiProjekat = new RelayCommand<object>(obrisiProjekat, mozeLiSeObrisatiProjekat);
            PosaljiPoruku = new RelayCommand<object>(posaljiPoruku, mozeLiSePoslatiPoruka);
            Korisnici = BatNet.Korisnici;
            for(int i = 0; i < Korisnici.Count; i++)
            {
                if (Korisnici.ElementAt(i).KorisnickoIme.Equals("admin")) Korisnici.RemoveAt(i);
            }
            Projekti = BatNet.Projekti;
        }

        public async void obrisiKorisnikaAsync(object parametar)
        {
            if (Kor == null) return;
            IMobileServiceTable<Korisnici> usersTable = App.MobileService.GetTable<Korisnici>();
            IMobileServiceTable<Projekti> projectsTable = App.MobileService.GetTable<Projekti>();

            for (int i = 0; i < BatNet.Projekti.Count; i++)
            {
                if (BatNet.Projekti.ElementAt(i).Autor.KorisnickoIme == Kor.KorisnickoIme)
                {
                    for(int j = 0; j < BatNet.Korisnici.Count; j++)
                    {
                        for(int k = 0; k < BatNet.Projekti.Count; k++)
                        {
                            if (BatNet.Projekti.ElementAt(k).ID1.Equals(Projekti.ElementAt(i).ID1)) BatNet.Korisnici.ElementAt(j).Projekti.RemoveAt(k);
                        }
                    }
                    List<Projekti> projekat = await projectsTable.Where(u => u.id == BatNet.Projekti.ElementAt(i).ID1).ToListAsync();
                    if (projekat.Count > 1)
                    {
                        Debug.WriteLine("Big mistake! Stahp!");
                        return;
                    }
                    projekat.ElementAt(0).obrisan = true;
                    await projectsTable.UpdateAsync(projekat.ElementAt(0));
                    BatNet.Projekti.RemoveAt(i);
                }
            }

            for (int i = 0; i < BatNet.Korisnici.Count; i++)
            {
                if (BatNet.Korisnici.ElementAt(i).KorisnickoIme == Kor.KorisnickoIme)
                {
                    List<Korisnici> korisnik = await usersTable.Where(u => u.id == Kor.ID.ToString()).ToListAsync();
                    if(korisnik.Count > 1)
                    {
                        Debug.WriteLine("Big mistake! Stahp!");
                        return;
                    }

                    korisnik.ElementAt(0).obrisan = true;
                    await usersTable.UpdateAsync(korisnik.ElementAt(0));
                    BatNet.Korisnici.RemoveAt(i);
                }
            }
        }

        public bool mozeLiSeObrisatiKorisnik(object parametar)
        {
            return true;
        }

        public async void obrisiProjekat(object parametar)
        {
            IMobileServiceTable<Projekti> usersTable = App.MobileService.GetTable<Projekti>();
            if (Pro == null) return;
            String idProjekta = Pro.ID1;
            for (int i = 0; i < BatNet.Projekti.Count; i++)
            {
                if (BatNet.Projekti.ElementAt(i) == Pro)
                {
                    BatNet.Projekti.RemoveAt(i);
                }
            }
            for(int i = 0; i < BatNet.Korisnici.Count; i++)
            {
                for(int j = 0; j < BatNet.Korisnici.ElementAt(i).Projekti.Count; j++)
                {
                    if (BatNet.Korisnici.ElementAt(i).Projekti.ElementAt(j).ID1.Equals(idProjekta)) BatNet.Korisnici.ElementAt(i).Projekti.RemoveAt(j);
                }
            }
            List<Projekti> projekat = await usersTable.Where(u => u.id == idProjekta).ToListAsync();
            if (projekat.Count > 1)
            {
                Debug.WriteLine("Big mistake! Stahp!");
                return;
            }
            projekat.ElementAt(0).obrisan = true;
            await usersTable.UpdateAsync(projekat.ElementAt(0));
        }

        public bool mozeLiSeObrisatiProjekat(object parametar)
        {
            return true;
        }

        public void posaljiPoruku(object parametar)
        {
            if(Kor != null && !String.IsNullOrEmpty(Por.SadrzajPoruke)) Kor.Poruke.Add(Por);
            else
            {
                MessageDialog messageDialog = new MessageDialog("Nije moguće poslati poruku bez odabira korisnika i unosa sadržaja!");
                messageDialog.ShowAsync();
            }
        }

        public bool mozeLiSePoslatiPoruka(object parametar)
        {
            return true;
        }
    }
}
