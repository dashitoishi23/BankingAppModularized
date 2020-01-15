using System;
using System.Collections.Generic;
using System.Text;
using BankingApplicationModularized.Models;

namespace BankingApplicationModularized.Services
{
    public class ManagerServiceProvider
    {
        Manager Manager = new Manager();
        
        public ManagerServiceProvider(Manager manager)
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
        public Manager CreateAccount(string accountType, string name, string userID, string password, string bankName, string address, string contact) 
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
                this.Manager.Banks.Remove(Bank);
                AccountHolder Holder = new AccountHolder(Bank.BankID, UserID, Password, Name, Address, Contact);
                Bank.AccountHolders.Add(Holder);
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
                string Name = name;
                string Address = address;
                string BankName = bankName;
                string UserID = userID;
                string Password = password;
                string Contact = contact;
                var Bank = this.Manager.Banks.Find(_ => (_.BankName.Equals(BankName)));
                this.Manager.Banks.Remove(Bank);
                BankStaff NewStaff = new BankStaff(EmployeeID, BankName, Bank.BankID, UserID, Password, Name, Address, Contact);
                Bank.BankStaffs.Add(NewStaff);
                this.Manager.Banks.Add(Bank);
            }
            return this.Manager;
        }
    }
}
