using System;

namespace CallinanBankLib
{
    public class TravelAccount : Account
    {
        public decimal OverdraftLimit { get; private set; }
        public decimal MonthlyFee { get; private set; }

        public TravelAccount(int accountNumber, string ownerName, decimal overdraftLimit, decimal monthlyFee)
            : base(accountNumber, ownerName, AccountType.Travel)
        {
            OverdraftLimit = overdraftLimit;
            MonthlyFee = monthlyFee;
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0m)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive.");

            }
            if (amount > Balance + OverdraftLimit)
            {
                throw new InvalidOperationException("Withdrawal amount exceeds balance and overdraft limit.");
            }
            return WithdrawWithLimit(amount, OverdraftLimit);
        }

        public override void ApplyMonthlyUpdate()
        {
            if (MonthlyFee <= 0m)
            {
                return;
            }

            bool feeApplied = WithdrawWithLimit(MonthlyFee, OverdraftLimit);
            if (feeApplied)
            {
                RecordTransaction($"Monthly fee applied: ${MonthlyFee}");
            }
        }
    }
}
