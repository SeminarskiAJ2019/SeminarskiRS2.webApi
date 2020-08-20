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
    public partial class UlazniceInfoPage2 : ContentPage
    {
        public UlaznicaSimpleDetailVM UlaznicaSimpleDetailVM { get; set; }
        public UlazniceInfoPage2(Ulaznice ulaznica)
        {
            InitializeComponent();
            BindingContext = UlaznicaSimpleDetailVM = new UlaznicaSimpleDetailVM() { ulaznica = ulaznica };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (UlaznicaSimpleDetailVM.ulaznica.DatumKupnje < DateTime.Now)
                UlaznicaSimpleDetailVM.ulaznica.color = "LightGray";
            else
                UlaznicaSimpleDetailVM.ulaznica.color = "LightGreen";
        }
    }
}