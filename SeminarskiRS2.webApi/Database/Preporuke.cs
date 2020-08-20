using System;
using System.Collections.Generic;

namespace SeminarskiRS2.webApi.Database
{
    public partial class Preporuke
    {
        public int PreporukaId { get; set; }
        public int KorisnikId { get; set; }
        public int TimId { get; set; }
        public int BrojKupljenihUlaznica { get; set; }

        public Korisnici Korisnik { get; set; }
        public Timovi Tim { get; set; }
    }
}
