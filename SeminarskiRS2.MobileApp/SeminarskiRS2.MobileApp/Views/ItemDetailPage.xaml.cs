using System.ComponentModel;
using Xamarin.Forms;
using SeminarskiRS2.MobileApp.ViewModels;
using SeminarskiRS2.MobileApp.Models;

namespace SeminarskiRS2.MobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }
        public ItemDetailPage()
        {
            InitializeComponent();
            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description. "
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}
