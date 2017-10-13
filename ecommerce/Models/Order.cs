using System;
using System.Collections.Generic;

namespace ecommerce.Models
{
    public class Order
    {
        public int OrderID {get; set;}
        public decimal TotalAmount {get; set;}
        public int Open {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public int CustomerID {get; set;}
        public Customer Customer {get; set;}
        public List<Cart> Carts {get; set;}
        public Order()
        {
            Carts = new List<Cart>();
        }
    }
}