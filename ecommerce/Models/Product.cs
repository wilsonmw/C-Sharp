using System;
using System.Collections.Generic;

namespace ecommerce.Models
{
    public class Product
    {
        public int ProductID {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public decimal Price {get; set;}
        public int InStock {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public List<Cart> Orders {get; set;}
        public List<Review> Reviews {get; set;}
        public List<Image> Images {get; set;}

        public Product(){
            Orders = new List<Cart>();
            Reviews = new List<Review>();
            Images = new List<Image>();
        }
    }
}
