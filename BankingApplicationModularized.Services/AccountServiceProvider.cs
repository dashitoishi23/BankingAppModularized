using BankingApplicationModularized.Models;
using System;
using System.Linq;

namespace BankingApplicationModularized.Services{
    class AccountServiceProvider
    {
        AccountHolder Holder;
        Manager Manager;

    public AccountServiceProvider(AccountHolder holder, Manager manager)
    {
            this.Holder = holder;
            this.Manager = manager;
    }

    public double DepositAmount(double fundsToDeposit)
    {
        Holder.Funds += fundsToDeposit;
        return Holder.Funds;
    }
    public void WithdrawMoney(double fundsToWithdraw)
    {
        if (Holder.Funds < fundsToWithdraw)
        {
            throw new Exception("Insufficient Funds");
        }
        Holder.Funds -= fundsToWithdraw;
    }
    public void TransferFunds(double amountToTransfer, string to, string bankID)
    {
            if (Holder.Funds < amountToTransfer)
            {
                throw new Exception("Insufficient Funds");
            }
            var DebitedBank = this.Manager.Banks.Find(_ => (_.BankID == Holder.BankID));
            var DebitedAccount = DebitedBank.Accounts.Find(_ => (_.UserID == Holder.UserID));
            DebitedAccount.Funds -= amountToTransfer;
            var BeneficiaryBank = this.Manager.Banks.FirstOrDefault(_ => (_.BankID == bankID));
            var BeneficiaryAccount = BeneficiaryBank.Accounts.Find(_ => (_.AccountID == to));
            BeneficiaryAccount.Funds += amountToTransfer;
            string TransactionID = "TXN" + DateTime.Now.ToString();
            Holder.Transactions.Add(new Transaction(TransactionID, DateTime.Now, amountToTransfer, DebitedAccount.AccountID, to));
            DebitedBank.Transactions.Add(new Transaction(TransactionID, DateTime.Now, amountToTransfer, DebitedAccount.AccountID, to));
            BeneficiaryBank.Transactions.Add(new Transaction(TransactionID, DateTime.Now, amountToTransfer, to, DebitedAccount.AccountID));
            Console.WriteLine("Transferred succesfully" + amountToTransfer);
    }
    public void ViewTransactions()
        {
            foreach(Transaction transaction in Holder.Transactions)
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
