namespace Acciunting.Entities.contracts
{
    public interface IAccount
    {
        decimal Balance { get; set; }
        string Name { get; set; }

        void Credit(decimal amount);
        void Debit(decimal amount);
    }
}