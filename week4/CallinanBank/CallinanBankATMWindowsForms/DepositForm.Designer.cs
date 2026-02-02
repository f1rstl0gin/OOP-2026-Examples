namespace CallinanBankATMWindowsForms
{
    partial class DepositForm
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainLayout;
        private Label titleLabel;
        private Label promptLabel;
        private NumericUpDown amountUpDown;
        private Label noteLabel;
        private TableLayoutPanel buttonLayout;
        private Button depositButton;
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
            promptLabel = new Label();
            amountUpDown = new NumericUpDown();
            noteLabel = new Label();
            buttonLayout = new TableLayoutPanel();
            depositButton = new Button();
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
            mainLayout.Controls.Add(promptLabel, 0, 1);
            mainLayout.Controls.Add(amountUpDown, 0, 2);
            mainLayout.Controls.Add(noteLabel, 0, 3);
            mainLayout.Controls.Add(buttonLayout, 0, 4);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.RowCount = 5;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Padding = new Padding(24);
            // 
            // titleLabel
            // 
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Text = "DEPOSIT FUNDS";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // promptLabel
            // 
            promptLabel.Dock = DockStyle.Fill;
            promptLabel.Text = "ENTER AMOUNT";
            promptLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // amountUpDown
            // 
            amountUpDown.DecimalPlaces = 2;
            amountUpDown.Dock = DockStyle.Fill;
            amountUpDown.Increment = 10;
            amountUpDown.Maximum = 5000;
            amountUpDown.Minimum = 10;
            amountUpDown.TextAlign = HorizontalAlignment.Center;
            amountUpDown.Value = 50;
            // 
            // noteLabel
            // 
            noteLabel.Dock = DockStyle.Fill;
            noteLabel.Text = "INSERT CASH/CHEQUE ENVELOPE";
            noteLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonLayout
            // 
            buttonLayout.ColumnCount = 2;
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonLayout.Controls.Add(depositButton, 0, 0);
            buttonLayout.Controls.Add(backButton, 1, 0);
            buttonLayout.Dock = DockStyle.Top;
            buttonLayout.RowCount = 1;
            buttonLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            buttonLayout.Padding = new Padding(40, 10, 40, 0);
            // 
            // depositButton
            // 
            depositButton.Dock = DockStyle.Fill;
            depositButton.Text = "DEPOSIT";
            depositButton.Click += DepositButton_Click;
            // 
            // backButton
            // 
            backButton.Dock = DockStyle.Fill;
            backButton.Text = "BACK";
            backButton.Click += BackButton_Click;
            // 
            // DepositForm
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 400);
            Controls.Add(mainLayout);
            Text = "Deposit";
            mainLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)amountUpDown).EndInit();
            buttonLayout.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
