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
    public partial class Income : Form
    {
        public Income()
        {
            InitializeComponent();
        }

        private void bntback1_Click(object sender, EventArgs e)
        {
            Expense ep = new Expense();
            ep.Show();
            this.Visible = false;
        }

        private void Income_Load(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            string acc = LogIn.acoount;
            button1.Text = acc + "";


            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");

                string sql = "SELECT *from Sale where saleid = (select max(saleid) from Sale) or saleid = (select max(saleid)-1 from Sale) or saleid = (select max(saleid)-2 from Sale); ";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string saleID1 = r.GetValue(0) + "";
                    string eid = r.GetValue(3) + "";
                    string saledate1 = r.GetValue(1) + "";
                    string total = r.GetValue(2) + "";
                    dataGridView2.Rows.Add(saleID1,  Convert.ToDateTime(saledate1), eid, total);
                    dataGridView2.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy".Trim();

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
            dataGridView2.Rows.Clear();
            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");

                string sql = "declare @x varchar(25);set @x = '" + textBox6.Text.Trim() + "';declare @y varchar(25);set @y = '" + textBox1.Text.Trim() + "';select* from Sale where saledate between @x and @y; ";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = s.ExecuteReader();
                double sum = 0;
                while (r.Read())
                {
                    string saleID1 = r.GetValue(0) + "";
                    string eid = r.GetValue(3) + "";
                    string saledate1 = r.GetValue(1) + "";
                    string total = r.GetValue(2) + "";
                    dataGridView2.Rows.Add(saleID1, eid, Convert.ToDateTime(saledate1), total);
                    dataGridView2.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy".Trim();
                    sum += Convert.ToDouble(total);
                }
                r.Close();
                s.Dispose();

                if (dataGridView2.Rows.Count > 1)
                {
                    string message = "Found";
                    string title = " Message ";
                    MessageBox.Show(message, title);
                    textBox2.Text = sum+"";
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

        private void Income_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Visible = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
