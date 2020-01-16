using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplicationModularized.Models
{
    public class AccountHolder
    {
        public string BankID { get; set; }
        public string UserID { get; set; }
        public double Funds { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public List<Transaction> transactions = new List<Transaction>();


        public AccountHolder(string userID, string password)
        {
            this.UserID = userID;
            this.Password = password;
        }

        public AccountHolder(string bankID, string userID, string password, string name, string address, string contact)
        {
            this.BankID = bankID;
            this.UserID = userID;
            this.Password = password;
            this.Name = name;
            this.Address = address;
            this.Contact = contact;

        }
    }
}
