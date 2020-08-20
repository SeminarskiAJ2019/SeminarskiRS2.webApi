using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS2.Model
{
    public class Timovi
    {
        public int TimID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Stadion { get; set; }
        public int StadionID { get; set; }
        public string Liga { get; set; }
        public int LigaID { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
    }
}
