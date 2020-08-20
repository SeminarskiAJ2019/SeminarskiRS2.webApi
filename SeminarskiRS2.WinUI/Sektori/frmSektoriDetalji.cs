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

namespace SeminarskiRS2.WinUI.Sektori
{
    public partial class frmSektoriDetalji : Form
    {
        private readonly APIService _apiServiceSektori = new APIService("Sektori");
        private readonly APIService _apiServiceTribine = new APIService("Tribine");
        private readonly int? _id = null;
        public frmSektoriDetalji(int? id=null)
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
        private async Task LoadTribine()
        {
            var result = await _apiServiceTribine.Get<List<Model.Tribine>>(null);
            cbTribine.DisplayMember = "Naziv";
            cbTribine.ValueMember = "TribinaID";
            cbTribine.SelectedItem = null;
            cbTribine.SelectedText = "--Odaberite--";
            cbTribine.DataSource = result;
        }
        private async void frmSektoriDetalji_Load(object sender, EventArgs e)
        {
            await LoadTribine();
            if (_id.HasValue)
            {
                Model.Sektori a = await _apiServiceSektori.GetById<Model.Sektori>(_id);
                txtNaziv.Text = a.Naziv;
                cbTribine.SelectedValue = int.Parse(a.TribinaID.ToString());
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                List<Model.Sektori> lista = await _apiServiceSektori.Get<List<Model.Sektori>>(new SektoriSearchRequest() { Naziv = txtNaziv.Text, TribinaID = int.Parse(cbTribine.SelectedValue.ToString()) });
                if (lista.Count == 0 || (lista.Count == 1 && lista[0].SektorID == _id))
                {
                    var req = new SektoriInsertRequest()
                    {
                        Naziv = txtNaziv.Text,
                        TribinaID = int.Parse(cbTribine.SelectedValue.ToString())
                    };
                    if (_id.HasValue)
                    {
                        int i = (int)_id;
                        try
                        {
                            await _apiServiceSektori.Update<dynamic>(i, req);
                            MessageBox.Show("Operacija uspjesna!");
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
                            await _apiServiceSektori.Insert<dynamic>(req);
                            MessageBox.Show("Operacija uspjesna!");
                            this.Close();
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Već postoji isti sektor za istu tribinu!");
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
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtNaziv.Text, @"^[a-zA-Z0-9 ]+$"))//brojevi i/ili slova
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtNaziv, null);
        }

        private void cbTribine_Validating_1(object sender, CancelEventArgs e)
        {
            if (cbTribine.SelectedItem == null)
            {
                errorProvider1.SetError(cbTribine, Properties.Resources.ObaveznoPolje);
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(cbTribine, null);
        }
    }
}
