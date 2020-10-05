using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VanjaReparatieWinkool.Models
{
    public class AssignmentModel
    {
        [Key]
        public int AssignmentId { get; set; }
        public string Omschrijving { get; set; }
        public Status Status { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime StartDatum { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EindDatum { get; set; }
        public virtual CustomerModel Klant { get; set; }
        [NotMapped]
        public decimal Prijs { get; set; }
        public double Uren { get; set; }
        public virtual EmployeeModel Werknemer { get; set; }
        public virtual ICollection<PartModel> Onderdelen { get; set; }
    }
}