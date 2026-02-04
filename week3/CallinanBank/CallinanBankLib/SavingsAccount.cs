using System;
using System.Collections.Generic;
using System.Text;

namespace CallinanBankLib
{
    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; private set; }
        public int WithdrawalLimit { get; private set; } = 3;
        private int _withdrawalsThisMonth;

        public SavingsAccount(int accountNumber, string ownerName, decimal interestRate)
                  : base(accountNumber, ownerName, AccountType.Savings) // KEY FIX: pass type
        {
            InterestRate = interestRate;
        }


        public void ApplyMonthlyInterest()
        {
            if (InterestRate <= 0) return;

            decimal interestAmount = Balance * InterestRate;
            if (interestAmount <= 0) return;

            Credit(interestAmount, $"Interest applied at {InterestRate:P}");
        }


        public void ResetMonthlyWithdrawals()
        {
            _withdrawalsThisMonth = 0;
        }

        public override bool Withdraw(decimal amount) // KEY FIX: base method is now virtual
        {
            if (_withdrawalsThisMonth >= WithdrawalLimit) return false;

            bool success = base.Withdraw(amount);
            if (success) _withdrawalsThisMonth++;

            return success;
        }
        public override void Deposit(decimal amount)
        {
            if (amount <= 0) throw new Exception();
            base.Deposit(amount);
        }
    }

}
