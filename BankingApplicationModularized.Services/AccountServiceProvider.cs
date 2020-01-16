using BankingApplicationModularized.Models;
using System;
using System.Linq;

namespace BankingApplicationModularized.Services{
    public class AccountServiceProvider
    {
        AccountHolder Holder;
        Manager Manager;

    public AccountServiceProvider(Manager manager)
    {
            this.Manager = manager;
    }
    public Manager CreateAccount(string userID, string bankID)
    {
        var Holder = this.Manager.Banks.Find(_=>(string.Equals(_.bankID, bankID))).accountHolders.Find(_ => (string.Equals(_.UserID, userID)));
        string AccountID = Holder.Name.Substring(0, 3) + DateTime.Now.ToString();
        Account account = new Account(userID, AccountID, 0);
        this.Manager.Banks.Find(_ => (string.Equals(_.bankID, bankID))).accounts.Find(_ => (string.Equals(_.AccountID, AccountID)));
        return Manager;
    }
    public Manager DeleteAccount(string bankID, string accountID)
    {
        string AccountID = accountID;
        var Account = this.Manager.Banks.Find(_ => (_.bankID.Equals(bankID))).accounts.Find(_ => (_.AccountID.Equals(accountID)));
        this.Manager.Banks.Find(_ => (_.bankID == bankID)).accounts.Remove(Account);
        return Manager;
    }
        public AccountHolder DepositAmount(double fundsToDeposit)
    {
            Holder.Funds += fundsToDeposit;
            return Holder;
    }
    public AccountHolder WithdrawMoney(double fundsToWithdraw, string userID, string bankID)
    {
        var Holder = this.Manager.Banks.Find(_ => (string.Equals(_.bankID, bankID))).accountHolders.Find(_ => (string.Equals(_.UserID, userID)));
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
            var DebitedBank = this.Manager.Banks.Find(_ => (_.bankID == Holder.BankID));
            var DebitedAccount = DebitedBank.accounts.Find(_ => (_.UserID == Holder.UserID));
            var BeneficiaryBank = this.Manager.Banks.FirstOrDefault(_ => (_.bankID == bankID));
            var BeneficiaryAccount = BeneficiaryBank.accounts.Find(_ => (_.AccountID == to));
            if (DebitedBank.bankID.Equals(BeneficiaryBank.bankID))
            {
                if (trasnferType.Equals("RTGS"))
                    Charges = DebitedBank.rtgsOwnBank * amountToTransfer;
                else
                    Charges = DebitedBank.impsOwnBank * amountToTransfer;
            }
            else
            {
                if (trasnferType.Equals("RTGS"))
                    Charges = DebitedBank.rtgsOtherBank * amountToTransfer;
                else
                    Charges = DebitedBank.impsOtherBank * amountToTransfer;
            }
            DebitedAccount.Funds -= (amountToTransfer + Charges);
            BeneficiaryAccount.Funds += amountToTransfer;
            Holder.transactions.Add(new Transaction(amountToTransfer, DebitedAccount.AccountID, to));
            DebitedBank.transactions.Add(new Transaction( amountToTransfer, DebitedAccount.AccountID, to));
            BeneficiaryBank.transactions.Add(new Transaction(amountToTransfer, to, DebitedAccount.AccountID));
    }
    public void ViewTransactions()
        {
            foreach(Transaction transaction in Holder.transactions)
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
