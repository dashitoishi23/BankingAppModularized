using BankingApplicationModularized.Models;
using System;
using System.Linq;

namespace BankingApplicationModularized.Services{
    public class AccountServiceProvider
    {
        AccountHolder Holder;
        Manager Manager;

    public AccountServiceProvider(AccountHolder holder, Manager manager)
    {
            this.Holder = holder;
            this.Manager = manager;
    }

    public AccountHolder DepositAmount(double fundsToDeposit)
    {
            Holder.Funds += fundsToDeposit;
            return Holder;
    }
    public AccountHolder WithdrawMoney(double fundsToWithdraw)
    {
        if (Holder.Funds < fundsToWithdraw)
        {
            throw new Exception("Insufficient Funds");
        }
        Holder.Funds -= fundsToWithdraw;
            return Holder;
    }
    public void TransferFunds(double amountToTransfer, string to, string bankID, string trasnferType)
    {
            if (Holder.Funds < amountToTransfer)
            {
                throw new Exception("Insufficient Funds");
            }
            double Charges = 0;
            var DebitedBank = this.Manager.Banks.Find(_ => (_.BankID == Holder.BankID));
            var DebitedAccount = DebitedBank.Accounts.Find(_ => (_.UserID == Holder.UserID));
            var BeneficiaryBank = this.Manager.Banks.FirstOrDefault(_ => (_.BankID == bankID));
            var BeneficiaryAccount = BeneficiaryBank.Accounts.Find(_ => (_.AccountID == to));
            if (DebitedBank.BankName.Equals(BeneficiaryBank.BankName))
            {
                if (trasnferType.Equals("RTGS"))
                    Charges = DebitedBank.RTGSOwnBank * amountToTransfer;
                else
                    Charges = DebitedBank.IMPSOwnBank * amountToTransfer;
            }
            else
            {
                if (trasnferType.Equals("RTGS"))
                    Charges = DebitedBank.RTGSOtherBank * amountToTransfer;
                else
                    Charges = DebitedBank.IMPSOtherBank * amountToTransfer;
            }
            DebitedAccount.Funds -= (amountToTransfer + Charges);
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
