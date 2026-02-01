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

        public BankAccount CreateAccount(BankUser user, BankAccount.AccountType type)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var accountNumber = _nextAccountNumber++;
            BankAccount account = type switch
            {
                BankAccount.AccountType.Rewards => new RewardsAccount(accountNumber, user.FullName, 0.02m, 3, 2.50m),
                BankAccount.AccountType.Student => new StudentAccount(accountNumber, user.FullName, 250m),
                BankAccount.AccountType.Travel => new TravelAccount(accountNumber, user.FullName, 250m, 3.95m),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unsupported account type.")
            };

            user.AddAccount(account);
            return account;
        }

        public void CreateStandardAccounts(BankUser user)
        {
            CreateAccount(user, BankAccount.AccountType.Travel);
            CreateAccount(user, BankAccount.AccountType.Rewards);
            CreateAccount(user, BankAccount.AccountType.Student);
        }
    }
}
