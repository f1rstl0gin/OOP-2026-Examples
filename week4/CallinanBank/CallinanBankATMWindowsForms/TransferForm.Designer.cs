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
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.Padding = new Padding(24);
            mainLayout.RowCount = 6;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(560, 420);
            mainLayout.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Consolas", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(27, 24);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(506, 70);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "TRANSFER FUNDS";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accountLabel
            // 
            accountLabel.Dock = DockStyle.Fill;
            accountLabel.Location = new Point(27, 94);
            accountLabel.Name = "accountLabel";
            accountLabel.Size = new Size(506, 36);
            accountLabel.TabIndex = 1;
            accountLabel.Text = "DESTINATION ACCOUNT";
            accountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accountTextBox
            // 
            accountTextBox.Dock = DockStyle.Fill;
            accountTextBox.Location = new Point(27, 133);
            accountTextBox.Name = "accountTextBox";
            accountTextBox.PlaceholderText = "ACCT NUMBER";
            accountTextBox.Size = new Size(506, 23);
            accountTextBox.TabIndex = 2;
            accountTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // amountLabel
            // 
            amountLabel.Dock = DockStyle.Fill;
            amountLabel.Location = new Point(27, 180);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new Size(506, 36);
            amountLabel.TabIndex = 3;
            amountLabel.Text = "AMOUNT";
            amountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // amountUpDown
            // 
            amountUpDown.DecimalPlaces = 2;
            amountUpDown.Dock = DockStyle.Fill;
            amountUpDown.Increment = new decimal(new int[] { 25, 0, 0, 0 });
            amountUpDown.Location = new Point(27, 219);
            amountUpDown.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            amountUpDown.Minimum = new decimal(new int[] { 25, 0, 0, 0 });
            amountUpDown.Name = "amountUpDown";
            amountUpDown.Size = new Size(506, 23);
            amountUpDown.TabIndex = 4;
            amountUpDown.TextAlign = HorizontalAlignment.Center;
            amountUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // buttonLayout
            // 
            buttonLayout.ColumnCount = 2;
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonLayout.Controls.Add(transferButton, 0, 0);
            buttonLayout.Controls.Add(backButton, 1, 0);
            buttonLayout.Dock = DockStyle.Top;
            buttonLayout.Location = new Point(27, 279);
            buttonLayout.Name = "buttonLayout";
            buttonLayout.Padding = new Padding(40, 10, 40, 0);
            buttonLayout.RowCount = 1;
            buttonLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            buttonLayout.Size = new Size(506, 100);
            buttonLayout.TabIndex = 5;
            // 
            // transferButton
            // 
            transferButton.Dock = DockStyle.Fill;
            transferButton.Location = new Point(43, 13);
            transferButton.Name = "transferButton";
            transferButton.Size = new Size(207, 84);
            transferButton.TabIndex = 0;
            transferButton.Text = "TRANSFER";
            transferButton.Click += TransferButton_Click;
            // 
            // backButton
            // 
            backButton.Dock = DockStyle.Fill;
            backButton.Location = new Point(256, 13);
            backButton.Name = "backButton";
            backButton.Size = new Size(207, 84);
            backButton.TabIndex = 1;
            backButton.Text = "BACK";
            backButton.Click += BackButton_Click;
            // 
            // TransferForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 420);
            Controls.Add(mainLayout);
            Name = "TransferForm";
            Text = "Transfer";
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)amountUpDown).EndInit();
            buttonLayout.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
