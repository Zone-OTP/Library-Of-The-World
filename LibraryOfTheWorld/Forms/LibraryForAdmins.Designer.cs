namespace LibraryOfTheWorld.Forms
{
    partial class LibraryForAdmins
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
            this.RemoveOneBook = new System.Windows.Forms.Button();
            this.AddBook = new System.Windows.Forms.Button();
            this.NameOfBook = new System.Windows.Forms.Label();
            this.AuthorOfBook = new System.Windows.Forms.Label();
            this.TakenOrNot = new System.Windows.Forms.Label();
            this.RemoveByROOT = new System.Windows.Forms.Button();
            this.BookGrid = new System.Windows.Forms.DataGridView();
            this.TotalBooksLable = new System.Windows.Forms.Label();
            this.BooksTakenOutLabel = new System.Windows.Forms.Label();
            this.BooksAvalablelabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EditBookButton = new System.Windows.Forms.Button();
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
            // RemoveOneBook
            // 
            this.RemoveOneBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RemoveOneBook.Location = new System.Drawing.Point(297, 372);
            this.RemoveOneBook.Name = "RemoveOneBook";
            this.RemoveOneBook.Size = new System.Drawing.Size(110, 23);
            this.RemoveOneBook.TabIndex = 7;
            this.RemoveOneBook.Text = "Remove One Book";
            this.RemoveOneBook.UseVisualStyleBackColor = true;
            this.RemoveOneBook.Click += new System.EventHandler(this.RemoveOneBook_Click);
            // 
            // AddBook
            // 
            this.AddBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddBook.Location = new System.Drawing.Point(603, 372);
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
            // RemoveByROOT
            // 
            this.RemoveByROOT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RemoveByROOT.Location = new System.Drawing.Point(448, 372);
            this.RemoveByROOT.Name = "RemoveByROOT";
            this.RemoveByROOT.Size = new System.Drawing.Size(107, 23);
            this.RemoveByROOT.TabIndex = 12;
            this.RemoveByROOT.Text = "Remove By ROOT";
            this.RemoveByROOT.UseVisualStyleBackColor = true;
            this.RemoveByROOT.Click += new System.EventHandler(this.RemoveByRoot_Click);
            // 
            // BookGrid
            // 
            this.BookGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BookGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BookGrid.Location = new System.Drawing.Point(297, 38);
            this.BookGrid.Name = "BookGrid";
            this.BookGrid.Size = new System.Drawing.Size(545, 295);
            this.BookGrid.TabIndex = 13;
            this.BookGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BookGrid_CellContentClick);
            this.BookGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.BookGrid_CellFormatting);
            this.BookGrid.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.BookGrid_CellStateChanged);
            this.BookGrid.SelectionChanged += new System.EventHandler(this.BookGrid_SelectionChanged);
            this.BookGrid.Enter += new System.EventHandler(this.BookGrid_Enter);
            // 
            // TotalBooksLable
            // 
            this.TotalBooksLable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TotalBooksLable.AutoSize = true;
            this.TotalBooksLable.Location = new System.Drawing.Point(174, 259);
            this.TotalBooksLable.Name = "TotalBooksLable";
            this.TotalBooksLable.Size = new System.Drawing.Size(117, 13);
            this.TotalBooksLable.TabIndex = 14;
            this.TotalBooksLable.Text = "Amount Of Books Total";
            // 
            // BooksTakenOutLabel
            // 
            this.BooksTakenOutLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BooksTakenOutLabel.AutoSize = true;
            this.BooksTakenOutLabel.Location = new System.Drawing.Point(174, 290);
            this.BooksTakenOutLabel.Name = "BooksTakenOutLabel";
            this.BooksTakenOutLabel.Size = new System.Drawing.Size(85, 13);
            this.BooksTakenOutLabel.TabIndex = 15;
            this.BooksTakenOutLabel.Text = "BooksTakenOut";
            // 
            // BooksAvalablelabel
            // 
            this.BooksAvalablelabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BooksAvalablelabel.AutoSize = true;
            this.BooksAvalablelabel.Location = new System.Drawing.Point(174, 320);
            this.BooksAvalablelabel.Name = "BooksAvalablelabel";
            this.BooksAvalablelabel.Size = new System.Drawing.Size(82, 13);
            this.BooksAvalablelabel.TabIndex = 16;
            this.BooksAvalablelabel.Text = "Books in Library";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Total books in Library";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Books taken out";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Books within Library";
            // 
            // EditBookButton
            // 
            this.EditBookButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditBookButton.Location = new System.Drawing.Point(749, 372);
            this.EditBookButton.Name = "EditBookButton";
            this.EditBookButton.Size = new System.Drawing.Size(75, 23);
            this.EditBookButton.TabIndex = 20;
            this.EditBookButton.Text = "Edit Book";
            this.EditBookButton.UseVisualStyleBackColor = true;
            this.EditBookButton.Click += new System.EventHandler(this.EditBookButton_Click);
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
            // LibraryForAdmins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 450);
            this.Controls.Add(this.DarkModeToggleButton);
            this.Controls.Add(this.EditBookButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BooksAvalablelabel);
            this.Controls.Add(this.BooksTakenOutLabel);
            this.Controls.Add(this.TotalBooksLable);
            this.Controls.Add(this.BookGrid);
            this.Controls.Add(this.RemoveByROOT);
            this.Controls.Add(this.TakenOrNot);
            this.Controls.Add(this.AuthorOfBook);
            this.Controls.Add(this.NameOfBook);
            this.Controls.Add(this.AddBook);
            this.Controls.Add(this.RemoveOneBook);
            this.Controls.Add(this.SignOut);
            this.Controls.Add(this.SignedInAs);
            this.Controls.Add(this.IsTheBookTaken);
            this.Controls.Add(this.author);
            this.Controls.Add(this.name);
            this.Name = "LibraryForAdmins";
            this.Text = "Library";
            this.Activated += new System.EventHandler(this.Library_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Library_FormClosed);
            this.Load += new System.EventHandler(this.Library_Load);
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
        private System.Windows.Forms.Button RemoveOneBook;
        private System.Windows.Forms.Button AddBook;
        private System.Windows.Forms.Label NameOfBook;
        private System.Windows.Forms.Label AuthorOfBook;
        private System.Windows.Forms.Label TakenOrNot;
        private System.Windows.Forms.Button RemoveByROOT;
        private System.Windows.Forms.DataGridView BookGrid;
        private System.Windows.Forms.Label TotalBooksLable;
        private System.Windows.Forms.Label BooksTakenOutLabel;
        private System.Windows.Forms.Label BooksAvalablelabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button EditBookButton;
        private System.Windows.Forms.Button DarkModeToggleButton;
    }
}