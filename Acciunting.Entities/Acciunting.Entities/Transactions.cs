using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acciunting.Entities
{
    public class Transaction
    {
        public Account DebitAccount { get; private set; }
        public Account CreditAccount { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }

        public Transaction(Account debitAccount, Account creditAccount, decimal amount, string description)
        {
            DebitAccount = debitAccount;
            CreditAccount = creditAccount;
            Amount = amount;
            Description = description;
        }
    }
}
