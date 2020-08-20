using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS2.Model.Requests
{
    public class TribineInsertRequest
    {
        public string Naziv { get; set; }
        public int StadionID { get; set; }

        public decimal Cijena { get; set; }
    }
}
