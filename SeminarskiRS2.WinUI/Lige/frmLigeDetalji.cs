using SeminarskiRS2.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeminarskiRS2.WinUI.Lige
{
    public partial class frmLigeDetalji : Form
    {
        private readonly int? _id = null;
        private readonly APIService _apiService = new APIService("Lige");

        private readonly APIService _apiServiceDrzave = new APIService("Drzave");
        public frmLigeDetalji(int? id=null)
        {
            InitializeComponent();
            _id = id;
        }
        private const int WM_CLOSE = 0x0010;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CLOSE)
                AutoValidate = AutoValidate.Disable;
            base.WndProc(ref m);
        }
        private async Task LoadDrzave()
        {
            var result = await _apiServiceDrzave.Get<List<Model.Drzave>>(null);
            cbDrzave.DisplayMember = "Naziv";
            cbDrzave.ValueMember = "DrzavaID";
            cbDrzave.SelectedItem = null;
            cbDrzave.SelectedText = "--Odaberite--";
            cbDrzave.DataSource = result;
        }
        private async void frmLigeDetalji_Load(object sender, EventArgs e)
        {
            await LoadDrzave();
            if (_id.HasValue)
            {
                var a = await _apiService.GetById<dynamic>(_id);
                txtNaziv.Text = a.naziv;
                cbDrzave.SelectedValue = int.Parse(a.drzavaID.ToString());
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                List<Model.Lige> lista = await _apiService.Get<List<Model.Lige>>(new LigaSearchRequest() { Naziv = txtNaziv.Text, DrzavaID = int.Parse(cbDrzave.SelectedValue.ToString()) });
                if (lista.Count == 0 || (lista.Count == 1 && lista[0].LigaID == _id))
                {
                    var req = new LigaInsertRequest()
                    {
                        Naziv = txtNaziv.Text,
                        DrzavaID = int.Parse(cbDrzave.SelectedValue.ToString())
                    };
                    if (_id.HasValue)
                    {
                        int i = (int)_id;
                        try
                        {
                            await _apiService.Update<dynamic>(i, req);
                            MessageBox.Show("Operacija uspjela");
                            this.Close();
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else
                    {
                        try
                        {
                            await _apiService.Insert<dynamic>(req);
                            MessageBox.Show("Operacija uspjela");
                            this.Close();
                        }
                        catch (Exception)
                        {
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Unesena liga već postoji!");
                }
            }
            else
            {
                MessageBox.Show("Operacija nije uspjela!");
                this.Close();
            }
        }

        private void txtNaziv_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.ObaveznoPolje);
            }
            else if (!Regex.IsMatch(txtNaziv.Text, @"^[a-zA-Z0-9 .]+$"))//brojevi i/ili slova
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtNaziv, null);
        }

        private void cbDrzave_Validating_1(object sender, CancelEventArgs e)
        {
            if (cbDrzave.SelectedItem == null)
            {
                errorProvider1.SetError(cbDrzave, Properties.Resources.ObaveznoPolje);
            }
            else
                errorProvider1.SetError(cbDrzave, null);
        }
    }
}
