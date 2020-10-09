namespace VanjaReparatieWinkool.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<VanjaReparatieWinkool.DAL.VanjaReparatieWinkoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VanjaReparatieWinkool.DAL.VanjaReparatieWinkoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Customers.AddOrUpdate(c => c.CustomerId, 
                                                new Models.CustomerModel { Voornaam = "Jan", Achternaam = "Klaasen", Adres = "Klaasstraat 1", Postcode = "1234KK", Provincie = Models.ProvinciesEnum.Limburg },
                                                new Models.CustomerModel { Voornaam = "Olivier", Achternaam = "Bommel", Adres = "Bommelstraat 1", Postcode = "1234BO", Provincie = Models.ProvinciesEnum.Utrecht },
                                                new Models.CustomerModel { Voornaam = "Minnie", Achternaam = "Mouse", Adres = "Mouseval 1", Postcode = "4321MM", Provincie = Models.ProvinciesEnum.Overijsel });

            context.Employees.AddOrUpdate(e => e.EmployeeId,
                                                new Models.EmployeeModel { Voornaam = "Harry", Achternaam = "Handig", Adres = "Maaklaan 101", Postcode = "7777ON", Provincie = Models.ProvinciesEnum.Zuid_Holland },
                                                new Models.EmployeeModel { Voornaam = "Mega", Achternaam = "Mindy", Adres = "Mindystraat 101", Postcode = "4567MM", Provincie = Models.ProvinciesEnum.Noord_Brabant });

        }
    }
}
