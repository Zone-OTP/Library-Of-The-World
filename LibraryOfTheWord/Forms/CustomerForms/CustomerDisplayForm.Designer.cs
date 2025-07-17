namespace LibraryOfTheWorld.Forms
{
    partial class CustomerDisplayForm
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
            NameOfCustomer = new Label();
            EmailOfCustomer = new Label();
            LibraryCardOfCustomer = new Label();
            GovermentIdOfCustomer = new Label();
            IdOfCustomer = new Label();
            DeleteAccButton = new Button();
            ChangePasswordButton = new Button();
            SuspendLayout();
            // 
            // NameOfCustomer
            // 
            NameOfCustomer.AutoSize = true;
            NameOfCustomer.Location = new Point(75, 55);
            NameOfCustomer.Name = "NameOfCustomer";
            NameOfCustomer.Size = new Size(38, 15);
            NameOfCustomer.TabIndex = 0;
            NameOfCustomer.Text = "label1";
            // 
            // EmailOfCustomer
            // 
            EmailOfCustomer.AutoSize = true;
            EmailOfCustomer.Location = new Point(75, 95);
            EmailOfCustomer.Name = "EmailOfCustomer";
            EmailOfCustomer.Size = new Size(38, 15);
            EmailOfCustomer.TabIndex = 1;
            EmailOfCustomer.Text = "label1";
            // 
            // LibraryCardOfCustomer
            // 
            LibraryCardOfCustomer.AutoSize = true;
            LibraryCardOfCustomer.Location = new Point(75, 135);
            LibraryCardOfCustomer.Name = "LibraryCardOfCustomer";
            LibraryCardOfCustomer.Size = new Size(38, 15);
            LibraryCardOfCustomer.TabIndex = 2;
            LibraryCardOfCustomer.Text = "label2";
            // 
            // GovermentIdOfCustomer
            // 
            GovermentIdOfCustomer.AutoSize = true;
            GovermentIdOfCustomer.Location = new Point(75, 175);
            GovermentIdOfCustomer.Name = "GovermentIdOfCustomer";
            GovermentIdOfCustomer.Size = new Size(38, 15);
            GovermentIdOfCustomer.TabIndex = 3;
            GovermentIdOfCustomer.Text = "label3";
            // 
            // IdOfCustomer
            // 
            IdOfCustomer.AutoSize = true;
            IdOfCustomer.Location = new Point(75, 215);
            IdOfCustomer.Name = "IdOfCustomer";
            IdOfCustomer.Size = new Size(38, 15);
            IdOfCustomer.TabIndex = 4;
            IdOfCustomer.Text = "label1";
            // 
            // DeleteAccButton
            // 
            DeleteAccButton.Location = new Point(560, 215);
            DeleteAccButton.Name = "DeleteAccButton";
            DeleteAccButton.Size = new Size(111, 23);
            DeleteAccButton.TabIndex = 5;
            DeleteAccButton.Text = "Delete Account";
            DeleteAccButton.UseVisualStyleBackColor = true;
            DeleteAccButton.Click += DeleteAccButton_ClickAsync;
            // 
            // ChangePasswordButton
            // 
            ChangePasswordButton.Location = new Point(560, 131);
            ChangePasswordButton.Name = "ChangePasswordButton";
            ChangePasswordButton.Size = new Size(111, 23);
            ChangePasswordButton.TabIndex = 6;
            ChangePasswordButton.Text = "Change Password";
            ChangePasswordButton.UseVisualStyleBackColor = true;
            ChangePasswordButton.Click += ChangePasswordButton_Click;
            // 
            // CustomerDisplayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ChangePasswordButton);
            Controls.Add(DeleteAccButton);
            Controls.Add(IdOfCustomer);
            Controls.Add(GovermentIdOfCustomer);
            Controls.Add(LibraryCardOfCustomer);
            Controls.Add(EmailOfCustomer);
            Controls.Add(NameOfCustomer);
            Name = "CustomerDisplayForm";
            Text = "CustomerDisplayForm";
            Load += CustomerDisplayForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NameOfCustomer;
        private Label EmailOfCustomer;
        private Label LibraryCardOfCustomer;
        private Label GovermentIdOfCustomer;
        private Label IdOfCustomer;
        private Button DeleteAccButton;
        private Button ChangePasswordButton;
    }
}