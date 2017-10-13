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
    public class CartController : Controller
    {
        private EcommerceContext _context;
 
        public CartController(EcommerceContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("cart")]
        public IActionResult ShowCart(){
            int? loggedIn = HttpContext.Session.GetInt32("userID");
            if(loggedIn == null){
                ViewBag.loggedIn = false;
                return RedirectToAction("ShowLogin", "Reg");
            }
            else{
                ViewBag.loggedIn = true;
                Customer currentCustomer = _context.Customers.Include(c => c.Orders).ThenInclude(o => o.Carts).ThenInclude(cart => cart.Product).Single(u => u.CustomerID == loggedIn);
                currentCustomer.Orders = currentCustomer.Orders.Where(o => o.Open == 1).ToList<Order>();
                ViewBag.currentCustomer = currentCustomer;
                ViewBag.total = currentCustomer.Orders[0].TotalAmount;
                return View("cart");
            }
        }
    }
}