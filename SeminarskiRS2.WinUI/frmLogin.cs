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
    public partial class frmLogin : Form
    {
        APIService _apiService = new APIService("Korisnici");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIService.KorisnickoIme = txtUsername.Text;
            APIService.Lozinka = txtPassword.Text;
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "frmIndex")
                {
                    isOpen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (!isOpen)
            {
                try
                {
                    await _apiService.Get<dynamic>(null);
                    var frm = new frmIndex();
                    frm.Show();

                }
                catch (Exception)
                {
                    MessageBox.Show("Niste autentificirani", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            var frm = new frmRegistracija();
            frm.Show();
        }
    }
}
