using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using wall.Models;

namespace wall.Controllers
{
    public class RegController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public RegController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");
        }
        [HttpPost]
        [Route("")]
        public IActionResult Register(ValidateUser user){
            if(ModelState.IsValid){
                User newUser = new User{
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password};
                _dbConnector.Execute($"INSERT INTO users (FirstName, LastName, Email, Password) VALUES ('{newUser.FirstName}','{newUser.LastName}','{newUser.Email}','{newUser.Password}')");
                HttpContext.Session.SetString("name", newUser.FirstName);
                List<Dictionary<string,object>> currentUser = _dbConnector.Query($"SELECT * FROM users WHERE(Email='{newUser.Email}')");
                HttpContext.Session.SetInt32("userId", (int)currentUser[0]["idusers"]);
                return RedirectToAction("Wall", "Wall");
            }
            else{
                return View("index");
            }
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string Email, string Password){
            List<Dictionary<string,object>> currentUser = _dbConnector.Query($"SELECT * FROM users WHERE(Email='{Email}')");
            if(currentUser.Count<1){
                ViewBag.loginError = "Login failed, please try again.";
                return View("index");
            }
            else if ((string)currentUser[0]["Password"] != Password){
                ViewBag.loginError = "Login failed, please try again.";
                return View("index");
            }
            else{
                HttpContext.Session.SetInt32("userId", (int)currentUser[0]["idusers"]);
                return RedirectToAction("Wall", "Wall");
            }
        }

        [HttpGet]
        [Route("/logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
