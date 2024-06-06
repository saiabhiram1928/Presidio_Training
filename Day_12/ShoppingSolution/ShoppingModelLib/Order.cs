using ShoppingModelLib;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Order
    {
        
        public int Id { get; set; }
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; } = string.Empty;
        public int Pincode { get; set; }
        public string PhoneNumber { get; set; } = string.Empty ;
        public string PaymentMethod { get; set; } = "COD";
        public double TotalAmount { get; set; }
        public bool PaymentStatus { get; set; } = false;
        
        public Order(int id, int cartId, string address, int pincode, string phoneNumber, string paymentMethod, double totalAmount, int customerId ,bool paymentStatus)
        {
            Id = id;
            CartId = cartId;
            Address = address;
            Pincode = pincode;
            PhoneNumber = phoneNumber;
            PaymentMethod = paymentMethod;
            TotalAmount = totalAmount;
            CustomerId = customerId;
            PaymentStatus = paymentStatus;
            
        }
        public override string ToString()
        {
            return $"Order Id : {Id} \n Customer Id : {CustomerId} \n Adress : {Address} \n Phone Number : {PhoneNumber} \n Pincode : {Pincode} \n Total Amount : {TotalAmount} \n Payment Status : {PaymentStatus}" ;
        }
    }
}
