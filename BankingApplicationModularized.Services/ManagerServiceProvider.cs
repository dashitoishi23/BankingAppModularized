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
