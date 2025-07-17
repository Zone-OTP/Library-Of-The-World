namespace LibraryOfTheWorld
{
    partial class SignUp
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
            label1 = new Label();
            label2 = new Label();
            NameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            SignUpButton = new Button();
            Switch = new Button();
            GovermentIDLabel = new Label();
            GovermentIdTextBox = new TextBox();
            EmailTextBox = new TextBox();
            EmailLable = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(219, 121);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(6);
            label1.Size = new Size(51, 27);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(198, 167);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(6);
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(69, 27);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // NameTextBox
            // 
            NameTextBox.Anchor = AnchorStyles.None;
            NameTextBox.Location = new Point(280, 121);
            NameTextBox.Margin = new Padding(4, 3, 4, 3);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(148, 23);
            NameTextBox.TabIndex = 2;
            NameTextBox.KeyPress += NameTextBox_KeyPress;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Anchor = AnchorStyles.None;
            PasswordTextBox.Location = new Point(280, 167);
            PasswordTextBox.Margin = new Padding(4, 3, 4, 3);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.Size = new Size(148, 23);
            PasswordTextBox.TabIndex = 3;
            PasswordTextBox.KeyPress += PasswordTextBox_KeyPress;
            // 
            // SignUpButton
            // 
            SignUpButton.Anchor = AnchorStyles.None;
            SignUpButton.Location = new Point(298, 330);
            SignUpButton.Margin = new Padding(4, 3, 4, 3);
            SignUpButton.Name = "SignUpButton";
            SignUpButton.Size = new Size(88, 27);
            SignUpButton.TabIndex = 4;
            SignUpButton.Text = "Sign Up";
            SignUpButton.UseVisualStyleBackColor = true;
            SignUpButton.Click += button1_Click;
            // 
            // Switch
            // 
            Switch.Location = new Point(15, 15);
            Switch.Margin = new Padding(4, 3, 4, 3);
            Switch.Name = "Switch";
            Switch.Size = new Size(113, 27);
            Switch.TabIndex = 6;
            Switch.Text = "Switch to Sign in\r\n";
            Switch.UseVisualStyleBackColor = true;
            Switch.Click += Switch_Click;
            // 
            // GovermentIDLabel
            // 
            GovermentIDLabel.AutoSize = true;
            GovermentIDLabel.Location = new Point(175, 213);
            GovermentIDLabel.Margin = new Padding(4, 0, 4, 0);
            GovermentIDLabel.Name = "GovermentIDLabel";
            GovermentIDLabel.Padding = new Padding(6);
            GovermentIDLabel.Size = new Size(92, 27);
            GovermentIDLabel.TabIndex = 7;
            GovermentIDLabel.Text = "Goverment ID";
            // 
            // GovermentIdTextBox
            // 
            GovermentIdTextBox.Location = new Point(280, 213);
            GovermentIdTextBox.Margin = new Padding(4, 3, 4, 3);
            GovermentIdTextBox.MaxLength = 11;
            GovermentIdTextBox.Name = "GovermentIdTextBox";
            GovermentIdTextBox.Size = new Size(148, 23);
            GovermentIdTextBox.TabIndex = 8;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(280, 257);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(148, 23);
            EmailTextBox.TabIndex = 9;
            EmailTextBox.KeyPress += EmailTextBox_KeyPress;
            // 
            // EmailLable
            // 
            EmailLable.AutoSize = true;
            EmailLable.Location = new Point(219, 260);
            EmailLable.Name = "EmailLable";
            EmailLable.Size = new Size(36, 15);
            EmailLable.TabIndex = 10;
            EmailLable.Text = "Email";
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(721, 425);
            Controls.Add(EmailLable);
            Controls.Add(EmailTextBox);
            Controls.Add(GovermentIdTextBox);
            Controls.Add(GovermentIDLabel);
            Controls.Add(Switch);
            Controls.Add(SignUpButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "SignUp";
            Text = "Library - SignUp";
            FormClosed += SignUp_FormClosed;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button SignUpButton;
        private System.Windows.Forms.Button Switch;
        private System.Windows.Forms.Label GovermentIDLabel;
        private System.Windows.Forms.TextBox GovermentIdTextBox;
        private TextBox EmailTextBox;
        private Label EmailLable;
    }
}

