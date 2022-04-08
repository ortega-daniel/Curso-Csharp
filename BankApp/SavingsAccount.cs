using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class SavingsAccount : Account
    {
        private const int bonusLimit = 500;

        public SavingsAccount(string name, decimal initBalance, int minBalance) : base(name, initBalance, minBalance) { }

        protected override void PerformEndMonthTransaction()
        {
            if (Balance > bonusLimit)
                Deposit((Balance - bonusLimit)* 0.05m, DateTime.Now, "Savings Deposit");
        }
    }
}