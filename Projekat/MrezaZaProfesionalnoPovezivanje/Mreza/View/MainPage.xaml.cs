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

using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;
using Mreza.Azure;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Mreza.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class MainPage : Page
    {


        IMobileServiceTable<Korisnici> userTableObj = App.MobileService.GetTable<Korisnici>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) // za firmu
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e) // za privatni profil
        {

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            nazivFirme_tb.Visibility = Visibility.Visible;
            osnivanjeFirme_tekst.Visibility = Visibility.Visible;
            imePrezime_tb.Visibility = Visibility.Collapsed;
            rodjenje_tekst.Visibility = Visibility.Collapsed;
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            nazivFirme_tb.Visibility = Visibility.Collapsed;
            osnivanjeFirme_tekst.Visibility = Visibility.Collapsed;
            imePrezime_tb.Visibility = Visibility.Visible;
            rodjenje_tekst.Visibility = Visibility.Visible;
        }

        private void Registruj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Korisnici obj = new Korisnici();


                userTableObj.InsertAsync(obj);

                MessageDialog msgDialog = new MessageDialog("Registracija uspjesna. Dobrodosli u BatNet :)");

                msgDialog.ShowAsync();
            }
            catch (Exception ex)
            {
                MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                msgDialogError.ShowAsync();
            }
        }
    }
}
