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
        public List<Transaction> Transactions = new List<Transaction>();


        public AccountHolder(string UserID, string Password)
        {
            this.UserID = UserID;
            this.Password = Password;
        }

        public AccountHolder(string BankID, string UserID, string Password, string Name, string Address, string Contact)
        {
            this.BankID = BankID;
            this.UserID = UserID;
            this.Password = Password;
            this.Name = Name;
            this.Address = Address;
            this.Contact = Contact;

        }

        public AccountHolder()
        {

        }
    }
}
