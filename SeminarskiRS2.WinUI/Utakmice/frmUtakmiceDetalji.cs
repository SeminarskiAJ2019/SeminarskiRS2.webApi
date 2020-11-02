using SeminarskiRS2.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeminarskiRS2.WinUI.Utakmice
{
    public partial class frmUtakmiceDetalji : Form
    {
        private readonly int? _id = null;
        private readonly APIService _apiService = new APIService("Utakmice");
        private readonly APIService _apiServiceStadioni = new APIService("Stadioni");
        private readonly APIService _apiServiceTimovi = new APIService("Timovi");
        private readonly APIService _apiServiceLige = new APIService("Lige");
        private readonly ImageService _imageService = new ImageService();
        public frmUtakmiceDetalji(int? id=null)
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
            cbStadion.DisplayMember = "Naziv";
            cbStadion.ValueMember = "StadionID";
            cbStadion.SelectedItem = null;
            cbStadion.SelectedText = "--Odaberite--";
            cbStadion.DataSource = result;
        }
        private async Task LoadLige()
        {
            var result = await _apiServiceLige.Get<List<Model.Lige>>(null);
            cbLiga.DisplayMember = "Naziv";
            cbLiga.ValueMember = "LigaID";
            cbLiga.SelectedItem = null;
            cbLiga.SelectedText = "--Odaberite--";
            cbLiga.DataSource = result;
        }
        private async Task LoadDomaci()
        {
            var result = await _apiServiceTimovi.Get<List<Model.Timovi>>(null);
            cbDomaci.DisplayMember = "Naziv";
            cbDomaci.ValueMember = "TimID";
            cbDomaci.SelectedItem = null;
            cbDomaci.SelectedText = "--Odaberite--";
            cbDomaci.DataSource = result;

        }
        private async Task LoadGosti()
        {
            var result = await _apiServiceTimovi.Get<List<Model.Timovi>>(null);

            cbGosti.DisplayMember = "Naziv";
            cbGosti.ValueMember = "TimID";
            cbGosti.SelectedItem = null;
            cbGosti.SelectedText = "--Odaberite--";
            cbGosti.DataSource = result;
        }
        private async void frmUtakmiceDetalji_Load(object sender, EventArgs e)
        {
            await LoadDomaci();
            await LoadGosti();
            await LoadStadioni();
            await LoadLige();

            if (_id.HasValue)
            {
                Model.Utakmice a = await _apiService.GetById<Model.Utakmice>(_id);
                cbDomaci.SelectedValue = int.Parse(a.DomaciTimID.ToString());
                cbGosti.SelectedValue = int.Parse(a.GostujuciTimID.ToString());
                dtpDatum.Value = a.DatumOdigravanja;
                dtpVrijeme.Value = a.VrijemeOdigravanja;
                cbStadion.SelectedValue = int.Parse(a.StadionID.ToString());
                cbLiga.SelectedValue = int.Parse(a.LigaID.ToString());


                if (a.Slika.Length != 0)
                {
                    var img = _imageService.BytesToImage(a.Slika);
                    Image mythumb = _imageService.ImageToThumbnail(img);
                    pictureBox1.Image = mythumb;
                }
                else
                {
                    var noimg = _imageService.GetNoImage();
                    var th = _imageService.ImageToThumbnail(noimg);
                    pictureBox1.Image = th;
                }

            }
        }
        UtakmiceInsertRequest req = new UtakmiceInsertRequest();
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren() && int.Parse(cbDomaci.SelectedValue.ToString()) != int.Parse(cbGosti.SelectedValue.ToString()))
            {


                //radi nemogucnosti nacina da na razini baze ogranicimo unos zamjene timova(gosti/domaci) a istog datuma
                var stadionid = int.Parse(cbStadion.SelectedValue.ToString());
                ; var t = await _apiService.Get<List<Model.Utakmice>>(null);
                var utakmiceSaIstimStadionom = await _apiService.Get<List<Model.Utakmice>>(new UtakmiceSearchRequest() { StadionID = stadionid });
                var domaciid = int.Parse(cbDomaci.SelectedValue.ToString());
                var gostiid = int.Parse(cbGosti.SelectedValue.ToString());
                var obrnutiisti = false;
                var isti = false;
                var postojecaUtakmica = false;
                if (utakmiceSaIstimStadionom.Count != 0)
                {
                    foreach (var u in utakmiceSaIstimStadionom)
                    {
                        if (u.UtakmicaID == _id)
                            postojecaUtakmica = true;
                    }
                }


                foreach (var a in t)
                {
                    if ((a.GostujuciTimID == domaciid || a.DomaciTimID == gostiid) && DateTime.Compare(a.DatumOdigravanja.Date, dtpDatum.Value.Date) == 0 && a.UtakmicaID != _id)
                    {
                        obrnutiisti = true;
                        break;
                    }

                }
                foreach (var a in t)
                {
                    if ((a.GostujuciTimID == gostiid || a.DomaciTimID == domaciid) && DateTime.Compare(a.DatumOdigravanja.Date, dtpDatum.Value.Date) == 0 && a.UtakmicaID != _id)
                    {
                        isti = true;
                        break;
                    }

                }

                if (!obrnutiisti && !isti && !postojecaUtakmica)
                {

                    req.DatumOdigravanja = dtpDatum.Value.Date + dtpVrijeme.Value.TimeOfDay;
                    req.VrijemeOdigravanja = dtpDatum.Value.Date + dtpVrijeme.Value.TimeOfDay;
                    req.DomaciTimID = int.Parse(cbDomaci.SelectedValue.ToString());
                    req.GostujuciTimID = int.Parse(cbGosti.SelectedValue.ToString());
                    req.StadionID = int.Parse(cbStadion.SelectedValue.ToString());
                    req.LigaID = int.Parse(cbLiga.SelectedValue.ToString());


                    if (req.Slika == null && _id.HasValue)
                    {
                        Model.Utakmice a = await _apiService.GetById<Model.Utakmice>(_id);
                        req.Slika = a.Slika;
                        req.SlikaThumb = a.SlikaThumb;
                    }

                    //za slucaj da korisnik ne unese sliku
                    if (req.Slika == null && !_id.HasValue)
                    {
                        var img = _imageService.GetNoImage();
                        req.Slika = _imageService.ImageToBytes(img);
                        var th = _imageService.ImageToThumbnail(img);
                        req.SlikaThumb = _imageService.ImageToBytes(th);
                    }
                    if (_id.HasValue)
                    {
                        int i = (int)_id;
                        try
                        {
                            await _apiService.Update<dynamic>(i, req);
                            MessageBox.Show("Operacija uspjela");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Operacija nije uspjela");
                        }
                    }
                    else
                    {
                        try
                        {
                            await _apiService.Insert<dynamic>(req);
                            MessageBox.Show("Operacija uspjela");

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Operacija nije uspjela");
                        }

                    }
                    this.Close();
                }
                else
                {
                    if (obrnutiisti)
                        MessageBox.Show("Operacija nije uspjela, postoji utakmica sa istim timovima u bazi na isti datum. ");
                    else if (isti)
                        MessageBox.Show("Operacija nije uspjela, postoji utakmica sa istim timovima u bazi na isti datum. ");
                    else if(postojecaUtakmica && _id.HasValue)
                    {
                        req.DatumOdigravanja = dtpDatum.Value.Date + dtpVrijeme.Value.TimeOfDay;
                        req.VrijemeOdigravanja = dtpDatum.Value.Date + dtpVrijeme.Value.TimeOfDay;
                        req.DomaciTimID = int.Parse(cbDomaci.SelectedValue.ToString());
                        req.GostujuciTimID = int.Parse(cbGosti.SelectedValue.ToString());
                        req.StadionID = int.Parse(cbStadion.SelectedValue.ToString());
                        req.LigaID = int.Parse(cbLiga.SelectedValue.ToString());
                        if (req.Slika == null && _id.HasValue)
                        {
                            Model.Utakmice a = await _apiService.GetById<Model.Utakmice>(_id);
                            req.Slika = a.Slika;
                            req.SlikaThumb = a.SlikaThumb;
                        }

                        //za slucaj da korisnik ne unese sliku
                       

                        int i = (int)_id;
                        try
                        {
                            await _apiService.Update<dynamic>(i, req);
                            MessageBox.Show("Operacija uspjela");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Operacija nije uspjela. ");
                        }
                    }
                    else if (postojecaUtakmica)
                        MessageBox.Show("Operacija nije uspjela, postoji ista utakmica u bazi. ");
                    this.Close();
                }


            }
            else
            {
                if (int.Parse(cbDomaci.SelectedValue.ToString()) == int.Parse(cbGosti.SelectedValue.ToString()))
                    MessageBox.Show("Operacije nije uspjela, ne možete izabrati isti domaći i gostujući tim. ");
                else
                {
                    MessageBox.Show("Operacija nije uspjela. Morate unijeti sva polja.");
                }
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                req.Slika = file;
                Image image = Image.FromFile(fileName);

                Image mythumb = _imageService.ImageToThumbnail(image);
                req.SlikaThumb = _imageService.ImageToBytes(mythumb);
                pictureBox1.Image = mythumb;

            }
        }

        private void cbDomaci_Validating(object sender, CancelEventArgs e)
        {
            if (cbDomaci.SelectedItem == null && int.Parse(cbDomaci.SelectedValue.ToString()) != int.Parse(cbGosti.SelectedValue.ToString()))
            {
                errorProvider1.SetError(cbDomaci, "Morate odabrati domaći tim. ");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(cbDomaci, null);
        }

        private void cbGosti_Validating(object sender, CancelEventArgs e)
        {
            if (cbGosti.SelectedItem == null)
            {
                errorProvider1.SetError(cbGosti, "Morate odabrati gostujući tim. ");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(cbGosti, null);
        }

        private void dtpDatum_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(dtpDatum.Value.Date.ToString()))
            {
                errorProvider1.SetError(dtpDatum, "Morate odabrati datum. ");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(dtpDatum, null);
        }

        private void dtpVrijeme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(dtpVrijeme.Value.TimeOfDay.ToString()))
            {
                errorProvider1.SetError(dtpVrijeme, "Morate odabrati vrijeme. ");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(dtpVrijeme, null);
        }

        private void cbLiga_Validating(object sender, CancelEventArgs e)
        {
            if (cbLiga.SelectedItem == null)
            {
                errorProvider1.SetError(cbLiga, "Morate odabrati ligu. ");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(cbLiga, null);
        }

        private void cbStadion_Validating(object sender, CancelEventArgs e)
        {
            if (cbStadion.SelectedItem == null)
            {
                errorProvider1.SetError(cbStadion, "Morate odabrati stadion. ");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(cbStadion, null);
        }
    }
}
