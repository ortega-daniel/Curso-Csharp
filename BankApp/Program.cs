using System;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Credit Account:");
            CreditAccount creditAccount = new("Daniel", 0, 1000);
            creditAccount.Withdraw(200, DateTime.Now.AddDays(-1), "Withdraw");
            creditAccount.Deposit(200, DateTime.Now.AddDays(-1), "Deposit");
            creditAccount.Withdraw(200, DateTime.Now.AddDays(-1), "Withdray");
            Console.WriteLine(creditAccount.GetAccountHistory());

            Console.WriteLine("\nSavings Account:");

            SavingsAccount savingsAccount = new("Daniel", 0, 0);
            savingsAccount.Deposit(250, DateTime.Now.AddDays(-2), "Deposit");
            savingsAccount.Deposit(250, DateTime.Now.AddDays(1), "Deposit");
            savingsAccount.Deposit(250, DateTime.Now.AddDays(0), "Deposit");
            Console.WriteLine(savingsAccount.GetAccountHistory());
        }
    }
}
