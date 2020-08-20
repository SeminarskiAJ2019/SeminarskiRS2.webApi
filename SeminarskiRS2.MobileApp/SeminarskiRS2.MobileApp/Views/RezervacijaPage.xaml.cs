using SeminarskiRS2.MobileApp.ViewModels;
using SeminarskiRS2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeminarskiRS2.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RezervacijaPage : ContentPage
    {
        private SektoriViewModel sektoriViewModel = null;
        public RezervacijaPage(Utakmice utakmica)
        {
            InitializeComponent();
            BindingContext = sektoriViewModel = new SektoriViewModel()
            {
                StadionID = utakmica.StadionID
            ,
                Utakmica = utakmica
            };
        }
        protected async override void OnAppearing()
        {
            //pozivanje init metode u samom kodu
            //kada se pojavi utakmice page na uredjaju ova ce se metoda pokrenuti
            base.OnAppearing();

            await sektoriViewModel.Init();
            sektoriViewModel.IsBusy = false;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Sektori;
            await Navigation.PushAsync(new OdabirSjedalaPage(item, sektoriViewModel.Utakmica));
        }

    }
}