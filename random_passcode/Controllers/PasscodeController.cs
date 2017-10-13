using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Session;

namespace random_passcode.Controllers
{
    public class PasscodeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult generate(){
            int? count = HttpContext.Session.GetInt32("count");
            if (count == null){
                count = 0;
            }
            count = count + 1;
            string codeChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rando = new Random();
            string passcode = "";
            for (int i =1;1<=14;i++){
                passcode = passcode + codeChars[rando.Next(0,codeChars.Length)];
            }

            ViewBag.passcode = passcode;
            ViewBag.count = count;
            HttpContext.Session.SetInt32("count", (int)count);

            return View("generate");
        }
    }
}