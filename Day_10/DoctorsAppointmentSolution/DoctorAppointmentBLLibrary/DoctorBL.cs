using DoctorAppointmentModelLib;
using DoctorAppointmentDALLibrary;
using System.Linq.Expressions;

namespace DoctorAppointmentBLLibrary
{
    public class DoctorBL : IDoctorService
    {
        readonly IRepository<int, Doctor> _doctorService;
        public DoctorBL()
        {
            _doctorService = new DoctorRepository();
        }
        void ThrowNullRefEx(string msg)
        {
            throw new NullReferenceException(msg);
        }
        public int DeleteDocotrDetalis(int key)
        {
            var response = _doctorService.Delete(key);
            if (response == null) ThrowNullRefEx("The Doctor with given id doesnt present");
            return response.Id;
        }

        public List<Doctor> GetAllDocotrs()
        {
            List<Doctor> response = _doctorService.GetAll();
            if (response == null) ThrowNullRefEx("There are no doctors present in the db");
            return response;
        }

        public Doctor GetDoctor(int id)
        {
           Doctor doctor = _doctorService.GetById(id);
            if (doctor == null) ThrowNullRefEx("The Doctor with given id doesnt exist");
            return doctor;
        }

        public bool RegisterDoctor(Doctor doctor)
        {
            var response = _doctorService.Add(doctor);
            if (response == null) throw new DuplicateWaitObjectException("The Doctor Already Exist in the db");
            return true;



        }

        public bool UpdateDoctorDetails(Doctor doctor)
        {
           var response = _doctorService.Update(doctor);
            if (response == null) ThrowNullRefEx("The Doctor with given Doesnt Exist");
            return true;
        }
    }
}
