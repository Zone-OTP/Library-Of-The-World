namespace LibraryOfTheWorld.Forms
{
    partial class CustomerCheckoutForm
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
            CustomerGrid = new DataGridView();
            BookInfoLabel = new Label();
            CheckCustomerButton = new Button();
            ((System.ComponentModel.ISupportInitialize)CustomerGrid).BeginInit();
            SuspendLayout();
            // 
            // CustomerGrid
            // 
            CustomerGrid.AllowUserToOrderColumns = true;
            CustomerGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomerGrid.Location = new Point(29, 25);
            CustomerGrid.Name = "CustomerGrid";
            CustomerGrid.Size = new Size(738, 312);
            CustomerGrid.TabIndex = 0;
            CustomerGrid.CellContentClick += CustomerGridVeiw_CellContentClick;
            CustomerGrid.CellFormatting += CustomerGrid_CellFormatting;
            // 
            // BookInfoLabel
            // 
            BookInfoLabel.AutoSize = true;
            BookInfoLabel.Location = new Point(31, 7);
            BookInfoLabel.Name = "BookInfoLabel";
            BookInfoLabel.Size = new Size(34, 15);
            BookInfoLabel.TabIndex = 1;
            BookInfoLabel.Text = "Book";
            // 
            // CheckCustomerButton
            // 
            CheckCustomerButton.Location = new Point(329, 401);
            CheckCustomerButton.Name = "CheckCustomerButton";
            CheckCustomerButton.Size = new Size(130, 37);
            CheckCustomerButton.TabIndex = 2;
            CheckCustomerButton.Text = "Checkout Customer";
            CheckCustomerButton.UseVisualStyleBackColor = true;
            CheckCustomerButton.Click += CheckCustomerButton_Click;
            // 
            // CustomerCheckoutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CheckCustomerButton);
            Controls.Add(BookInfoLabel);
            Controls.Add(CustomerGrid);
            Name = "CustomerCheckoutForm";
            Text = "CustomerCheckoutForm";
            Activated += CustomerCheckoutForm_Activated;
            Load += CustomerCheckoutForm_Load;
            ((System.ComponentModel.ISupportInitialize)CustomerGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView CustomerGrid;
        private Label BookInfoLabel;
        private Button CheckCustomerButton;
    }
}