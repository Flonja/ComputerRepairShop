using System.ComponentModel.DataAnnotations;

namespace VanjaReparatieWinkool.Models
{
    public class CustomerModel : UserModel
    {
        [Key]
        public int CustomerId { get; set; }
    }
}