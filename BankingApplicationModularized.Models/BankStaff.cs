using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplicationModularized.Models
{
    public class BankStaff
    {
        public string EmployeeID { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string BankName { get; set; }
        public string BankID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

        public BankStaff()
        {

        }

        public BankStaff(string employeeID, string bankName, string bankID, string userID, string password, string name, string address, string contact)
        {
            this.EmployeeID = employeeID;
            this.BankName = bankName;
            this.BankID = bankID;
            this.UserID = userID;
            this.Password = password;
            this.Name = name;
            this.Address = address;
            this.Contact = contact;
        }
    }
}
