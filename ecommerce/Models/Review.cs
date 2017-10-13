using System;

namespace ecommerce.Models
{
    public class Review
    {
        public int ReviewID {get; set;}
        public string Content {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public int ProductID {get; set;}
        public Product Product {get; set;}
        public int CustomerID {get; set;}
        public Customer Customer {get; set;}
    }
}