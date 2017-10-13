using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System;

namespace dojodachi.Controllers
{

    public class DachiController : Controller
    {

 
       
        [HttpPost]
        [Route("feed")]
        public IActionResult feed(){
            HttpContext.Session.SetString("message", "");
            int? meals = HttpContext.Session.GetInt32("meals");
            int? fullness = HttpContext.Session.GetInt32("fullness");          
            if(meals < 1){
                HttpContext.Session.SetString("message", "You don't have enough meals to feed your DojoDachi!");
                return RedirectToAction ("index2");
            }
            Random rand = new Random();
            int chance = rand.Next(1,5);
            if(chance == 4){
                meals -=1;
                HttpContext.Session.SetInt32("meals", (int)meals);
                HttpContext.Session.SetString("message", "Your DojoDachi didn't like that meal!");
                return RedirectToAction("index2");
            }
            Random rando = new Random();
            int randFull = rando.Next(5,11);
            meals -= 1;
            fullness += randFull;            
            HttpContext.Session.SetInt32("meals", (int)meals);
            HttpContext.Session.SetInt32("fullness", (int)fullness);
            HttpContext.Session.SetString("message", "Your DojoDachi enjoyed the meal and gained "+ randFull +" fullness!");
            return RedirectToAction("index2");

        }

        [HttpPost]
        [Route("play")]
        public IActionResult play(){
            HttpContext.Session.SetString("message", "");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? energy = HttpContext.Session.GetInt32("energy");          
            if(energy < 5){
                HttpContext.Session.SetString("message", "Your DojoDachi doesn't have enough energy to play!");
                return RedirectToAction ("index2");
            }
            Random rand = new Random();
            int chance = rand.Next(1,5);
            if(chance == 4){
                energy -=5;
                HttpContext.Session.SetInt32("energy", (int)energy);
                HttpContext.Session.SetString("message", "Your DojoDachi didn't enjoy playing with you!");
                return RedirectToAction("index2");
            }
            Random rando = new Random();
            int randHapp = rando.Next(5,11);
            energy -= 5;
            happiness += randHapp;            
            HttpContext.Session.SetInt32("energy", (int)energy);
            HttpContext.Session.SetInt32("happiness", (int)happiness);
            HttpContext.Session.SetString("message", "Your DojoDachi had fun playing and gained "+ randHapp +" happiness!");
            return RedirectToAction("index2");

        }

        [HttpPost]
        [Route("work")]
        public IActionResult work(){
            HttpContext.Session.SetString("message", "");
            int? energy = HttpContext.Session.GetInt32("energy");
            int? meals = HttpContext.Session.GetInt32("meals");          
            if(energy < 5){
                HttpContext.Session.SetString("message", "Your DojoDachi doesn't have enough energy to work!");
                return RedirectToAction ("index2");
            }
            Random rando = new Random();
            int randMeals = rando.Next(1,4);
            energy -= 5;
            meals += randMeals;            
            HttpContext.Session.SetInt32("meals", (int)meals);
            HttpContext.Session.SetInt32("energy", (int)energy);
            HttpContext.Session.SetString("message", "Your DojoDachi worked hard and earned "+ randMeals +" meals!");
            return RedirectToAction("index2");

        }

        [HttpPost]
        [Route("sleep")]
        public IActionResult sleep(){
            HttpContext.Session.SetString("message", "");
            int? energy = HttpContext.Session.GetInt32("energy");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? happiness = HttpContext.Session.GetInt32("happiness");          
            energy += 15;
            fullness -=5;
            happiness -=5;            
            HttpContext.Session.SetInt32("fullness", (int)fullness);
            HttpContext.Session.SetInt32("happiness", (int)happiness);
            HttpContext.Session.SetInt32("energy", (int)energy);
            HttpContext.Session.SetString("message", "Your DojoDachi slept and gained 15 energy!");
            return RedirectToAction("index2");

        }
        [HttpPost]
        [Route("kick")]
        public IActionResult kick(){
            HttpContext.Session.SetString("message", "");
            int? happiness = HttpContext.Session.GetInt32("happiness"); 
            Random rand = new Random();
            int chance = rand.Next(1,5);
            if(chance == 4){
                happiness +=50;
                HttpContext.Session.SetInt32("happiness", (int)happiness);
                HttpContext.Session.SetString("message", "Your DojoDachi enjoyed that kick to the face and gained 50 happiness!");
                return RedirectToAction("index2");
            }         
            Random rando = new Random();
            int randHapp = rando.Next(25,51);
            happiness -=randHapp;            
            HttpContext.Session.SetInt32("happiness", (int)happiness);
            HttpContext.Session.SetString("message", "You kicked your DojoDachi in the face and took "+randHapp+" happiness!");
            return RedirectToAction("index2");

        }


    
        [HttpGet]
        [Route("")]
        public IActionResult index()
        {
            HttpContext.Session.Clear();
            Dachi yourDachi = new Dachi();
            HttpContext.Session.SetInt32("happiness", yourDachi.happiness);
            HttpContext.Session.SetInt32("fullness", yourDachi.fullness);
            HttpContext.Session.SetInt32("energy", yourDachi.energy);
            HttpContext.Session.SetInt32("meals", yourDachi.meals);
            ViewBag.happ = yourDachi.happiness;
            ViewBag.full = yourDachi.fullness;
            ViewBag.energy = yourDachi.energy;
            ViewBag.meals = yourDachi.meals;
            return View("index");
        }
        [Route("index2")]
        public IActionResult index2(){
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? energy = HttpContext.Session.GetInt32("energy");
            int? meals = HttpContext.Session.GetInt32("meals");
            string message = HttpContext.Session.GetString("message");
            if(happiness <= 0 || fullness <=0){
                return RedirectToAction("dead");
            }
            if(happiness >=100 && fullness >= 100 && energy >= 100){
                return RedirectToAction("win");
            }           
            ViewBag.happ = happiness;
            ViewBag.full = fullness;
            ViewBag.energy = energy;
            ViewBag.meals = meals;
            ViewBag.message = message;
            return View("index");
        }

        [Route("dead")]
        public IActionResult dead(){
            return View("dead");
        }
        [Route("win")]
        public IActionResult win(){
            return View("win");
        }
        [Route("restart")]
        public IActionResult restart(){
            return RedirectToAction("index");
        }
    }
}