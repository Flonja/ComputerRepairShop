using System.Data.Entity;
using VanjaReparatieWinkool.Models;

namespace VanjaReparatieWinkool.DAL
{
    public class VanjaReparatieWinkoolContext : DbContext
    {
        public VanjaReparatieWinkoolContext() : base("VanjaReparatieWinkool")
        {
        }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<AssignmentModel> Assignments { get; set; }
        public DbSet<PartModel> Parts { get; set; }
    }
}