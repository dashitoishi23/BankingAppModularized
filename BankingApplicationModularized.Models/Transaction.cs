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

        public Transaction(string TransactionID, DateTime transactionTime, double Amount, string From, string To)
        {
            this.TransactionID = TransactionID;
            this.TransactionDate = transactionTime;
            this.Amount = Amount;
            this.From = From;
            this.To = To;
        }
    }
}
