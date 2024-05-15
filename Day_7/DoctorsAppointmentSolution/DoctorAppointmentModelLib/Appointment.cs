using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentModelLib
{
    public class Appointment
    {
       
        public Doctor? DoctorAssigned { get; set; } 
        public Patient? PatientRaised { get; set; }
        public int Id {  get; set; }
        public string AppointmentDetails {  get; set; } = string.Empty;
        public DateTime AppointmentDateAndTime {  get; set; }
       
        public Appointment() 
        {
            Id = 0;
            DoctorAssigned = null;
            PatientRaised = null;
            AppointmentDetails = string.Empty;
            AppointmentDateAndTime = (DateTime.Now);
        }
        public Appointment(Doctor? doctorAssigned, Patient? patientRaised, int id, string appointment, DateTime appointmentDate)
        {
            DoctorAssigned = doctorAssigned;
            PatientRaised = patientRaised;
            Id = id;
            AppointmentDetails = appointment;
            AppointmentDateAndTime = appointmentDate;
        }

    }
}
