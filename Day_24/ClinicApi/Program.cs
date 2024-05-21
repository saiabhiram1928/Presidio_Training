using ClinicApi.Contexts;
using ClinicApi.Interfaces;
using ClinicApi.Models;
using ClinicApi.Repositories;
using ClinicApi.Services;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ClinicContext>(
                 options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
                );
            builder.Services.AddScoped<IRepository<int, Doctor>, DoctorRepository>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
