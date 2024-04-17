using DoctorAppointmentModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    internal interface IAppointmentService
    {
        /// <summary>
        /// Gives All the Appointment Present
        /// </summary>
        /// <returns></returns>
        public List<Appointmnet> GetAllAppointment();
        /// <summary>
        /// Gives Specific Appointment Details 
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Appointment</returns>
        public Appointmnet GetAppointmentDetails(int key);
        /// <summary>
        /// Updates An Specific Appointment and Gives true if sucess
        /// </summary>
        /// <param name="appointmnet"></param>
        /// <returns>Boolean</returns>
        public bool UpdateAppointment(Appointmnet appointmnet);
        /// <summary>
        /// Deltes An Appointment and Gives true if sucess
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Boolean</returns>
        public bool DeleteAppointment(int key);
        /// <summary>
        /// Creates An appointment and returns true if sucess
        /// </summary>
        /// <param name="appointmnet"></param>
        /// <returns>Boolean</returns>
        public bool AddAppointment(Appointmnet appointmnet);
        /// <summary>
        /// Takes id of the appointment and gives patient details on whose appointment registered
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Patinet</returns>
        public Patient GetDetailsOfPatientOfAnAppointment(int key);
        /// <summary>
        /// Takes id of the appointment and gives doctor details on whose appointment registred
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Doctor GetDetailsOfDoctorOfAnAppointment(int key);
    }
}
