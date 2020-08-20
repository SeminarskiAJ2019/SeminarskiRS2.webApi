using System;
using System.Collections.Generic;

namespace SeminarskiRS2.webApi.Database
{
    public partial class Timovi
    {
        public Timovi()
        {
            Preporuke = new HashSet<Preporuke>();
            UtakmiceDomaciTim = new HashSet<Utakmice>();
            UtakmiceGostujuciTim = new HashSet<Utakmice>();
        }

        public int TimId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int StadionId { get; set; }
        public int LigaId { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }

        public Lige Liga { get; set; }
        public Stadioni Stadion { get; set; }
        public ICollection<Preporuke> Preporuke { get; set; }
        public ICollection<Utakmice> UtakmiceDomaciTim { get; set; }
        public ICollection<Utakmice> UtakmiceGostujuciTim { get; set; }
    }
}
