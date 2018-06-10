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
using System.Collections.ObjectModel;

namespace Mreza.ViewModel
{
    class AdministratorViewModel
    {
        //public RegistracijaViewModel parent; -- za povratak na register/login; tj. logout
        public ICommand ObrisiKorisnika { get; set; }
        public ICommand ObrisiProjekat { get; set; }
        public ICommand PosaljiPoruku { get; set; }
        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public List<Projekat> Projekti { get; set; }
        public Korisnik Kor { get; set; }
        public Projekat Pro { get; set; }
        public String Por { get; set; }

        public AdministratorViewModel()
        {
            ObrisiKorisnika = new RelayCommand<object>(ObrisiKorisnikaAsync, MozeLiSeObrisatiKorisnik);
            ObrisiProjekat = new RelayCommand<object>(ObrisiProjekt, OmogucenoBrisanjeProjekta);
            PosaljiPoruku = new RelayCommand<object>(Posaljipp, OmogucenoSlanjePoruka);
            Korisnici = new ObservableCollection<Korisnik>();
            foreach(Korisnik k in BatNet.Korisnici)
            {
                Korisnici.Add(k);
            }
            for(int i = 0; i < Korisnici.Count; i++)
            {
                if (Korisnici.ElementAt(i).KorisnickoIme.Equals("admin")) Korisnici.RemoveAt(i);
            }
            Projekti = BatNet.Projekti;
        }

        public async void ObrisiKorisnikaAsync(object parametar)
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
                    Korisnici.Remove(Kor);
                    BatNet.Korisnici.Remove(Kor);
                    MessageDialog messageDialog = new MessageDialog("Korisnik obrisan!");
                    await messageDialog.ShowAsync();
                }
            }
        }

        public bool MozeLiSeObrisatiKorisnik(object parametar)
        {
            return true;
        }

        public async void ObrisiProjekt(object parametar)
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

        public bool OmogucenoBrisanjeProjekta(object parametar)
        {
            return true;
        }

        public void Posaljipp(object parametar)
        {
            if(Kor != null && !String.IsNullOrEmpty(Por))
            {
                Korisnik autor = BatNet.NadjiKorisnika("admin", BatNet.CreateMD5("admin"));
                Poruka p = new Poruka(Por, autor, DateTime.Now);
                MessageDialog messageDialog = new MessageDialog("Poruka poslana!");
                messageDialog.ShowAsync();
            }
            else
            {
                MessageDialog messageDialog = new MessageDialog("Nije moguće poslati poruku bez odabira korisnika i unosa sadržaja!");
                messageDialog.ShowAsync();
            }
        }

        public bool OmogucenoSlanjePoruka(object parametar)
        {
            return true;
        }
    }
}
