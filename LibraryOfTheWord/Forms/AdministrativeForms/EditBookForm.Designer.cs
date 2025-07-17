namespace LibraryOfTheWorld.Forms
{
    partial class EditBookForm
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
            BookTitleTextBox = new TextBox();
            SaveButton = new Button();
            CancelButton = new Button();
            AuthorEditComboBox = new ComboBox();
            SuspendLayout();
            // 
            // BookTitleTextBox
            // 
            BookTitleTextBox.Location = new Point(88, 113);
            BookTitleTextBox.Margin = new Padding(4, 3, 4, 3);
            BookTitleTextBox.Name = "BookTitleTextBox";
            BookTitleTextBox.Size = new Size(173, 23);
            BookTitleTextBox.TabIndex = 0;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(438, 108);
            SaveButton.Margin = new Padding(4, 3, 4, 3);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(88, 27);
            SaveButton.TabIndex = 1;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(438, 185);
            CancelButton.Margin = new Padding(4, 3, 4, 3);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(88, 27);
            CancelButton.TabIndex = 2;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // AuthorEditComboBox
            // 
            AuthorEditComboBox.FormattingEnabled = true;
            AuthorEditComboBox.Location = new Point(88, 173);
            AuthorEditComboBox.Margin = new Padding(4, 3, 4, 3);
            AuthorEditComboBox.Name = "AuthorEditComboBox";
            AuthorEditComboBox.Size = new Size(173, 23);
            AuthorEditComboBox.TabIndex = 3;
            // 
            // EditBookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 384);
            Controls.Add(AuthorEditComboBox);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(BookTitleTextBox);
            Margin = new Padding(4, 3, 4, 3);
            Name = "EditBookForm";
            Text = "EditBookForm";
            Activated += EditBookForm_Activated;
            FormClosed += EditBookForm_FormClosed;
            Load += EditBookForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BookTitleTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ComboBox AuthorEditComboBox;
    }
}