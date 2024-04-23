using DoctorAppointmentModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    internal interface IPatientService
    {
        /// <summary>
        /// Gives Details of Specific Patient
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Patient</returns>
        public Patient GetPatinetDetails(int key);
        /// <summary>
        /// Gives all the Doctor details visited by the patinet
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<Doctor> GetAllVisitedDoctor(int key);
        /// <summary>
        /// Creates a Patient and return true if patient added sucesfully
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>Boolean</returns>
        public bool RegisterPatient(Patient patient);   
        /// <summary>
        /// Updates details of an specific details and return true if updated sucessfully
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public bool UpdatePatient(Patient patient);
        /// <summary>
        /// Deletes a specific patient details and return true if deleted sucessfully
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DeletePatient(int key);
        /// <summary>
        /// Gives List of all Patinets present
        /// </summary>
        /// <returns>List of patients</returns>
        public List<Patient> GetAllPatients();

    }
}
