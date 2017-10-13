using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using QuotingDojo.Models;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = ModelState.Values;
            return View();
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult seeQuotes(){
            List<Dictionary<string,object>> allQuotes = DbConnector.Query("SELECT * FROM Quotes ORDER BY CreatedAt DESC");
            ViewBag.allQuotes = allQuotes;
            return View("quotes");
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult addQuote(Quote newQuote){
            if(ModelState.IsValid){
                
                newQuote.Content = newQuote.Content.Replace("'","\\'");
                
                DbConnector.Execute($"INSERT INTO Quotes(Name, Content) VALUES('{newQuote.Name}','{newQuote.Content}')");
                return RedirectToAction("seeQuotes");
            }
            else{
                ViewBag.errors = ModelState.Values;
                return View("index");
            }
        }
    }
}
