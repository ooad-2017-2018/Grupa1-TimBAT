using Mreza.Helper;
using Mreza.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Mreza.View;
using Mreza.Azure;
using Microsoft.WindowsAzure.MobileServices;
using Windows.Media.Capture;
using Windows.Storage;
using System.IO;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace Mreza.ViewModel
{
    class LoginRegistracijaViewModel
    {
        private byte[] buffer;

        public ICommand PrijaviSe { get; set; }
        public ICommand RegistrujSe { get; set; }
        public ICommand OdaberiSliku { get; set; }
        public ICommand PozoviKameru { get; set; }
        public Boolean PrivatanProfil { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Naziv { get; set; }
        public String Email { get; set; }
        public String Potvrda { get; set; }
        public String UsernameRegistracija { get; set; }
        public String PasswordRegistracija { get; set; }
        public DateTimeOffset Datum { get; set; }
        public String PathSlike { get; set; }
        public LoginRegistracijaViewModel()
        {
            PrijaviSe = new RelayCommand<object>(PrijavaAsync, OmogucenaPrijava);
            RegistrujSe = new RelayCommand<object>(RegistracijaAsync, OmogucenaRegistracija);
            OdaberiSliku = new RelayCommand<object>(OdabirSlikeAsync, OmogucenOdabirSlike);
            PozoviKameru = new RelayCommand<object>(KameraAsync, OmogucenaKamera);
            BitmapImage img = new BitmapImage();
            Uri uri = new Uri("ms-appx:///Assets/profilna.png");
            img.UriSource = uri;
            PathSlike = Convert.ToString(img.UriSource);
            System.Diagnostics.Debug.WriteLine("Hiii");
        }

        public async void KameraAsync(object parameter)
        {
            CameraCaptureUI KameraUI = new CameraCaptureUI();
            KameraUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            
            StorageFile SlikaKamera = await KameraUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (SlikaKamera == null)
            {
                // korisnik prekinuo sliku
                return;
            }
            else
            {
                using (Windows.Storage.Streams.IRandomAccessStream fileStream = await SlikaKamera.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    Windows.UI.Xaml.Media.Imaging.BitmapImage SlikaBitMapa = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    SlikaBitMapa.SetSource(fileStream);
                    PathSlike = Convert.ToString(SlikaBitMapa.UriSource);
                }
            }
        }

        public bool OmogucenaKamera(object parameter)
        {
            return true;
        }

        public async void OdabirSlikeAsync(object parameter)
        {
            var IzbornikSlike = new Windows.Storage.Pickers.FileOpenPicker
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail,
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary
            };
            IzbornikSlike.FileTypeFilter.Add(".jpg");
            IzbornikSlike.FileTypeFilter.Add(".jpeg");
            IzbornikSlike.FileTypeFilter.Add(".png");
            Windows.Storage.StorageFile Slika = await IzbornikSlike.PickSingleFileAsync();
            if(Slika == null)
            {
                MessageDialog greska = new MessageDialog("Greška pri odabiru slike!");
                greska.ShowAsync();
                return;
            }
            else
            {
                using(Windows.Storage.Streams.IRandomAccessStream fileStream = await Slika.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    Windows.UI.Xaml.Media.Imaging.BitmapImage SlikaBitMapa = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    SlikaBitMapa.SetSource(fileStream);
                    PathSlike = Convert.ToString(fileStream);
                }
            }
        }

        public bool OmogucenOdabirSlike(object parameter)
        {
            return true;
        }

        public async void RegistracijaAsync(object parametar)
        {
            IMobileServiceTable<Korisnici> userTableObj = App.MobileService.GetTable<Korisnici>();

            if (!String.IsNullOrWhiteSpace(UsernameRegistracija) && !String.IsNullOrWhiteSpace(PasswordRegistracija) && !String.IsNullOrWhiteSpace(Potvrda) && !String.IsNullOrWhiteSpace(Naziv) && !String.IsNullOrWhiteSpace(Email))
            {
                if(PasswordRegistracija.Equals(Potvrda))
                {
                    try
                    {
                        Korisnici NoviKorisnik = new Korisnici
                        {
                            id = Convert.ToString(BatNet.Korisnici.Last().ID + 1),
                            email = Email,
                            username = UsernameRegistracija,
                            sifra = BatNet.CreateMD5(PasswordRegistracija),
                            obrisan = false,
                            naziv = Naziv,
                            datum = Datum.Date
                        };
                        userTableObj.InsertAsync(NoviKorisnik);
                     
                        if (PrivatanProfil)
                        {
                            ObicniKorisnik korisnik = new ObicniKorisnik(Email, UsernameRegistracija, BatNet.CreateMD5(PasswordRegistracija), null, Naziv, Datum.Date, false);
                            BatNet.Korisnici.Add(korisnik);
                        }
                        else
                        {
                            Firma firma = new Firma(Email, UsernameRegistracija, BatNet.CreateMD5(PasswordRegistracija), null, Naziv, Datum.Date, false);
                            BatNet.Korisnici.Add(firma);
                        }

                        MessageDialog msgDialog = new MessageDialog("Registracija uspjesna. Dobrodosli u BatNet :)");

                        msgDialog.ShowAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageDialog msgDialogError = new MessageDialog("Error: " + ex.ToString());
                        msgDialogError.ShowAsync();
                    }
                }
                else
                {
                    MessageDialog greskaSifra = new MessageDialog("Potvrda šifre mora se slagati sa unesenom šifrom!");
                    greskaSifra.ShowAsync();
                }
            }
            else
            {
                MessageDialog greska = new MessageDialog("Nije moguća registracija bez popunjavanja svih polja!");
                greska.ShowAsync();
            }
        }

        public bool OmogucenaRegistracija(object parameter)
        {
            return true;
        }

        public async void PrijavaAsync(object parametar)
        {
            if (Username == null)
            {
                MessageDialog messageDialog = new MessageDialog("Nije vezano????");
                await messageDialog.ShowAsync();
            }
            else if (Password == null)
            {
                MessageDialog messageDialog = new MessageDialog("Nije vezano?");
                await messageDialog.ShowAsync();
            }
            else
            {
                Password = BatNet.CreateMD5(Password);
                Korisnik korisnikPretraga = BatNet.NadjiKorisnika(Username, Password);
                if (korisnikPretraga == null)
                {
                    MessageDialog Poruka = new MessageDialog("Korisnik sa unesenim podacima ne postoji.");
                    await Poruka.ShowAsync();
                }
                else if(korisnikPretraga != null && !korisnikPretraga.KorisnickoIme.Equals("admin"))
                {
                    MessageDialog Poruka = new MessageDialog("Pristupite aplikaciji koristeći web interfejs!");
                    await Poruka.ShowAsync();
                }
                else
                {
                    ((Frame)Window.Current.Content).Navigate(typeof(AdminPanel));
                }
            }
            Username = "";
            Password = "";
        }

        public bool OmogucenaPrijava(object parameter)
        {
            return true;
        }
    }
}
