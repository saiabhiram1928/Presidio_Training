using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLib
{
    public class Customer : IEquatable<Customer>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }   = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public Customer() 
        {
            Id = 0;
            Name = string.Empty;
            Phone = string.Empty;
            Username = string.Empty;
        }
        public Customer(int id,string username, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Username = username;
        }

        public bool Equals(Customer? other)
        {
            return this.Id.Equals(other.Id);
        }
        public override string ToString()
        {
           return $"Id : {Id} \n Username : {Username} \n Name : {Name} \n Phone : {Phone}";
        }
    }
}
