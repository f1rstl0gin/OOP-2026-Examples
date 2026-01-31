using System;

namespace CallinanBankLib
{
    public class TravelAccount : BankAccount
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
