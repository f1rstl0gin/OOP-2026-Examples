using CallinanBankLib;
using Xunit;

namespace CallinanBankLib.Tests;

public class CallinanBankServiceTests
{
    [Fact]
    public void RegisterUserCreatesStandardAccounts()
    {
        var service = new CallinanBankService();

        var user = service.RegisterUser("savannah", "Savannah Harper", "1234");

        Assert.Equal("Savannah Harper", user.FullName);
        Assert.Equal(3, user.Accounts.Count);
        Assert.Contains(user.Accounts, account => account.Type == BankAccount.AccountType.Travel);
        Assert.Contains(user.Accounts, account => account.Type == BankAccount.AccountType.Rewards);
        Assert.Contains(user.Accounts, account => account.Type == BankAccount.AccountType.Student);
    }

    [Fact]
    public void AuthenticateReturnsNullForInvalidPin()
    {
        var service = new CallinanBankService();
        service.RegisterUser("mason", "Mason Liu", "4321");

        var result = service.Authenticate("mason", "0000");

        Assert.Null(result);
    }

    [Fact]
    public void AuthenticateReturnsUserForValidCredentials()
    {
        var service = new CallinanBankService();
        service.RegisterUser("isla", "Isla Carter", "9876");

        var result = service.Authenticate("isla", "9876");

        Assert.NotNull(result);
        Assert.Equal("Isla Carter", result!.FullName);
    }

    [Fact]
    public void RegisterUserPreventsDuplicates()
    {
        var service = new CallinanBankService();
        service.RegisterUser("harper", "Harper Bates", "5555");

        var exception = Assert.Throws<InvalidOperationException>(() =>
            service.RegisterUser("harper", "Harper Bates", "5555"));

        Assert.Equal("A user with that username already exists.", exception.Message);
    }
}
