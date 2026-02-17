using CallinanBankLib;

namespace CallinanBankMaui;

public partial class App : Application
{
    public static CallinanBankService BankService { get; } = new();

    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage());
    }
}
