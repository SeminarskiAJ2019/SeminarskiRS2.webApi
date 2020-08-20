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

namespace SeminarskiRS2.WinUI.Drzave
{
    public partial class frmDrzaveTemp : Form
    {
        public DrzaveApiService drzaveApiService = new DrzaveApiService("DrzaveGet");
        public frmDrzaveTemp()
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
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                List<Model.Drzave> lista = await drzaveApiService.Get<List<Model.Drzave>>(new DrzaveSearchRequest() { Naziv = txtNaziv.Text });
                lista = lista.Where(s => s.Naziv.Equals(txtNaziv.Text)).ToList();
                if (lista.Count == 0)
                {
                    DrzaveInsertRequest req = new DrzaveInsertRequest() { Naziv = txtNaziv.Text };
                    try
                    {

                        await drzaveApiService.Insert<Model.Drzave>(req);
                        MessageBox.Show("Operacija uspjela!");
                        this.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Već postoji unesena država!");
                }
            }
            else
            {
                MessageBox.Show("Operacija nije uspjela!");
                this.Close();
            }
        }
    }
}
