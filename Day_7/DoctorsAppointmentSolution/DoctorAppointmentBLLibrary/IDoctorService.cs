using DoctorAppointmentModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    internal interface IDoctorService
    {
        /// <summary>
        /// Creates An Doctor and return true if sucessfully doctor added
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>boolean</returns>
        public bool RegisterDoctor(Doctor doctor);
        /// <summary>
        /// Gives All the doctors details
        /// </summary>
        /// <returns>List of Dcotor </returns>
        public List<Doctor> GetAllDocotrs();
        /// <summary>
        /// Gives Details of an specific doctor
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean</returns>
        public Doctor GetDoctor(int id);
        /// <summary>
        /// Upates Details of an specific Doctor and return true if sucessfully updated
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns>boolean</returns>
        public bool UpdateDoctorDetails(Doctor doctor);
        /// <summary>
        /// Delete a doctor details and return true if deleted;
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Boolean</returns>
        public bool DeleteDoctortails(int key);
        
        

    }
}
