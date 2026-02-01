using System.Collections.ObjectModel;
using System.Windows;
using CallinanBankLib;

namespace CallinanBankAtm;

public partial class MainWindow : Window
{
    private readonly CallinanBankService _bankService = new();
    private readonly ObservableCollection<string> _accountTypes = new();
    private BankUser? _currentUser;

    public MainWindow()
    {
        InitializeComponent();
        AccountTypesList.ItemsSource = _accountTypes;
    }

    private void OnRegisterClicked(object sender, RoutedEventArgs e)
    {
        RegisterStatusText.Text = string.Empty;
        LoginStatusText.Text = string.Empty;

        try
        {
            var fullName = RegisterFullNameTextBox.Text ?? string.Empty;
            var username = RegisterUsernameTextBox.Text ?? string.Empty;
            var pin = RegisterPinBox.Password ?? string.Empty;

            _currentUser = _bankService.RegisterUser(username, fullName, pin);
            RegisterStatusText.Text = "Profile created. Use Sign In to access accounts.";
            UpdateAccountTypes();
        }
        catch (Exception ex)
        {
            RegisterStatusText.Text = ex.Message;
        }
    }

    private void OnLoginClicked(object sender, RoutedEventArgs e)
    {
        RegisterStatusText.Text = string.Empty;
        LoginStatusText.Text = string.Empty;

        var username = LoginUsernameTextBox.Text ?? string.Empty;
        var pin = LoginPinBox.Password ?? string.Empty;
        var user = _bankService.Authenticate(username, pin);

        if (user == null)
        {
            LoginStatusText.Text = "Invalid username or PIN.";
            return;
        }

        _currentUser = user;
        UpdateAccountTypes();
    }

    private void OnRefreshClicked(object sender, RoutedEventArgs e)
    {
        UpdateAccountTypes();
    }

    private void UpdateAccountTypes()
    {
        _accountTypes.Clear();

        if (_currentUser == null)
        {
            WelcomeText.Text = "Sign in to view account types.";
            return;
        }

        WelcomeText.Text = $"Welcome, {_currentUser.FullName}.";
        foreach (var account in _currentUser.Accounts)
        {
            _accountTypes.Add($"{account.Type} account");
        }
    }
}
