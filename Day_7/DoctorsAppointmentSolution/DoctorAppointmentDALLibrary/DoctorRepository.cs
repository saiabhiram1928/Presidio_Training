using DoctorAppointmentDALLibrary.Context;
using DoctorAppointmentModelLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly DoctorAppointmentContext context;

        public DoctorRepository(DoctorAppointmentContext context)
        {
            this.context = context;
        }

        public async Task<Doctor> Add(Doctor item)
        {
            if (item == null) return null;
            try
            {
                await context.Doctors.AddAsync(item);
                await context.SaveChangesAsync();
                return item;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> Delete(int key)
        {
            try
            {
                var doctor = await context.Doctors.FindAsync(key);
                if (doctor == null) return false;

                context.Doctors.Remove(doctor);
                await context.SaveChangesAsync();
                return true;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public async Task<List<Doctor>> GetAll()
        {
            try
            {
                return await context.Doctors.ToListAsync();
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<Doctor> GetById(int key)
        {
            try
            {
                return await context.Doctors.FindAsync(key);
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public bool Update(Doctor item)
        {
            try
            {
                context.Doctors.Update(item);
                context.SaveChanges();
                return true;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
     
    }
}
