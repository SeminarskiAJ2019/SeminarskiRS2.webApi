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

namespace SeminarskiRS2.WinUI.Sektori
{
    public partial class frmSektori : Form
    {
        private readonly APIService _apiServiceSektori = new APIService("Sektori");
        private readonly APIService _apiServiceTribine = new APIService("Tribine");
        public frmSektori()
        {
            InitializeComponent();
        }
        private async Task loadSveTribine()
        {
            var result = await _apiServiceTribine.Get<List<Model.Tribine>>(null);
            cbTribine.DisplayMember = "Naziv";
            cbTribine.ValueMember = "TribinaID";
            result.Insert(0, new Model.Tribine());
            cbTribine.DataSource = result;
            cbTribine.Text = "--Odaberite tribinu--";
        }
        private async Task LoadSektori(int id)
        {
            var result = await _apiServiceSektori.Get<List<Model.Sektori>>(new SektoriSearchRequest()
            {
                TribinaID = id
            });
            dgvSektori.AutoGenerateColumns = false;
            dgvSektori.DataSource = result;
        }
        private async void frmSektori_Load(object sender, EventArgs e)
        {
            await loadSveTribine();
        }

        private void dgvSektori_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //var id = dgvSektori.SelectedRows[0].Cells[0].Value;
            //var frm = new frmSektoriDetalji(int.Parse(id.ToString()));
            //frm.Show();
        }

        private async void cbTribine_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cbTribine.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadSektori(id);
            }
        }
    }
}
