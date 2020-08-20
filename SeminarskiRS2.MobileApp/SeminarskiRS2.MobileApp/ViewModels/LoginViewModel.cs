using SeminarskiRS2.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SeminarskiRS2.MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _apiService = new APIService("Korisnici");
        string _korisnickoIme = string.Empty;
        public string KorisnickoIme
        {
            get { return _korisnickoIme; }
            set { SetProperty(ref _korisnickoIme, value); }
        }

        string _lozinka = string.Empty;
        public string Lozinka
        {
            get { return _lozinka; }
            set { SetProperty(ref _lozinka, value); }
        }
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }

        async Task Login()
        {
            IsBusy = true;
            APIService.KorisnickoIme = KorisnickoIme;
            APIService.Lozinka = Lozinka;
            PaymentAPIService.KorisnickoIme = KorisnickoIme;
            PaymentAPIService.Lozinka = Lozinka;
            try
            {
                await _apiService.Get<dynamic>(null);
                Application.Current.MainPage = new MainPage();
            }
            catch(Exception ex)
            {
                IsBusy = false;
            }
        }
    }
}
