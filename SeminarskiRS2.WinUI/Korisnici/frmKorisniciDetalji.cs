using SeminarskiRS2.Model;
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

namespace SeminarskiRS2.WinUI.Korisnici
{
    public partial class frmKorisniciDetalji : Form
    {
        private readonly APIService _apiService = new APIService("Korisnici");
        private readonly APIService _apiServiceGradovi = new APIService("Gradovi");
        private int? _id = null;
        public frmKorisniciDetalji(int? KorisnikID = null)
        {
            _id = KorisnikID;
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
            comboBox.DisplayMember = "Naziv";
            comboBox.ValueMember = "GradID";
            comboBox.SelectedItem = null;
            comboBox.SelectedText = "--Odaberite--";
            comboBox.DataSource = result;
        }
        private async void FrmKorisniciDetalji_Load(object sender, EventArgs e)
        {
            await LoadGradovi();
            if (_id != null)
            {
                var korisnik = await _apiService.GetById<dynamic>(_id);
                txtIme.Text = korisnik.ime;
                txtPrezime.Text = korisnik.prezime;
                dpdatumRodjenja.Value = (DateTime)korisnik.datumRodjenja;
                txtEmail.Text = korisnik.email;
                txtKorisnickoIme.Text = korisnik.korisnickoIme;
                txtTelefon.Text = korisnik.telefon;
                comboBox.SelectedValue = int.Parse(korisnik.gradID.ToString());

            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {


                var request = new KorisnikInsertRequest
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Email = txtEmail.Text,
                    DatumRodjenja = dpdatumRodjenja.Value.Date,
                    Telefon = txtTelefon.Text,
                    KorisnickoIme = txtKorisnickoIme.Text,
                    Lozinka = txtLozinka.Text,
                    PotvrdaLozinke = txtPotvrdaLozinke.Text,
                    GradID = (int)comboBox.SelectedValue
                };

                Model.Korisnik entity = null;
                if (!_id.HasValue)
                {
                    entity = await _apiService.Insert<Model.Korisnik>(request);
                }
                else
                {
                    entity = await _apiService.Update<Model.Korisnik>(_id.Value, request);
                }

                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Operacija nije uspjela! Morate unijeti sva polja. ");
            }

        }

        private void txtIme_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIme.Text))
            {
                errorProvider1.SetError(txtIme, "Polje ime je obavezno. ");
                e.Cancel = true;//zaustaviti procesiranje forme
            }
            else if (!Regex.IsMatch(txtIme.Text, @"^[a-zA-Z ]+$"))
            {
                errorProvider1.SetError(txtIme, "Dozvoljeno je koristiti samo slova za ime. ");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrezime.Text))
            {
                errorProvider1.SetError(txtPrezime, "Polje prezime je obavezno. ");
                e.Cancel = true;//zaustaviti procesiranje forme
            }
            else if (!Regex.IsMatch(txtPrezime.Text, @"^[a-zA-Z -]+$"))
            {
                errorProvider1.SetError(txtPrezime, "Dozvoljeno je koristiti samo slova za prezime. ");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPrezime, null);
            }
        }

        private void txtTelefon_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTelefon.Text))
            {
                errorProvider1.SetError(txtTelefon, "Polje telefon je obavezno. ");
                e.Cancel = true;//zaustaviti procesiranje forme
            }
            else if (!Regex.IsMatch(txtTelefon.Text, @"^[+]{1}\d{3}[ ]?\d{2}[ ]?\d{3}[ ]?\d{3}"))
            {
                errorProvider1.SetError(txtTelefon, "Format telefona je: +123 45 678 910");
                e.Cancel = true;//zaustaviti procesiranje forme
            }
            else
            {
                errorProvider1.SetError(txtTelefon, null);
            }
        }

        private void comboBox_Validating_1(object sender, CancelEventArgs e)
        {
            if (comboBox.SelectedItem == null)
            {
                errorProvider1.SetError(comboBox, "Morate izabrati grad. ");
                e.Cancel = true;//zaustaviti procesiranje forme
            }
            else
            {
                errorProvider1.SetError(comboBox, null);
            }
        }

        private void txtEmail_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Polje e-mail je obavezno. ");
                e.Cancel = true;//zaustaviti procesiranje forme
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"))
            {
                errorProvider1.SetError(txtEmail, "E-mail mora biti u formatu : text@nekastranica.com");
                e.Cancel = true;//zaustaviti procesiranje forme
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtKorisnickoIme_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtKorisnickoIme.Text) || txtKorisnickoIme.Text.Length < 4)
            {
                errorProvider1.SetError(txtKorisnickoIme, "Polje korisničko ime je obavezno i mora imati barem 4 znaka. ");
                e.Cancel = true;//zaustaviti procesiranje forme
            }

            else if (!Regex.IsMatch(txtKorisnickoIme.Text, @"^(?=.{4,40}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$"))
            {

                errorProvider1.SetError(txtKorisnickoIme, "Neispravan format ili dužina korisničkog imena (4-40)");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtKorisnickoIme, null);
            }
        }

        private void txtLozinka_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLozinka.Text))
            {
                errorProvider1.SetError(txtLozinka, "Polje lozinka je obavezno. ");
                e.Cancel = true;//zaustaviti procesiranje forme
            }
            else if (txtLozinka.Text.Length < 4)
            {

                errorProvider1.SetError(txtLozinka, "Lozinka mora sadrzavati minimalno 4 znaka.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtLozinka, null);
            }
        }

        private void txtPotvrdaLozinke_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPotvrdaLozinke.Text))
            {
                errorProvider1.SetError(txtPotvrdaLozinke, "Polje potvrda lozinke je obavezno. ");
                e.Cancel = true;//zaustaviti procesiranje forme
            }
            else if (txtPotvrdaLozinke.Text != txtLozinka.Text)
            {
                errorProvider1.SetError(txtPotvrdaLozinke, "Lozinke se ne poklapaju!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPotvrdaLozinke, null);
            }
        }
    }
}
