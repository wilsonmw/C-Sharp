namespace ecommerce.Models
{
    public class Cart
    {
        public int CartID {get; set;}
        public int OrderID {get; set;}
        public Order Order {get; set;}
        public int ProductID {get; set;}
        public Product Product {get; set;}
    }
}
