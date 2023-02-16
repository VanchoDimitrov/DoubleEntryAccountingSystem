using Acciunting.Entities;
using Acciunting.Entities.contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.Security.Cryptography.X509Certificates;

namespace Accpunting.Client
{
    public class Program
    {
        public static void Main()
        {
            var services = new ServiceCollection()
                .AddLogging(c => c.AddConsole(opt => opt.LogToStandardErrorThreshold = LogLevel.Debug))
                .AddSingleton<IAccount, Account>()
                .AddSingleton<IJournal, Journal>()
                .AddSingleton<ITransaction, Transaction>()
                .BuildServiceProvider();

            services.GetService<ILoggerFactory>();

            var logger = services?.GetService<ILoggerFactory>().CreateLogger<Program>();

            logger?.LogDebug("Start Console App");


            // Create a new instance of the Account class
            var cashAccount = new Account("Cash Account", 1000);
            var salesAccount = new Account("Sales Account", 0);
            var purchaseAccount = new Account("Purchase Account", 0);


            // Create a new instance of the Journal class
            // var journal = new Journal();

            // Instead of the above we use the registered interface.
            var journal = services.GetService<IJournal>();

            // Record a sales transaction
            journal?.RecordTransaction((Account)cashAccount, (Account)salesAccount, 500, "Sale of goods");
            // Cash Account will be debited by 500 and Sales Account will be credited by 500

            // Record a purchase transaction
            journal?.RecordTransaction((Account)cashAccount, (Account)purchaseAccount, -200, "Purchase of goods");
            // Cash Account will be credited by 200 and Purchase Account will be debited by 200

            // Display the account balances
            Console.WriteLine("Cash Account Balance: " + cashAccount?.Balance);
            Console.WriteLine("Sales Account Balance: " + salesAccount?.Balance);
            Console.WriteLine("Purchase Account Balance: " + purchaseAccount?.Balance);

            // Display the recorded transactions
            Console.WriteLine("\nRecorded Transactions:");
            foreach (var transaction in journal.Transactions)
            {
                Console.WriteLine("Description: " + transaction?.Description);
                Console.WriteLine("Debit Account: " + transaction?.DebitAccount.Name + " - Amount: " + transaction?.Amount);
                Console.WriteLine("Credit Account: " + transaction?.CreditAccount.Name + "\n");
            }
        }
    }
}