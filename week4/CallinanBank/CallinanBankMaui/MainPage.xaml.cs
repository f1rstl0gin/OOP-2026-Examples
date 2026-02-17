using System.Collections.ObjectModel;
using CallinanBankLib;

namespace CallinanBankMaui;

public partial class MainPage : ContentPage
{
    private readonly ObservableCollection<string> _accountTypes = new();
    private BankUser? _currentUser;

    public MainPage()
    {
        InitializeComponent();
        AccountTypesView.ItemsSource = _accountTypes;
    }

    private void OnRegisterClicked(object sender, EventArgs e)
    {
        RegisterStatusLabel.Text = string.Empty;
        LoginStatusLabel.Text = string.Empty;

        try
        {
            var fullName = RegisterFullNameEntry.Text ?? string.Empty;
            var username = RegisterUsernameEntry.Text ?? string.Empty;
            var pin = RegisterPinEntry.Text ?? string.Empty;

            _currentUser = App.BankService.RegisterUser(username, fullName, pin);
            RegisterStatusLabel.Text = "Profile created. You're ready to sign in.";
            UpdateAccountTypes();
        }
        catch (Exception ex)
        {
            RegisterStatusLabel.Text = ex.Message;
        }
    }

    private void OnLoginClicked(object sender, EventArgs e)
    {
        RegisterStatusLabel.Text = string.Empty;
        LoginStatusLabel.Text = string.Empty;

        var username = LoginUsernameEntry.Text ?? string.Empty;
        var pin = LoginPinEntry.Text ?? string.Empty;
        var user = App.BankService.Authenticate(username, pin);

        if (user == null)
        {
            LoginStatusLabel.Text = "Invalid username or PIN.";
            return;
        }

        _currentUser = user;
        UpdateAccountTypes();
    }

    private void UpdateAccountTypes()
    {
        _accountTypes.Clear();

        if (_currentUser == null)
        {
            WelcomeLabel.Text = "Sign in to view account types.";
            return;
        }

        WelcomeLabel.Text = $"Welcome back, {_currentUser.FullName}.";
        foreach (var account in _currentUser.Accounts)
        {
            _accountTypes.Add($"{account.Type} account");
        }
    }
}
