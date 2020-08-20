using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SeminarskiRS2.MobileApp.Models;
using Xamarin.Forms;

namespace SeminarskiRS2.MobileApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
