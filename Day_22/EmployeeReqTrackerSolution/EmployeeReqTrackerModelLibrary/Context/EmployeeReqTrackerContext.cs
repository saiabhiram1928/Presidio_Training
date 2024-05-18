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
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 101, Name = "test1", Password = "test1123", Role = "Admin" },
                new Employee { Id = 102, Name = "test2", Password = "test2123", Role = "user" },
                new Employee { Id = 103, Name = "test3", Password = "test3123", Role = "User" }
              ) ;
            modelBuilder.Entity<Request>().HasData(
                new Request { Id = 1, RequestMessage = "Laptop Repair", RequestStatus = "Open", RequestRaisedBy = 102 , RequestDate = DateTime.Now }
                );
            modelBuilder.Entity<Solution>().HasData(
                new Solution() { Id = 1 , SolutionText = "Check Bois" , IsSolutionAccepted  = false , RequestId = 1, SolvedBy = 101 , RequestRaiserComment = "Checked it" , SolvedDate = DateTime.Now }
                );

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
            modelBuilder.Entity<Solution>()
                 .HasOne(rs => rs.RequestRaisedBy)
                 .WithMany(r => r.RequestSolutions)
                 .HasForeignKey(rs => rs.RequestId)
                 .OnDelete(DeleteBehavior.Restrict)
                 .IsRequired();
            modelBuilder.Entity<Solution>()
                .HasOne(s => s.RequestSolvedBy)
                .WithMany(s => s.SolutionsProvided)
                .HasForeignKey(s => s.SolvedBy)
                .OnDelete(DeleteBehavior.Restrict)
                 .IsRequired();
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Solution)
                .WithMany(s => s.Feedbacks)
                .HasForeignKey(f => f.SolutionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            modelBuilder.Entity<Feedback>()
              .HasOne(sf => sf.FeedbackByEmployee)
              .WithMany(e => e.FeedbacksProvided)
              .HasForeignKey(sf => sf.FeedbackBy)
              .OnDelete(DeleteBehavior.Restrict)
              .IsRequired();

        }
    }
}
