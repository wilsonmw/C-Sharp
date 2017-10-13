using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BankAccounts.Models;
using BankAccounts.Controllers;
using System.Linq;

namespace BankAccounts.Controllers
{
    public class LoginController : Controller
    {
        private BankAccountsContext _context;
        public LoginController(BankAccountsContext context){
            _context = context;
        }

        [HttpGet]
        [Route("gotologin")]
        public IActionResult Index(){
            return View();
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string Email, string Password){
            bool exists = _context.Users.Any(u => u.Email == Email);
            System.Console.WriteLine(exists);
            if(exists == true){
                User currentUser = _context.Users.Single(user => user.Email == Email);
                System.Console.WriteLine(currentUser);
                if(currentUser.Password == Password){
                    HttpContext.Session.SetInt32("curID", currentUser.UserID);
                    ViewBag.currentUser = currentUser;
                    return RedirectToAction("Show", "Account");
                }
                    else{
                        ViewBag.loginError = "Login failed, please try again.";
                        return RedirectToAction("Index");
                    
                    }   
                } 
            else{
                ViewBag.loginError = "Login failed, please try again.";
                return RedirectToAction("Index");
            }
        }
    }
}