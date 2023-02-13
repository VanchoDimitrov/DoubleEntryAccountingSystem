using Acciunting.Entities;

namespace Accounting.Test
{
    public class AccountTests
    {
        [Fact]
        public void RecordTransaction_NegativeAmmount()
        {
            // Arrange
            var debitAccount = new Account("Debit Account", 1000);
            var creditAccount = new Account("Credit Account", 0);
            var journal = new Journal();

            // Act
            journal.RecordTransaction(debitAccount, creditAccount, 500, "Test Transaction");

            // Assert
            Assert.Equal(-500, creditAccount.Balance); // -500
            Assert.Equal(1, journal.Transactions.Count);
        }

        [Fact]
        public void RecordTransaction_PositiveAmmount()
        {
            // Arrange
            var debitAccount = new Account("Debit Account", 1000);
            var creditAccount = new Account("Credit Account", 0);
            var journal = new Journal();

            // Act
            journal.RecordTransaction(debitAccount, creditAccount, -500, "Test Transaction"); // 500

            // Assert
            Assert.Equal(500, debitAccount.Balance);
            Assert.Equal(1, journal.Transactions.Count);
        }

        [Fact]
        public void RecordTransaction_SameAccount()
        {
            // Arrange
            var debitAccount = new Account("Debit Account", 1000);
            var journal = new Journal();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => journal.RecordTransaction(debitAccount, debitAccount, 500, "Test Transaction")); // 1000 1000
        }

        [Fact]

        public void RecordTransaction_LargeAmount()
        {
            // Arrange
            var debitAccount = new Account("Debit Account", 10000000000000000);
            var creditAccount = new Account("Credit Account", 0);
            var journal = new Journal();

            // Act
            journal.RecordTransaction(debitAccount, creditAccount, 10000000000000000, "Test Transaction");

            // Assert
            Assert.Equal(20000000000000000, debitAccount.Balance); // 20000000000000000
            Assert.Equal(1, journal.Transactions.Count);
        }

        [Fact]
        public void RecordTransaction_LargeNumberOfTransactions()
        {
            // Arrange
            var debitAccount = new Account("Debit Account", 1000000000);
            var creditAccount = new Account("Credit Account", 0);
            var journal = new Journal();

            // Act
            for (int i = 0; i < 10000; i++)
            {
                journal.RecordTransaction(debitAccount, creditAccount, 1, "Test Transaction");
            }

            // Assert
            Assert.Equal(1000010000, debitAccount.Balance); // 1000010000
            Assert.Equal(-10000, creditAccount.Balance); // -10000
            Assert.Equal(10000, journal.Transactions.Count);
        }

        [Fact]
        public void RecordTransaction_NullOrEmptyDescription()
        {
            // Arrange
            var debitAccount = new Account("Debit Account", 1000);
            var creditAccount = new Account("Credit Account", 0);
            var journal = new Journal();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => journal.RecordTransaction(debitAccount, creditAccount, 500, null));
            Assert.Throws<ArgumentException>(() => journal.RecordTransaction(debitAccount, creditAccount, 500, string.Empty));
        }


    }
}