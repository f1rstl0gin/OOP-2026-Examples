namespace CallinanBankATMWindowsForms
{
    public partial class DepositForm : Form
    {
        public DepositForm()
        {
            InitializeComponent();
            AtmTheme.ApplyTo(this);
        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, $"DEPOSIT ACCEPTED: ${amountUpDown.Value:0.00}\nPLEASE INSERT ENVELOPE.", "Deposit", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
