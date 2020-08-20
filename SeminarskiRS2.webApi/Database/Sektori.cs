using System;
using System.Collections.Generic;

namespace SeminarskiRS2.webApi.Database
{
    public partial class Sektori
    {
        public Sektori()
        {
            Sjedala = new HashSet<Sjedala>();
        }

        public int SektorId { get; set; }
        public string Naziv { get; set; }
        public int TribinaId { get; set; }

        public Tribine Tribina { get; set; }
        public ICollection<Sjedala> Sjedala { get; set; }
    }
}
