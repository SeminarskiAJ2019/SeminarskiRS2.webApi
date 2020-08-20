using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS2.Model.Requests
{
    public class PreporukaInsertRequest
    {
        public int KorisnikID { get; set; }
        public int TimID { get; set; }
        public int BrojKupljenihUlaznica { get; set; }
    }
}
