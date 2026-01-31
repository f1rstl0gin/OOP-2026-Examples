using System;
using System.Collections.Generic;
using System.Text;

namespace CallinanBankLib
{
    public class BankAccount
    {

        // =========================
        // Attributes (State / Data)
        // =========================

        // Primitive & common types
        public int AccountNumber { get; private set; }
        public string OwnerName { get; private set; }
        private decimal _balance;
        public decimal Balance
        {
            get { return _balance; }
        }
        public bool IsActive { get; private set; }

        // Dates & enums
        public DateTime DateOpened { get; private set; }

        // =========================
        // Supporting Enum
        // =========================
        public enum AccountType
        {
            Travel,
            Rewards,
            Student
        }
        public AccountType Type { get; private set; }

        // Collections
        private readonly List<string> transactionHistory;

        // =========================
        // Constructors
        // =========================

        // Default constructor
        public BankAccount()
        {
            AccountNumber = 0;
            OwnerName = "Unknown";
            _balance = 0.00m;
            IsActive = false;
            DateOpened = DateTime.Now;
            Type = AccountType.Travel;
            transactionHistory = new List<string>();
        }

        // Constructor with parameters
        public BankAccount(int accountNumber, string ownerName, AccountType type)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            Type = type;
            _balance = 0.00m;
            IsActive = true;
            DateOpened = DateTime.Now;
            transactionHistory = new List<string>();

            transactionHistory.Add($"Account opened on {DateOpened}");
        }

        // =========================
        // Methods (Behavior)
        // =========================

        public virtual void Deposit(decimal amount)
        {
            if (!IsActive || amount <= 0)
            {
                return;
            }

            Credit(amount, $"Deposited ${amount}");
        }

        public virtual bool Withdraw(decimal amount)
        {
            return WithdrawWithLimit(amount, 0m);
        }

        public virtual void ApplyMonthlyUpdate()
        {
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        public void CloseAccount()
        {
            IsActive = false;
            transactionHistory.Add("Account closed");
        }

        public void CloseAccount(string reason)
        {
            IsActive = false;
            transactionHistory.Add($"Account closed: {reason}");
        }

        public List<string> GetTransactionHistory()
        {
            return new List<string>(transactionHistory);
        }

        public override string ToString()
        {
            return $"Account #{AccountNumber} ({Type}) - Owner: {OwnerName}, Balance: ${Balance}";
        }

        public static decimal operator +(BankAccount left, BankAccount right)
        {
            return left._balance + right._balance;
        }

        protected void RecordTransaction(string message)
        {
            transactionHistory.Add(message);
        }

        protected void Credit(decimal amount, string message)
        {
            _balance += amount;
            RecordTransaction(message);
        }

        protected bool WithdrawWithLimit(decimal amount, decimal overdraftLimit)
        {
            if (!IsActive || amount <= 0)
            {
                return false;
            }

            if (_balance + overdraftLimit < amount)
            {
                return false;
            }

            _balance -= amount;
            RecordTransaction($"Withdrew ${amount}");
            return true;
        }
    }
}
