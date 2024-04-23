using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentModelLib
{
    public class Appointmnet
    {
       
        public Doctor? DoctorAssigned { get; set; } 
        public Patient? PatientRaised { get; set; }
        public int Id {  get; set; }
        public string AppointmentDetails {  get; set; } = string.Empty;
        public DateOnly AppointmentDate {  get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public Appointmnet() 
        {
            Id = 0;
            DoctorAssigned = null;
            PatientRaised = null;
            AppointmentDetails = string.Empty;
            AppointmentTime = TimeOnly.FromDateTime(DateTime.Now);
            AppointmentDate = DateOnly.FromDateTime(DateTime.Now);
          

        }
        public Appointmnet(Doctor? doctorAssigned, Patient? patientRaised, int id, string appointment, DateOnly appointmentDate, TimeOnly appointmentTime)
        {
            DoctorAssigned = doctorAssigned;
            PatientRaised = patientRaised;
            Id = id;
            AppointmentDetails = appointment;
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
           
        }

    }
}
