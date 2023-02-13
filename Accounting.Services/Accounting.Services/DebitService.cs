using Acciunting.Entities;

namespace Accounting.Services
{
    public class DebitService : Account
    {
        public void Debit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Invalid debit amount");
            Balance += amount;
        }
        public void Credit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Invalid credit amount");
            Balance -= amount;
        }
    }
}
