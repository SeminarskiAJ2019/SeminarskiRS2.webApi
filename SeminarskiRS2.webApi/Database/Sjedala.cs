using System;
using System.Collections.Generic;

namespace SeminarskiRS2.webApi.Database
{
    public partial class Sjedala
    {
        public Sjedala()
        {
            Ulaznice = new HashSet<Ulaznice>();
        }

        public int SjedaloId { get; set; }
        public string Oznaka { get; set; }
        public int SektorId { get; set; }
        public bool Status { get; set; }

        public Sektori Sektor { get; set; }
        public ICollection<Ulaznice> Ulaznice { get; set; }
    }
}
