namespace LibraryOfTheWorld.Forms.AdministrativeForms
{
    partial class AdminCustomerDisplay
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
            components = new System.ComponentModel.Container();
            CustomerDataGrid = new DataGridView();
            DeleteCustomerAccountButton = new Button();
            ForceReturnBookButton = new Button();
            CheckoutsDataGrid = new DataGridView();
            SendCollectionOfficersToolTip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)CustomerDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CheckoutsDataGrid).BeginInit();
            SuspendLayout();
            // 
            // CustomerDataGrid
            // 
            CustomerDataGrid.AllowUserToAddRows = false;
            CustomerDataGrid.AllowUserToDeleteRows = false;
            CustomerDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomerDataGrid.Location = new Point(12, 12);
            CustomerDataGrid.Name = "CustomerDataGrid";
            CustomerDataGrid.ReadOnly = true;
            CustomerDataGrid.Size = new Size(812, 216);
            CustomerDataGrid.TabIndex = 0;
            CustomerDataGrid.CellClick += CustomerDataGrid_CellClick;
            // 
            // DeleteCustomerAccountButton
            // 
            DeleteCustomerAccountButton.Location = new Point(12, 246);
            DeleteCustomerAccountButton.Name = "DeleteCustomerAccountButton";
            DeleteCustomerAccountButton.Size = new Size(167, 32);
            DeleteCustomerAccountButton.TabIndex = 1;
            DeleteCustomerAccountButton.Text = "Delete Customer Account";
            DeleteCustomerAccountButton.UseVisualStyleBackColor = true;
            DeleteCustomerAccountButton.Click += DeleteCustomerAccountButton_Click;
            // 
            // ForceReturnBookButton
            // 
            ForceReturnBookButton.Location = new Point(12, 310);
            ForceReturnBookButton.Name = "ForceReturnBookButton";
            ForceReturnBookButton.Size = new Size(167, 29);
            ForceReturnBookButton.TabIndex = 2;
            ForceReturnBookButton.Text = "Send Collection Officers ";
            ForceReturnBookButton.UseVisualStyleBackColor = true;
            ForceReturnBookButton.Click += ForceReturnBookButton_Click;
            ForceReturnBookButton.MouseHover += ForceReturnBookButton_MouseHover;
            // 
            // CheckoutsDataGrid
            // 
            CheckoutsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CheckoutsDataGrid.Location = new Point(234, 246);
            CheckoutsDataGrid.Name = "CheckoutsDataGrid";
            CheckoutsDataGrid.Size = new Size(590, 192);
            CheckoutsDataGrid.TabIndex = 3;
            // 
            // AdminCustomerDisplay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(836, 450);
            Controls.Add(CheckoutsDataGrid);
            Controls.Add(ForceReturnBookButton);
            Controls.Add(DeleteCustomerAccountButton);
            Controls.Add(CustomerDataGrid);
            Name = "AdminCustomerDisplay";
            Text = "AdminCustomerDisplay";
            Load += AdminCustomerDisplay_Load;
            ((System.ComponentModel.ISupportInitialize)CustomerDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)CheckoutsDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView CustomerDataGrid;
        private Button DeleteCustomerAccountButton;
        private Button ForceReturnBookButton;
        private DataGridView CheckoutsDataGrid;
        private ToolTip SendCollectionOfficersToolTip;
    }
}