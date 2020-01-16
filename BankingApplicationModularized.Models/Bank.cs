using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplicationModularized.Models
{
    public class Bank
    {
        public double impsOwnBank;
        public double rtgsOwnBank;
        public double impsOtherBank;
        public double rtgsOtherBank;
        public string bankID;
        public string bankName;
        public List<AccountHolder> accountHolders = new List<AccountHolder>();
        public List<Currency> currencies = new List<Currency>();
        public List<BankStaff> bankStaffs = new List<BankStaff>();
        public List<Transaction> transactions = new List<Transaction>();
        public List<Account> accounts = new List<Account>();

        public Bank(double impsOwnBank, double rtgsOwnBank, double impsOtherBank, double rtgsOtherBank, string bankName, Currency currency)
        {
            this.impsOwnBank = impsOwnBank;
            this.rtgsOwnBank = rtgsOwnBank;
            this.impsOtherBank = impsOtherBank;
            this.rtgsOtherBank = rtgsOtherBank;
            this.bankName = bankName;
            this.bankID = $"{bankName.Substring(0, 3)}{DateTime.Now.ToString()}";
            this.currencies.Add(currency);
            Console.WriteLine("Bank has been created!!!");


        }
    }
}
