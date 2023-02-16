namespace Acciunting.Entities.contracts
{
    public interface ITransaction
    {
        decimal Amount { get; }
        Account CreditAccount { get; }
        Account DebitAccount { get; }
        string Description { get; }
    }
}