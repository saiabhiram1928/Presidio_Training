using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentModelLib
{
    public class Patient
    {
        public List<Doctor>? DoctorVisited { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; }= string.Empty;
        public int Age { get; set; }
        public string PhoneNumber {  get; set; } = string.Empty ;

        public string Adress { get; set; } = string.Empty;

        public Patient() 
        { 
            Id = 0;
            Name = string.Empty;
            Gender = string.Empty;
            Age = 0;
            PhoneNumber = string.Empty;
            Adress = string.Empty;
            DoctorVisited = null;
        }

        public Patient(int id, string name, string gender, int age, string phoneNumber, string adress, List<Doctor> doctorVisited)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Age = age;
            PhoneNumber = phoneNumber;
            Adress = adress;
            DoctorVisited = doctorVisited;
        }
    }
}
