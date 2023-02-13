using System.Security.Principal;
using System.Transactions;

namespace Accounting.Services
{
    public List<Transaction> Transactions { get; private set; }

    public Journal()
    {
        Transactions = new List<Transaction>();
    }

    public void RecordTransaction(Account debitAccount, Account creditAccount, decimal amount, string description)
    {
        if (amount == 0)
            throw new ArgumentException("The amount cannot be zero.");
        if (amount > 0)
        {
            debitAccount.Debit(amount);
            creditAccount.Credit(amount);
        }
        else
        {
            debitAccount.Credit(-amount);
            creditAccount.Debit(-amount);
        }
        Transactions.Add(new Transaction(debitAccount, creditAccount, amount, description));
    }
}