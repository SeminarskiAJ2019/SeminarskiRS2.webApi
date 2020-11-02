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

namespace SeminarskiRS2.WinUI.Stadioni
{
    public partial class frmStadioni : Form
    {
        private readonly APIService _apiService = new APIService("Stadioni");
        private readonly APIService _apiServiceGradovi = new APIService("Gradovi");
        private readonly ImageService _imageService = new ImageService();
        public frmStadioni()
        {
            InitializeComponent();
        }
        private async Task LoadSviGradovi()
        {
            var result = await _apiServiceGradovi.Get<List<Model.Grad>>(null);
            cbGradovi.DisplayMember = "Naziv";
            cbGradovi.ValueMember = "GradID";
            result.Insert(0, new Model.Grad());
            cbGradovi.DataSource = result;
            cbGradovi.Text = "-Odaberite grad-";
        }
        private async Task LoadStadioni(int id)
        {
            var result = await _apiService.Get<List<Model.Stadioni>>(new StadioniSearchRequest()
            {
                GradID = id
            });
            dgvStadioni.AutoGenerateColumns = false;
            dgvStadioni.DataSource = result;
        }
        private void dgvStadioni_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvStadioni.SelectedRows[0].Cells[0].Value;
            var frm = new frmStadioniDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private async void frmStadioni_Load(object sender, EventArgs e)
        {
            await LoadSviGradovi();
        }

        private async void cbGradovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cbGradovi.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadStadioni(id);
            }
        }
    }
}
