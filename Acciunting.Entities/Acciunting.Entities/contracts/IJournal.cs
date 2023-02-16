namespace Acciunting.Entities.contracts
{
    public interface IJournal
    {
        List<Transaction> Transactions { get; }

        void RecordTransaction(IAccount debitAccount, IAccount creditAccount, decimal amount, string description);
    }
}