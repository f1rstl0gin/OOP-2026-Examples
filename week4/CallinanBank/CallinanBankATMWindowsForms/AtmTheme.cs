using System.Drawing;

namespace CallinanBankATMWindowsForms
{
    internal static class AtmTheme
    {
        private static readonly Color ScreenBlack = Color.Black;
        private static readonly Color ScreenGreen = Color.Lime;
        private static readonly Color AccentOrange = Color.Orange;

        public static void ApplyTo(Form form)
        {
            form.BackColor = ScreenBlack;
            form.ForeColor = ScreenGreen;
            form.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.StartPosition = FormStartPosition.CenterScreen;

            ApplyToControls(form.Controls);
        }

        private static void ApplyToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.BackColor = ScreenBlack;
                control.ForeColor = ScreenGreen;

                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = AccentOrange;
                    button.FlatAppearance.BorderSize = 2;
                    button.Height = 44;
                }
                else if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Popup;
                }
                else if (control is Panel || control is TableLayoutPanel)
                {
                    control.BackColor = ScreenBlack;
                }

                if (control.HasChildren)
                {
                    ApplyToControls(control.Controls);
                }
            }
        }
    }
}
