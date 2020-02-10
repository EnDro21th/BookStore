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
    public partial class HistoryExpense : Form
    {
        public HistoryExpense()
        {
            InitializeComponent();
        }

        private void bntback1_Click(object sender, EventArgs e)
        {
            Expense ep = new Expense();
            ep.Show();
            this.Visible = false;
        }

        private void HistoryExpense_Load(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            string acc = LogIn.acoount;
            button1.Text = acc + "";

            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");

                string sql = "SELECT *from Expense where expenseid = (select max(expenseid) from Expense) or expenseid = (select max(expenseid)-1 from Expense) or expenseid = (select max(expenseid)-2 from Expense); ";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string expenseID = r.GetValue(0) + "";
                    string eid = r.GetValue(3) + "";
                    string date = r.GetValue(1) + "";
                    string total = r.GetValue(2) + "";
                    dataGridView1.Rows.Add(expenseID, eid, Convert.ToDateTime(date),  total);
                    dataGridView1.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy".Trim();

                }
                r.Close();
                s.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");

                string sql = "declare @x varchar(25);set @x = '" + textBox6.Text.Trim() + "';declare @y varchar(25);set @y = '" + textBox1.Text.Trim() + "';select* from Expense where expensedate between @x and @y; ";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = s.ExecuteReader();
                double sum = 0;
                while (r.Read())
                {
                    string ep1 = r.GetValue(0) + "";
                    string eid1 = r.GetValue(3) + "";
                    string date1 = r.GetValue(1) + "";
                    string total1 = r.GetValue(2) + "";
                    dataGridView2.Rows.Add(ep1, eid1, Convert.ToDateTime(date1), total1);
                    dataGridView2.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy".Trim();
                    sum += Convert.ToDouble(total1);
                }
                r.Close();
                s.Dispose();

                if (dataGridView2.Rows.Count>1)
                {
                    string message = "Found";
                    string title = " Message ";
                    MessageBox.Show(message, title);
                    textBox2.Text = sum + "";
                }
                else
                {
                    string message = "No Record Found";
                    string title = " Message ";
                    MessageBox.Show(message, title);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }






        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void HistoryExpense_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Visible = false;
        }
    }
}
