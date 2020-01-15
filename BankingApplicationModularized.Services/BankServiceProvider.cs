using System;
using System.Collections.Generic;
using System.Text;
using BankingApplicationModularized.Models;
using System.Linq;

namespace BankingApplicationModularized.Services
{   
    public class BankServiceProvider
    {
        Manager Manager;

        public BankServiceProvider( Manager manager)
        {
            this.Manager = manager;
        }
        public Manager CreateAccount(string userID, string bankName)
        {
            string UserID = userID;
            string BankName = bankName;
            var Holder = this.Manager.Banks.Find(_ => (_.BankName.Equals(BankName))).AccountHolders.Find(_ => (_.UserID.Equals(UserID)));
            string AccountID = Holder.Name.Substring(0, 3) + DateTime.Now.ToString();
            Account account = new Account(UserID, AccountID, 0);
            this.Manager.Banks.Find(_ => (_.BankName.Equals(BankName))).Accounts.Add(account);
            return Manager;
        }
        public Manager DeleteAccount(string bankName, string accountID)
        {
            string BankName = bankName;
            string AccountID = accountID;
            var Account = this.Manager.Banks.Find(_ => (_.BankName.Equals(BankName))).Accounts.Find(_ => (_.AccountID.Equals(AccountID)));
            this.Manager.Banks.Find(_ => (_.BankName == BankName)).Accounts.Remove(Account);
            return Manager;
        }
        public Manager AddCurrency(string bankName, string currencyName, int exchangeRate)
        {
            string CurrencyName = currencyName;
            int ExchangeRate = exchangeRate;
            string BankName = bankName;
            Currency NewCurrency = new Currency(CurrencyName, ExchangeRate, false);
            this.Manager.Banks.Find(_ => (_.BankName.Equals(BankName))).Currencies.Add(NewCurrency);
            return Manager;
        }
        public Manager EditCharges(string bankName, double rtgsSameBank, double rtgsOtherBank, double impsSameBank, double impsOtherBank)
        {
            string BankName = bankName;
            double RTGSSameBank = rtgsSameBank;
            double IMPSSameBank = impsSameBank;
            double RTGSOtherBank = rtgsOtherBank;
            double IMPSOtherBank = impsOtherBank;
            var Bank = this.Manager.Banks.Find(_ => (_.BankName.Equals(BankName)));
            this.Manager.Banks.Remove(Bank);
            Bank.RTGSOwnBank = RTGSSameBank;
            Bank.RTGSOtherBank = RTGSOtherBank;
            Bank.IMPSOwnBank = IMPSSameBank;
            Bank.IMPSOtherBank = IMPSOtherBank;
            this.Manager.Banks.Add(Bank);
            return Manager;
        }                                          
        public void ViewAllTransactions(string bankName)
        {
            var Bank = this.Manager.Banks.Find(_ => _.BankName.Equals(bankName));
            foreach(Transaction transaction in Bank.Transactions)
            {
                Console.WriteLine("Transaction ID" + transaction.TransactionID);
                Console.WriteLine("Transaction Date" + transaction.TransactionDate);
                Console.WriteLine("Amount" + transaction.Amount);
                Console.WriteLine("From" + transaction.From);
                Console.WriteLine("To" + transaction.To);
            }
        }
    }
}
