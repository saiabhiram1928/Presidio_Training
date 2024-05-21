using ClinicApi.Models;

namespace ClinicApi.Interfaces
{
    public interface IDoctorService
    {
        public Task<List<Doctor>> GetAllDoctors();
        public Task<IList<Doctor>> GetDoctorsBySpecialization(string spec);
        public Task<Doctor> UpdateDoctorExperience(int id, int exp);  
    }
}
