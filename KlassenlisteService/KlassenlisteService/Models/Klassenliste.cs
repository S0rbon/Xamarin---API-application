using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlassenlisteService.Models
{
    public class Klassenliste
    {
        
            public int Id { get; set; }
            public string Name { get; set; }
            public string Vorname { get; set; }
            public string Klasse { get; set; }
            public string Location { get; set; }
        
    }
}