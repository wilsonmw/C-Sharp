using System;
using System.Collections.Generic;

namespace ecommerce.Models
{
    public class Customer
    {
        public int CustomerID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public int UserLevel {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public Address Address {get; set;}
        public List<Review> Reviews {get; set;}
        public List<Order> Orders {get; set;}

        public Customer(){
            Orders = new List<Order>();
        }
    }
}