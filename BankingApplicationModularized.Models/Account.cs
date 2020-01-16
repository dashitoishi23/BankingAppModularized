using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplicationModularized.Models
{
    public class Account
    {
        public string UserID { get; set; }
        public string AccountID { get; set; }
        public double Funds { get; set; }

        public Account(string userID, string accountID, double funds)
        {
            this.UserID = userID;
            this.AccountID = accountID;
            this.Funds = funds;
        }
    }
}
