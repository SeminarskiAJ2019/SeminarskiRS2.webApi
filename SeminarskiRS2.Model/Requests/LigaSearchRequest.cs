using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS2.Model.Requests
{
    public class LigaSearchRequest
    {
        public int? DrzavaID { get; set; }
        public string Naziv { get; set; }
    }
}
