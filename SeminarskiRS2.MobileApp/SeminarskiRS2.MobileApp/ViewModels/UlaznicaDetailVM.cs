using QRCoder;
using SeminarskiRS2.Model;
using SeminarskiRS2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SeminarskiRS2.MobileApp.ViewModels
{
    public class UlaznicaDetailVM : BaseViewModel
    {
        public string Oznaka { get; set; }
        public Sjedala Sjedalo { get; set; }
        public Utakmice Utakmica { get; set; }
        public string UtakmicaPodaci { get; set; }
        public Sektori Sektor { get; set; }
        public string SektorPodaci { get; set; }
        public Korisnik Korisnik { get; set; }
        public string KorisnikPodaci { get; set; }
        public decimal Iznos { get; set; }
        
        public DateTime DatumKupnje { get; set; }
       
        public DateTime VrijemeKupnje { get; set; }
        public string Datum { get { return DatumKupnje.ToShortDateString(); } }
        public string Vrijeme { get { return DatumKupnje.ToShortTimeString(); } }
        private readonly APIService _apiServiceSjedala = new APIService("Sjedala");
        private readonly APIService _apiServiceKorisnici = new APIService("Korisnici");
        private readonly APIService _apiServiceUlaznice = new APIService("Ulaznica");
        private readonly APIService _apiServicePreporuke = new APIService("Preporuke");
        private readonly APIService _apiServiceUtakmica = new APIService("Utakmice");
        private readonly APIService _apiServiceUplate = new APIService("Uplate");

        public Ulaznice Ulaznica { get; set; }
        public UlaznicaDetailVM()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            IsBusy = true;
            List<Sjedala> list = await _apiServiceSjedala.Get<List<Sjedala>>(new SjedalaSearchRequest() { Oznaka = Oznaka, SektorID = Sektor.SektorID });
            Sjedalo = list[0];
            Korisnik k = await _apiServiceKorisnici.GetById<Korisnik>(Korisnik.KorisnikID);
            UlazniceInsertRequest req = new UlazniceInsertRequest()
            {
                DatumKupnje = DatumKupnje,
                VrijemeKupnje = VrijemeKupnje,
                KorisnikID = Korisnik.KorisnikID,
                SjedaloID = Sjedalo.SjedaloID,
                UtakmicaID = Utakmica.UtakmicaID
            };
            Sjedala s1 = await _apiServiceSjedala.GetById<Sjedala>(req.SjedaloID);
            s1.Status = true;
            SjedalaInsertRequest req2 = new SjedalaInsertRequest()
            {
                Oznaka = s1.Oznaka,
                SektorID = s1.SektorID,
                Status = s1.Status
            };

            Ulaznice u;
            try
            {
                u = await _apiServiceUlaznice.Insert<Ulaznice>(req);
                await _apiServiceSjedala.Update<dynamic>(req.SjedaloID, req2);

            }
            catch (Exception)
            {
                throw;

            }
            //SPREMANJE UPLATA

            UplateInsertRequest requestUplate = new UplateInsertRequest()
            {
                Iznos = Iznos,
                UlaznicaID = u.UlaznicaID
            };
            try
            {
                await _apiServiceUplate.Insert<Uplate>(requestUplate);
            }
            catch (Exception)
            {
                throw;
            }

            //SPREMANJE PREPORUKA
            Utakmice utakmica = await _apiServiceUtakmica.GetById<Utakmice>(req.UtakmicaID);
            var prviTim = utakmica.DomaciTimID;
            var drugiTim = utakmica.GostujuciTimID;
            List<Preporuke> rezultat = await _apiServicePreporuke.Get<List<Preporuke>>(new PreporukaSearchRequest() { KorisnikID = k.KorisnikID, PrviTimID = prviTim, DrugiTimID = drugiTim });
            if (rezultat.Count == 1)
            {
                rezultat[0].BrojKupljenihUlaznica++;
                PreporukaInsertRequest reqP;
                if (rezultat[0].TimID == prviTim)
                {
                    reqP = new PreporukaInsertRequest
                    {
                        TimID = drugiTim,
                        BrojKupljenihUlaznica = 1,
                        KorisnikID = k.KorisnikID
                    };

                }
                else
                {
                    reqP = new PreporukaInsertRequest
                    {
                        TimID = prviTim,
                        BrojKupljenihUlaznica = 1,
                        KorisnikID = k.KorisnikID
                    };
                }


                PreporukaInsertRequest reqPU = new PreporukaInsertRequest
                {
                    TimID = rezultat[0].TimID,
                    KorisnikID = rezultat[0].KorisnikID,
                    BrojKupljenihUlaznica = rezultat[0].BrojKupljenihUlaznica
                };
                await _apiServicePreporuke.Insert<Preporuke>(reqP);
                await _apiServicePreporuke.Update<Preporuke>(rezultat[0].PreporukaID, reqPU);

            }
            else if (rezultat.Count == 2)
            {
                PreporukaInsertRequest req1 = new PreporukaInsertRequest
                {
                    TimID = rezultat[0].TimID,
                    BrojKupljenihUlaznica = ++rezultat[0].BrojKupljenihUlaznica,
                    KorisnikID = rezultat[0].KorisnikID
                };
                PreporukaInsertRequest req3 = new PreporukaInsertRequest
                {
                    TimID = rezultat[1].TimID,
                    BrojKupljenihUlaznica = ++rezultat[1].BrojKupljenihUlaznica,
                    KorisnikID = rezultat[1].KorisnikID
                };

                await _apiServicePreporuke.Update<Preporuke>(rezultat[0].PreporukaID, req1);
                await _apiServicePreporuke.Update<Preporuke>(rezultat[1].PreporukaID, req3);

            }
            else//ako je 0
            {
                PreporukaInsertRequest req1 = new PreporukaInsertRequest
                {
                    TimID = prviTim,
                    BrojKupljenihUlaznica = 1,
                    KorisnikID = k.KorisnikID
                };
                PreporukaInsertRequest req3 = new PreporukaInsertRequest
                {
                    TimID = drugiTim,
                    BrojKupljenihUlaznica = 1,
                    KorisnikID = k.KorisnikID
                };

                await _apiServicePreporuke.Insert<Preporuke>(req1);
                await _apiServicePreporuke.Insert<Preporuke>(req3);
            }

        }



    }
}
