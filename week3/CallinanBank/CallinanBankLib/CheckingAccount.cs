using System;
using System.Collections.Generic;
using System.Text;

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
