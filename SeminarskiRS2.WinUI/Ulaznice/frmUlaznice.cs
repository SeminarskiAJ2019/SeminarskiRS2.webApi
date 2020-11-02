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

namespace SeminarskiRS2.WinUI.Ulaznice
{
    public partial class frmUlaznice : Form
    {
        private readonly APIService _apiService = new APIService("Ulaznica");
        private readonly APIService _apiServiceKorisnici = new APIService("Korisnici");
        public frmUlaznice()
        {
            InitializeComponent();
        }
        private async Task LoadUlaznice(int id)
        {
            var result = await _apiService.Get<List<Model.Ulaznice>>(new UlazniceSearchRequest()
            {
                KorisnikID = id
            });
            dgvUlaznice.AutoGenerateColumns = false;
            dgvUlaznice.DataSource = result;
        }
        private async Task LoadSviKorisnici()
        {
            var result = await _apiServiceKorisnici.Get<List<Model.Korisnik>>(null);
            cbKorisniciPretraga.DisplayMember = "KorisnikPodaci";
            cbKorisniciPretraga.ValueMember = "KorisnikID";
            result.Insert(0, new Model.Korisnik());
            cbKorisniciPretraga.DataSource = result;
            cbKorisniciPretraga.Text = "--Odaberite korisnika--";
        }
        private void dgvUlaznice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvUlaznice.SelectedRows[0].Cells[0].Value;
            frmUlazniceDetalji frm = new frmUlazniceDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private async void cbKorisniciPretraga_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cbKorisniciPretraga.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadUlaznice(id);
            }
        }

        private async void frmUlaznice_Load(object sender, EventArgs e)
        {
            await LoadSviKorisnici();
        }
    }
}
