using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplicationModularized.Models
{
    public class Transaction
    {
        public string TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public double Amount { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public Transaction()
        {

        }

        public Transaction(double Amount, string From, string To)
        {
            this.TransactionID = "TXN" + DateTime.Now.ToString("MMddyyyy");
            this.TransactionDate = DateTime.Now;
            this.Amount = Amount;
            this.From = From;
            this.To = To;
        }
    }
}
