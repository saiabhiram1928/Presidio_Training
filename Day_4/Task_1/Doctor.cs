using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Doctor
    {
        /// <summary>
        /// creating a id (Integer) and Getting it up
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Creating a name (String) and Getting it up
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Creating a Age(Integer) and Getting it up
        /// </summary>
        public int Age { get; private set; }

        /// <summary>
        /// Creating a Experience(Integer) and Getting it up
        /// </summary>
        public int Experience { get; private set; }
        /// <summary>
        /// Creating a Qualification(String) and Getting it up
        /// </summary>
        public string Qualification { get; private set; }
        /// <summary>
        /// Creating a Speciality(String) and Getting it up
        /// </summary>
        public string Speciality { get; private set; }

        /// <summary>
        /// Default Constructor for the Class : Doctor
        /// </summary>
        public Doctor()
        {
            Id = 0;
            Name = string.Empty;
            Age = 0;
            Experience = 0;
            Qualification = string.Empty;
            Speciality = string.Empty;
        }
        /// <summary>
        /// Parameterized Constructor for Class : Doctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="experience"></param>
        /// <param name="qualification"></param>
        /// <param name="speciality"></param>
        public Doctor(int id, string name, int age , int experience, string qualification, string speciality)
        {
            Id = id;
            Name = name;
            Age = age;
            Experience = experience;
            Qualification = qualification;
            Speciality = speciality;
        }
        
        public void PrintingDoctorDetails()
        {
            Console.WriteLine($"Id : {Id} \n Name : {Name} \n Age : {Age} \n Experience : {Experience} \n Qualification : {Qualification} \n Speciality : {Speciality} \n");
        }


    }
}
