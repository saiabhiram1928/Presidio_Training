using EmployeeReqTrackerApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReqTrackerApplication.Context
{
    public class ReqTrackerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=8RXBBX3\\PRACTICEINSTANCE;Integrated Security=true;Initial Catalog=db_EmployeeReqTracker");
        }
        public DbSet<Employee> Employees { get; set; }

    }
}
