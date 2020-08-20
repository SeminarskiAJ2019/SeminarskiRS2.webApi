using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS2.Model.Requests
{
    public class UtakmiceSearchRequest
    {
        public int? LigaID { get; set; }
        public int? StadionID { get; set; }
        public bool sveUtakmice { get; set; }
    }
}
