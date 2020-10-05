using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VanjaReparatieWinkool.Models
{
    public class EmployeeModel : UserModel
    {
        //public EmployeeModel()
        //{
        //    this.Assignments = new HashSet<AssignmentModel>();
        //}

        [Key]
        public int EmployeeId { get; set; }

        public virtual ICollection<AssignmentModel> Assignments { get; set; }
    }
}