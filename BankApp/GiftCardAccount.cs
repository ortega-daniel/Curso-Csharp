using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class GiftCardAccount : Account
    {
        public GiftCardAccount(string name, decimal initBalance) : base(name, initBalance) { }

        public string GetAccountHistory() 
        {
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
    }
}
