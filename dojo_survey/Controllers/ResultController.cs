using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dojo_survey.Controllers
{
    public class ResultController : Controller
    {
        [HttpPost]
        [Route("results")]
        public IActionResult survey(string name, string location, string favelang, string comment){
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.favelang = favelang;
            ViewBag.comment = comment;
            return View("result");
        }
    }
}