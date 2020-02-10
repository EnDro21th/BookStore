using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HistoryImport hi = new HistoryImport();
            hi.Show();
            this.Visible = false;
        }

        private void Expense_Click(object sender, EventArgs e)
        {
            Expense ep = new Expense();
            ep.Show();
            this.Visible = false;
        }

        private void password_Click(object sender, EventArgs e)
        {
            Password ps = new Password();
            ps.Show();
            this.Visible = false;
        }

        private void logout_Click(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            li.Show();
            this.Visible = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            string acc = LogIn.acoount;
            password.Text = acc + "";

            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");
                string sql = "SELECT acctype FROM Username WHERE username='" + acc + "';";
                SqlCommand a = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = a.ExecuteReader();
                while (r.Read())
                {
                    string id = r.GetValue(0) + "";

                    boxx.Text = id + "";
                }
                r.Close();

                if (boxx.Text == "admin")
                {
                    Book.Enabled = true;
                    Expense.Enabled = true;
                    Sale.Enabled = true;
                    User.Enabled = true;
                }
                if (boxx.Text == "stock")
                {
                    Book.Enabled = true;
                    Expense.Enabled = false;
                    Sale.Enabled = false;
                    User.Enabled = false;
                }
                if (boxx.Text == "cashier")
                {
                    Book.Enabled = false;
                    Expense.Enabled = false;
                    Sale.Enabled = true;
                    User.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void User_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Show();
            this.Visible = false;
        }

        private void Sale_Click(object sender, EventArgs e)
        {
            sale sl = new sale();
            sl.Show();
            this.Visible = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogIn li = new LogIn();
            li.Show();
            this.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
