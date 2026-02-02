using System;

namespace CallinanBankLib
{
    public class StudentAccount : Account
    {
        public decimal MonthlyInterestRate { get; private set; }
        public decimal DailyWithdrawalLimit { get; private set; }

        public StudentAccount(int accountNumber, string ownerName, decimal monthlyInterestRate, decimal dailyWithdrawalLimit)
            : base(accountNumber, ownerName, AccountType.Student)
        {
            MonthlyInterestRate = monthlyInterestRate;
            DailyWithdrawalLimit = dailyWithdrawalLimit;
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount > DailyWithdrawalLimit)
            {
                return false;
            }

            return base.Withdraw(amount);
        }

        public override void ApplyMonthlyUpdate()
        {
            if (MonthlyInterestRate <= 0)
            {
                return;
            }

            decimal interest = Balance * MonthlyInterestRate;
            if (interest > 0)
            {
                Credit(interest, $"Monthly interest applied: ${interest}");
            }
        }
    }
}
