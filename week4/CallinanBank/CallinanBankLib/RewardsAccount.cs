using System;

namespace CallinanBankLib
{
    public class RewardsAccount : BankAccount
    {
        public decimal BonusRate { get; private set; }
        public int FreeWithdrawals { get; private set; }
        public decimal WithdrawalFee { get; private set; }
        private int _withdrawalsThisMonth;

        public RewardsAccount(int accountNumber, string ownerName, decimal bonusRate, int freeWithdrawals, decimal withdrawalFee)
            : base(accountNumber, ownerName, AccountType.Rewards)
        {
            BonusRate = bonusRate;
            FreeWithdrawals = freeWithdrawals;
            WithdrawalFee = withdrawalFee;
        }

        public override void Deposit(decimal amount)
        {
            base.Deposit(amount);

            if (amount > 0 && BonusRate > 0)
            {
                decimal bonus = amount * BonusRate;
                if (bonus > 0)
                {
                    Credit(bonus, $"Rewards bonus applied: ${bonus}");
                }
            }
        }

        public override bool Withdraw(decimal amount)
        {
            bool success = base.Withdraw(amount);
            if (!success)
            {
                return false;
            }

            _withdrawalsThisMonth++;
            if (_withdrawalsThisMonth > FreeWithdrawals && WithdrawalFee > 0)
            {
                bool feeApplied = WithdrawWithLimit(WithdrawalFee, 0m);
                if (feeApplied)
                {
                    RecordTransaction($"Withdrawal fee applied: ${WithdrawalFee}");
                }
            }

            return true;
        }

        public override void ApplyMonthlyUpdate()
        {
            _withdrawalsThisMonth = 0;
        }
    }
}
