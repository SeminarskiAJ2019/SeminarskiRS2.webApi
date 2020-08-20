using System;
using System.Collections.Generic;

namespace SeminarskiRS2.webApi.Database
{
    public partial class Tribine
    {
        public Tribine()
        {
            Sektori = new HashSet<Sektori>();
        }

        public int TribinaId { get; set; }
        public string Naziv { get; set; }
        public int StadionId { get; set; }
        public decimal Cijena { get; set; }

        public Stadioni Stadion { get; set; }
        public ICollection<Sektori> Sektori { get; set; }
    }
}
