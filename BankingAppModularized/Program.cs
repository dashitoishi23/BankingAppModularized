using System;
using System.Linq;
using BankingApplicationModularized.Models;
using BankingApplicationModularized.Services;
namespace BankingAppModularized
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager managerControl = new Manager();
            while (true)
            {
                Console.WriteLine("Welcome to this banking app");
                Console.WriteLine("1. Continue as an existing bank ");
                Console.WriteLine("2. Continue as a manager");
                Console.WriteLine("3. Exit");
                int UserInput = Convert.ToInt32(Console.ReadLine());
                ManagerServiceProvider ManagerServices = new ManagerServiceProvider(managerControl);
                switch (UserInput)
                {
                    case 1:
                        Console.WriteLine("1. Continue as an account holder");
                        Console.WriteLine("2. Continue as a bank staff");
                        UserInput = Convert.ToInt32(Console.ReadLine());
                        switch (UserInput)
                        {
                            case 1:
                                LoginServiceProvider LoginHelper = new LoginServiceProvider();
                                Console.WriteLine("Enter Bank");
                                string BankName = Console.ReadLine();
                                var Bank = managerControl.Banks.FirstOrDefault(_ => (_.BankName.Equals(BankName)));
                                Console.WriteLine("Enter user ID");
                                string UserID = Console.ReadLine();
                                var AccountHolder = Bank.AccountHolders.FirstOrDefault(_ => (_.UserID.Equals(UserID)));
                                Console.WriteLine("Enter Password");
                                string Password = Console.ReadLine();
                                try
                                {
                                    if (LoginHelper.ValidateAccountHolderLogin(AccountHolder, UserID, Password))
                                    {
                                        Console.WriteLine("1. Deposit Money");
                                        Console.WriteLine("2. Withdraw Money");
                                        Console.WriteLine("3. Transfer Funds");
                                        Console.WriteLine("4. View Your Transactions");
                                        UserInput = Convert.ToInt32(Console.ReadLine());
                                        AccountServiceProvider ServiceProvider = new AccountServiceProvider(AccountHolder, managerControl);
                                        switch (UserInput)
                                        {
                                            case 1:
                                                Console.WriteLine("Enter the amount you want to deposit");
                                                double fundsToDeposit = Convert.ToDouble(Console.ReadLine());
                                                AccountHolder = ServiceProvider.DepositAmount(fundsToDeposit);
                                                Console.WriteLine("Deposited successfully");
                                                break;
                                            case 2:
                                                Console.WriteLine("Enter amount you want to withdraw");
                                                double amountToWithdraw = Convert.ToDouble(Console.ReadLine());
                                                try
                                                {
                                                    AccountHolder = ServiceProvider.WithdrawMoney(amountToWithdraw);
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine(e);
                                                }
                                                break;
                                            case 3:
                                                Console.WriteLine("Enter amount to be transferred");
                                                double amountToTransfer = Convert.ToDouble(Console.ReadLine());
                                                Console.WriteLine("Whom to send money (Account ID)");
                                                string beneficiaryAccount = Console.ReadLine();
                                                Console.WriteLine("Enter Bank ID to transfer to");
                                                string bankID = Console.ReadLine();
                                                Console.WriteLine("Give the type of transfer");
                                                string transferType = Console.ReadLine().ToUpper();
                                                try
                                                {
                                                    ServiceProvider.TransferFunds(amountToTransfer, beneficiaryAccount, bankID, transferType);
                                                    Console.WriteLine("Transferred Successfully");
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine(e);
                                                }
                                                break;
                                            case 4:
                                                ServiceProvider.ViewTransactions();
                                                break;
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong username or password");
                                    }
                                }
                                catch (Exception e)
                                {

                                    Console.WriteLine("Invalid Credentials");
                                }

                                break;
                            case 2:
                                Program.ContinueAsBankStaff(managerControl);
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("1.Create Bank");
                        Console.WriteLine("2. Create User");
                        UserInput = Convert.ToInt32(Console.ReadLine());
                        switch (UserInput)
                        {
                            case 1:
                                Program.CreateNewBank(ManagerServices, managerControl);
                                break;
                            case 2:
                                Program.CreateAccount(ManagerServices, managerControl);
                                break;
                        }
                        break;
                    case 3:
                        System.Environment.Exit(0);
                        break;
                }
            }
        }
        public static void ContinueAsBankStaff(Manager managerControl)
        {
            LoginServiceProvider LoginHelper = new LoginServiceProvider();
            Console.WriteLine("Enter Bank");
            string BankName = Console.ReadLine();
            var Bank = managerControl.Banks.FirstOrDefault(_ => (_.BankName.Equals(BankName)));
            Console.WriteLine(Bank.BankName);
            Console.WriteLine("Enter user ID");
            string UserID = Console.ReadLine();
            var BankStaff = Bank.BankStaffs.FirstOrDefault(_ => (_.UserID.Equals(UserID)));
            Console.WriteLine(BankStaff.BankName);
            Console.WriteLine("Enter Password");
            string Password = Console.ReadLine();
            try
            {
                if (LoginHelper.ValidateBankStaffLogin(BankStaff, UserID, Password))
                {
                    Console.WriteLine("1. Create Account");
                    Console.WriteLine("2. Delete Account");
                    Console.WriteLine("3. Add Currency");
                    Console.WriteLine("4. Edit Charges");
                    Console.WriteLine("5. View Transactions");
                    int UserInput = Convert.ToInt32(Console.ReadLine());
                    BankServiceProvider ServiceProvider = new BankServiceProvider(managerControl);
                    switch (UserInput)
                    {
                        case 1:
                            Console.WriteLine("Enter User ID");
                            UserID = Console.ReadLine();
                            Console.WriteLine("Name of bank");
                            BankName = Console.ReadLine();
                            managerControl = ServiceProvider.CreateAccount(UserID, BankName);
                            break;
                        case 2:
                            Console.WriteLine("Enter Bank Name");
                            BankName = Console.ReadLine();
                            Console.WriteLine("Enter Account ID");
                            string AccountID = Console.ReadLine();
                            managerControl = ServiceProvider.DeleteAccount(BankName, AccountID);
                            break;
                        case 3:
                            Console.WriteLine("Enter Bank Name");
                            BankName = Console.ReadLine();
                            Console.WriteLine("Enter Currency Name");
                            string CurrencyName = Console.ReadLine();
                            Console.WriteLine("Enter Exchange Rate");
                            int ExchangeRate = Convert.ToInt32(Console.ReadLine());
                            managerControl = ServiceProvider.AddCurrency(BankName, CurrencyName, ExchangeRate);
                            break;
                        case 4:
                            Console.WriteLine("Enter Bank Name");
                            BankName = Console.ReadLine();
                            Console.WriteLine("Enter new RTGS charges for same bank");
                            double RTGSOwn = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter new RTGS charges for other bank");
                            double RTGSOther = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter IMPS charges for same bank");
                            double IMPSOwn = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter IMPS charges for other bank");
                            double IMPSOther = Convert.ToDouble(Console.ReadLine());
                            managerControl = ServiceProvider.EditCharges(BankName, RTGSOwn, RTGSOther, IMPSOwn, IMPSOther);
                            break;
                        case 5:
                            Console.WriteLine("Enter Bank Name");
                            BankName = Console.ReadLine();
                            ServiceProvider.ViewAllTransactions(BankName);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong username or password");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Invalid");
            }

        }
        public static void CreateNewBank(ManagerServiceProvider managerServices, Manager managerControl)
        {
            Console.WriteLine("Give a name to the bank");
            string BankName = Console.ReadLine();
            Console.WriteLine("Give charges for RTGS own bank");
            double RTGSOwn = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Give charges for RTGS otehr bank");
            double RTGSOther = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Give charges for IMPS own bank");
            double IMPSOwn = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Give charges for IMPS otehr bank");
            double IMPSOther = Convert.ToDouble(Console.ReadLine());
            managerControl = managerServices.CreateBank(BankName, IMPSOwn, IMPSOther, RTGSOwn, RTGSOther);
        }
        public static void CreateAccount(ManagerServiceProvider managerServices, Manager managerControl)
        {
            Console.WriteLine("1. Create an AccountHolder user");
            Console.WriteLine("2. Create a Bank Staff");
            int UserInput = Convert.ToInt32(Console.ReadLine());
            switch (UserInput)
            {
                case 1:
                    Console.WriteLine("Enter your name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter USER ID");
                    string UserID = Console.ReadLine();
                    Console.WriteLine("Enter password");
                    string Password = Console.ReadLine();
                    Console.WriteLine("Bank Name");
                    string BankName = Console.ReadLine();
                    Console.WriteLine("Address");
                    string Address = Console.ReadLine();
                    Console.WriteLine("Contact");
                    string Contact = Console.ReadLine();
                    managerControl = managerServices.CreateAccount(AccountType.Account.ToString(), BankName, UserID, Password, BankName, Address, Contact);
                    break;
                case 2:
                    Console.WriteLine("Enter your name");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter USER ID");
                    UserID = Console.ReadLine();
                    Console.WriteLine("Enter password");
                    Password = Console.ReadLine();
                    Console.WriteLine("Bank Name");
                    BankName = Console.ReadLine();
                    Console.WriteLine("Address");
                    Address = Console.ReadLine();
                    Console.WriteLine("Contact");
                    Contact = Console.ReadLine();
                    managerControl = managerServices.CreateAccount(AccountType.Staff.ToString(), BankName, UserID, Password, BankName, Address, Contact);
                    break;
            }
        }


    }
}
