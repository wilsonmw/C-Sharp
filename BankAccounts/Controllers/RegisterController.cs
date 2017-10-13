using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BankAccounts.Models;
using System.Linq;

namespace BankAccounts.Controllers
{
    public class RegisterController : Controller
    {
        private BankAccountsContext _context;
        public RegisterController(BankAccountsContext context){
            _context = context;
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Register(RegisterViewModel model){
            if(ModelState.IsValid){
                User newUser = new User{
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();
                User currentUser = _context.Users.Single(user => user.Email == model.Email);
                HttpContext.Session.SetInt32("curID", currentUser.UserID);
                return RedirectToAction("Show","Account");
            }
            else{
                return View("Index");
            }
        }
        [HttpPost]
        [Route("gotologin")]
        public IActionResult GoToLogin(){
            return RedirectToAction("Index", "Login");
        }
    }
}
