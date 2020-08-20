using System;
using System.Collections.Generic;

namespace SeminarskiRS2.webApi.Database
{
    public partial class Stadioni
    {
        public Stadioni()
        {
            Timovi = new HashSet<Timovi>();
            Tribine = new HashSet<Tribine>();
            Utakmice = new HashSet<Utakmice>();
        }

        public int StadionId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int GradId { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public Gradovi Grad { get; set; }
        public ICollection<Timovi> Timovi { get; set; }
        public ICollection<Tribine> Tribine { get; set; }
        public ICollection<Utakmice> Utakmice { get; set; }
    }
}
