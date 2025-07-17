namespace LibraryOfTheWorld.Forms
{
    partial class ChangePasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            EmailTextBox = new TextBox();
            SendEmailButton = new Button();
            SuspendLayout();
            // 
            // EmailTextBox
            // 
            EmailTextBox.Anchor = AnchorStyles.None;
            EmailTextBox.Location = new Point(95, 55);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(280, 23);
            EmailTextBox.TabIndex = 0;
            // 
            // SendEmailButton
            // 
            SendEmailButton.Location = new Point(190, 110);
            SendEmailButton.Name = "SendEmailButton";
            SendEmailButton.Size = new Size(75, 23);
            SendEmailButton.TabIndex = 1;
            SendEmailButton.Text = "Send Email";
            SendEmailButton.UseVisualStyleBackColor = true;
            SendEmailButton.Click += SendEmailButton_Click;
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 211);
            Controls.Add(SendEmailButton);
            Controls.Add(EmailTextBox);
            Name = "ChangePasswordForm";
            Text = "ChangePasswordForm";
            Load += ChangePasswordForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox EmailTextBox;
        private Button SendEmailButton;
    }
}