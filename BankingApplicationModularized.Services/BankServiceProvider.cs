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
        public Manager CreateBank(string bankName, double impsOwnBank, double impsOtherBank, double rtgsOwnBank, double rtgsOtherBank)
        {
            string BankID = bankName.Substring(0, 3) + DateTime.Now.ToString();
            Currency NewCurrency = new Currency("INR", 1, true);
            Bank NewBank = new Bank(impsOwnBank, rtgsOwnBank, impsOtherBank, rtgsOtherBank, bankName, NewCurrency);
            this.Manager.Banks.Add(NewBank);
            return Manager;
        }
        public Manager AddCurrency(string bankID, string currencyName, int exchangeRate)
        {
            string CurrencyName = currencyName;
            int ExchangeRate = exchangeRate;
            Currency NewCurrency = new Currency(CurrencyName, ExchangeRate, false);
            this.Manager.Banks.Find(_ => (_.bankID.Equals(bankID))).currencies.Add(NewCurrency);
            return Manager;
        }
        public Manager EditCharges(string bankID, double rtgsSameBank, double rtgsOtherBank, double impsSameBank, double impsOtherBank)
        {
            double RTGSSameBank = rtgsSameBank;
            double IMPSSameBank = impsSameBank;
            double RTGSOtherBank = rtgsOtherBank;
            double IMPSOtherBank = impsOtherBank;
            var Bank = this.Manager.Banks.Find(_ => (string.Equals(_.bankID, bankID)));
            this.Manager.Banks.Remove(Bank);
            Bank.rtgsOwnBank = rtgsSameBank;
            Bank.rtgsOtherBank = rtgsOtherBank;
            Bank.impsOwnBank = impsSameBank;
            Bank.impsOtherBank = impsOtherBank;
            this.Manager.Banks.Add(Bank);
            return Manager;
        }                                          
        public void ViewAllTransactions(string bankID)
        {
            var Bank = this.Manager.Banks.Find(_ => (string.Equals(_.bankID, bankID)));
            foreach(Transaction transaction in Bank.transactions)
            {
                Console.WriteLine("Transaction ID" + transaction.TransactionID);
                Console.WriteLine("Transaction Date" + transaction.TransactionDate);
                Console.WriteLine("Amount" + transaction.Amount);
                Console.WriteLine("From" + transaction.From);
                Console.WriteLine("To" + transaction.To);
            }
        }
        public Manager CreateUser(AccountType accountType, string name, string userID, string password, string bankID, string address, string contact)
        {
            if (accountType.Equals("Account"))
            {
                string Name = name;
                var Bank = this.Manager.Banks.Find(_ => (string.Equals(_.bankID, bankID)));
                this.Manager.Banks.Remove(Bank);
                AccountHolder Holder = new AccountHolder(Bank.bankID, userID, password, name, address, contact);
                Bank.accountHolders.Add(Holder);
                this.Manager.Banks.Add(Bank);
            }
            else if (accountType.Equals("Staff"))
            {
                string builder = "";
                string EmployeeID = "";
                Random random = new Random();
                char ch;
                for (int i = 0; i < 10; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder += ch;
                }
                EmployeeID = builder;
                var Bank = this.Manager.Banks.Find(_ => (string.Equals(_.bankID, bankID)));
                this.Manager.Banks.Remove(Bank);
                BankStaff NewStaff = new BankStaff(EmployeeID, Bank.bankName, Bank.bankID, userID, password, name, address, contact);
                Bank.bankStaffs.Add(NewStaff);
                this.Manager.Banks.Add(Bank);
            }
            return this.Manager;
        }
    }
}
