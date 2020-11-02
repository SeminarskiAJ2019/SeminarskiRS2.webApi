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

namespace SeminarskiRS2.WinUI.Gradovi
{
    public partial class frmGradoviDetalji : Form
    {
        private readonly int? _id = null;
        private readonly APIService _apiService = new APIService("Gradovi");
        private readonly APIService _apiServiceDrzave = new APIService("Drzave");
        public frmGradoviDetalji(int? id=null)
        {
            _id = id;
            InitializeComponent();
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
        private async void frmGradoviDetalji_Load(object sender, EventArgs e)
        {
            await LoadDrzave();
            if (_id.HasValue)
            {
                var a = await _apiService.GetById<dynamic>(_id);
                txtNaziv.Text = a.naziv;
                cbDrzave.SelectedValue = int.Parse(a.drzavaID.ToString());
            };
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                List<Model.Grad> lista = await _apiService.Get<List<Model.Grad>>(new GradoviSearchRequest() { Naziv = txtNaziv.Text, DrzavaID = (int)cbDrzave.SelectedValue });
                if (lista.Count == 0 || (lista.Count == 1 && lista[0].GradID == _id))
                {

                    var req = new GradoviInsertRequest
                    {
                        Naziv = txtNaziv.Text,
                        DrzavaID = (int)cbDrzave.SelectedValue
                    };
                    if (_id.HasValue)
                    {
                        int i = (int)_id;
                        try
                        {
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
                    MessageBox.Show("Uneseni grad već postoji u unesenoj državi!");

                }
            }
            else
            {
                MessageBox.Show("Operacija nije uspjela! Morate unijeti sva polja. ");
            }
        }

        private void txtNaziv_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, "Polje naziv je obavezno. ");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtNaziv.Text, @"^[a-zA-Z -]+$"))
            {
                errorProvider1.SetError(txtNaziv, "Dozvoljeno je koristiti samo slova za naziv. ");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtNaziv, null);
        }

        private void cbDrzave_Validating_1(object sender, CancelEventArgs e)
        {
            if (cbDrzave.SelectedItem == null)
            {
                errorProvider1.SetError(cbDrzave, "Morate izabrati državu. ");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(cbDrzave, null);
        }
    }
}
