namespace EmployeeRegister.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeRegister.DataAccessLayer.RegisterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EmployeeRegister.DataAccessLayer.RegisterContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Employees.AddOrUpdate(r => r.LastName, new Models.Employee { LastName = "Chupakabra", FirstName = "Maria", Position = "Developer", Salary = 100, Department = "IT", BirthDate = new DateTime(2008, 3, 15), JobDate = new DateTime(2015, 3, 15) },
              new Models.Employee { LastName = "ChupaBubra", FirstName = "Marea", Position = "Developer", Salary = 500, Department = "IT", BirthDate = new DateTime(2003, 1, 14), JobDate = new DateTime(2010, 2, 17) },
              new Models.Employee { LastName = "ChupaDodra", FirstName = "Marue", Position = "Developer", Salary = 900, Department = "IT", BirthDate = new DateTime(2008, 3, 15), JobDate = new DateTime(2015, 3, 15) }
              );
            context.DepartmentList.AddOrUpdate(r => r.Name, new Models.DepartmentList { Name = "IT" }, new Models.DepartmentList { Name = "FINANCE" }, new Models.DepartmentList { Name = "SALES" });

        }
    }
}
