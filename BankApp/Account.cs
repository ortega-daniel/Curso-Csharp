using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Account
    {
        public string Owner { get; set; }
        public string Number { get; set; }
        public decimal Balance
        {
            get 
            {
                decimal balance = 0;
                foreach (var transaction in TransactionList)
                {
                    balance += transaction.Amount;
                }

                return balance;
            }
        }

        public List<Transaction> TransactionList = new List<Transaction>();
        private readonly int _minBalance;
        private static int accountNumberSeed = 1234567890;

        public Account(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

        public Account(string owner, decimal initBalance, int minBalance)
        {
            Owner = owner;
            _minBalance = minBalance;
            
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            if (initBalance > 0) 
            {
                Deposit(initBalance, DateTime.Now, "Initial balance");
            }
        }

        public void Deposit(decimal amount, DateTime date, string description) 
        {
            if (amount <= 0) 
                Console.WriteLine("Deposit amount must be greater than 0");

            TransactionList.Add(new Transaction(amount, date, description));
        }

        public void Withdraw(decimal amount, DateTime date, string description) 
        {
            if (amount <= 0) 
                Console.WriteLine("Withdraw amount must be greater than 0");

            var txn = checkWithdrawalLimit(Balance - amount < _minBalance);
            TransactionList.Add(new Transaction(-amount, date, description));

            if (txn != null) 
            {
                TransactionList.Add(txn);
            }
        }

        protected virtual Transaction checkWithdrawalLimit(bool isOverdraft) 
        {
            if (isOverdraft)
                throw new InvalidOperationException("You don't have enough funds");
            else 
                return default;
        }

        public string GetAccountHistory()
        {
            PerformEndMonthTransaction();

            decimal balance = 0;
            StringBuilder history = new();
            history.AppendLine("Date\t\tAmount\tBalance\tDescription\t");

            foreach (var txn in TransactionList)
            {
                balance += txn.Amount;
                history.AppendLine($"{txn.Date.ToString("d")}\t{txn.Amount}\t{balance}\t{txn.Description}");
            }

            return history.ToString();
        }

        protected virtual void PerformEndMonthTransaction() { }
    }
}
