namespace projectPBO
{
    partial class FormCreatePeminjaman
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtCheckoutId;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.TextBox txtBookId;
        private System.Windows.Forms.DateTimePicker dtpCheckoutDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Button btnCreate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCheckoutId = new System.Windows.Forms.TextBox();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.txtBookId = new System.Windows.Forms.TextBox();
            this.dtpCheckoutDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCheckoutId
            // 
            this.txtCheckoutId.Location = new System.Drawing.Point(16, 15);
            this.txtCheckoutId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCheckoutId.Name = "txtCheckoutId";
            this.txtCheckoutId.Size = new System.Drawing.Size(265, 22);
            this.txtCheckoutId.TabIndex = 0;
            this.txtCheckoutId.Text = "Checkout ID";
            this.txtCheckoutId.TextChanged += new System.EventHandler(this.txtCheckoutId_TextChanged);
            // 
            // txtMemberId
            // 
            this.txtMemberId.Location = new System.Drawing.Point(16, 47);
            this.txtMemberId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(265, 22);
            this.txtMemberId.TabIndex = 1;
            this.txtMemberId.Text = "Member ID";
            // 
            // txtBookId
            // 
            this.txtBookId.Location = new System.Drawing.Point(16, 79);
            this.txtBookId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBookId.Name = "txtBookId";
            this.txtBookId.Size = new System.Drawing.Size(265, 22);
            this.txtBookId.TabIndex = 2;
            this.txtBookId.Text = "Book ID";
            // 
            // dtpCheckoutDate
            // 
            this.dtpCheckoutDate.Location = new System.Drawing.Point(16, 111);
            this.dtpCheckoutDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpCheckoutDate.Name = "dtpCheckoutDate";
            this.dtpCheckoutDate.Size = new System.Drawing.Size(265, 22);
            this.dtpCheckoutDate.TabIndex = 3;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Location = new System.Drawing.Point(16, 143);
            this.dtpDueDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(265, 22);
            this.dtpDueDate.TabIndex = 4;
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.Location = new System.Drawing.Point(16, 175);
            this.dtpReturnDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(265, 22);
            this.dtpReturnDate.TabIndex = 5;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(16, 207);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(267, 28);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // FormCreatePeminjaman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 250);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dtpReturnDate);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.dtpCheckoutDate);
            this.Controls.Add(this.txtBookId);
            this.Controls.Add(this.txtMemberId);
            this.Controls.Add(this.txtCheckoutId);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormCreatePeminjaman";
            this.Text = "Create Peminjaman";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
