using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ecommerce.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private EcommerceContext _context;
 
        public HomeController(EcommerceContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? loggedIn = HttpContext.Session.GetInt32("userID");
            if(loggedIn == null){
                ViewBag.loggedIn = false;
            }
            else{
                ViewBag.loggedIn = true;
                Customer currentCustomer = _context.Customers.Single(u => u.CustomerID == loggedIn);
                ViewBag.currentCustomer = currentCustomer;
            }
            List<Product> allProducts = _context.Products.Include(i => i.Images).OrderByDescending(p => p.CreatedAt).ToList();
            List<Product> recentProducts = allProducts.Take(5).ToList();
            ViewBag.recentProducts = recentProducts;
            Random rando = new Random();
            ViewBag.randNum = rando.Next(0,3);
            return View();
        }
    }
}
