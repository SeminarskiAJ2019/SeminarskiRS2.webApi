using System;
using System.Collections.Generic;

namespace SeminarskiRS2.webApi.Database
{
    public partial class Uplate
    {
        public int UplataId { get; set; }
        public int UlaznicaId { get; set; }
        public decimal Iznos { get; set; }

        public Ulaznice Ulaznica { get; set; }
    }
}
