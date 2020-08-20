using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.WinUI.Drzave;
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
    public partial class frmGradoviTemp : Form
    {
        public DrzaveApiService _apiServiceDrzave = new DrzaveApiService("DrzaveGet");
        public GradoviApiService _apiServiceGradovi = new GradoviApiService("GradoviGet");
        public frmGradoviTemp()
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
        private async Task LoadDrzave()
        {
            var result = await _apiServiceDrzave.Get<List<Model.Grad>>(null);
            comboBox1.DisplayMember = "Naziv";
            comboBox1.ValueMember = "DrzavaID";
            comboBox1.SelectedItem = null;
            comboBox1.SelectedText = "--Odaberite--";
            comboBox1.DataSource = result;
        }
        private async void frmGradoviTemp_Load(object sender, EventArgs e)
        {
            await LoadDrzave();
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                List<Model.Grad> lista = await _apiServiceGradovi.Get<List<Model.Grad>>(new GradoviSearchRequest() { Naziv = txtNaziv.Text, DrzavaID = int.Parse(comboBox1.SelectedValue.ToString()) });
                if (lista.Count == 0)
                {
                    GradoviInsertRequest req = new GradoviInsertRequest()
                    {
                        DrzavaID = int.Parse(comboBox1.SelectedValue.ToString()),
                        Naziv = txtNaziv.Text
                    };

                    try
                    {
                        await _apiServiceGradovi.Insert<Model.Grad>(req);
                        MessageBox.Show("Operacija uspjela!");
                        this.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Već postoji uneseni grad u unesenoj državi");
                }
            }
            else
            {
                MessageBox.Show("Operacija nije uspjela.");
                this.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmDrzaveTemp();
            frm.Show();
            this.Close();
        }
    }
}
