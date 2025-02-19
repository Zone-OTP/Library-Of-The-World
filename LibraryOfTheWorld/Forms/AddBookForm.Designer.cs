namespace LibraryOfTheWorld.Forms
{
    partial class AddBookForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BookNameText = new System.Windows.Forms.TextBox();
            this.BookAuthorText = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Book Author";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // BookNameText
            // 
            this.BookNameText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BookNameText.Location = new System.Drawing.Point(274, 106);
            this.BookNameText.Name = "BookNameText";
            this.BookNameText.Size = new System.Drawing.Size(100, 20);
            this.BookNameText.TabIndex = 2;
            this.BookNameText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BookAuthorText
            // 
            this.BookAuthorText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BookAuthorText.Location = new System.Drawing.Point(273, 156);
            this.BookAuthorText.Name = "BookAuthorText";
            this.BookAuthorText.Size = new System.Drawing.Size(100, 20);
            this.BookAuthorText.TabIndex = 3;
            this.BookAuthorText.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(424, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Add Book";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 368);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BookAuthorText);
            this.Controls.Add(this.BookNameText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddBookForm";
            this.Text = "AddBook";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddBookForm_FormClosed);
            this.Load += new System.EventHandler(this.AddBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BookNameText;
        private System.Windows.Forms.TextBox BookAuthorText;
        private System.Windows.Forms.Button button2;
    }
}