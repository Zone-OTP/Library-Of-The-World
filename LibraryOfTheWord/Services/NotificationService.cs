namespace LibraryOfTheWorld.Services
{
    public class NotificationService
    {

        public static void ShowMessage(string message, string title = "Information")
        {
            using (var dialog = new Form())
            {
                dialog.Text = title;
                dialog.Size = new Size(400, 200);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;

                var label = new Label()
                {
                    Text = message,
                    AutoSize = false,
                    Size = new Size(360, 100),
                    Location = new Point(20, 20),
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Control.DefaultBackColor,

                };

                var okButton = new System.Windows.Forms.Button()
                {
                    Text = "OK",
                    Size = new Size(75, 30),
                    Location = new Point(200, 120),
                    DialogResult = DialogResult.OK
                };

                dialog.Controls.Add(label);
                dialog.Controls.Add(okButton);
                dialog.AcceptButton = okButton;
                dialog.ShowDialog();
            }


        }
        public static DialogResult ShowMessageYesNo(string message, string title = "Information")
        {
            using (var dialog = new Form())
            {
                dialog.Text = title;
                dialog.Size = new Size(400, 200);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;

                var label = new Label()
                {
                    Text = message,
                    AutoSize = false,
                    Size = new Size(360, 100),
                    Location = new Point(20, 20),
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Control.DefaultBackColor,

                };

                var yesButton = new System.Windows.Forms.Button()
                {
                    Text = "Yes",
                    Size = new Size(75, 30),
                    Location = new Point(100, 120),
                    DialogResult = DialogResult.Yes
                };

                var noButton = new System.Windows.Forms.Button()
                {
                    Text = "No",
                    Size = new Size(75, 30),
                    Location = new Point(200, 120),
                    DialogResult = DialogResult.No,
                };
                dialog.Controls.Add(label);
                dialog.Controls.Add(yesButton);
                dialog.AcceptButton = yesButton;
                dialog.Controls.Add(noButton);

                return dialog.ShowDialog();
            }

        }
    }

}
