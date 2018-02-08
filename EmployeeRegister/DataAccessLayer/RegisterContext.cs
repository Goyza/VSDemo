using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeRegister.DataAccessLayer
{
    public class RegisterContext : DbContext
    {
        public RegisterContext(): base("name=DefaultConnection")
        {

        }

        public DbSet<Models.Employee> Employees { get; set; }
        public DbSet<Models.DepartmentList> DepartmentList { get; set; }
        
    }
}