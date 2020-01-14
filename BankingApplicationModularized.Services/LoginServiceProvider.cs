using System;
using BankingApplicationModularized.Models;

namespace BankingApplicationModularized.Services
{
    public class LoginServiceProvider
    {
        public bool ValidateManagerLogin(Manager manager, string userID, string password)
        {
            return (manager.userID == userID && manager.password == password) ? true : false;
        }
        public bool ValidateAccountHolderLogin(AccountHolder holder, string userID, string password)
        {
            return (holder.UserID == userID && holder.Password == password) ? true : false;
        }
        public bool ValidateBankStaffLogin(BankStaff staff, string userID, string password)
        {
            return (staff.UserID == userID && staff.Password == password) ? true : false;
        }
    }

}
