using SeminarskiRS2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS2.MobileApp.ViewModels
{
    public class UlaznicaSimpleDetailVM : BaseViewModel
    {
        public Ulaznice ulaznica { get; set; }
        public string Code { get; set; }
    }
}
