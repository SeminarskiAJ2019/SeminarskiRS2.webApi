﻿using SeminarskiRS2.MobileApp.ViewModels;
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
    public partial class TimoviPage : ContentPage
    {
        TimoviViewModel timoviViewModel = null;
        public TimoviPage()
        {
            InitializeComponent();
            BindingContext = timoviViewModel = new TimoviViewModel();
        }

        protected async override void OnAppearing()
        {
            //pozivanje init metode u samom kodu
            //kada se pojavi utakmice page na uredjaju ova ce se metoda pokrenuti
            base.OnAppearing();
            await timoviViewModel.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Timovi;
            await Navigation.PushAsync(new TimDetailPage(item));
        }
    }
}