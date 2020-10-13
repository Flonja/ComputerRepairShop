using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VanjaReparatieWinkool.Models
{
    public class UserModel : IdentityUser
    {
        [Display(Name = "Email")]
        public new string UserName { get; set; }

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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserModel> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}