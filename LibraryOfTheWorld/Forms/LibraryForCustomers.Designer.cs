namespace LibraryOfTheWorld.Forms
{
    partial class LibraryForCustomers
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
            this.name = new System.Windows.Forms.Label();
            this.author = new System.Windows.Forms.Label();
            this.IsTheBookTaken = new System.Windows.Forms.Label();
            this.SignedInAs = new System.Windows.Forms.Label();
            this.SignOut = new System.Windows.Forms.Button();
            this.TakeBookOut = new System.Windows.Forms.Button();
            this.NameOfBook = new System.Windows.Forms.Label();
            this.AuthorOfBook = new System.Windows.Forms.Label();
            this.TakenOrNot = new System.Windows.Forms.Label();
            this.ReturnBook = new System.Windows.Forms.Button();
            this.BookGrid = new System.Windows.Forms.DataGridView();
            this.PayOverdue = new System.Windows.Forms.Button();
            this.DarkModeToggleButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BookGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(60, 86);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(89, 13);
            this.name.TabIndex = 1;
            this.name.Text = "Name Of Book ->";
            // 
            // author
            // 
            this.author.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.author.AutoSize = true;
            this.author.Location = new System.Drawing.Point(57, 131);
            this.author.Name = "author";
            this.author.Size = new System.Drawing.Size(92, 13);
            this.author.TabIndex = 2;
            this.author.Text = "Author Of Book ->";
            // 
            // IsTheBookTaken
            // 
            this.IsTheBookTaken.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IsTheBookTaken.AutoSize = true;
            this.IsTheBookTaken.Location = new System.Drawing.Point(36, 175);
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
            this.SignedInAs.Location = new System.Drawing.Point(39, 392);
            this.SignedInAs.Name = "SignedInAs";
            this.SignedInAs.Size = new System.Drawing.Size(61, 13);
            this.SignedInAs.TabIndex = 5;
            this.SignedInAs.Text = "SignedInAs";
            this.SignedInAs.Click += new System.EventHandler(this.SignedInAs_Click);
            // 
            // SignOut
            // 
            this.SignOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SignOut.Location = new System.Drawing.Point(39, 408);
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
            this.TakeBookOut.Location = new System.Drawing.Point(297, 372);
            this.TakeBookOut.Name = "TakeBookOut";
            this.TakeBookOut.Size = new System.Drawing.Size(110, 23);
            this.TakeBookOut.TabIndex = 7;
            this.TakeBookOut.Text = "Take Book Out";
            this.TakeBookOut.UseVisualStyleBackColor = true;
            this.TakeBookOut.Click += new System.EventHandler(this.TakeBookOut_Click);
            // 
            // NameOfBook
            // 
            this.NameOfBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameOfBook.AutoSize = true;
            this.NameOfBook.Location = new System.Drawing.Point(177, 86);
            this.NameOfBook.Name = "NameOfBook";
            this.NameOfBook.Size = new System.Drawing.Size(35, 13);
            this.NameOfBook.TabIndex = 9;
            this.NameOfBook.Text = "Name";
            // 
            // AuthorOfBook
            // 
            this.AuthorOfBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AuthorOfBook.AutoSize = true;
            this.AuthorOfBook.Location = new System.Drawing.Point(174, 131);
            this.AuthorOfBook.Name = "AuthorOfBook";
            this.AuthorOfBook.Size = new System.Drawing.Size(38, 13);
            this.AuthorOfBook.TabIndex = 10;
            this.AuthorOfBook.Text = "Author";
            // 
            // TakenOrNot
            // 
            this.TakenOrNot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TakenOrNot.AutoSize = true;
            this.TakenOrNot.Location = new System.Drawing.Point(177, 175);
            this.TakenOrNot.Name = "TakenOrNot";
            this.TakenOrNot.Size = new System.Drawing.Size(104, 13);
            this.TakenOrNot.TabIndex = 11;
            this.TakenOrNot.Text = "Taken/Not Avalable";
            // 
            // ReturnBook
            // 
            this.ReturnBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReturnBook.Location = new System.Drawing.Point(513, 372);
            this.ReturnBook.Name = "ReturnBook";
            this.ReturnBook.Size = new System.Drawing.Size(107, 23);
            this.ReturnBook.TabIndex = 12;
            this.ReturnBook.Text = "Return Book";
            this.ReturnBook.UseVisualStyleBackColor = true;
            this.ReturnBook.Click += new System.EventHandler(this.ReturnBook_Click);
            // 
            // BookGrid
            // 
            this.BookGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BookGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BookGrid.Location = new System.Drawing.Point(297, 38);
            this.BookGrid.Name = "BookGrid";
            this.BookGrid.Size = new System.Drawing.Size(545, 295);
            this.BookGrid.TabIndex = 13;
            this.BookGrid.SelectionChanged += new System.EventHandler(this.BookGrid_SelectionChanged);
            // 
            // PayOverdue
            // 
            this.PayOverdue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PayOverdue.Location = new System.Drawing.Point(723, 372);
            this.PayOverdue.Name = "PayOverdue";
            this.PayOverdue.Size = new System.Drawing.Size(101, 23);
            this.PayOverdue.TabIndex = 20;
            this.PayOverdue.Text = "Pay Overdue Fine";
            this.PayOverdue.UseVisualStyleBackColor = true;
            // 
            // DarkModeToggleButton
            // 
            this.DarkModeToggleButton.Location = new System.Drawing.Point(13, 13);
            this.DarkModeToggleButton.Name = "DarkModeToggleButton";
            this.DarkModeToggleButton.Size = new System.Drawing.Size(75, 23);
            this.DarkModeToggleButton.TabIndex = 21;
            this.DarkModeToggleButton.Text = "Dark/Light Mode";
            this.DarkModeToggleButton.UseVisualStyleBackColor = true;
            this.DarkModeToggleButton.Click += new System.EventHandler(this.DarkModeToggleButton_Click);
            // 
            // LibraryForCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 450);
            this.Controls.Add(this.DarkModeToggleButton);
            this.Controls.Add(this.PayOverdue);
            this.Controls.Add(this.BookGrid);
            this.Controls.Add(this.ReturnBook);
            this.Controls.Add(this.TakenOrNot);
            this.Controls.Add(this.AuthorOfBook);
            this.Controls.Add(this.NameOfBook);
            this.Controls.Add(this.TakeBookOut);
            this.Controls.Add(this.SignOut);
            this.Controls.Add(this.SignedInAs);
            this.Controls.Add(this.IsTheBookTaken);
            this.Controls.Add(this.author);
            this.Controls.Add(this.name);
            this.Name = "LibraryForCustomers";
            this.Text = "Library";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LibraryForCustomers_FormClosed);
            this.Load += new System.EventHandler(this.LibraryForCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BookGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label author;
        private System.Windows.Forms.Label IsTheBookTaken;
        private System.Windows.Forms.Label SignedInAs;
        private System.Windows.Forms.Button SignOut;
        private System.Windows.Forms.Button TakeBookOut;
        private System.Windows.Forms.Label NameOfBook;
        private System.Windows.Forms.Label AuthorOfBook;
        private System.Windows.Forms.Label TakenOrNot;
        private System.Windows.Forms.Button ReturnBook;
        private System.Windows.Forms.DataGridView BookGrid;
        private System.Windows.Forms.Button PayOverdue;
        private System.Windows.Forms.Button DarkModeToggleButton;
    }
}