using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acciunting.Entities
{
    public class Journal
    {
        public List<Transaction> Transactions { get; private set; }

        public Journal()
        {
            Transactions = new List<Transaction>();
        }

        public void RecordTransaction(Account debitAccount, Account creditAccount, decimal amount, string description)
        {
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
