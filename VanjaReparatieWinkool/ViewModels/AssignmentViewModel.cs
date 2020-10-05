using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VanjaReparatieWinkool.Models;

namespace VanjaReparatieWinkool.ViewModels
{
    public class AssignmentViewModel
    {
        public AssignmentModel Opdracht { get; set; }
        public int KlantId { get; set; }
        public IEnumerable<CustomerModel> Klanten { get; set; }
        public int WerknemerId { get; set; }
        public EmployeeModel Werknemer { get; set; }
    }
}