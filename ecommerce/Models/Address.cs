namespace ecommerce.Models
{
    public class Address
    {
        public int AddressID {get; set;}
        public string Address1 {get; set;}
        public string Address2 {get; set;}
        public string City {get; set;}
        public string State {get; set;}
        public string Zip {get; set;}
        public int CustomerID {get; set;}
        public Customer Customer {get; set;}
    }
}
