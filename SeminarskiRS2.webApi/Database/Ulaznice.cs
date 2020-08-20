using System;
using System.Collections.Generic;

namespace SeminarskiRS2.webApi.Database
{
    public partial class Ulaznice
    {
        public Ulaznice()
        {
            Uplate = new HashSet<Uplate>();
        }

        public int UlaznicaId { get; set; }
        public int SjedaloId { get; set; }
        public int UtakmicaId { get; set; }
        public int KorisnikId { get; set; }
        public DateTime DatumKupnje { get; set; }
        public DateTime VrijemeKupnje { get; set; }
        public byte[] Barcodeimg { get; set; }
        public string UlaznicaPodaci { get { return DatumKupnje.ToShortDateString() + ": " + Utakmica.DomaciTim.Naziv + "-" + Utakmica.GostujuciTim.Naziv + "; Korisnik: " + Korisnik.Ime + " " + Korisnik.Prezime; } }
        public Korisnici Korisnik { get; set; }
        public Sjedala Sjedalo { get; set; }
        public Utakmice Utakmica { get; set; }
        public ICollection<Uplate> Uplate { get; set; }
    }
}
