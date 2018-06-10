using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Mreza;
using Mreza.Model;
using System.Diagnostics;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Mreza.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminPanel : Page
    {

        ObservableCollection<Korisnik> korisniciLista;
        List<Projekat> projektiLista;
        bool done1 = false, done2 = false;

        public AdminPanel()
        {
            korisniciLista = new ObservableCollection<Korisnik>();
            projektiLista = new List<Projekat>();
            this.InitializeComponent();
        }

        private void korisnik_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!done1)
            {
                korisniciLista = ((ObservableCollection<Korisnik>)(korisnici.ItemsSource));
                done1 = true;
            }

            String trazeni = korisnik.Text.ToLower();

            korisnici.ItemsSource = null;
            korisnici.Items.Clear();
            foreach (Korisnik k in korisniciLista)
                if (k.KorisnickoIme.ToLower().Contains(trazeni))
                    korisnici.Items.Add(k);
        }

        private void Pretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!done1)
            {
                korisniciLista = ((ObservableCollection<Korisnik>)(AutoriProjekta.ItemsSource));
                done1 = true;
            }

            String trazeni = Pretraga.Text.ToLower();

            AutoriProjekta.ItemsSource = null;
            AutoriProjekta.Items.Clear();
            foreach (Korisnik k in korisniciLista)
                if (k.KorisnickoIme.ToLower().Contains(trazeni))
                    AutoriProjekta.Items.Add(k);
        }

        private void AutoriProjekta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!done2)
            {
                projektiLista = ((List<Projekat>)(Projekti.ItemsSource));
                done2 = true;
            }
            
            Korisnik autorProjekta = (Korisnik)AutoriProjekta.SelectedItem;

            Projekti.ItemsSource = null;
            Projekti.Items.Clear();
            foreach (Projekat p in projektiLista)
                if (autorProjekta == p.Autor)
                    Projekti.Items.Add(p);
        }
    }
}
