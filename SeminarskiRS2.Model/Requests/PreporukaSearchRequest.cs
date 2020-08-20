using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS2.Model.Requests
{
    public class PreporukaSearchRequest
    {
        public int? KorisnikID { get; set; }
        public int? PrviTimID { get; set; }
        public int? DrugiTimID { get; set; }
    }
}
