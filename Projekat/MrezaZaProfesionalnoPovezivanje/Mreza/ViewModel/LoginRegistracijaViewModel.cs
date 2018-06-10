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
            PrijaviSe = new RelayCommand<object>(prijavaAsync, mogucaPrijava);
            RegistrujSe = new RelayCommand<object>(registracijaAsync, mogucaRegistracija);
            OdaberiSliku = new RelayCommand<object>(odabirSlikeAsync, mogucOdabirSlike);
            PozoviKameru = new RelayCommand<object>(kameraAsync, mogucaKamera);
            BitmapImage img = new BitmapImage();
            Uri uri = new Uri("ms-appx:///Assets/profilna.png");
            img.UriSource = uri;
            PathSlike = Convert.ToString(img.UriSource);
            System.Diagnostics.Debug.WriteLine("Hiii");
        }

        public async void kameraAsync(object parameter)
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            
            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (photo == null)
            {
                // korisnik prekinuo sliku
                return;
            }
            else
            {
                using (Windows.Storage.Streams.IRandomAccessStream fileStream = await photo.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    Windows.UI.Xaml.Media.Imaging.BitmapImage img = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    img.SetSource(fileStream);
                    PathSlike = Convert.ToString(img.UriSource);
                }
            }
        }

        public bool mogucaKamera(object parameter)
        {
            return true;
        }

        public async void odabirSlikeAsync(object parameter)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if(file == null)
            {
                MessageDialog greska = new MessageDialog("Greška pri odabiru slike!");
                greska.ShowAsync();
                return;
            }
            else
            {
                using(Windows.Storage.Streams.IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    Windows.UI.Xaml.Media.Imaging.BitmapImage img = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    img.SetSource(fileStream);
                    PathSlike = Convert.ToString(fileStream);
                    MessageDialog messageDialog = new MessageDialog(PathSlike);
                    messageDialog.ShowAsync();
                }
            }
        }

        public bool mogucOdabirSlike(object parameter)
        {
            return true;
        }

        public async void registracijaAsync(object parametar)
        {
            IMobileServiceTable<Korisnici> userTableObj = App.MobileService.GetTable<Korisnici>();

            if (!String.IsNullOrWhiteSpace(UsernameRegistracija) && !String.IsNullOrWhiteSpace(PasswordRegistracija) && !String.IsNullOrWhiteSpace(Potvrda) && !String.IsNullOrWhiteSpace(Naziv) && !String.IsNullOrWhiteSpace(Email))
            {
                if(PasswordRegistracija.Equals(Potvrda))
                {
                    try
                    {
                        Korisnici obj = new Korisnici(); 
                        obj.id = Convert.ToString(BatNet.Korisnici.Last().ID + 1);
                        obj.email = Email;
                        obj.username = UsernameRegistracija;
                        obj.sifra = BatNet.CreateMD5(PasswordRegistracija);
                        obj.obrisan = false;
                        obj.naziv = Naziv;
                        obj.datum = Datum.Date;
                        await userTableObj.InsertAsync(obj);

                        if (PrivatanProfil)
                        {
                            ObicniKorisnik obicni = new ObicniKorisnik(Email, UsernameRegistracija, BatNet.CreateMD5(PasswordRegistracija), null, Naziv, Datum.Date, false);
                            BatNet.Korisnici.Add(obicni);
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

        public bool mogucaRegistracija(object parameter)
        {
            return true;
        }

        public async void prijavaAsync(object parametar)
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
                Korisnik kor = BatNet.NadjiKorisnika(Username, Password);
                if (kor == null)
                {
                    MessageDialog Poruka = new MessageDialog("Korisnik sa unesenim podacima ne postoji.");
                    await Poruka.ShowAsync();
                }
                else if(kor != null && !kor.KorisnickoIme.Equals("admin"))
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

        public bool mogucaPrijava(object parameter)
        {
            return true;
        }
    }
}
