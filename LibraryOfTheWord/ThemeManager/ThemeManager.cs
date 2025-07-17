using System.Runtime.InteropServices;

namespace LibraryOfTheWorld.Themes
{
    public static class ThemeManager
    {
        public static bool IsDarkMode { get; set; } = true;

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(nint hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(nint hWnd, nint hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern nint SendMessage(nint hWnd, uint Msg, nint wParam, nint lParam);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOZORDER = 0x0004;
        private const uint SWP_FRAMECHANGED = 0x0020;
        private const uint WM_NCCALCSIZE = 0x0083;


        public static void ApplyTheme(Control control)
        {
            if (control is Form form && Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= 18362)
            {
                int attribute = 20;
                if (Environment.OSVersion.Version.Build < 19041)
                {
                    attribute = 19;
                }
                int useImmersiveDarkMode = IsDarkMode ? 1 : 0;
                DwmSetWindowAttribute(form.Handle, attribute, ref useImmersiveDarkMode, sizeof(int));

                SetWindowPos(form.Handle, nint.Zero, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED);
                SendMessage(form.Handle, WM_NCCALCSIZE, nint.Zero, nint.Zero);
            }

            if (IsDarkMode)
            {
                control.BackColor = Color.FromArgb(30, 30, 30);
                control.ForeColor = Color.White;

                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.FromArgb(50, 50, 50);
                    button.ForeColor = Color.White;
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = Color.FromArgb(40, 40, 40);
                    textBox.ForeColor = Color.White;
                }
                else if (control is DataGridView grid)
                {
                    grid.BackgroundColor = Color.FromArgb(30, 30, 30);
                    grid.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
                    grid.DefaultCellStyle.ForeColor = Color.White;


                    grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70);
                    grid.DefaultCellStyle.SelectionForeColor = Color.White;


                    grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    grid.EnableHeadersVisualStyles = false;


                    grid.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
                    grid.RowHeadersDefaultCellStyle.ForeColor = Color.White;
                    grid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70);
                    grid.RowHeadersDefaultCellStyle.SelectionForeColor = Color.White;


                }
            }
            else
            {
                control.BackColor = SystemColors.Control;
                control.ForeColor = SystemColors.ControlText;

                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Standard;
                    button.BackColor = SystemColors.Control;
                    button.ForeColor = SystemColors.ControlText;
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = SystemColors.Window;
                    textBox.ForeColor = SystemColors.WindowText;
                }
                else if (control is DataGridView grid)
                {
                    grid.BackgroundColor = SystemColors.Control;
                    grid.DefaultCellStyle.BackColor = Color.White;
                    grid.DefaultCellStyle.ForeColor = Color.Black;
                    grid.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                    grid.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
                    grid.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                    grid.EnableHeadersVisualStyles = true;
                }

            }



            foreach (Control child in control.Controls)
            {
                ApplyTheme(child);
            }
            control.Refresh();

        }
    }
}