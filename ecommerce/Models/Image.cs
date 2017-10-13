namespace ecommerce.Models
{
    public class Image
    {
        public int ImageID {get; set;}
        public string ImageURL {get; set;}
        public int ProductID {get; set;}
        public Product Product {get; set;}
    }
}