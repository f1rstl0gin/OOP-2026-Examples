using System;
using System.Collections.Generic;
using System.Text;

namespace CallinanBankLib
{
    public class Account
    {

        // =========================
        // Attributes (State / Data)
        // =========================

        // Primitive & common types
        public int AccountNumber { get; private set; }
        public string OwnerName { get; private set; }
        public decimal Balance { get; protected set; }
        public bool IsActive { get; private set; }

        // Dates & enums
        public DateTime DateOpened { get; private set; }
        // =========================
        // Supporting Enum
        // =========================
        public enum AccountType
        {
            Checking,
            Savings,
            Business
        }
        public AccountType Type { get; private set; }

        // Collections
        private List<string> transactionHistory;

        // =========================
        // Constructors
        // =========================

        // Default constructor
        public Account()
        {
            AccountNumber = 0;
            OwnerName = "Unknown";
            Balance = 0.00m;
            IsActive = false;
            DateOpened = DateTime.Now;
            Type = AccountType.Checking;
            transactionHistory = new List<string>();
        }

        // Constructor with parameters
        public Account(int accountNumber, string ownerName, AccountType type)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            Type = type;
            Balance = 0.00m;
            IsActive = true;
            DateOpened = DateTime.Now;
            transactionHistory = new List<string>();

            transactionHistory.Add($"Account opened on {DateOpened}");
        }

        // =========================
        // Methods (Behavior)
        // =========================

        // Void method with parameters
        public virtual void Deposit(decimal amount)
        {
            if (!IsActive || amount <= 0)
            {
                return;
            }

            Balance += amount;
            transactionHistory.Add($"Deposited ${amount}");
        }

        // Method that returns a value
        public virtual bool Withdraw(decimal amount)
        {
            if (!IsActive || amount <= 0)
            {
                return false;
            }

            if (Balance >= amount)
            {
                Balance -= amount;
                transactionHistory.Add($"Withdrew ${amount}");
                return true;
            }

            return false;
        }

        // Method with no parameters
        public decimal GetBalance()
        {
            return Balance;
        }

        // Overloaded method (same name, different signature)
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

        // Method returning a collection
        public List<string> GetTransactionHistory()
        {
            return transactionHistory;
        }

        // Method returning formatted string
        public override string ToString()
        {
            return $"Account #{AccountNumber} ({Type}) - Owner: {OwnerName}, Balance: ${Balance}";
        }
    }


}
