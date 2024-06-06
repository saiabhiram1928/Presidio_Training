using DoctorAppointmentDALLibrary;
using DoctorAppointmentModelLib;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentTest
{
    public class Tests
    {
        IRepository<int, Doctor> doctorRepository;
        [SetUp]
        public void Setup()
        {
            doctorRepository = new DoctorRepository();
        }

        [Test]
        public void AddTestSucess()
        {
            //Arrange
            Doctor doctor = new Doctor(1, "test" , "ortho", "morning");
            //Action
            var response = doctorRepository.Add(doctor);
            //Assert
             Assert.That(doctor.Id, Is.EqualTo(response.Id));
        }
        [Test]
        public void AddFailTest()
        {
            Doctor doctor = new Doctor(1, "test", "ortho", "morning");
             doctorRepository.Add(doctor);
            Doctor doctor2 = new Doctor(1, "test", "ortho", "morning");
            var response = doctorRepository.Add(doctor2);
            Assert.IsNull(response);
        }
        [Test]
        public void GetAllSucessTest()
        {
            Doctor doctor1 = new Doctor(1, "test", "ortho", "morning");
            Doctor doctor2 = new Doctor(2, "test", "ortho", "morning");
            doctorRepository.Add(doctor1);
            doctorRepository.Add(doctor2);
            var resposne = doctorRepository.GetAll();
            Assert.That(2 , Is.EqualTo(resposne.Count));
        }
        [TestCase(1, "test1" , "Ortho" , "morning")]
        [TestCase (2, "test2" , "Gen" , "Evening")]
        public void GetSucessTest(int id, string name , string specialization , string shift)
        {
            Doctor doctor = new Doctor(id, name, specialization, shift);
            doctorRepository.Add (doctor);
            var reponse = doctorRepository.GetById(id);
            Assert.IsNotNull(reponse);
        }
    }
}