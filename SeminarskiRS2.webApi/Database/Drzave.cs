using System;
using System.Collections.Generic;

namespace SeminarskiRS2.webApi.Database
{
    public partial class Drzave
    {
        public Drzave()
        {
            Gradovi = new HashSet<Gradovi>();
            Lige = new HashSet<Lige>();
        }

        public int DrzavaId { get; set; }
        public string Naziv { get; set; }

        public ICollection<Gradovi> Gradovi { get; set; }
        public ICollection<Lige> Lige { get; set; }
    }
}
