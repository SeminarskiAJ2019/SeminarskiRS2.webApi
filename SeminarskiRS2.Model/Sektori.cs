using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS2.Model
{
    public class Sektori
    {
        public int SektorID { get; set; }
        public string Naziv { get; set; }
        public int TribinaID { get; set; }
        public string Tribina { get; set; }
        public string SektorPodaci { get { return Tribina + "/" + Naziv; } }
        public string Cijena { get; set; }
        public string CijenaPodaci { get { return "Cijena: " + Cijena + " KM"; } }
    }
}
