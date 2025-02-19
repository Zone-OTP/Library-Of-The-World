namespace LibraryOfTheWorld.Forms
{
    partial class Library
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
            this.BookSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.name = new System.Windows.Forms.Label();
            this.author = new System.Windows.Forms.Label();
            this.IsTheBookTaken = new System.Windows.Forms.Label();
            this.SignedInAs = new System.Windows.Forms.Label();
            this.SignOut = new System.Windows.Forms.Button();
            this.TakeBookOut = new System.Windows.Forms.Button();
            this.AddBook = new System.Windows.Forms.Button();
            this.NameOfBook = new System.Windows.Forms.Label();
            this.AuthorOfBook = new System.Windows.Forms.Label();
            this.TakenOrNot = new System.Windows.Forms.Label();
            this.ReturnBookButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BookSelectionComboBox
            // 
            this.BookSelectionComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BookSelectionComboBox.FormattingEnabled = true;
            this.BookSelectionComboBox.Location = new System.Drawing.Point(609, 83);
            this.BookSelectionComboBox.Name = "BookSelectionComboBox";
            this.BookSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.BookSelectionComboBox.TabIndex = 0;
            this.BookSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.BookSelectionComboBox_SelectedIndexChanged);
            this.BookSelectionComboBox.Click += new System.EventHandler(this.BookSelectionComboBox_Click);
            // 
            // name
            // 
            this.name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(58, 86);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(89, 13);
            this.name.TabIndex = 1;
            this.name.Text = "Name Of Book ->";
            this.name.Click += new System.EventHandler(this.NameOfBook_Click);
            // 
            // author
            // 
            this.author.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.author.AutoSize = true;
            this.author.Location = new System.Drawing.Point(58, 131);
            this.author.Name = "author";
            this.author.Size = new System.Drawing.Size(92, 13);
            this.author.TabIndex = 2;
            this.author.Text = "Author Of Book ->";
            // 
            // IsTheBookTaken
            // 
            this.IsTheBookTaken.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IsTheBookTaken.AutoSize = true;
            this.IsTheBookTaken.Location = new System.Drawing.Point(58, 175);
            this.IsTheBookTaken.Name = "IsTheBookTaken";
            this.IsTheBookTaken.Size = new System.Drawing.Size(131, 13);
            this.IsTheBookTaken.TabIndex = 3;
            this.IsTheBookTaken.Text = "Is The Book Taken Out ->";
            // 
            // SignedInAs
            // 
            this.SignedInAs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SignedInAs.AutoSize = true;
            this.SignedInAs.BackColor = System.Drawing.Color.Transparent;
            this.SignedInAs.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            this.SignedInAs.Location = new System.Drawing.Point(12, 392);
            this.SignedInAs.Name = "SignedInAs";
            this.SignedInAs.Size = new System.Drawing.Size(61, 13);
            this.SignedInAs.TabIndex = 5;
            this.SignedInAs.Text = "SignedInAs";
            this.SignedInAs.Click += new System.EventHandler(this.SignedInAs_Click);
            // 
            // SignOut
            // 
            this.SignOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SignOut.Location = new System.Drawing.Point(12, 408);
            this.SignOut.Name = "SignOut";
            this.SignOut.Size = new System.Drawing.Size(61, 21);
            this.SignOut.TabIndex = 6;
            this.SignOut.Text = "Sign Out";
            this.SignOut.UseVisualStyleBackColor = true;
            this.SignOut.Click += new System.EventHandler(this.SignOut_Click);
            // 
            // TakeBookOut
            // 
            this.TakeBookOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TakeBookOut.Location = new System.Drawing.Point(609, 280);
            this.TakeBookOut.Name = "TakeBookOut";
            this.TakeBookOut.Size = new System.Drawing.Size(91, 23);
            this.TakeBookOut.TabIndex = 7;
            this.TakeBookOut.Text = "Take Book Out";
            this.TakeBookOut.UseVisualStyleBackColor = true;
            this.TakeBookOut.Click += new System.EventHandler(this.TakeBookOut_Click);
            // 
            // AddBook
            // 
            this.AddBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddBook.Location = new System.Drawing.Point(609, 372);
            this.AddBook.Name = "AddBook";
            this.AddBook.Size = new System.Drawing.Size(91, 23);
            this.AddBook.TabIndex = 8;
            this.AddBook.Text = "Add Book";
            this.AddBook.UseVisualStyleBackColor = true;
            this.AddBook.Click += new System.EventHandler(this.AddBook_Click);
            // 
            // NameOfBook
            // 
            this.NameOfBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameOfBook.AutoSize = true;
            this.NameOfBook.Location = new System.Drawing.Point(180, 86);
            this.NameOfBook.Name = "NameOfBook";
            this.NameOfBook.Size = new System.Drawing.Size(35, 13);
            this.NameOfBook.TabIndex = 9;
            this.NameOfBook.Text = "Name";
            this.NameOfBook.Click += new System.EventHandler(this.label1_Click);
            // 
            // AuthorOfBook
            // 
            this.AuthorOfBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AuthorOfBook.AutoSize = true;
            this.AuthorOfBook.Location = new System.Drawing.Point(180, 131);
            this.AuthorOfBook.Name = "AuthorOfBook";
            this.AuthorOfBook.Size = new System.Drawing.Size(38, 13);
            this.AuthorOfBook.TabIndex = 10;
            this.AuthorOfBook.Text = "Author";
            // 
            // TakenOrNot
            // 
            this.TakenOrNot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TakenOrNot.AutoSize = true;
            this.TakenOrNot.Location = new System.Drawing.Point(209, 175);
            this.TakenOrNot.Name = "TakenOrNot";
            this.TakenOrNot.Size = new System.Drawing.Size(104, 13);
            this.TakenOrNot.TabIndex = 11;
            this.TakenOrNot.Text = "Taken/Not Avalable";
            this.TakenOrNot.Click += new System.EventHandler(this.label3_Click);
            // 
            // ReturnBookButton
            // 
            this.ReturnBookButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReturnBookButton.Location = new System.Drawing.Point(609, 330);
            this.ReturnBookButton.Name = "ReturnBookButton";
            this.ReturnBookButton.Size = new System.Drawing.Size(91, 23);
            this.ReturnBookButton.TabIndex = 12;
            this.ReturnBookButton.Text = "Return Book";
            this.ReturnBookButton.UseVisualStyleBackColor = true;
            this.ReturnBookButton.Click += new System.EventHandler(this.ReturnBookButton_Click);
            // 
            // Library
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ReturnBookButton);
            this.Controls.Add(this.TakenOrNot);
            this.Controls.Add(this.AuthorOfBook);
            this.Controls.Add(this.NameOfBook);
            this.Controls.Add(this.AddBook);
            this.Controls.Add(this.TakeBookOut);
            this.Controls.Add(this.SignOut);
            this.Controls.Add(this.SignedInAs);
            this.Controls.Add(this.IsTheBookTaken);
            this.Controls.Add(this.author);
            this.Controls.Add(this.name);
            this.Controls.Add(this.BookSelectionComboBox);
            this.Name = "Library";
            this.Text = "Library";
            this.Activated += new System.EventHandler(this.Library_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Library_FormClosed);
            this.Load += new System.EventHandler(this.Library_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox BookSelectionComboBox;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label author;
        private System.Windows.Forms.Label IsTheBookTaken;
        private System.Windows.Forms.Label SignedInAs;
        private System.Windows.Forms.Button SignOut;
        private System.Windows.Forms.Button TakeBookOut;
        private System.Windows.Forms.Button AddBook;
        private System.Windows.Forms.Label NameOfBook;
        private System.Windows.Forms.Label AuthorOfBook;
        private System.Windows.Forms.Label TakenOrNot;
        private System.Windows.Forms.Button ReturnBookButton;
    }
}