using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS2.Model.Requests
{
    public class UlazniceSearchRequest
    {
        public int? KorisnikID { get; set; }
        public int? Godina { get; set; }
        public int? UtakmicaID { get; set; }
    }
}
