using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Validation;
using VanjaReparatieWinkool.Models;

namespace VanjaReparatieWinkool.DAL
{
    public class VanjaReparatieWinkoolContext : IdentityDbContext
    {
        public VanjaReparatieWinkoolContext() : base("VanjaReparatieWinkool")
        {
        }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<AssignmentModel> Assignments { get; set; }
        public DbSet<PartModel> Parts { get; set; }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }
    }
}