using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.WinUI.Gradovi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeminarskiRS2.WinUI
{
    public partial class frmRegistracija : Form
    {
        public GradoviApiService _apiServiceGradovi = new GradoviApiService("GradoviGet");
        public KorisniciApiService _apiServiceKorisnici = new KorisniciApiService("KorisniciInsert");
        public frmRegistracija()
        {
            InitializeComponent();
        }
        private const int WM_CLOSE = 0x0010;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CLOSE)
                AutoValidate = AutoValidate.Disable;
            base.WndProc(ref m);
        }
        private async Task LoadGradovi()
        {
            var result = await _apiServiceGradovi.Get<List<Model.Grad>>(null);
            comboBox1.DisplayMember = "Naziv";
            comboBox1.ValueMember = "GradID";
            comboBox1.SelectedItem = null;
            comboBox1.SelectedText = "--Odaberite--";
            comboBox1.DataSource = result;
        }
        private async void frmRegistracija_Load_1(object sender, EventArgs e)
        {
            await LoadGradovi();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmGradoviTemp();
            frm.Show();
            this.Close();
        }

        private async void btnRegistrirajSe_Click_1(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                List<Model.Korisnik> lista = await _apiServiceKorisnici.Get<List<Model.Korisnik>>(new KorisnikSearchRequest() { Ime = txtKorisnickoIme.Text });
                if (lista.Count == 0)
                {
                    var request = new KorisnikInsertRequest()
                    {
                        Ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        Email = txtEmail.Text,
                        DatumRodjenja = dateTimePicker1.Value.Date,
                        Telefon = txtTelefon.Text,
                        KorisnickoIme = txtKorisnickoIme.Text,
                        Lozinka = txtLozinka.Text,
                        PotvrdaLozinke = txtPotvrdaLozinke.Text,
                        GradID = (int)comboBox1.SelectedValue
                    };

                    try
                    {
                        await _apiServiceKorisnici.Insert<dynamic>(request);
                        MessageBox.Show("Operacija uspjesna!");
                        this.Close();
                    }
                    catch (Exception)
                    {
                    }

                }
                else
                {
                    MessageBox.Show("Zauzeto korisnicko ime!");
                }
            }
            else
            {
                MessageBox.Show("Operacija nije uspjela");
                this.Close();
            }
        }
    }
}

