using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using loginreg.Models;

namespace loginreg.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dictionary<string,object>> allUsers = _dbConnector.Query("SELECT * FROM Users");
            ViewBag.allUsers = allUsers;
            return View("Index");
        }

        [HttpPost]
        [Route("")]
        public IActionResult register(User newUser){
            if(!ModelState.IsValid){
                return View("Index");
            }
            else{
                newUser.Email.Replace("@","\\@");
                _dbConnector.Execute($"INSERT INTO Users(FirstName, LastName, Email, Password)VALUES ('{newUser.FirstName}','{newUser.LastName}','{newUser.Email}','{newUser.Password}')");
                List<Dictionary<string,object>> currentUser = _dbConnector.Query($"SELECT * FROM Users WHERE Email = '{newUser.Email}'");
                HttpContext.Session.SetInt32("userID", (int)currentUser[0]["idUsers"]);
                return Redirect("Homepage");
            }
        }
        [HttpGet]
        [Route("Homepage")]
        public IActionResult Homepage(){
            int? userID = HttpContext.Session.GetInt32("userID");
            List<Dictionary<string,object>> currentUser = _dbConnector.Query($"SELECT * FROM Users WHERE idUsers = '{userID}'");
            ViewBag.name = currentUser[0]["FirstName"];
            return View("Success");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string Email, string Password){
            List<Dictionary<string,object>> potentialUser = _dbConnector.Query($"SELECT * FROM Users WHERE Email = '{Email}' AND Password = '{Password}'");
            if(potentialUser.Count < 1){
                ViewBag.errors = "Login failed, please try again.";
                return RedirectToAction("Index");
            }
            else{
                ViewBag.name = potentialUser[0]["FirstName"];
                return View("Success");
            }
        }
    }
}
