using ClinicApi.Exceptions;
using ClinicApi.Interfaces;
using ClinicApi.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System;

namespace ClinicApi.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<int,Doctor> _repository;
        public DoctorService(IRepository<int,Doctor> repository)
        {
            _repository = repository;   
        }
        public async Task<List<Doctor>> GetAllDoctors()
        {
            
                var doctors = await _repository.GetAll();
               if (doctors == null) throw new NoDoctorsInDb();
                return doctors.ToList();
        }

        public async Task<IList<Doctor>> GetDoctorsBySpecialization(string spec)
        {
            var res = await _repository.GetAll();
            if (res == null) throw new NoDoctorsInDb();
            var doctors = res.Where(doc => doc.Specialization.Equals(spec, 
             StringComparison.OrdinalIgnoreCase));
            if (doctors.Count() == 0) throw new NoDocWithSpec();
            return doctors.ToList();
        }

        public async Task<Doctor> UpdateDoctorExperience(int id, int exp)
        {
           
                var doctor = await _repository.GetById(id);
                if (doctor == null) throw new NoDoctorException();
                doctor.Experience = exp;
                doctor = await _repository.Update(doctor);
                return doctor;
           
            
        }
    }
}
