using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class CreditAccount : Account
    {
        public CreditAccount(string name, decimal initBalance, int creditLimit) : base(name, initBalance, -creditLimit) { }

        protected override void PerformEndMonthTransaction()
        {
            if (Balance < 0)
                Withdraw(-Balance * 0.07m, DateTime.Now, "Interest");
        }

        protected override Transaction checkWithdrawalLimit(bool isOverDraft) => isOverDraft? new Transaction(-20, DateTime.Now, "Interest Fee") : default;
    }
}
