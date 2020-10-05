using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VanjaReparatieWinkool.Models;

namespace VanjaReparatieWinkool.DAL
{
    public class VanjaReparatieWinkoolContext : DbContext
    {
        public VanjaReparatieWinkoolContext() : base("VanjaReparatieWinkool")
        {
        }

        public DbSet<EmployeeModel> EmployeeModels { get; set; }
        public DbSet<CustomerModel> CustomerModels { get; set; }
        public DbSet<AssignmentModel> AssignmentModels { get; set; }
        public DbSet<PartModel> PartModels { get; set; }
    }
}