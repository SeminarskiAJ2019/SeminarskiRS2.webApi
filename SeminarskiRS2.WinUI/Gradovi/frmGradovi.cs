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

namespace SeminarskiRS2.WinUI.Gradovi
{
    public partial class frmGradovi : Form
    {
        private readonly APIService _apiService = new APIService("Gradovi");
        public frmGradovi()
        {
            InitializeComponent();
        }

        private async void btnPretrazi_Click(object sender, EventArgs e)
        {
            var search = new GradoviSearchRequest()
            {
                Naziv = txtPretraga.Text
            };

            var result = await _apiService.Get<dynamic>(search);
            dgvGradovi.AutoGenerateColumns = false;
            dgvGradovi.DataSource = result;
        }

        private void dgvGradovi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvGradovi.SelectedRows[0].Cells[0].Value;
            var frm = new frmGradoviDetalji(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
