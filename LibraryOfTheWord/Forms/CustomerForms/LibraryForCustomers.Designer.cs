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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryForCustomers));
            name = new Label();
            author = new Label();
            IsTheBookTaken = new Label();
            SignedInAs = new Label();
            SignOut = new Button();
            TakeBookOut = new Button();
            NameOfBook = new Label();
            AuthorOfBook = new Label();
            TakenOrNot = new Label();
            ReturnBook = new Button();
            BookGrid = new DataGridView();
            PayOverdue = new Button();
            DarkModeToggleButton = new Button();
            ((System.ComponentModel.ISupportInitialize)BookGrid).BeginInit();
            SuspendLayout();
            // 
            // name
            // 
            name.Anchor = AnchorStyles.None;
            name.AutoSize = true;
            name.Location = new Point(70, 99);
            name.Margin = new Padding(4, 0, 4, 0);
            name.Name = "name";
            name.Size = new Size(101, 15);
            name.TabIndex = 1;
            name.Text = "Name Of Book ->";
            // 
            // author
            // 
            author.Anchor = AnchorStyles.None;
            author.AutoSize = true;
            author.Location = new Point(66, 151);
            author.Margin = new Padding(4, 0, 4, 0);
            author.Name = "author";
            author.Size = new Size(106, 15);
            author.TabIndex = 2;
            author.Text = "Author Of Book ->";
            // 
            // IsTheBookTaken
            // 
            IsTheBookTaken.Anchor = AnchorStyles.None;
            IsTheBookTaken.AutoSize = true;
            IsTheBookTaken.Location = new Point(42, 202);
            IsTheBookTaken.Margin = new Padding(4, 0, 4, 0);
            IsTheBookTaken.Name = "IsTheBookTaken";
            IsTheBookTaken.Size = new Size(139, 15);
            IsTheBookTaken.TabIndex = 3;
            IsTheBookTaken.Text = "Is The Book Taken Out ->";
            // 
            // SignedInAs
            // 
            SignedInAs.Anchor = AnchorStyles.None;
            SignedInAs.AutoSize = true;
            SignedInAs.BackColor = Color.Transparent;
            SignedInAs.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            SignedInAs.Location = new Point(46, 452);
            SignedInAs.Margin = new Padding(4, 0, 4, 0);
            SignedInAs.Name = "SignedInAs";
            SignedInAs.Size = new Size(66, 15);
            SignedInAs.TabIndex = 5;
            SignedInAs.Text = "SignedInAs";
            SignedInAs.Click += SignedInAs_Click;
            // 
            // SignOut
            // 
            SignOut.Anchor = AnchorStyles.None;
            SignOut.Image = Properties.Resources.signout_120220;
            SignOut.ImageAlign = ContentAlignment.MiddleLeft;
            SignOut.Location = new Point(42, 470);
            SignOut.Margin = new Padding(4, 3, 4, 3);
            SignOut.Name = "SignOut";
            SignOut.Size = new Size(90, 37);
            SignOut.TabIndex = 4;
            SignOut.Text = "Sign Out";
            SignOut.TextImageRelation = TextImageRelation.ImageBeforeText;
            SignOut.UseVisualStyleBackColor = true;
            SignOut.Click += SignOut_Click;
            // 
            // TakeBookOut
            // 
            TakeBookOut.Anchor = AnchorStyles.None;
            TakeBookOut.Image = Properties.Resources.TakeBookOutIcon;
            TakeBookOut.ImageAlign = ContentAlignment.MiddleLeft;
            TakeBookOut.Location = new Point(411, 429);
            TakeBookOut.Margin = new Padding(4, 4, 4, 3);
            TakeBookOut.Name = "TakeBookOut";
            TakeBookOut.Size = new Size(119, 44);
            TakeBookOut.TabIndex = 1;
            TakeBookOut.Text = "Take Book Out";
            TakeBookOut.TextImageRelation = TextImageRelation.ImageBeforeText;
            TakeBookOut.UseVisualStyleBackColor = true;
            TakeBookOut.Click += TakeBookOut_Click;
            // 
            // NameOfBook
            // 
            NameOfBook.Anchor = AnchorStyles.None;
            NameOfBook.AutoSize = true;
            NameOfBook.Location = new Point(206, 99);
            NameOfBook.Margin = new Padding(4, 0, 4, 0);
            NameOfBook.Name = "NameOfBook";
            NameOfBook.Size = new Size(39, 15);
            NameOfBook.TabIndex = 9;
            NameOfBook.Text = "Name";
            // 
            // AuthorOfBook
            // 
            AuthorOfBook.Anchor = AnchorStyles.None;
            AuthorOfBook.AutoSize = true;
            AuthorOfBook.Location = new Point(203, 151);
            AuthorOfBook.Margin = new Padding(4, 0, 4, 0);
            AuthorOfBook.Name = "AuthorOfBook";
            AuthorOfBook.Size = new Size(44, 15);
            AuthorOfBook.TabIndex = 10;
            AuthorOfBook.Text = "Author";
            // 
            // TakenOrNot
            // 
            TakenOrNot.Anchor = AnchorStyles.None;
            TakenOrNot.AutoSize = true;
            TakenOrNot.Location = new Point(206, 202);
            TakenOrNot.Margin = new Padding(4, 0, 4, 0);
            TakenOrNot.Name = "TakenOrNot";
            TakenOrNot.Size = new Size(110, 15);
            TakenOrNot.TabIndex = 11;
            TakenOrNot.Text = "Taken/Not Avalable";
            // 
            // ReturnBook
            // 
            ReturnBook.Anchor = AnchorStyles.None;
            ReturnBook.Image = Properties.Resources.ReturnBookICon;
            ReturnBook.ImageAlign = ContentAlignment.MiddleLeft;
            ReturnBook.Location = new Point(613, 429);
            ReturnBook.Margin = new Padding(4, 3, 4, 3);
            ReturnBook.Name = "ReturnBook";
            ReturnBook.Size = new Size(108, 44);
            ReturnBook.TabIndex = 2;
            ReturnBook.Text = "Return Book";
            ReturnBook.TextImageRelation = TextImageRelation.ImageBeforeText;
            ReturnBook.UseVisualStyleBackColor = true;
            ReturnBook.Click += ReturnBook_Click;
            // 
            // BookGrid
            // 
            BookGrid.Anchor = AnchorStyles.None;
            BookGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BookGrid.Location = new Point(346, 44);
            BookGrid.Margin = new Padding(4, 3, 4, 3);
            BookGrid.Name = "BookGrid";
            BookGrid.Size = new Size(636, 340);
            BookGrid.TabIndex = 13;
            BookGrid.CellFormatting += BookGrid_CellFormatting;
            BookGrid.SelectionChanged += BookGrid_SelectionChanged;
            // 
            // PayOverdue
            // 
            PayOverdue.Anchor = AnchorStyles.None;
            PayOverdue.Image = Properties.Resources.credit_card;
            PayOverdue.ImageAlign = ContentAlignment.MiddleLeft;
            PayOverdue.Location = new Point(808, 429);
            PayOverdue.Margin = new Padding(4, 3, 4, 3);
            PayOverdue.Name = "PayOverdue";
            PayOverdue.Size = new Size(128, 44);
            PayOverdue.TabIndex = 3;
            PayOverdue.Text = "    Pay Overdue Fine";
            PayOverdue.TextImageRelation = TextImageRelation.ImageBeforeText;
            PayOverdue.UseVisualStyleBackColor = true;
            PayOverdue.Click += PayOverdue_Click;
            // 
            // DarkModeToggleButton
            // 
            DarkModeToggleButton.Location = new Point(15, 15);
            DarkModeToggleButton.Margin = new Padding(4, 3, 4, 3);
            DarkModeToggleButton.Name = "DarkModeToggleButton";
            DarkModeToggleButton.Size = new Size(88, 27);
            DarkModeToggleButton.TabIndex = 21;
            DarkModeToggleButton.Text = "Dark/Light Mode";
            DarkModeToggleButton.UseVisualStyleBackColor = true;
            DarkModeToggleButton.Click += DarkModeToggleButton_Click;
            // 
            // LibraryForCustomers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(996, 519);
            Controls.Add(DarkModeToggleButton);
            Controls.Add(PayOverdue);
            Controls.Add(BookGrid);
            Controls.Add(ReturnBook);
            Controls.Add(TakenOrNot);
            Controls.Add(AuthorOfBook);
            Controls.Add(NameOfBook);
            Controls.Add(TakeBookOut);
            Controls.Add(SignOut);
            Controls.Add(SignedInAs);
            Controls.Add(IsTheBookTaken);
            Controls.Add(author);
            Controls.Add(name);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "LibraryForCustomers";
            Text = "Customer Window";
            Activated += LibraryForCustomers_Activated;
            FormClosed += LibraryForCustomers_FormClosed;
            Load += LibraryForCustomers_Load;
            ((System.ComponentModel.ISupportInitialize)BookGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();

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