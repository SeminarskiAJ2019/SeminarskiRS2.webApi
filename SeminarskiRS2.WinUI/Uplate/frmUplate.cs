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

namespace SeminarskiRS2.WinUI.Uplate
{
    public partial class frmUplate : Form
    {
        private readonly APIService _apiService = new APIService("Uplate");
        private readonly APIService _apiServiceUtakmice = new APIService("Utakmice");
        public frmUplate()
        {
            InitializeComponent();
        }
        private async Task LoadSveUtakmice()
        {
            List<Model.Utakmice> result = await _apiServiceUtakmice.Get<List<Model.Utakmice>>(new UtakmiceSearchRequest() { sveUtakmice = true });
            cbUtakmice.DisplayMember = "UtakmicaPodaci";
            cbUtakmice.ValueMember = "UtakmicaID";
            cbUtakmice.DataSource = result;
            cbUtakmice.SelectedItem = null;
            cbUtakmice.Text = "--Odaberite utakmicu--";
        }
        private async Task LoadUplate(int id)
        {
            var result = await _apiService.Get<List<Model.Uplate>>(new UplateSearchRequest()
            {
                UtakmicaID = id
            });
            dgvUplate.AutoGenerateColumns = false;
            dgvUplate.DataSource = result;
        }
        private async void frmUplate_Load(object sender, EventArgs e)
        {
            await LoadSveUtakmice();
        }

        private async void cbUtakmice_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var idObj = cbUtakmice.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadUplate(id);
            }
        }
    }
}
