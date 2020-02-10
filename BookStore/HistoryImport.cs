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
    public partial class HistoryImport : Form
    {
        public HistoryImport()
        {
            InitializeComponent();
        }

        private void bntback1_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ImportBook ib = new ImportBook();
            ib.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stock st = new Stock();
            st.Show();
            this.Visible = false;
        }

        private void HistoryImport_Load(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            string acc = LogIn.acoount;
            button1.Text = acc + "";


            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");

                string sql = "SELECT *from Import where Importid = (select max(Importid) from Import) or Importid = (select max(Importid)-1 from Import) or Importid = (select max(Importid)-2 from Import); ";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string ImportID = r.GetValue(0) + "";
                    string employee = r.GetValue(3) + "";
                    string Date = r.GetValue(1) + "";
                    string GrandTotal = r.GetValue(2) + "";
                    string supplier = r.GetValue(4) + "";
                    dataGridView1.Rows.Add(ImportID, employee, supplier, Convert.ToDateTime(Date), GrandTotal);
                    dataGridView1.Columns[3].DefaultCellStyle.Format = "MM/dd/yyyy".Trim();

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

                string sql = "declare @x varchar(25);set @x = '" + textBox6.Text.Trim() + "';declare @y varchar(25);set @y = '" + textBox1.Text.Trim() + "';select* from Import where Importdate between @x and @y;";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string ImportID = r.GetValue(0) + "";
                    string employee = r.GetValue(3) + "";
                    string Date = r.GetValue(1) + "";
                    string GrandTotal = r.GetValue(2) + "";
                    string supplier = r.GetValue(4) + "";
                    dataGridView2.Rows.Add(ImportID, employee, supplier, Convert.ToDateTime(Date), GrandTotal);
                    dataGridView2.Columns[3].DefaultCellStyle.Format = "MM/dd/yyyy".Trim();

                }
                r.Close();
                s.Dispose();
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void HistoryImport_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Visible = false;
        }
    }
}
