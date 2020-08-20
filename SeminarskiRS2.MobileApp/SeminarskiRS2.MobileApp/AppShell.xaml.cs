using System;
using System.Collections.Generic;
using SeminarskiRS2.MobileApp.ViewModels;
using SeminarskiRS2.MobileApp.Views;
using Xamarin.Forms;

namespace SeminarskiRS2.MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
