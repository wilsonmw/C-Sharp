using Microsoft.EntityFrameworkCore;
 
namespace ecommerce.Models
{
    public class EcommerceContext : DbContext
    {
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Address> Addresses {get; set;}
        public DbSet<Cart> Cart {get; set;}
        public DbSet<Image> Images {get; set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<Review> Reviews {get; set;}
        // base() calls the parent class' constructor passing the "options" parameter along
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options) { }
    }
}
