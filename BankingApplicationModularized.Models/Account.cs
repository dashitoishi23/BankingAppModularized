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

        public Account(string UserID, string AccountID, double Funds)
        {
            this.UserID = UserID;
            this.AccountID = AccountID;
            this.Funds = Funds;
        }
    }
}
