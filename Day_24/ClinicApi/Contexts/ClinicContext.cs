using ClinicApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.Contexts
{
    public class ClinicContext :DbContext
    {
        public ClinicContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 101, Name = "Doctor 1", Specialization = "Cardio", Experience = 2 },
                new Doctor { Id = 102, Name = "Doctor 2", Specialization = "Radio", Experience = 3 },
                new Doctor { Id = 103, Name = "Doctor 3", Specialization = "Radio", Experience = 6 }
                ) ;
        }
    }
}
