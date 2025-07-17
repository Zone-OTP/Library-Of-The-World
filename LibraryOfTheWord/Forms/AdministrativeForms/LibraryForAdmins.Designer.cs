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
            name = new Label();
            author = new Label();
            IsTheBookTaken = new Label();
            SignedInAs = new Label();
            SignOut = new Button();
            RemoveOneBook = new Button();
            AddBook = new Button();
            NameOfBook = new Label();
            AuthorOfBook = new Label();
            TakenOrNot = new Label();
            RemoveByROOT = new Button();
            BookGrid = new DataGridView();
            TotalBooksLable = new Label();
            BooksTakenOutLabel = new Label();
            BooksAvalablelabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            EditBookButton = new Button();
            DarkModeToggleButton = new Button();
            CustomerPanelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)BookGrid).BeginInit();
            SuspendLayout();
            // 
            // name
            // 
            name.Anchor = AnchorStyles.None;
            name.AutoSize = true;
            name.Location = new Point(72, 98);
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
            author.Location = new Point(68, 150);
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
            IsTheBookTaken.Location = new Point(44, 201);
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
            SignedInAs.Location = new Point(48, 451);
            SignedInAs.Margin = new Padding(4, 0, 4, 0);
            SignedInAs.Name = "SignedInAs";
            SignedInAs.Size = new Size(66, 15);
            SignedInAs.TabIndex = 5;
            SignedInAs.Text = "SignedInAs";
            // 
            // SignOut
            // 
            SignOut.Anchor = AnchorStyles.None;
            SignOut.Image = Properties.Resources.signout_120220;
            SignOut.ImageAlign = ContentAlignment.MiddleLeft;
            SignOut.Location = new Point(40, 470);
            SignOut.Margin = new Padding(4, 3, 4, 3);
            SignOut.Name = "SignOut";
            SignOut.Size = new Size(84, 41);
            SignOut.TabIndex = 5;
            SignOut.Text = "Sign Out";
            SignOut.TextImageRelation = TextImageRelation.ImageBeforeText;
            SignOut.UseVisualStyleBackColor = true;
            SignOut.Click += SignOut_Click;
            // 
            // RemoveOneBook
            // 
            RemoveOneBook.Anchor = AnchorStyles.None;
            RemoveOneBook.Image = Properties.Resources.Remove_one_Book;
            RemoveOneBook.ImageAlign = ContentAlignment.MiddleLeft;
            RemoveOneBook.Location = new Point(348, 428);
            RemoveOneBook.Margin = new Padding(4, 3, 4, 3);
            RemoveOneBook.Name = "RemoveOneBook";
            RemoveOneBook.Size = new Size(146, 38);
            RemoveOneBook.TabIndex = 1;
            RemoveOneBook.Text = "Remove One Book";
            RemoveOneBook.TextImageRelation = TextImageRelation.ImageBeforeText;
            RemoveOneBook.UseVisualStyleBackColor = true;
            RemoveOneBook.Click += RemoveOneBook_Click;
            // 
            // AddBook
            // 
            AddBook.Anchor = AnchorStyles.None;
            AddBook.Image = Properties.Resources.add_book;
            AddBook.ImageAlign = ContentAlignment.MiddleLeft;
            AddBook.Location = new Point(706, 428);
            AddBook.Margin = new Padding(4, 3, 4, 3);
            AddBook.Name = "AddBook";
            AddBook.Size = new Size(132, 38);
            AddBook.TabIndex = 3;
            AddBook.Text = "Add Book";
            AddBook.TextImageRelation = TextImageRelation.ImageBeforeText;
            AddBook.UseVisualStyleBackColor = true;
            AddBook.Click += AddBook_Click;
            // 
            // NameOfBook
            // 
            NameOfBook.Anchor = AnchorStyles.None;
            NameOfBook.AutoSize = true;
            NameOfBook.Location = new Point(208, 98);
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
            AuthorOfBook.Location = new Point(205, 150);
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
            TakenOrNot.Location = new Point(208, 201);
            TakenOrNot.Margin = new Padding(4, 0, 4, 0);
            TakenOrNot.Name = "TakenOrNot";
            TakenOrNot.Size = new Size(110, 15);
            TakenOrNot.TabIndex = 11;
            TakenOrNot.Text = "Taken/Not Avalable";
            // 
            // RemoveByROOT
            // 
            RemoveByROOT.Anchor = AnchorStyles.None;
            RemoveByROOT.Image = Properties.Resources.delete_from_database;
            RemoveByROOT.ImageAlign = ContentAlignment.MiddleLeft;
            RemoveByROOT.Location = new Point(525, 428);
            RemoveByROOT.Margin = new Padding(4, 3, 4, 3);
            RemoveByROOT.Name = "RemoveByROOT";
            RemoveByROOT.Size = new Size(141, 38);
            RemoveByROOT.TabIndex = 2;
            RemoveByROOT.Text = "Remove By ROOT";
            RemoveByROOT.TextImageRelation = TextImageRelation.ImageBeforeText;
            RemoveByROOT.UseVisualStyleBackColor = true;
            RemoveByROOT.Click += RemoveByRoot_Click;
            // 
            // BookGrid
            // 
            BookGrid.AllowUserToAddRows = false;
            BookGrid.AllowUserToDeleteRows = false;
            BookGrid.Anchor = AnchorStyles.None;
            BookGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BookGrid.Location = new Point(348, 43);
            BookGrid.Margin = new Padding(4, 3, 4, 3);
            BookGrid.Name = "BookGrid";
            BookGrid.Size = new Size(639, 340);
            BookGrid.TabIndex = 13;
            BookGrid.CellContentClick += BookGrid_CellContentClick;
            BookGrid.CellFormatting += BookGrid_CellFormatting;
            BookGrid.SelectionChanged += BookGrid_SelectionChanged;
            // 
            // TotalBooksLable
            // 
            TotalBooksLable.Anchor = AnchorStyles.None;
            TotalBooksLable.AutoSize = true;
            TotalBooksLable.Location = new Point(205, 298);
            TotalBooksLable.Margin = new Padding(4, 0, 4, 0);
            TotalBooksLable.Name = "TotalBooksLable";
            TotalBooksLable.Size = new Size(130, 15);
            TotalBooksLable.TabIndex = 14;
            TotalBooksLable.Text = "Amount Of Books Total";
            // 
            // BooksTakenOutLabel
            // 
            BooksTakenOutLabel.Anchor = AnchorStyles.None;
            BooksTakenOutLabel.AutoSize = true;
            BooksTakenOutLabel.Location = new Point(205, 334);
            BooksTakenOutLabel.Margin = new Padding(4, 0, 4, 0);
            BooksTakenOutLabel.Name = "BooksTakenOutLabel";
            BooksTakenOutLabel.Size = new Size(89, 15);
            BooksTakenOutLabel.TabIndex = 15;
            BooksTakenOutLabel.Text = "BooksTakenOut";
            // 
            // BooksAvalablelabel
            // 
            BooksAvalablelabel.Anchor = AnchorStyles.None;
            BooksAvalablelabel.AutoSize = true;
            BooksAvalablelabel.Location = new Point(205, 368);
            BooksAvalablelabel.Margin = new Padding(4, 0, 4, 0);
            BooksAvalablelabel.Name = "BooksAvalablelabel";
            BooksAvalablelabel.Size = new Size(91, 15);
            BooksAvalablelabel.TabIndex = 16;
            BooksAvalablelabel.Text = "Books in Library";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(40, 298);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 17;
            label1.Text = "Total books in Library";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(40, 334);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 18;
            label2.Text = "Books taken out";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(40, 368);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(114, 15);
            label3.TabIndex = 19;
            label3.Text = "Books within Library";
            // 
            // EditBookButton
            // 
            EditBookButton.Anchor = AnchorStyles.None;
            EditBookButton.Image = Properties.Resources.Eddit_Book_recycle;
            EditBookButton.ImageAlign = ContentAlignment.MiddleLeft;
            EditBookButton.Location = new Point(876, 428);
            EditBookButton.Margin = new Padding(4, 3, 4, 3);
            EditBookButton.Name = "EditBookButton";
            EditBookButton.Size = new Size(111, 38);
            EditBookButton.TabIndex = 4;
            EditBookButton.Text = "Edit Book";
            EditBookButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            EditBookButton.UseVisualStyleBackColor = true;
            EditBookButton.Click += EditBookButton_Click;
            // 
            // DarkModeToggleButton
            // 
            DarkModeToggleButton.Location = new Point(15, 15);
            DarkModeToggleButton.Margin = new Padding(4, 3, 4, 3);
            DarkModeToggleButton.Name = "DarkModeToggleButton";
            DarkModeToggleButton.Size = new Size(88, 27);
            DarkModeToggleButton.TabIndex = 6;
            DarkModeToggleButton.Text = "Dark/Light Mode";
            DarkModeToggleButton.UseVisualStyleBackColor = true;
            DarkModeToggleButton.Click += DarkModeToggleButton_Click;
            // 
            // CustomerPanelButton
            // 
            CustomerPanelButton.Location = new Point(630, 472);
            CustomerPanelButton.Name = "CustomerPanelButton";
            CustomerPanelButton.Size = new Size(110, 39);
            CustomerPanelButton.TabIndex = 20;
            CustomerPanelButton.Text = "Customer Panel";
            CustomerPanelButton.UseVisualStyleBackColor = true;
            CustomerPanelButton.Click += CustomerPanelButton_Click;
            // 
            // LibraryForAdmins
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 516);
            Controls.Add(CustomerPanelButton);
            Controls.Add(AddBook);
            Controls.Add(EditBookButton);
            Controls.Add(RemoveByROOT);
            Controls.Add(RemoveOneBook);
            Controls.Add(BookGrid);
            Controls.Add(DarkModeToggleButton);
            Controls.Add(SignOut);
            Controls.Add(SignedInAs);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(IsTheBookTaken);
            Controls.Add(author);
            Controls.Add(TakenOrNot);
            Controls.Add(AuthorOfBook);
            Controls.Add(NameOfBook);
            Controls.Add(name);
            Controls.Add(BooksAvalablelabel);
            Controls.Add(BooksTakenOutLabel);
            Controls.Add(TotalBooksLable);
            Margin = new Padding(4, 3, 4, 3);
            Name = "LibraryForAdmins";
            Text = "Library";
            Activated += Library_Activated;
            FormClosed += Library_FormClosed;
            Load += Library_Load;
            Shown += LibraryForAdmins_Shown;
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
        private Button CustomerPanelButton;
    }
}