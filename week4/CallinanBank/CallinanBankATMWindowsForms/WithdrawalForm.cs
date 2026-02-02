namespace CallinanBankATMWindowsForms
{
    public partial class WithdrawalForm : Form
    {
        public WithdrawalForm()
        {
            InitializeComponent();
            AtmTheme.ApplyTo(this);
        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, $"DISPENSING CASH: ${amountUpDown.Value:0.00}\nPLEASE TAKE YOUR NOTES.", "Withdraw", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
