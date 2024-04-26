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
        public string Name { get; set; }   = string.Empty;
        public string Phone { get; set; } = String.Empty;
        public Customer() 
        {
            Id = 0;
            Name = string.Empty;
            Phone = string.Empty;
        }
        public Customer(int id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }

        public bool Equals(Customer? other)
        {
            return this.Id.Equals(other.Id);
        }
    }
}
