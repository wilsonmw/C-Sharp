using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using restauranter.Models;
using System.Linq;

namespace restauranter.Controllers
{
    public class HomeController : Controller
    {
        private RestauranterContext _context;
        public HomeController(RestauranterContext context)
        {
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
        public IActionResult NewReview(Review newReview){
            if(ModelState.IsValid){
                _context.Add(newReview);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            else{
                return View("Index");
            }
        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews(){
            List<Review> allReviews = _context.Reviews.OrderByDescending(review => review.CreatedAt).ToList();
            ViewBag.allReviews = allReviews;
            return View("reviews");
        }

        [HttpPost]
        [Route("skip")]
        public IActionResult Skip(){
            return RedirectToAction("Reviews");
        }
        [HttpPost]
        [Route("helpful")]
        public IActionResult Helpful(int id){
            Review review = _context.Reviews.Single(thing => thing.id == id);
            review.HelpfulCount = review.HelpfulCount+1;
            _context.SaveChanges();
            return RedirectToAction("Reviews");
        }

        [HttpPost]
        [Route("unhelpful")]
        public IActionResult Unhelpful(int id){
            Review review = _context.Reviews.Single(thing => thing.id == id);
            review.UnhelpfulCount = review.UnhelpfulCount+1;
            _context.SaveChanges();
            return RedirectToAction("Reviews");
        }
    }
}
