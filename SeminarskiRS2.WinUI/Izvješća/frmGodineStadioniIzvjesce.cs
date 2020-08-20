using SeminarskiRS2.Model;
using SeminarskiRS2.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeminarskiRS2.WinUI.Izvješća
{
    public partial class frmGodineStadioniIzvjesce : Form
    {
        public APIService _apiServiceStadioni = new APIService("Stadioni");
        public APIService _apiServiceUlaznice = new APIService("Ulaznica");
        public APIService _apiServiceUtakmice = new APIService("Utakmice");
        public APIService _apiServiceTribine = new APIService("Tribine");
        public APIService _apiServiceSektori = new APIService("Sektori");
        public frmGodineStadioniIzvjesce()
        {
            InitializeComponent();
        }
        private void LoadGodine()
        {
            var gZ = DateTime.Now.Year;
            var gP = 2010;
            for (int i = gP; i <= gZ; i++)
            {
                cbGodina.Items.Add(i);
            }
            cbGodina.Text = "--Odaberite godinu--";
        }
        private void frmGodineStadioniIzvjesce_Load(object sender, EventArgs e)
        {
            LoadGodine();
        }
        private async Task LoadIzvjesce(int idGodina)
        {
            var stadioni = await _apiServiceStadioni.Get<List<Model.Stadioni>>(null);
            List<Model.Stadioni> listaStadiona = new List<Model.Stadioni>();
            List<Model.Utakmice> listaUtakmica = new List<Model.Utakmice>();
            List<Model.IzvjesceGodine> lista = new List<Model.IzvjesceGodine>();
            foreach (var s in stadioni)
            {
                int brojUlaznica = 0;
                decimal UkupnaZarada = 0;
                var tribine = await _apiServiceTribine.Get<List<Model.Tribine>>(new TribineSearchRequest() { StadionID = s.StadionID });
                var utakmice = await _apiServiceUtakmice.Get<List<Model.Utakmice>>(new UtakmiceSearchRequest() { StadionID = s.StadionID, sveUtakmice = true });
                foreach (var ut in utakmice)
                {
                    var ulaznice = await _apiServiceUlaznice.Get<List<Model.Ulaznice>>(new UlazniceSearchRequest() { Godina = idGodina, UtakmicaID = ut.UtakmicaID });
                    foreach (var ul in ulaznice)
                    {
                        brojUlaznica++;
                        var sektori = await _apiServiceSektori.Get<List<Model.Sektori>>(new SektoriSearchRequest() { Naziv = ul.sektor });
                        foreach (var sek in sektori)
                        {
                            foreach (var t in tribine)
                            {
                                if (sek.TribinaID == t.TribinaID)
                                    UkupnaZarada += t.Cijena;
                            }
                        }
                    }
                }
                lista.Add(new IzvjesceGodine() { Stadion = s.Naziv, Grad = s.Grad, Zarada = UkupnaZarada, BrojProdanihUlaznica = brojUlaznica });
            }
            dgvIzvješće.AutoGenerateColumns = false;
            dgvIzvješće.DataSource = lista;


        }

        private async void cbGodina_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cbGodina.SelectedItem;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadIzvjesce(id);
            }
        }
    }
}
