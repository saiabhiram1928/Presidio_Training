using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementModelLib
{
    public class Patron
    {
        public int Id { get; private set; }
        public string Name { get;  set; } = string.Empty;
        public string PhoneNumber {get; set;} = string.Empty;
        public string Address { get; set;} = string.Empty;  
        public Patron()
        {
            Id = 0;
            PhoneNumber = string.Empty;
            Name = string.Empty ;
            Address = string.Empty ;
        }
        public Patron(int id, string name, string phoneNumber, string address)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
        }
        public override bool Equals(object? obj)
        {
            Patron p1, p2;
            p1 = this;
            p2 = (Patron)obj;
            return p1.Id.Equals(p2.Id);
        }
        public override string ToString()
        {
            return $"Id : {Id} \n Name : {Name} \n Adress : {Address} \n PhoneNumber : ${PhoneNumber}" ;
        }
    }
}
