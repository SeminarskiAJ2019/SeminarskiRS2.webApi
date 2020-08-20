using SeminarskiRS2.MobileApp.ViewModels;
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
    public partial class UlaznicaInfoPage : ContentPage
    {
        UlaznicaDetailVM ulaznicaDetailVM = null;
        public UlaznicaInfoPage(UlaznicaDetailVM vm)
        {
            InitializeComponent();
            BindingContext = ulaznicaDetailVM = vm;
            NavigationPage.SetHasBackButton(this, false);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}