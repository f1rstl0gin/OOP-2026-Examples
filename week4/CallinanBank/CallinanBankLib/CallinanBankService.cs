using System;
using System.Collections.Generic;

namespace CallinanBankLib
{
    public class CallinanBankService
    {
        private readonly Dictionary<string, BankUser> _users;
        private int _nextAccountNumber;

        public CallinanBankService()
        {
            _users = new Dictionary<string, BankUser>(StringComparer.OrdinalIgnoreCase);
            _nextAccountNumber = 1000;
        }

        public BankUser RegisterUser(string username, string fullName, string pin)
        {
            if (_users.ContainsKey(username))
            {
                throw new InvalidOperationException("A user with that username already exists.");
            }

            var user = new BankUser(username, fullName, pin);
            _users[username] = user;
            CreateStandardAccounts(user);
            return user;
        }

        public BankUser? Authenticate(string username, string pin)
        {
            if (!_users.TryGetValue(username, out var user))
            {
                return null;
            }

            return user.ValidatePin(pin) ? user : null;
        }

        public Account CreateAccount(BankUser user, Account.AccountType type)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var accountNumber = _nextAccountNumber++;
            Account account = type switch
            {
                Account.AccountType.Rewards => new RewardsAccount(accountNumber, user.FullName, 0.02m, 3, 2.50m),
                Account.AccountType.Student => new StudentAccount(accountNumber, user.FullName, 2.50m, 100m),
                Account.AccountType.Travel => new TravelAccount(accountNumber, user.FullName, 250m, 3.95m),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unsupported account type.")
            };

            user.AddAccount(account);
            return account;
        }

        public void CreateStandardAccounts(BankUser user)
        {
            CreateAccount(user, Account.AccountType.Travel);
            CreateAccount(user, Account.AccountType.Rewards);
            CreateAccount(user, Account.AccountType.Student);
        }
    }
}
