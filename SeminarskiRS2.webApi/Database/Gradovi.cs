using System;
using System.Collections.Generic;

namespace SeminarskiRS2.webApi.Database
{
    public partial class Gradovi
    {
        public Gradovi()
        {
            Korisnici = new HashSet<Korisnici>();
            Stadioni = new HashSet<Stadioni>();
        }

        public int GradId { get; set; }
        public string Naziv { get; set; }
        public int DrzavaId { get; set; }

        public Drzave Drzava { get; set; }
        public ICollection<Korisnici> Korisnici { get; set; }
        public ICollection<Stadioni> Stadioni { get; set; }
    }
}
