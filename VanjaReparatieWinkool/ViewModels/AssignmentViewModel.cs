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
        public string submitButton { get; set; }
        public AssignmentModel Opdracht { get; set; }
        public int KlantId { get; set; }
        public IEnumerable<CustomerModel> Klanten { get; set; }
        public int WerknemerId { get; set; }
        public IEnumerable<EmployeeModel> Werknemers { get; set; }

        public int GekozenOnderdeelId { get; set; }
        public List<int> GekozenOnderdelen { get; set; }
        public IEnumerable<PartModel> Onderdelen { get; set; }
        public IEnumerable<SelectListItem> OnderdelenSLI { get; set; }
    }
}