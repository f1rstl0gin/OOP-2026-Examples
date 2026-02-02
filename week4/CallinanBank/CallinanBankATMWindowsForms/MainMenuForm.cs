namespace CallinanBankATMWindowsForms
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            AtmTheme.ApplyTo(this);
        }

        private void BalanceButton_Click(object sender, EventArgs e)
        {
            using var form = new BalanceForm();
            form.ShowDialog(this);
        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            using var form = new WithdrawalForm();
            form.ShowDialog(this);
        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            using var form = new DepositForm();
            form.ShowDialog(this);
        }

        private void TransferButton_Click(object sender, EventArgs e)
        {
            using var form = new TransferForm();
            form.ShowDialog(this);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
