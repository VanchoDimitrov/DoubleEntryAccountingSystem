using Acciunting.Entities.contracts;

namespace Acciunting.Entities
{
    public class Transaction : ITransaction
    {
        public IAccount DebitAccount { get; private set; }
        public IAccount CreditAccount { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }

        public Transaction(IAccount debitAccount, IAccount creditAccount, decimal amount, string description)
        {
            DebitAccount = debitAccount;
            CreditAccount = creditAccount;
            Amount = amount;
            Description = description;
        }
    }
}
