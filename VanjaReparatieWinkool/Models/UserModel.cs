using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VanjaReparatieWinkool.Models
{
    public class UserModel
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public string Provincie { get; set; }
    }
}