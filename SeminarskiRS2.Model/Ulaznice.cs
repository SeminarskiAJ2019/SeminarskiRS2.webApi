using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;

namespace SeminarskiRS2.Model
{
    public class Ulaznice
    {
        public int UlaznicaID { get; set; }

        public int SjedaloID { get; set; }
        public string Oznaka { get; set; }
        public int UtakmicaID { get; set; }
        public string utakmica { get; set; }
        public string sektor { get; set; }
        public int KorisnikID { get; set; }
        public string korisnik { get; set; }
        public DateTime DatumKupnje { get; set; }
        public DateTime VrijemeKupnje { get; set; }
        public string color { get; set; }
    }
}
