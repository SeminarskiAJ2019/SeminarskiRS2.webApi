using SeminarskiRS2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SeminarskiRS2.MobileApp.Models;

namespace SeminarskiRS2.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public APIService aPIServiceKorisnici = new APIService("Korisnici");
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Početna, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Početna:
                        MenuPages.Add(id, new NavigationPage(new PocetnaPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Utakmice:
                        MenuPages.Add(id, new NavigationPage(new UtakmicePage()));
                        break;
                    case (int)MenuItemType.Stadioni:
                        MenuPages.Add(id, new NavigationPage(new StadioniPage()));
                        break;
                    case (int)MenuItemType.Timovi:
                        MenuPages.Add(id, new NavigationPage(new TimoviPage()));
                        break;
                    case (int)MenuItemType.MojeUlaznice:
                        MenuPages.Add(id, new NavigationPage(new MojeUlaznicePage()));
                        break;
                    case (int)MenuItemType.UrediProfil:
                        Korisnik korisnik = new Korisnik();
                        var ki = APIService.KorisnickoIme;
                        List<Korisnik> lista = await aPIServiceKorisnici.Get<List<Korisnik>>(null);
                        foreach (var k in lista)
                        {
                            if (k.KorisnickoIme == ki)
                            {
                                korisnik = k;
                                break;
                            }
                        }
                        MenuPages.Add(id, new NavigationPage(new UrediProfilPage(korisnik)));
                        break;
                    case (int)MenuItemType.Odjava:
                        MenuPages.Add(id, new NavigationPage(new LoginPage()));
                        break;

                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}