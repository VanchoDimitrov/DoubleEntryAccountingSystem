using System.Xml.Linq;
using Acciunting.Entities.contracts;

namespace Acciunting.Entities
{
    public class Account : IAccount
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public Account(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }

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