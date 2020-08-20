using SeminarskiRS2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SeminarskiRS2.MobileApp.ViewModels
{
    public class SektoriViewModel : BaseViewModel
    {
        private APIService _apiServiceSektori = new APIService("Sektori");
        private APIService _apiServiceTribine = new APIService("Tribine");

        public SektoriViewModel()
        {
            InitCommand = new Command(async () => await Init());

        }
        public ObservableCollection<Sektori> SektoriList { get; set; } = new ObservableCollection<Sektori>();
        public Utakmice Utakmica { get; set; }
        public int StadionID { get; set; }
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            IsBusy = true;
            List<Tribine> listTribina = await _apiServiceTribine.Get<List<Tribine>>(null);
            List<int> listazahtjev = new List<int>();
            foreach (var tribina in listTribina)
            {
                if (tribina.StadionID == StadionID)
                    listazahtjev.Add(tribina.TribinaID);
            }

            var list = await _apiServiceSektori.Get<IEnumerable<Sektori>>(null);
            SektoriList.Clear();
            foreach (var sektor in list)
            {
                if (listazahtjev.Contains(sektor.TribinaID))
                    SektoriList.Add(sektor);
            }

        }


    }
}
