using System;

namespace BankAccounts.Models
{
    public class Transaction
    {
        public int TransactionID {get; set;}
        public DateTime CreatedAt {get; set;}
        public decimal Amount {get; set;}
        public int UserID {get; set;}
        public User User {get; set;}

        public Transaction(){
            CreatedAt = DateTime.Now;
        }
    }
}