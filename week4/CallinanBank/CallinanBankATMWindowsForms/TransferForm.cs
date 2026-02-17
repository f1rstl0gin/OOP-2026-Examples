namespace CallinanBankATMWindowsForms
{
    public partial class TransferForm : Form
    {
        public TransferForm()
        {
            InitializeComponent();
            AtmTheme.ApplyTo(this);
        }

        private void TransferButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, $"TRANSFER QUEUED\nTO: {accountTextBox.Text}\nAMOUNT: ${amountUpDown.Value:0.00}", "Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
