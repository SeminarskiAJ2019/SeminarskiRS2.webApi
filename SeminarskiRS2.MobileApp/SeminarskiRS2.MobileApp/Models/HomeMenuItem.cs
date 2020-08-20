using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS2.MobileApp.Models
{
    public enum MenuItemType
    {
        Početna,
        About,
        Utakmice,
        Stadioni,
        Timovi,
        MojeUlaznice,
        UrediProfil,
        Odjava
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
