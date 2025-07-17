namespace LibraryOfTheWorld
{
    partial class Signin
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
            NameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SignInButton = new Button();
            Switch = new Button();
            ForgotPasswordBtn = new Button();
            SuspendLayout();
            // 
            // NameTextBox
            // 
            NameTextBox.Anchor = AnchorStyles.None;
            NameTextBox.Location = new Point(280, 135);
            NameTextBox.Margin = new Padding(4, 3, 4, 3);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(148, 23);
            NameTextBox.TabIndex = 3;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Anchor = AnchorStyles.None;
            PasswordTextBox.Location = new Point(280, 202);
            PasswordTextBox.Margin = new Padding(4, 3, 4, 3);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.Size = new Size(148, 23);
            PasswordTextBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(220, 135);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(6);
            label1.Size = new Size(51, 27);
            label1.TabIndex = 5;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(200, 198);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(6);
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(69, 27);
            label2.TabIndex = 6;
            label2.Text = "Password";
            // 
            // SignInButton
            // 
            SignInButton.Anchor = AnchorStyles.None;
            SignInButton.Location = new Point(306, 291);
            SignInButton.Margin = new Padding(4, 3, 4, 3);
            SignInButton.Name = "SignInButton";
            SignInButton.Size = new Size(88, 27);
            SignInButton.TabIndex = 7;
            SignInButton.Text = "Sign In";
            SignInButton.UseVisualStyleBackColor = true;
            SignInButton.Click += SignInButton_Click;
            // 
            // Switch
            // 
            Switch.Location = new Point(14, 14);
            Switch.Margin = new Padding(4, 3, 4, 3);
            Switch.Name = "Switch";
            Switch.Size = new Size(119, 27);
            Switch.TabIndex = 8;
            Switch.Text = "Switch to Sign Up\r\n";
            Switch.UseVisualStyleBackColor = true;
            Switch.Click += Switch_Click;
            // 
            // ForgotPasswordBtn
            // 
            ForgotPasswordBtn.Location = new Point(280, 335);
            ForgotPasswordBtn.Name = "ForgotPasswordBtn";
            ForgotPasswordBtn.Size = new Size(148, 23);
            ForgotPasswordBtn.TabIndex = 9;
            ForgotPasswordBtn.Text = "Forgot Password?";
            ForgotPasswordBtn.UseVisualStyleBackColor = true;
            ForgotPasswordBtn.Click += ForgotPasswordBtn_Click;
            // 
            // Signin
            // 
            AcceptButton = SignInButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(721, 425);
            Controls.Add(ForgotPasswordBtn);
            Controls.Add(Switch);
            Controls.Add(SignInButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PasswordTextBox);
            Controls.Add(NameTextBox);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Signin";
            Text = "Library - Sign In";
            FormClosed += Signin_FormClosed;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SignInButton;
        private System.Windows.Forms.Button Switch;
        private Button ForgotPasswordBtn;
    }
}