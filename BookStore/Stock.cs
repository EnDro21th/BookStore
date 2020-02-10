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
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }
        public static string sendtext = "";

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bntback1_Click(object sender, EventArgs e)
        {
            HistoryImport hi = new HistoryImport();
            hi.Show();
            this.Visible = false;
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            string acc = LogIn.acoount;
            button2.Text = acc + "";
            button1.Text = "By Book Name";

            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");

                string sql = "SELECT * from Book; ";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string Book_Code = r.GetValue(0) + "";
                    string Title = r.GetValue(1) + "";
                    string Quantity = r.GetValue(2) + "";
                    string Author = r.GetValue(5) + "";
                    string year = r.GetValue(6) + "";
                    string Location = r.GetValue(7) + "";
                    string Price = r.GetValue(3) + "";
                    string Genre = r.GetValue(4) + "";
                    string Attachment = r.GetValue(8) + "";
                    dataGridView1.Rows.Add(Book_Code,Title,Quantity,Author,year,Location,Price,Genre,Attachment);

                }
                r.Close();
                s.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && button1.Text == "By Book Name")
            {
                dataGridView1.Rows.Clear();
                try
                {
                    DataCon.ConnectionDB("ENDROX", "BookStore");

                    string sql = "SELECT * from Book where bname like '%" + textBox2.Text.Trim() + "%';";
                    SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                    SqlDataReader r = s.ExecuteReader();
                    int c = 0;
                    while (r.Read())
                    {
                        string Book_Code = r.GetValue(0) + "";
                        string Title = r.GetValue(1) + "";
                        string Quantity = r.GetValue(2) + "";
                        string Author = r.GetValue(5) + "";
                        string year = r.GetValue(6) + "";
                        string Location = r.GetValue(7) + "";
                        string Price = r.GetValue(3) + "";
                        string Genre = r.GetValue(4) + "";
                        string Attachment = r.GetValue(8) + "";
                        dataGridView1.Rows.Add(Book_Code, Title, Quantity, Author, year, Location, Price, Genre, Attachment);
                        c++;
                        textBox3.Text = c + "";
                    }
                    r.Close();
                    s.Dispose();
                    MessageBox.Show(textBox3.Text+" Record Found");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else if (textBox2.Text == "" && button1.Text == "By Book Name")
            {
                button1.Text = "By Book Code";
            }

            else if(textBox2.Text != "" && button1.Text == "By Book Code")
            {
                dataGridView1.Rows.Clear();
                try
                {
                    DataCon.ConnectionDB("ENDROX", "BookStore");

                    string sql = "SELECT * from Book where bid like '%" + textBox2.Text.Trim() + "%';";
                    SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                    SqlDataReader r = s.ExecuteReader();
                    int c = 0;
                    while (r.Read())
                    {
                        string Book_Code = r.GetValue(0) + "";
                        string Title = r.GetValue(1) + "";
                        string Quantity = r.GetValue(2) + "";
                        string Author = r.GetValue(5) + "";
                        string year = r.GetValue(6) + "";
                        string Location = r.GetValue(7) + "";
                        string Price = r.GetValue(3) + "";
                        string Genre = r.GetValue(4) + "";
                        string Attachment = r.GetValue(8) + "";
                        dataGridView1.Rows.Add(Book_Code, Title, Quantity, Author, year, Location, Price, Genre, Attachment);
                        c++;
                        textBox3.Text = c + "";

                    }
                    r.Close();
                    s.Dispose();
                    MessageBox.Show(textBox3.Text + " Record Found");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (textBox2.Text == "" && button1.Text == "By Book Code")
            {
                button1.Text = "By Book Name";
            }

            
        }

        private void Stock_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Visible = false;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.RowCount - 1)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                sendtext = textBox1.Text;
                stockaj sj = new stockaj();
                sj.Show();
                Visible = false;
            }
        }
    }
}
