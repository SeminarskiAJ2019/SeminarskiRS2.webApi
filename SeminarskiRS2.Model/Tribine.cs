using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS2.Model
{
    public class Tribine
    {
        public int TribinaID { get; set; }
        public string Naziv { get; set; }
        public int StadionID { get; set; }
        public string Stadion { get; set; }
        public decimal Cijena { get; set; }
    }
}
