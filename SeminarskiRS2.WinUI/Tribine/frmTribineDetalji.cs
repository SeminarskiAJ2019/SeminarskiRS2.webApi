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

namespace SeminarskiRS2.WinUI.Tribine
{
    public partial class frmTribineDetalji : Form
    {
        private readonly int? _id = null;
        private readonly APIService _apiService = new APIService("Tribine");
        private readonly APIService _apiServiceStadioni = new APIService("Stadioni");
        public frmTribineDetalji(int? id =null)
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
        private async Task LoadStadioni()
        {
            var result = await _apiServiceStadioni.Get<List<Model.Stadioni>>(null);
            cbStadioni.DisplayMember = "Naziv";
            cbStadioni.ValueMember = "StadionID";
            cbStadioni.SelectedItem = null;
            cbStadioni.SelectedText = "--Odaberite--";
            cbStadioni.DataSource = result;
        }
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                List<Model.Tribine> lista = await _apiService.Get<List<Model.Tribine>>(new TribineSearchRequest() { Naziv = txtNaziv.Text, StadionID = int.Parse(cbStadioni.SelectedValue.ToString()) });
                if (lista.Count == 0 || (lista.Count == 1 && lista[0].TribinaID == _id))
                {
                    var req = new TribineInsertRequest()
                    {
                        Naziv = txtNaziv.Text,
                        StadionID = int.Parse(cbStadioni.SelectedValue.ToString()),
                        Cijena = decimal.Parse(txtCijena.Text)
                    };

                    if (_id.HasValue)
                    {
                        try
                        {
                            int i = (int)_id;
                            await _apiService.Update<dynamic>(i, req);
                            MessageBox.Show("Operacija uspjela!");
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
                            MessageBox.Show("Operacija uspjela!");
                            this.Close();
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Unesena tribina za taj stadion već postoji!");
                }
            }
            else
            {
                MessageBox.Show("Operacija nije uspjela");
                this.Close();
            }
        }

        private async void frmTribineDetalji_Load(object sender, EventArgs e)
        {
            await LoadStadioni();
            if (_id.HasValue)
            {
                var a = await _apiService.GetById<dynamic>(_id);
                txtNaziv.Text = a.naziv;
                cbStadioni.SelectedValue = int.Parse(a.stadionID.ToString());
                txtCijena.Text = a.cijena.ToString();
            }
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.ObaveznoPolje);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtNaziv.Text, @"^[a-zA-Z0-9 -]+$"))//brojevi i/ili slova
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtNaziv, null);
        }

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCijena.Text))
            {
                errorProvider1.SetError(txtCijena, Properties.Resources.ObaveznoPolje);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtCijena.Text, @"^[0-9,]+$"))
            {
                errorProvider1.SetError(txtCijena, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtCijena, null);
        }

        private void cbStadioni_Validating(object sender, CancelEventArgs e)
        {
            if (cbStadioni.SelectedItem == null)
            {
                errorProvider1.SetError(cbStadioni, Properties.Resources.ObaveznoPolje);
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(cbStadioni, null);
        }
    }
}
