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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        public static string sendtext = "";
        public static int row;
        

        private void Employee_Load(object sender, EventArgs e)
        {
            button4.Enabled = true;
            LogIn li = new LogIn();
            string acc = LogIn.acoount;
            button1.Text = acc + "";

            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");

                string sql = "select * from Employee";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string id = r.GetValue(0) + "";
                    string name = r.GetValue(1) + "";
                    string address = r.GetValue(3) + "";
                    string contact = r.GetValue(4) + "";
                    string position = r.GetValue(2) + "";
                    dataGridView1.Rows.Add(id, name, address, contact, position);
                }
                r.Close();
                s.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bntback1_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Visible = false;
        }

        public void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Equals(true))
            {
                int id = Convert.ToInt16(textBox1.ToString());
            }

            row = dataGridView1.RowCount;
           


            User us = new User();
            us.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                if (textBox6.Text == "")
                {
                    textBox6.Focus();
                    MessageBox.Show("Please fill in 'Name'");
                }
                if (textBox7.Text == "")
                {
                    textBox7.Focus();
                    MessageBox.Show("Please fill in 'Address'");
                }
                if (textBox8.Text == "")
                {
                    textBox8.Focus();
                    MessageBox.Show("Please fill in 'Contact'");
                }
                if (textBox9.Text == "")
                {
                    textBox9.Focus();
                    MessageBox.Show("Please fill in 'Position'");
                }
            }
            else
            {
                try
                {
                    int index;
                    string sql = "select MAX(eid) from Employee";
                    SqlCommand a = new SqlCommand(sql, DataCon.DataConnection);
                    SqlDataReader r = a.ExecuteReader();
                    while (r.Read())
                    {
                        string id = r.GetValue(0) + "";
                        index = Convert.ToInt16(id) + 1;
                        textBox1.Text = index + "";
                    }
                    r.Close();

                    string indexx = textBox1.Text.Trim();
                    string name = textBox6.Text.Trim();
                    string contact = textBox8.Text.Trim();
                    string position = textBox9.Text.Trim();
                    string address = textBox7.Text.Trim();
                    sql = "insert into Employee(eid,ename, position, address, telephone) values ('" + indexx + "',N'" + name + "',N'" + position + "',N'" + address + "','" + contact + "')";
                    SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                    s.ExecuteNonQuery();
                    s.Dispose();

                    Employee em = new Employee();
                    em.Show();
                    this.Dispose();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.RowCount - 1)
            {
                button5.Enabled=true;
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox6.Text = row.Cells[1].Value.ToString();
                textBox7.Text = row.Cells[2].Value.ToString();
                textBox8.Text = row.Cells[3].Value.ToString();
                textBox9.Text = row.Cells[4].Value.ToString();

                button4.Enabled = false;
                button7.Enabled = true;
                button6.Enabled = true;

            }
            else
            {
                button5.Enabled = false;
                button4.Enabled = true;
                button7.Enabled = false;
                button6.Enabled = false;

                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
            }
            sendtext = textBox1.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");

                int row = dataGridView1.CurrentCell.RowIndex+1;
                string name = textBox6.Text.Trim();
                string contact = textBox8.Text.Trim();
                string position = textBox9.Text.Trim();
                string address = textBox7.Text.Trim();
                string sql = "update Employee SET ename=N'" + name + "', position=N'" + position + "', address=N'" + address + "', telephone='" + contact + "'Where eid="+row+" ;";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                s.ExecuteNonQuery();
                s.Dispose();

                string message = "Successfully Updated";
                string title = " Message ";
                MessageBox.Show(message, title);

                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";

                Employee em = new Employee();
                em.Show();
                this.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");

                int row = Convert.ToInt16(textBox1.Text);
                string sql = "delete from Employee Where eid=" + row + " ;";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                s.ExecuteNonQuery();
                s.Dispose();

                string message = "One Row Deleted";
                string title = " Message ";
                MessageBox.Show(message, title);

                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";

                button4.Enabled = true;
                button7.Enabled = false;
                button6.Enabled = false;
                
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Employee_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
