using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS2.Model
{
    public class Uplate
    {
        public int UplataID { get; set; }
        public int UlaznicaID { get; set; }
        public Ulaznice Ulaznica { get; set; }
        public decimal Iznos { get; set; }
        public string UplataPodaci { get; set; }
    }
}
