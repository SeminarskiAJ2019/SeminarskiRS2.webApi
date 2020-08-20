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
    public partial class TimDetailPage : ContentPage
    {
        private TimDetailVM timDetailVM = null;
        public TimDetailPage(Timovi tim)
        {
            InitializeComponent();
            BindingContext = timDetailVM = new TimDetailVM
            {
                Tim = tim
            };

        }
    }
}