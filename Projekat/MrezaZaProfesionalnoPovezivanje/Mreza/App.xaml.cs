using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Mreza.View;
using Mreza.Model;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Mreza.Azure;

using System.Data;

namespace Mreza
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {

        // This MobileServiceClient has been configured to communicate with the Azure Mobile Service and
        // Azure Gateway using the application url. You're all set to start working with your Mobile Service!
        //public static Microsoft.WindowsAzure.MobileServices.MobileServiceClient MrezaClient = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient("https://mreza.azurewebsites.net");

        public static MobileServiceClient MobileService = new MobileServiceClient("https://mreza.azurewebsites.net");

        private async void ucitajKorisnike()
        {
            IMobileServiceTable<Korisnici> usersTable = MobileService.GetTable<Korisnici>();
            var users = await usersTable.ToListAsync();
            
            for(int i = 0; i < users.Count; i++)
            {
                if(users.ElementAt(i).CV == null && users.ElementAt(i).obrisan == false)
                {
                    BatNet.Korisnici.Add(new Firma(Convert.ToInt32(users.ElementAt(i).id), users.ElementAt(i).email, users.ElementAt(i).username, users.ElementAt(i).sifra, null, null, users.ElementAt(i).naziv));
                }
                else if(users.ElementAt(i).obrisan == false)
                {
                    BatNet.Korisnici.Add(new ObicniKorisnik(Convert.ToInt32(users.ElementAt(i).id), users.ElementAt(i).email, users.ElementAt(i).username, users.ElementAt(i).sifra, null, null, users.ElementAt(i).naziv));
                }
            }
        }

        private async void ucitajProjekte()
        {
            IMobileServiceTable<Projekti> projectsTable = MobileService.GetTable<Projekti>();
            var projects = await projectsTable.ToListAsync();

            for(int i = 0; i < projects.Count; i++)
            {
                if(projects.ElementAt(i).obrisan == false)
                {
                    List<Korisnik> listaKolaboratora = new List<Korisnik>();
                    String[] idKolaboratora = new String[0];
                    if(projects.ElementAt(i).kolaboratori_id != null)
                    {
                        projects.ElementAt(i).kolaboratori_id.Split(',');
                        for (int j = 0; j < idKolaboratora.Count(); j++)
                        {
                            Korisnik kor = BatNet.Korisnici.Find(k => k.ID.Equals(idKolaboratora[j]));
                            if (kor != null) listaKolaboratora.Add(kor);
                        }
                        Korisnik autor = BatNet.Korisnici.Find(k => k.ID.Equals(projects.ElementAt(i).autor_id));
                        BatNet.Projekti.Add(new Projekat(projects.ElementAt(i).id, projects.ElementAt(i).naslov, autor, listaKolaboratora));
                        autor.Projekti.Add(BatNet.Projekti.Last());
                        foreach (Korisnik k in listaKolaboratora)
                        {
                            k.Projekti.Add(BatNet.Projekti.Last());
                        }
                    }
                }
            }
        }

        private async void dodajKontakte()
        {
            IMobileServiceTable<Korisnici> usersTable = MobileService.GetTable<Korisnici>();
            var users = await usersTable.ToListAsync();

            for (int i = 0; i < users.Count; i++)
            {
                if (users.ElementAt(i).obrisan == false)
                {
                    List<Korisnik> listaKontakata = new List<Korisnik>();
                    String[] idKontakata = new String[0];
                    if (users.ElementAt(i).kontakti_id != null)
                    {
                        idKontakata = users.ElementAt(i).kontakti_id.Split(',');
                        for (int j = 0; j < idKontakata.Count(); j++)
                        {
                            Korisnik kor = BatNet.Korisnici.Find(k => k.ID.Equals(idKontakata[j]));
                            if (kor != null) listaKontakata.Add(kor);
                        }
                        Korisnik kori = BatNet.Korisnici.Find(x => x.ID.Equals(users.ElementAt(i).id));
                        kori.Kontakti = listaKontakata;
                    }
                }
            }
        }

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            ucitajKorisnike();
            ucitajProjekte();
            dodajKontakte();
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    // ayyyy lmao
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
