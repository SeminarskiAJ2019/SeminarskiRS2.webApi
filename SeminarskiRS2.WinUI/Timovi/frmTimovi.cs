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

namespace SeminarskiRS2.WinUI.Timovi
{

    public partial class frmTimovi : Form
    {
        private readonly APIService _apiService = new APIService("Timovi");
        private readonly APIService _apiServiceLige = new APIService("Lige");
        private readonly ImageService _imageService = new ImageService();
        public frmTimovi()
        {
            InitializeComponent();
        }
        private async Task LoadSveLige()
        {
            var result = await _apiServiceLige.Get<List<Model.Lige>>(null);
            cbLiga.DisplayMember = "Naziv";
            cbLiga.ValueMember = "LigaID";
            result.Insert(0, new Model.Lige());
            cbLiga.DataSource = result;
            cbLiga.Text = "-Odaberite Ligu-";
        }
        private async Task LoadTimovi(int id)
        {
            var result = await _apiService.Get<List<Model.Timovi>>(new TimoviSearchRequest()
            {
                LigaID = id
            });
            dgvTimovi.AutoGenerateColumns = false;
            dgvTimovi.DataSource = result;
        }
        private void dgvTimovi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //var id = dgvTimovi.SelectedRows[0].Cells[0].Value;
           // var frm = new frmTimoviDetalji(int.Parse(id.ToString()));
            //frm.Show();
        }

        private async void cbLiga_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cbLiga.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadTimovi(id);
            }
        }

        private async void frmTimovi_Load(object sender, EventArgs e)
        {
            await LoadSveLige();
        }
    }
}
