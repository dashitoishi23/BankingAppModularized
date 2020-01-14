using System;
using BankingApplicationModularized.Models;

namespace BankingApplicationModularized.Services
{
    public class LoginServiceProvider
    {
        public bool ValidateManagerLogin(string userID, string password)
        {
            return (userID == "Admin" && password == "Admin");
        }
        public bool ValidateAccountHolderLogin(AccountHolder holder, string userID, string password)
        {
            return (holder.UserID == userID && holder.Password == password);
        }
        public bool ValidateBankStaffLogin(BankStaff staff, string userID, string password)
        {
            return (staff.UserID == userID && staff.Password == password);
        }
    }

}
