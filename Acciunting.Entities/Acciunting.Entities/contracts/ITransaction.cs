namespace Acciunting.Entities.contracts
{
    public interface ITransaction
    {
        decimal Amount { get; }
        IAccount CreditAccount { get; }
        IAccount DebitAccount { get; }
        string Description { get; }
    }
}