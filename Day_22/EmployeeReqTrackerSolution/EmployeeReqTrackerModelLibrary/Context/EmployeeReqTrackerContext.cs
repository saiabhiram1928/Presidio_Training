using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReqTrackerModelLibrary.Context
{
    public class EmployeeReqTrackerContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //db_EmployeeReqTracker
            optionsBuilder.UseSqlServer("Data Source=8RXBBX3\\PRACTICEINSTANCE;Integrated Security=true;Initial Catalog=db_EmployeeReqTracker");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Request> Requests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 101, Name = "test1", Password = "test1123", Role = "Admin" },
                new Employee { Id = 102, Name = "test2", Password = "test2123", Role = "user" },
                new Employee { Id = 103, Name = "test3", Password = "test3123", Role = "User" }
              ) ;

            modelBuilder.Entity<Request>()
            .HasOne(r => r.RequestRaisedByEmployee)
            .WithMany(e => e.RequestsRaised)
            .HasForeignKey(r => r.RequestRaisedBy)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

            modelBuilder.Entity<Request>()
               .HasOne(r => r.RequestClosedByEmployee)
               .WithMany(e => e.RequestsClosed)
               .HasForeignKey(r => r.RequestClosedBy)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
