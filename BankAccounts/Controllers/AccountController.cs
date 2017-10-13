using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BankAccounts.Models;
using BankAccounts.Controllers;
using System.Linq;

namespace BankAccounts.Controllers
{
    public class AccountController : Controller
    {
        private BankAccountsContext _context;
        public AccountController(BankAccountsContext context){
            _context = context;
        }


        [HttpGet]
        [Route("account")]
        public IActionResult Show(){
            int? id = HttpContext.Session.GetInt32("curID");
            User currentUser = _context.Users.Single(user => user.UserID == id);
            ViewBag.currentUser = currentUser;
            ViewBag.underZero = HttpContext.Session.GetInt32("UnderZero");
            ViewBag.UnderZeroMessage = HttpContext.Session.GetString("UnderZeroMessage");
            bool exists = _context.Transactions.Any(u => u.UserID == currentUser.UserID);
            if(exists == true){
                List<Transaction> allTransactions = _context.Transactions.Where(change => change.UserID ==currentUser.UserID).OrderByDescending(when => when.CreatedAt).ToList();
                ViewBag.allTransactions = allTransactions;
                ViewBag.exists = exists;
                return View("Show");
            }
            else{
                ViewBag.exists = exists;
                return View("Show");
            }
        }


        [HttpGet]
        [Route("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Login");
        }


        [HttpPost]
        [Route("newTransaction")]
        public IActionResult newTransaction(decimal Amount){
            HttpContext.Session.SetInt32("UnderZero", 0);
            int? id = HttpContext.Session.GetInt32("curID");
            User currentUser = _context.Users.Single(user => user.UserID == id);
            if(currentUser.TotalAmount + Amount <0){
                HttpContext.Session.SetInt32("UnderZero", 1);
                HttpContext.Session.SetString("UnderZeroMessage","You cannot withdraw more money than you have in your account.");
                return RedirectToAction("Show");
            }
            else{
                currentUser.TotalAmount = currentUser.TotalAmount + Amount;
                _context.SaveChanges();
                Transaction newTransaction = new Transaction{
                    Amount = Amount,
                    UserID = (int)id 
                };
                _context.Transactions.Add(newTransaction);
                _context.SaveChanges();
                return RedirectToAction("Show");
            }
        }
    }
    
}