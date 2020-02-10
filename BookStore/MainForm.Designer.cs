namespace BookStore
{
    partial class MainForm
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
            this.Book = new System.Windows.Forms.Button();
            this.Expense = new System.Windows.Forms.Button();
            this.Sale = new System.Windows.Forms.Button();
            this.User = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.boxx = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Book
            // 
            this.Book.Location = new System.Drawing.Point(25, 177);
            this.Book.Name = "Book";
            this.Book.Size = new System.Drawing.Size(256, 410);
            this.Book.TabIndex = 0;
            this.Book.Text = "Book";
            this.Book.UseVisualStyleBackColor = true;
            this.Book.Click += new System.EventHandler(this.button1_Click);
            // 
            // Expense
            // 
            this.Expense.Location = new System.Drawing.Point(341, 177);
            this.Expense.Name = "Expense";
            this.Expense.Size = new System.Drawing.Size(256, 410);
            this.Expense.TabIndex = 1;
            this.Expense.Text = "Expense";
            this.Expense.UseVisualStyleBackColor = true;
            this.Expense.Click += new System.EventHandler(this.Expense_Click);
            // 
            // Sale
            // 
            this.Sale.Location = new System.Drawing.Point(665, 177);
            this.Sale.Name = "Sale";
            this.Sale.Size = new System.Drawing.Size(256, 410);
            this.Sale.TabIndex = 2;
            this.Sale.Text = "Sale";
            this.Sale.UseVisualStyleBackColor = true;
            this.Sale.Click += new System.EventHandler(this.Sale_Click);
            // 
            // User
            // 
            this.User.Location = new System.Drawing.Point(984, 177);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(256, 410);
            this.User.TabIndex = 3;
            this.User.Text = "User";
            this.User.UseVisualStyleBackColor = true;
            this.User.Click += new System.EventHandler(this.User_Click);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(1075, 23);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(166, 44);
            this.password.TabIndex = 4;
            this.password.Text = "Password";
            this.password.UseVisualStyleBackColor = true;
            this.password.Click += new System.EventHandler(this.password_Click);
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(1151, 84);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(89, 28);
            this.logout.TabIndex = 5;
            this.logout.Text = "Logout";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // boxx
            // 
            this.boxx.Location = new System.Drawing.Point(41, 89);
            this.boxx.Margin = new System.Windows.Forms.Padding(2);
            this.boxx.Name = "boxx";
            this.boxx.Size = new System.Drawing.Size(76, 20);
            this.boxx.TabIndex = 7;
            this.boxx.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(257, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 70);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.boxx);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.password);
            this.Controls.Add(this.User);
            this.Controls.Add(this.Sale);
            this.Controls.Add(this.Expense);
            this.Controls.Add(this.Book);
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Book;
        private System.Windows.Forms.Button Expense;
        private System.Windows.Forms.Button Sale;
        private System.Windows.Forms.Button User;
        private System.Windows.Forms.Button password;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.TextBox boxx;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

