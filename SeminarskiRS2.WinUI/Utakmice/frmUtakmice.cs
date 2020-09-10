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

namespace SeminarskiRS2.WinUI.Utakmice
{
    public partial class frmUtakmice : Form
    {
        private readonly APIService _apiService = new APIService("Utakmice");
        private readonly APIService _apiServiceLige = new APIService("Lige");
        public frmUtakmice()
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
            cbLiga.Text = "--Odaberite ligu--";
        }
        private async Task LoadUtakmice(int id)
        {
            var result = await _apiService.Get<List<Model.Utakmice>>(new UtakmiceSearchRequest()
            {
                LigaID = id,
                sveUtakmice = true
            });
            dgvUtakmice.AutoGenerateColumns = false;
            dgvUtakmice.DataSource = result;
        }
        private void dgvUtakmice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //var id = dgvUtakmice.SelectedRows[0].Cells[0].Value;
            //var frm = new frmUtakmiceDetalji(int.Parse(id.ToString()));
            //frm.Show();
        }

        private async void frmUtakmice_Load(object sender, EventArgs e)
        {
            await LoadSveLige();
        }

        private async void cbLiga_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cbLiga.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadUtakmice(id);
            }
        }
    }
}
