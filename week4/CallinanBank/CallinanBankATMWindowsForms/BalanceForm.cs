namespace CallinanBankATMWindowsForms
{
    public partial class BalanceForm : Form
    {
        public BalanceForm()
        {
            InitializeComponent();
            AtmTheme.ApplyTo(this);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "RECEIPT PRINTING...\nTHANK YOU FOR BANKING WITH CALLINAN.", "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
