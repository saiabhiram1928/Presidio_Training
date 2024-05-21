using ClinicApi.Contexts;
using ClinicApi.Exceptions;
using ClinicApi.Interfaces;
using ClinicApi.Models;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace ClinicApi.Repositories
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly ClinicContext _context;
        public DoctorRepository(ClinicContext context)
        {
            _context = context;
        }
        public async Task<Doctor> Add(Doctor item)
        {
            if(item == null) throw new ArgumentNullException("Doctor cant be null while adding to db");
            try
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }catch(DBConcurrencyException dbcex)
            {
                 Console.WriteLine(dbcex);
               
            }
            return null; 
        }

        public async Task<Doctor> Delete(int key)
        {
            try
            {
                var doctor = await GetById(key);
                if (doctor != null)
                {

                    _context.Remove(doctor);
                    await _context.SaveChangesAsync(true);
                    return doctor;
                }
                throw new NoDoctorException();
            }catch(DbException dbex) { Console.WriteLine(dbex.Message); }

            return null;
            

        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            try
            {
                var doctors = await _context.Doctors.ToListAsync();
                return doctors;
            }catch(DbException dbcex) {  Console.WriteLine(dbcex.Message); }
            return null;
           
        }

        public async Task<Doctor> GetById(int key)
        {
            try
            {
                var doctor = await _context.Doctors.FindAsync(key);
                return doctor;
            }catch(DbException dbcex) {  Console.WriteLine(dbcex.Message); }
            return null;

}

        public async Task<Doctor> Update(Doctor item)
        {
            try
            {
                var doctor = await GetById(item.Id);
                if (doctor != null)
                {
                    _context.Update(item);
                   await _context.SaveChangesAsync(true);
                    return doctor;
                }
                throw new NoDoctorException();
            }
            catch (DbException dbcex) { Console.WriteLine(dbcex.Message); }
            return null;

        }
    }
}
