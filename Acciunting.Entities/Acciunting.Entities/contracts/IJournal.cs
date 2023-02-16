namespace Acciunting.Entities.contracts
{
    public interface IJournal
    {
        List<Transaction> Transactions { get; }

        void RecordTransaction(Account debitAccount, Account creditAccount, decimal amount, string description);
    }
}