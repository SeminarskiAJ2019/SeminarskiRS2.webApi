using SeminarskiRS2.Model;
using SeminarskiRS2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SeminarskiRS2.MobileApp.ViewModels
{
    public class UtakmiceViewModel : BaseViewModel
    {
        private APIService _apiServiceUtakmice = new APIService("Utakmice");
        private APIService _apiServiceLige = new APIService("Lige");
        public UtakmiceViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Utakmice> UtakmiceList { get; set; } = new ObservableCollection<Utakmice>();
        public ObservableCollection<Lige> LigeList { get; set; } = new ObservableCollection<Lige>();
        Lige _selectedLiga = null;

        public Lige SelectedLiga
        {
            //u pickeru smo rekli: kada se promijeni item preko bindinga pozovi selectedliga property
            get { return _selectedLiga; }
            set
            {
                SetProperty(ref _selectedLiga, value); //kao value dobijemo odabrano i poziva se init komanda koja poziva init metodu
                if (value != null)
                    InitCommand.Execute(null); //ne moze init jer property ne podrzavaju async await pozive i iz toga razloga imamo i komandu
            }

        }



        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            if (LigeList.Count == 0)//u prvom slucaju odnosno kada nista nije odabrano...ako je nesto odabrano ovo preskacemo
            {
                var ligalist = await _apiServiceLige.Get<IEnumerable<Lige>>(null);
                foreach (var liga in ligalist)
                {
                    LigeList.Add(liga);
                }
            }
            if (SelectedLiga != null)//dolazimo ovdje kada korisnik odabere nesto u dropdown listi
            {
                UtakmiceSearchRequest searchRequest = new UtakmiceSearchRequest
                {
                    LigaID = SelectedLiga.LigaID//uzimamo id i saljemo na api
                };
                var list = await _apiServiceUtakmice.Get<IEnumerable<Utakmice>>(searchRequest);
                UtakmiceList.Clear();
                foreach (var utakmica in list)
                {
                    UtakmiceList.Add(utakmica);
                }
            }

        }
    }
}
