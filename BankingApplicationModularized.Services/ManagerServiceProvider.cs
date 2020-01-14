using System;
using System.Collections.Generic;
using System.Text;
using BankingApplicationModularized.Models;

namespace BankingApplicationModularized.Services
{
    class ManagerServiceProvider
    {
        Manager Manager;
        
        public ManagerServiceProvider(Manager manager)
        {
            this.Manager = manager;
        }
        public void CreateBank(string bankName, double impsOwnBank, double impsOtherBank, double rtgsOwnBank, double rtgsOtherBank)
        {
            string BankID = bankName.Substring(0, 3) + DateTime.Now.ToString();
            Currency NewCurrency = new Currency("INR", 1, true);
            Bank NewBank = new Bank(impsOwnBank, rtgsOwnBank, impsOtherBank, rtgsOtherBank, bankName, NewCurrency);
        }
        public void CreateAccount(string accountType, string name, string userID, string password, string bankName, string address, string contact) 
        {
            if (accountType.Equals("Account"))
            {
                string Name = name;
                string UserID = userID;
                string Password = password;
                string BankName = bankName;
                string Address = address;
                string Contact = contact;
                var Bank = this.Manager.Banks.Find(_ => (_.BankName.Equals(BankName)));
                AccountHolder Holder = new AccountHolder(Bank.BankID, UserID, Password, Name, Address, Contact);
                Bank.AccountHolders.Add(Holder);
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
                string Name = name;
                string Address = address;
                string BankName = bankName;
                string UserID = userID;
                string Password = password;
                string Contact = contact;
                var Bank = this.Manager.Banks.Find(_ => (_.BankName.Equals(BankName)));
                BankStaff NewStaff = new BankStaff(EmployeeID, BankName, Bank.BankID, UserID, Password, Name, Address, Contact);
                Bank.BankStaffs.Add(NewStaff);
            }
        }
    }
}
