using System;
using System.Collections.Generic;

namespace BankAccounts.Models
{
    public class User
    {
        public int UserID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public decimal TotalAmount {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public List<Transaction> Transactions {get; set;}

        public User(){
            CreatedAt = DateTime.Now;
            UpdatedAt=DateTime.Now;
            TotalAmount = 0.00m;
            Transactions = new List<Transaction>();
        }
    }
}