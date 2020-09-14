using System;
using System.Collections.Generic;

namespace SeminarskiRS2.webApi.Database
{
    public partial class Utakmice
    {
        public Utakmice()
        {
            Ulaznice = new HashSet<Ulaznice>();
        }

        public int UtakmicaId { get; set; }
        public int DomaciTimId { get; set; }
       // public string Utakmica { get { return DomaciTim.Naziv + "-" + GostujuciTim.Naziv + " - " + DatumOdigravanja.ToShortDateString(); } }
        public int GostujuciTimId { get; set; }
        public int LigaId { get; set; }
        public DateTime DatumOdigravanja { get; set; }
        public DateTime VrijemeOdigravanja { get; set; }
        public int StadionId { get; set; }
        public DateTime Dateonly { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }

        public Timovi DomaciTim { get; set; }
        public Timovi GostujuciTim { get; set; }
        public Lige Liga { get; set; }
        public Stadioni Stadion { get; set; }
        public ICollection<Ulaznice> Ulaznice { get; set; }
    }
}
