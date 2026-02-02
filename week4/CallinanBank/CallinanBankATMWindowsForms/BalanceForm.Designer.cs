namespace CallinanBankATMWindowsForms
{
    partial class BalanceForm
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainLayout;
        private Label titleLabel;
        private Label accountLabel;
        private Label balanceLabel;
        private TableLayoutPanel buttonLayout;
        private Button printButton;
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
            balanceLabel = new Label();
            buttonLayout = new TableLayoutPanel();
            printButton = new Button();
            backButton = new Button();
            mainLayout.SuspendLayout();
            buttonLayout.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(titleLabel, 0, 0);
            mainLayout.Controls.Add(accountLabel, 0, 1);
            mainLayout.Controls.Add(balanceLabel, 0, 2);
            mainLayout.Controls.Add(buttonLayout, 0, 3);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.RowCount = 4;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Padding = new Padding(24);
            // 
            // titleLabel
            // 
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Text = "BALANCE INQUIRY";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accountLabel
            // 
            accountLabel.Dock = DockStyle.Fill;
            accountLabel.Text = "ACCOUNT: CHECKING 009872";
            accountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // balanceLabel
            // 
            balanceLabel.Dock = DockStyle.Fill;
            balanceLabel.Font = new Font("Consolas", 16F, FontStyle.Bold, GraphicsUnit.Point);
            balanceLabel.Text = "AVAILABLE BALANCE\n$ 1,240.00";
            balanceLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonLayout
            // 
            buttonLayout.ColumnCount = 2;
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonLayout.Controls.Add(printButton, 0, 0);
            buttonLayout.Controls.Add(backButton, 1, 0);
            buttonLayout.Dock = DockStyle.Top;
            buttonLayout.RowCount = 1;
            buttonLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            buttonLayout.Padding = new Padding(40, 20, 40, 0);
            // 
            // printButton
            // 
            printButton.Dock = DockStyle.Fill;
            printButton.Text = "PRINT RECEIPT";
            printButton.Click += PrintButton_Click;
            // 
            // backButton
            // 
            backButton.Dock = DockStyle.Fill;
            backButton.Text = "BACK";
            backButton.Click += BackButton_Click;
            // 
            // BalanceForm
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 380);
            Controls.Add(mainLayout);
            Text = "Balance";
            mainLayout.ResumeLayout(false);
            buttonLayout.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
