using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace callingCard.Controllers{
    
    public class CardController : Controller{
        [HttpGetAttribute]
        
        [HttpGet]
        [Route("{FirstName}/{LastName}/{Age}/{FavoriteColor}")]
        public JsonResult index(string FirstName, string LastName, string Age, string FavoriteColor){
            return Json(new {firstName = FirstName, lastName = LastName, age=Age, faveColor = FavoriteColor});
        }

        [HttpGet]
        [Route("{age}")]
        public string age(int age){
            return "Age: "+ age;
        }

        [HttpGet]
        [Route("{name}")]
        public string name(string name){
            return $"Hello {name}";
        }

        [HttpGet]
        [Route("bonus")]
        public IActionResult firstTemplate(){
            return View("index");
        }
    }
}