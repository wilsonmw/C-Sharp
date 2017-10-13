using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FormSubmission.Controllers
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
            
            ViewBag.errors=ModelState.Values;
            
            return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult register(User newUser){
            if (ModelState.IsValid){
                return View("success");
            }
            ViewBag.errors=ModelState.Values;
            return View("Index");
            }
        }
}
