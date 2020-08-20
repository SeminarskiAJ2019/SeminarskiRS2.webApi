using System;
using System.Collections.Generic;

namespace SeminarskiRS2.webApi.Database
{
    public partial class Lige
    {
        public Lige()
        {
            Timovi = new HashSet<Timovi>();
            Utakmice = new HashSet<Utakmice>();
        }

        public int LigaId { get; set; }
        public string Naziv { get; set; }
        public int DrzavaId { get; set; }

        public Drzave Drzava { get; set; }
        public ICollection<Timovi> Timovi { get; set; }
        public ICollection<Utakmice> Utakmice { get; set; }
    }
}
