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
    public class MojeUlazniceVM : BaseViewModel
    {
        private APIService _apiServiceUlaznice = new APIService("Ulaznica");
        private APIService _apiServiceKorisnici = new APIService("Korisnici");
        private APIService _apiServiceUtakmice = new APIService("Utakmice");

        public MojeUlazniceVM()
        {
            InitCommand = new Command(async () => await Init());
        }

        public Korisnik korisnik { get; set; }
        public ObservableCollection<Ulaznice> UlazniceList { get; set; } = new ObservableCollection<Ulaznice>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var korisnicko = APIService.KorisnickoIme;
            List<Korisnik> listKorisnici = await _apiServiceKorisnici.Get<List<Korisnik>>(null);
            foreach (var k in listKorisnici)
            {
                if (k.KorisnickoIme == korisnicko)
                {
                    korisnik = k;
                    break;
                }
            }
            var list = await _apiServiceUlaznice.Get<IEnumerable<Ulaznice>>(new UlazniceSearchRequest() { KorisnikID = korisnik.KorisnikID });
            UlazniceList.Clear();
            foreach (var ulaznica in list)
            {
                Utakmice u = await _apiServiceUtakmice.GetById<Utakmice>(ulaznica.UtakmicaID);
                if (u.DatumOdigravanja < DateTime.Now)
                    ulaznica.color = "LightGray";
                else
                    ulaznica.color = "LightGreen";
                UlazniceList.Add(ulaznica);

            }
        }

    }
}
