namespace CallinanBankATMWindowsForms
{
    partial class TransferForm
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainLayout;
        private Label titleLabel;
        private Label accountLabel;
        private TextBox accountTextBox;
        private Label amountLabel;
        private NumericUpDown amountUpDown;
        private TableLayoutPanel buttonLayout;
        private Button transferButton;
        private Button backButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mainLayout = new TableLayoutPanel();
            titleLabel = new Label();
            accountLabel = new Label();
            accountTextBox = new TextBox();
            amountLabel = new Label();
            amountUpDown = new NumericUpDown();
            buttonLayout = new TableLayoutPanel();
            transferButton = new Button();
            backButton = new Button();
            mainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)amountUpDown).BeginInit();
            buttonLayout.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(titleLabel, 0, 0);
            mainLayout.Controls.Add(accountLabel, 0, 1);
            mainLayout.Controls.Add(accountTextBox, 0, 2);
            mainLayout.Controls.Add(amountLabel, 0, 3);
            mainLayout.Controls.Add(amountUpDown, 0, 4);
            mainLayout.Controls.Add(buttonLayout, 0, 5);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.RowCount = 6;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Padding = new Padding(24);
            // 
            // titleLabel
            // 
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Text = "TRANSFER FUNDS";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accountLabel
            // 
            accountLabel.Dock = DockStyle.Fill;
            accountLabel.Text = "DESTINATION ACCOUNT";
            accountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accountTextBox
            // 
            accountTextBox.Dock = DockStyle.Fill;
            accountTextBox.PlaceholderText = "ACCT NUMBER";
            accountTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // amountLabel
            // 
            amountLabel.Dock = DockStyle.Fill;
            amountLabel.Text = "AMOUNT";
            amountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // amountUpDown
            // 
            amountUpDown.DecimalPlaces = 2;
            amountUpDown.Dock = DockStyle.Fill;
            amountUpDown.Increment = 25;
            amountUpDown.Maximum = 5000;
            amountUpDown.Minimum = 25;
            amountUpDown.TextAlign = HorizontalAlignment.Center;
            amountUpDown.Value = 100;
            // 
            // buttonLayout
            // 
            buttonLayout.ColumnCount = 2;
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonLayout.Controls.Add(transferButton, 0, 0);
            buttonLayout.Controls.Add(backButton, 1, 0);
            buttonLayout.Dock = DockStyle.Top;
            buttonLayout.RowCount = 1;
            buttonLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            buttonLayout.Padding = new Padding(40, 10, 40, 0);
            // 
            // transferButton
            // 
            transferButton.Dock = DockStyle.Fill;
            transferButton.Text = "TRANSFER";
            transferButton.Click += TransferButton_Click;
            // 
            // backButton
            // 
            backButton.Dock = DockStyle.Fill;
            backButton.Text = "BACK";
            backButton.Click += BackButton_Click;
            // 
            // TransferForm
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 420);
            Controls.Add(mainLayout);
            Text = "Transfer";
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)amountUpDown).EndInit();
            buttonLayout.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
