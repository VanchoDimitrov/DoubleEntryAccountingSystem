using Acciunting.Entities.contracts;

namespace Acciunting.Entities
{
    public class Journal : IJournal
    {
        public List<Transaction> Transactions { get; private set; }
        
        public Journal()
        {
            Transactions = new List<Transaction>();
        }

        public void RecordTransaction(IAccount debitAccount, IAccount creditAccount, decimal amount, string description)
        {
            if (description == null || description == string.Empty)
                throw new ArgumentException("The description is empty.");

            if (debitAccount == creditAccount)
                throw new ArgumentException("The account is the same.");

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
}
