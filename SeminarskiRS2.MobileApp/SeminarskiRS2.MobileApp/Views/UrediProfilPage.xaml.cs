using SeminarskiRS2.MobileApp.ViewModels;
using SeminarskiRS2.Model;
using SeminarskiRS2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeminarskiRS2.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UrediProfilPage : ContentPage
    {
        public APIService _apiServiceKorisnici = new APIService("Korisnici");
        public KorisnikVM korisnikVM { get; set; }
        public UrediProfilPage(Korisnik k)
        {
            InitializeComponent();
            BindingContext = korisnikVM = new KorisnikVM() { korisnik = k };

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await korisnikVM.Init();
            this.gradovi.SelectedItem = korisnikVM.GradoviList.FirstOrDefault(s => s.GradID == korisnikVM.korisnik.GradID);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (this.Ime.Text == null)
            {
                await DisplayAlert("Greška", "Morate unijeti ime", "OK");
            }
            
            else if (!Regex.IsMatch(this.Ime.Text, @"^[a-zA-Z]+$"))
            {
                await DisplayAlert("Greška", "Ime se sastoji samo od slova", "OK");
            }
            else if (this.Prezime.Text == null)
            {
                await DisplayAlert("Greška", "Morate unijeti prezime", "OK");
            }
            else if (!Regex.IsMatch(this.Prezime.Text, @"^[a-zA-Z]+$"))
            {
                await DisplayAlert("Greška", "Prezime se sastoji samo od slova", "OK");
            }
            else if (this.Telefon.Text == null)
            {
                await DisplayAlert("Greška", "Morate unijeti telefon", "OK");
            }
            else if (!Regex.IsMatch(this.Telefon.Text, @"^[+]{1}\d{3}[ ]?\d{2}[ ]?\d{3}[ ]?\d{3}"))
            {
                await DisplayAlert("Greška", "Format telefona je: +123 45 678 910", "OK");
            }
            else if (this.Email.Text == null)
            {
                await DisplayAlert("Greška", "Morate unijeti email", "OK");
            }
            else if (!Regex.IsMatch(this.Email.Text, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"))
            {
                await DisplayAlert("Greška", "Neispravan format email-a!", "OK");

            }
            else if (this.KorisnickoIme.Text == null)
            {
                await DisplayAlert("Greška", "Morate unijeti korisničko ime", "OK");
            }
            else if (!Regex.IsMatch(this.KorisnickoIme.Text, @"^(?=.{4,40}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$"))
            {
                await DisplayAlert("Greška", "Neispravan format ili dužina korisničkog imena (4-40)", "OK");
            }
            else if (string.IsNullOrWhiteSpace(this.Lozinka.Text))
            {
                await DisplayAlert("Greška", "Morate unijeti novu ili staru lozinku", "OK");

            }
            else if (this.Lozinka.Text != this.PotvrdaLozinke.Text)
            {
                await DisplayAlert("Greška", "Lozinke moraju biti iste", "OK");

            }
            else if (this.Lozinka.Text.Length < 4)
            {
                await DisplayAlert("Greška", "Lozinka ne smije biti kraća od 4 karaktera", "OK");
            }
            else if (this.gradovi.SelectedItem == null)
            {
                await DisplayAlert("Greška", "Morate odabrati grad", "OK");

            }
            else
            {
                try
                {
                    Grad g = this.gradovi.SelectedItem as Grad;
                    KorisnikInsertRequest req = new KorisnikInsertRequest()
                    {
                        DatumRodjenja = this.DatumRodjenja.Date,
                        Email = this.Email.Text,
                        GradID = g.GradID,
                        Ime = this.Ime.Text,
                        Prezime = this.Prezime.Text,
                        KorisnickoIme = this.KorisnickoIme.Text,
                        Lozinka = this.Lozinka.Text,
                        PotvrdaLozinke = this.PotvrdaLozinke.Text,
                        Telefon = this.Telefon.Text
                    };
                    var lozinka = APIService.Lozinka;
                    var korisnicko = APIService.KorisnickoIme;
                    await _apiServiceKorisnici.Update<dynamic>(korisnikVM.korisnik.KorisnikID, req);
                    await DisplayAlert("OK", "Uspješno uneseni podaci", "OK");
                    if (lozinka != this.Lozinka.Text || korisnicko != this.KorisnickoIme.Text)
                    {
                        App.Current.MainPage = new LoginPage();
                    }

                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }
            }

        }

    }
}