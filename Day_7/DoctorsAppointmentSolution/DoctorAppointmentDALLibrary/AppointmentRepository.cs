using DoctorAppointmentDALLibrary.Context;
using DoctorAppointmentModelLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        DoctorAppointmentContext context;
        public AppointmentRepository(DoctorAppointmentContext Context)
        {
            context = Context;
        }
        public async Task<Appointment> Add(Appointment item)
        {
            if (item == null) return null;
            try
            {
                await context.Appointments.AddAsync(item);
                await context.SaveChangesAsync();
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
            return item;

        }

        public async Task<bool> Delete(int key)
        {
          Appointment? res = null;
            try
            {
                 res = await context.Appointments.FindAsync(key);
                if (res == null) return false;
                context.Appointments.Remove(res);
                await context.SaveChangesAsync();
            }catch (DbException dbEx)
            {
                Console.WriteLine($"Databas error {dbEx.Message}");
                return false;
            }catch (Exception ex)
            {
                Console.WriteLine($"Exception Message {ex.Message}");
                return false;
            }
            return true;
        }

        public async Task<List<Appointment>> GetAll()
        {
            List<Appointment>? list;
            try
            {
                 list = await context.Appointments.ToListAsync();
            
            }catch(DbException dbEx) 
            {
                Console.WriteLine($"Db error {dbEx.Message}");
                return null;
            }catch(Exception ex)
            {
                Console.WriteLine($"Exception {ex.Message}");
                return null;
            }
            return list;
        }

        public async Task<Appointment> GetById(int key)
        {
            Appointment ? res;
            try
            {
                res = await context.Appointments.FindAsync(key);
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Db error {dbEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception {ex.Message}");
                return null;
            }
            return res;

        }

        public bool Update(Appointment item)
        {
            try
            {
                context.Appointments.Update(item);
                context.SaveChanges();
                return true;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Db error {dbEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception {ex.Message}");
                return false;
            }
            

        }
    }
}
