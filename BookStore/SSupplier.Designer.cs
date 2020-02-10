namespace BookStore
{
    partial class SSupplier
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Supplierid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ssname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ssAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bntback1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Supplierid,
            this.ssname,
            this.ssAddress,
            this.contact});
            this.dataGridView1.Location = new System.Drawing.Point(12, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(880, 231);
            this.dataGridView1.TabIndex = 0;
            // 
            // Supplierid
            // 
            this.Supplierid.HeaderText = "Supplier No.";
            this.Supplierid.Name = "Supplierid";
            this.Supplierid.ReadOnly = true;
            this.Supplierid.Width = 200;
            // 
            // ssname
            // 
            this.ssname.HeaderText = "Supplier Name";
            this.ssname.Name = "ssname";
            this.ssname.ReadOnly = true;
            this.ssname.Width = 200;
            // 
            // ssAddress
            // 
            this.ssAddress.HeaderText = "Supplier Address";
            this.ssAddress.Name = "ssAddress";
            this.ssAddress.ReadOnly = true;
            this.ssAddress.Width = 300;
            // 
            // contact
            // 
            this.contact.HeaderText = "Contact";
            this.contact.Name = "contact";
            this.contact.ReadOnly = true;
            this.contact.Width = 200;
            // 
            // bntback1
            // 
            this.bntback1.Location = new System.Drawing.Point(720, 337);
            this.bntback1.Name = "bntback1";
            this.bntback1.Size = new System.Drawing.Size(72, 29);
            this.bntback1.TabIndex = 2;
            this.bntback1.Text = "<   Back";
            this.bntback1.UseVisualStyleBackColor = true;
            this.bntback1.Click += new System.EventHandler(this.bntback1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(133, 315);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(202, 20);
            this.textBox2.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 318);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Search By Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(241, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 378);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bntback1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGridView1);
            this.MaximumSize = new System.Drawing.Size(920, 417);
            this.MinimumSize = new System.Drawing.Size(920, 417);
            this.Name = "SSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSupplier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SSupplier_FormClosing);
            this.Load += new System.EventHandler(this.SSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bntback1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplierid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ssname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ssAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn contact;
        private System.Windows.Forms.Button button1;
    }
}