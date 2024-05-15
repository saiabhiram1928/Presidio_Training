using DoctorAppointmentDALLibrary.Context;
using DoctorAppointmentModelLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        private readonly DoctorAppointmentContext context;

        public PatientRepository(DoctorAppointmentContext context)
        {
            this.context = context;
        }

        public async Task<Patient> Add(Patient item)
        {
            if (item == null) return null;
            try
            {
                await context.Patients.AddAsync(item);
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
                var patient = await context.Patients.FindAsync(key);
                if (patient == null) return false;

                context.Patients.Remove(patient);
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

        public async Task<List<Patient>> GetAll()
        {
            try
            {
                return await context.Patients.ToListAsync();
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

        public async Task<Patient> GetById(int key)
        {
            try
            {
                return await context.Patients.FindAsync(key);
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

        public  bool Update(Patient item)
        {
            try
            {
                context.Patients.Update(item);
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
