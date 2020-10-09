using System.ComponentModel.DataAnnotations.Schema;

namespace VanjaReparatieWinkool.Models
{
    public class UserModel
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }

        [NotMapped]
        public string VolledigeNaam {
            get{
                return string.Format("{0} {1}", Voornaam, Achternaam);
            }
        }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public ProvinciesEnum Provincie { get; set; }
    }
}