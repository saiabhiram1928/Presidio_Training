namespace DoctorAppointmentModelLib
{
    public class Doctor : IEquatable<Doctor>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Specialization { get; set; } = string.Empty;

        public string Shift { get; set; } = string.Empty;

        public Doctor() 
        { 
            Id = 0;
            Name = string.Empty;
            Specialization = string.Empty;
            Shift = string.Empty;
        }

        public Doctor(int id, string name, string specialization, string shift)
        {
            Id = id;
            Name = name;
            Specialization = specialization;
            Shift = shift;
        }
        public override string ToString()
        {
            return $"Doctor ID : {Id} \n Name : {Name}\n Specialization : {Specialization}\n  Shift : ${Specialization}";
        }
        public  bool Equals(Doctor? Otherdoc)
        {
            return Id.Equals(Otherdoc.Id);
        }
        

    }
}
