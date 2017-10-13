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
    public class ProductController : Controller
    {
        private EcommerceContext _context;
 
        public ProductController(EcommerceContext context)
        {
            _context = context;
        }
    
        [HttpGet]
        [Route("products")]
        public IActionResult Products(){
            int? loggedIn = HttpContext.Session.GetInt32("userID");
            if(loggedIn == null){
                    ViewBag.loggedIn = false;
                }
                else{
                    ViewBag.loggedIn = true;
                    Customer currentCustomer = _context.Customers.Single(u => u.CustomerID == loggedIn);
                    ViewBag.currentCustomer = currentCustomer;
                }
            List<Product> allProducts = _context.Products.Include(g => g.Images).OrderByDescending(p => p.CreatedAt).ToList();
            ViewBag.allProducts = allProducts;
            Random rando = new Random();
            ViewBag.randNum = rando.Next(0,3);
            return View("products");
        }

        [HttpGet]
        [Route("products/{id}")]
        public IActionResult SingleProd(int id){
            int? loggedIn = HttpContext.Session.GetInt32("userID");
            if(loggedIn == null){
                    ViewBag.loggedIn = false;
                }
                else{
                    ViewBag.loggedIn = true;
                    ViewBag.currentCustomer = _context.Customers.Single(u => u.CustomerID == loggedIn);
                }
            Product currentProduct = _context.Products.Include(i => i.Images).Single(p => p.ProductID == id);
            ViewBag.currentProduct = currentProduct;
            return View("singleprod");
        }

        [HttpGet]
        [Route("buyNow/{id}")]
        public IActionResult ShowBuyPage(int id){
            int? loggedIn = HttpContext.Session.GetInt32("userID");
            if(loggedIn == null){
                    ViewBag.loggedIn = false;
                    return RedirectToAction("ShowLogin", "Reg");
                }
                else{
                    ViewBag.loggedIn = true;
                    ViewBag.currentCustomer = _context.Customers.Single(u => u.CustomerID == loggedIn);
                }
            ViewBag.currentProduct = _context.Products.Include(i => i.Images).Single(p => p.ProductID == id);
            return View("buyProd");
        }

        [HttpPost]
        [Route("buy")]
        public IActionResult Buy(int prodID)
        {
            System.Console.WriteLine("*************************************************");
            System.Console.WriteLine(prodID);
            Product currentProduct = _context.Products.Single(i => i.ProductID == prodID);
            Customer currentCustomer = _context.Customers.Include(o => o.Orders).Single(c => c.CustomerID == HttpContext.Session.GetInt32("userID"));
            if (currentCustomer.Orders.Count <1){
                Order newOrder = new Order{
                    TotalAmount = currentProduct.Price,
                    Open = 1,
                    CustomerID = currentCustomer.CustomerID
                };
                Cart newCart = new Cart{
                    OrderID = newOrder.OrderID,
                    ProductID = prodID
                };
                // _context.Orders.Add(newOrder);
                // _context.SaveChanges();
                _context.Cart.Add(newCart);
                _context.SaveChanges();
            }
            else{
                Order currentOrder = currentCustomer.Orders.Single(o => o.Open == 1);
                if (currentOrder != null){
                    Cart newCart = new Cart{
                        OrderID = currentOrder.OrderID,
                        ProductID = prodID
                    };
                    currentOrder.TotalAmount = currentOrder.TotalAmount + currentProduct.Price;
                    _context.Cart.Add(newCart);
                    _context.SaveChanges();
                }
                else{
                    Order newOrder = new Order{
                    TotalAmount = currentProduct.Price,
                    Open = 1,
                    CustomerID = currentCustomer.CustomerID
                    };
                    Cart newCart = new Cart{
                        OrderID = newOrder.OrderID,
                        ProductID = prodID
                    };
                    // _context.Orders.Add(newOrder);
                    // _context.SaveChanges();
                    _context.Cart.Add(newCart);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Products");
        }
        
    }
}
