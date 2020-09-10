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

namespace SeminarskiRS2.WinUI.Lige
{
    public partial class frmLige : Form
    {
        private readonly APIService _apiService = new APIService("Lige");
        private readonly APIService _apiServiceDrzave = new APIService("Drzave");
        public frmLige()
        {
            InitializeComponent();
        }
        private async Task LoadSveDrzave()
        {
            var result = await _apiServiceDrzave.Get<List<Model.Drzave>>(null);
            cbDrzave.DisplayMember = "Naziv";
            cbDrzave.ValueMember = "DrzavaID";
            result.Insert(0, new Model.Drzave());
            cbDrzave.DataSource = result;
            cbDrzave.Text = "--Odaberite državu--";
        }
        private async Task LoadLige(int id)
        {
            var result = await _apiService.Get<List<Model.Lige>>(new LigaSearchRequest()
            {
                DrzavaID = id
            });
            dgvLige.AutoGenerateColumns = false;
            dgvLige.DataSource = result;
        }

        private async void frmLige_Load(object sender, EventArgs e)
        {
            await LoadSveDrzave();
        }

        private void dgvLige_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //var id = dgvLige.SelectedRows[0].Cells[0].Value;
            //var frm = new frmLigeDetalji(int.Parse(id.ToString()));
            //frm.Show();
        }

        private async void cbDrzave_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cbDrzave.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadLige(id);
            }
        }
    }
}
