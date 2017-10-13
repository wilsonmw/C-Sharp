using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;

namespace passcode_try2.Controllers
{
    public class PasscodeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult index(){
            int? count = HttpContext.Session.GetInt32("count");
            if (count == null){
                count = 0;
            }
            count = count + 1;
            string codeChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rando = new Random();
            string passcode = "";
            for (int i =1;i<=14;i++){
                passcode = passcode + codeChars[rando.Next(0,codeChars.Length)];
            }

            ViewBag.passcode = passcode;
            ViewBag.count = count;
            HttpContext.Session.SetInt32("count", (int)count);

            return View("index");
        }

        [HttpPost]
        [Route("reset")]
        public IActionResult reset(){
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }
    }
}