using System;
using System.Collections.Generic;

namespace CallinanBankLib
{
    public class BankUser
    {
        private readonly string _pin;
        private readonly List<BankAccount> _accounts;

        public BankUser(string username, string fullName, string pin)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username is required.", nameof(username));
            }

            if (string.IsNullOrWhiteSpace(pin))
            {
                throw new ArgumentException("PIN is required.", nameof(pin));
            }

            Username = username.Trim();
            FullName = string.IsNullOrWhiteSpace(fullName) ? "Callinan Customer" : fullName.Trim();
            _pin = pin.Trim();
            _accounts = new List<BankAccount>();
        }

        public string Username { get; }
        public string FullName { get; }

        public IReadOnlyList<BankAccount> Accounts => _accounts.AsReadOnly();

        public bool ValidatePin(string pin)
        {
            return string.Equals(_pin, pin?.Trim(), StringComparison.Ordinal);
        }

        public void AddAccount(BankAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            _accounts.Add(account);
        }
    }
}
