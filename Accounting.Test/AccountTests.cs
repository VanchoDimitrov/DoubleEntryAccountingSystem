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
    }
}