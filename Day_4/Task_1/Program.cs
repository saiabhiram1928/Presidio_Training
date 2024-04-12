using System.Transactions;

namespace Task_1
{
    internal class Program
    {
        /// <summary>
        /// Handling Input , Exception for Integer feild
        /// </summary>
        /// <returns>Integer</returns>
        int HandlingIntegerInput()
        {
            int num = 0;
            while(int.TryParse(Console.ReadLine(),out num) == false)
            {
                Console.WriteLine("Please Enter a valid number \n");
            }
            return num;

        }
        /// <summary>
        /// Handling Input , Exception for String feild
        /// </summary>
        /// <returns>String</returns>
        string HandlingStringInput()
        {
            string ? str  =string.Empty;
            do
            {
                str = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(str))
                Console.WriteLine("Please Enter a valid string \n");
            } while (string.IsNullOrWhiteSpace(str));
            return str;

        }
         /// <summary>
         /// Takes Counter (Integer) as Argument and Creats Doctor 
         /// </summary>
         /// <param name="counter"></param>
         /// <returns>Doctor class</returns>
        Doctor CreateDoctor(int counter) {
            int id = int.Parse((DateTime.Now.ToString("yyyyMMdd"))),age ,experience;
            string name, qualification, speciality;
            Console.WriteLine($"Please Enter the Age of {counter + 1} doctor : ");
            age = HandlingIntegerInput();
            Console.WriteLine($"Please Enter the Experience of {counter + 1} doctor : ");
            experience = HandlingIntegerInput();
            Console.WriteLine($"Please Enter the Name of {counter + 1} doctor : ");
            name = HandlingStringInput();
            Console.WriteLine($"Please Enter the Qualification of {counter + 1} doctor : ");
            qualification = HandlingStringInput();
            Console.WriteLine($"Please Enter the Speciality of {counter + 1} doctor : ");
            speciality = HandlingStringInput();

            Doctor doctor = new Doctor(id,name,age,experience,qualification,speciality);
            return doctor;
        }
        /// <summary>
        /// Takes Specailty (String) , Doctor (Array)
        /// </summary>
        /// <param name="specailty"></param>
        /// <param name="doctors"></param>
      static void GetDoctorBySpecailty(string specailty , Doctor[] doctors)
         {
            bool flag = false;
            for(int i = 0; i < doctors.Length; i++)
            {
                if (doctors[i].Speciality.ToLower() == specailty.ToLower())
                {
                    flag = true;
                    doctors[i].PrintingDoctorDetails();
                    break;
                }
            }
            if(!flag) { Console.WriteLine("There Are No Such Doctors With Given Speciality"); }
            return;
         }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Please Enter the number of doctors : ");
            //Console.WriteLine(DateTime.Now.ToString("yyyyMMdd"));
            int size = program.HandlingIntegerInput();
            Doctor[] doctors = new Doctor[size];
            Console.WriteLine("_________________________Creating Doctor _____________________________________");

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("************************************************* \n");
                Console.WriteLine($"Please Enter Doctor {i+1} Details \n");
                doctors[i] = program.CreateDoctor(i);
               
            }
            Console.WriteLine("_________________________Fetching All Doctors _____________________________________");

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"The Doctor {i + 1} Details \n");
                doctors[i].PrintingDoctorDetails();
            }
            Console.WriteLine("_________________________Search Doctor by Speciality_____________________________________");
            string speciality;
            do
            {
                Console.WriteLine("Please Enter the Speciality of Doctor or Enter q for quit: ");
                speciality = program.HandlingStringInput();
                if(speciality != "q") GetDoctorBySpecailty(speciality, doctors);
            } while (speciality != "q");

        }
    }
}
