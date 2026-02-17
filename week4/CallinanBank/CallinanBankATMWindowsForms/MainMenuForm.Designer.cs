namespace CallinanBankATMWindowsForms
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainLayout;
        private Label titleLabel;
        private Label subtitleLabel;
        private Label promptLabel;
        private TableLayoutPanel buttonLayout;
        private Button balanceButton;
        private Button withdrawButton;
        private Button depositButton;
        private Button transferButton;
        private Button exitButton;

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
            subtitleLabel = new Label();
            promptLabel = new Label();
            buttonLayout = new TableLayoutPanel();
            balanceButton = new Button();
            withdrawButton = new Button();
            depositButton = new Button();
            transferButton = new Button();
            exitButton = new Button();
            mainLayout.SuspendLayout();
            buttonLayout.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(titleLabel, 0, 0);
            mainLayout.Controls.Add(subtitleLabel, 0, 1);
            mainLayout.Controls.Add(promptLabel, 0, 2);
            mainLayout.Controls.Add(buttonLayout, 0, 3);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.RowCount = 4;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Padding = new Padding(24);
            // 
            // titleLabel
            // 
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Consolas", 20F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Text = "CALLINAN BANK ATM";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // subtitleLabel
            // 
            subtitleLabel.Dock = DockStyle.Fill;
            subtitleLabel.Text = "SECURE TERMINAL - 1989 EDITION";
            subtitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // promptLabel
            // 
            promptLabel.Dock = DockStyle.Fill;
            promptLabel.Text = "SELECT A TRANSACTION";
            promptLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonLayout
            // 
            buttonLayout.ColumnCount = 1;
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            buttonLayout.Controls.Add(balanceButton, 0, 0);
            buttonLayout.Controls.Add(withdrawButton, 0, 1);
            buttonLayout.Controls.Add(depositButton, 0, 2);
            buttonLayout.Controls.Add(transferButton, 0, 3);
            buttonLayout.Controls.Add(exitButton, 0, 4);
            buttonLayout.Dock = DockStyle.Fill;
            buttonLayout.RowCount = 5;
            buttonLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            buttonLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            buttonLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            buttonLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            buttonLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            buttonLayout.Padding = new Padding(80, 20, 80, 20);
            // 
            // balanceButton
            // 
            balanceButton.Dock = DockStyle.Fill;
            balanceButton.Text = "BALANCE INQUIRY";
            balanceButton.Click += BalanceButton_Click;
            // 
            // withdrawButton
            // 
            withdrawButton.Dock = DockStyle.Fill;
            withdrawButton.Text = "WITHDRAW CASH";
            withdrawButton.Click += WithdrawButton_Click;
            // 
            // depositButton
            // 
            depositButton.Dock = DockStyle.Fill;
            depositButton.Text = "DEPOSIT FUNDS";
            depositButton.Click += DepositButton_Click;
            // 
            // transferButton
            // 
            transferButton.Dock = DockStyle.Fill;
            transferButton.Text = "TRANSFER FUNDS";
            transferButton.Click += TransferButton_Click;
            // 
            // exitButton
            // 
            exitButton.Dock = DockStyle.Fill;
            exitButton.Text = "EXIT";
            exitButton.Click += ExitButton_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 480);
            Controls.Add(mainLayout);
            Text = "Main Menu";
            mainLayout.ResumeLayout(false);
            buttonLayout.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
