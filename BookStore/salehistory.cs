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
    public partial class salehistory : Form
    {
        public salehistory()
        {
            InitializeComponent();
        }

        private void bntback1_Click(object sender, EventArgs e)
        {
            sale s = new sale();
            s.Show();
            this.Visible = false;
        }

        private void salehistory_Load(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            string acc = LogIn.acoount;
            button1.Text = acc + "";

            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");

                string sql = "SELECT *from Sale; ";
                double sum = 0;
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string saleid = r.GetValue(0) + "";
                    string employee = r.GetValue(3) + "";
                    string date = r.GetValue(1) + "";
                    string GrandTotal = r.GetValue(2) + "";
                    dataGridView1.Rows.Add(saleid, Convert.ToDateTime(date), employee, GrandTotal);
                    dataGridView1.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy".Trim();
                    sum += Convert.ToDouble(GrandTotal);
                    textBox2.Text = sum + "";
                }
                r.Close();
                s.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");

                string sql = "declare @x varchar(25);set @x = '" + textBox6.Text.Trim() + "';declare @y varchar(25);set @y = '" + textBox1.Text.Trim() + "';select* from Sale where saledate between @x and @y; ";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = s.ExecuteReader();
                double sum = 0,count=0;
                while (r.Read())
                {
                    string saleid = r.GetValue(0) + "";
                    string employee = r.GetValue(3) + "";
                    string date = r.GetValue(1) + "";
                    string GrandTotal = r.GetValue(2) + "";
                    dataGridView1.Rows.Add(saleid, Convert.ToDateTime(date), employee, GrandTotal);
                    dataGridView1.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy".Trim();
                    sum += Convert.ToDouble(GrandTotal);
                    textBox2.Text = sum + "";
                    count += 1;
                    textBox3.Text = count + "";
                }
                r.Close();
                s.Dispose();

                if (dataGridView1.Rows.Count > 1)
                {
                    count = Convert.ToDouble(textBox3.Text);
                    string message = "Found "+count+"";
                    string title = " Message ";
                    MessageBox.Show(message, title);
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

        private void salehistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Visible = false;
        }
    }
}
