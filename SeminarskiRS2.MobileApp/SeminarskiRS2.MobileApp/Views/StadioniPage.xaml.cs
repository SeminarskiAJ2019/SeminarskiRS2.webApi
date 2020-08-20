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
    public partial class StadioniPage : ContentPage
    {
        StadioniViewModel stadioniViewModel = null;
        public StadioniPage()
        {
            InitializeComponent();
            BindingContext = stadioniViewModel = new StadioniViewModel();
        }

        protected async override void OnAppearing()
        {
            //pozivanje init metode u samom kodu
            //kada se pojavi utakmice page na uredjaju ova ce se metoda pokrenuti
            base.OnAppearing();
            await stadioniViewModel.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Stadioni;
            await Navigation.PushAsync(new StadionDetailPage(item));
        }
    }
}