using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplicationModularized.Models
{
    public class Bank
    {
        public double IMPSOwnBank;
        public double RTGSOwnBank;
        public double IMPSOtherBank;
        public double RTGSOtherBank;
        public string BankID;
        public string BankName;
        public List<AccountHolder> AccountHolders = new List<AccountHolder>();
        public List<Currency> Currencies = new List<Currency>();
        public List<BankStaff> BankStaffs = new List<BankStaff>();
        public List<Transaction> Transactions = new List<Transaction>();
        public List<Account> Accounts = new List<Account>();

        public Bank()
        {
            this.BankID = $"{BankName.Substring(0, 3)}{DateTime.Now.ToString()}";

        }
        public Bank(double IMPSOwnBank, double RTGSOwnBank, double IMPSOtherBank, double RTGSOtherBank, string BankName, Currency currency)
        {
            this.IMPSOwnBank = IMPSOwnBank;
            this.RTGSOwnBank = RTGSOwnBank;
            this.IMPSOtherBank = IMPSOtherBank;
            this.RTGSOtherBank = RTGSOtherBank;
            this.BankName = BankName;
            this.BankID = $"{BankName.Substring(0, 3)}{DateTime.Now.ToString()}";
            this.Currencies.Add(currency);
            Console.WriteLine("Bank has been created!!!");


        }
    }
}
