using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ecommerce.Models;
using ecommerce.Controllers;
using System.Linq;

namespace ecommerce.Controllers
{
    public class RegController : Controller
    {
        private EcommerceContext _context;
        public RegController(EcommerceContext context)
        {
            _context = context;
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("login")]
        public IActionResult ShowLogin(){
            ViewBag.existsError = HttpContext.Session.GetString("existsError");
            ViewBag.loginError = HttpContext.Session.GetString("loginError");
            HttpContext.Session.SetString("existsError", "");
            HttpContext.Session.SetString("loginError", "");
            return View("Login");
        }


        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model){
            if (ModelState.IsValid){
                bool exists = _context.Customers.Any(u => u.Email == model.Email);
                if (exists == true){
                    HttpContext.Session.SetString("existsError", "That email address is already in use, please try again.");
                    return RedirectToAction ("ShowLogin");
                }
                else{
                    Customer newUser = new Customer{
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = model.Password
                    };
                    _context.Customers.Add(newUser);
                    _context.SaveChanges();
                    Customer currentUser = _context.Customers.Single(u => u.Email == newUser.Email);
                    HttpContext.Session.SetInt32("userID", currentUser.CustomerID);
                    return RedirectToAction ("Index", "Home");
                }
            }
            else{
                return View("Login");
            }
        }

        [HttpPost]
        [Route("login/login")]
        public IActionResult Login(string Email, string Password){
            if (Email.Length < 1 || Password.Length < 1){
                HttpContext.Session.SetString("loginError", "Login failed, please try again.");
                return RedirectToAction("Login");
            }
            else{
                bool exists = _context.Customers.Any(u => u.Email == Email);
                if(exists == true){
                    Customer currentUser = _context.Customers.Single(u => u.Email == Email);
                    if (currentUser.Password == Password){
                        HttpContext.Session.SetInt32("userID", currentUser.CustomerID);
                        return RedirectToAction("Index", "Home");
                    }
                    else{
                        HttpContext.Session.SetString("loginError", "Login failed, please try again.");
                        return RedirectToAction("ShowLogin");
                    }
                }
                else{
                    HttpContext.Session.SetString("loginError", "Login failed, please try again.");
                    return RedirectToAction("ShowLogin");
                }
            }
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
