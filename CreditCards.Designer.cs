namespace VidaControls
{
    partial class CreditCards
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Institution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Limit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinimumPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Institution,
            this.AccountNumber,
            this.Limit,
            this.Balance,
            this.APR,
            this.MinimumPayment,
            this.DueDate,
            this.AccountNickName});
            this.dataGridView1.Location = new System.Drawing.Point(14, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(845, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // Institution
            // 
            this.Institution.HeaderText = "Institution";
            this.Institution.Name = "Institution";
            // 
            // AccountNumber
            // 
            this.AccountNumber.HeaderText = "Account Number";
            this.AccountNumber.Name = "AccountNumber";
            // 
            // Limit
            // 
            this.Limit.HeaderText = "Limit";
            this.Limit.Name = "Limit";
            // 
            // Balance
            // 
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            // 
            // APR
            // 
            this.APR.HeaderText = "APR";
            this.APR.Name = "APR";
            // 
            // MinimumPayment
            // 
            this.MinimumPayment.HeaderText = "Minimum Payment";
            this.MinimumPayment.Name = "MinimumPayment";
            // 
            // DueDate
            // 
            this.DueDate.HeaderText = "Due Date";
            this.DueDate.Name = "DueDate";
            // 
            // AccountNickName
            // 
            this.AccountNickName.HeaderText = "Account Nickname";
            this.AccountNickName.Name = "AccountNickName";
            // 
            // CreditCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "CreditCards";
            this.Size = new System.Drawing.Size(874, 266);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Institution;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Limit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn APR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinimumPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNickName;
    }
}
