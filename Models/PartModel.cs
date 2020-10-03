using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VanjaReparatieWinkool.Models
{
    public class PartModel
    {
        [Key]
        public int PartId { get; set; }
        public string Naam { get; set; }
        public string Leverancier { get; set; }
        public int Aantal { get; set; }
        public decimal Prijs { get; set; }
        public virtual ICollection<AssignmentModel> Assignments { get; set; }
    }
}