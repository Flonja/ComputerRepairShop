using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VanjaReparatieWinkool.Models
{
    public class CustomerModel : UserModel
    {
        [Key]
        public int CustomerId { get; set; }
    }
}