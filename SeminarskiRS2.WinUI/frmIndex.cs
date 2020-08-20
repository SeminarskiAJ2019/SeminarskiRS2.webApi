using SeminarskiRS2.WinUI.Drzave;
using SeminarskiRS2.WinUI.Gradovi;
using SeminarskiRS2.WinUI.Izvješća;
using SeminarskiRS2.WinUI.Korisnici;
using SeminarskiRS2.WinUI.Lige;
using SeminarskiRS2.WinUI.Sektori;
using SeminarskiRS2.WinUI.Sjedala;
using SeminarskiRS2.WinUI.Stadioni;
using SeminarskiRS2.WinUI.Timovi;
using SeminarskiRS2.WinUI.Tribine;
using SeminarskiRS2.WinUI.Ulaznice;
using SeminarskiRS2.WinUI.Uplate;
using SeminarskiRS2.WinUI.Utakmice;
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
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;
        public frmIndex()
        {
            InitializeComponent();
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisnici frm = new frmKorisnici();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviKorisnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmKorisniciDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDrzave frm = new frmDrzave();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void novaDržavaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrzaveDetalji frm = new frmDrzaveDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var frm = new frmGradovi();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviGradToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmGradoviDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var frm = new frmSjedala();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void novoSjedaloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmSjedalaDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var frm = new frmStadioni();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviStadionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmStadioniDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            var frm = new frmTimovi();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviTimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmTimoviDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            var frm = new frmTribine();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void novaTribinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmTribineDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var frm = new frmUlaznice();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void novaUlaznicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmUlazniceDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            var frm = new frmUtakmice();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void novaUtakmicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmUtakmiceDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            var frm = new frmLige();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void novaLigaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmLigeDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            var frm = new frmSektori();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviSektorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmSektoriDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            var frm = new frmUplate();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void godišnjeIzvješćeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmGodineStadioniIzvjesce();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
