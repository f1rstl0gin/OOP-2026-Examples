using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallinanBankLib
{
    public class CheckingAccount : Account
    {
        public decimal OverdraftLimit { get; private set; }

        public CheckingAccount(int accountNumber, string ownerName, decimal overdraftLimit)
           : base(accountNumber, ownerName, AccountType.Checking)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override bool Withdraw(decimal amount)
        {
            return WithdrawWithLimit(amount, OverdraftLimit);
        }
    }

}
