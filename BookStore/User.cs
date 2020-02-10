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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }
        

        private void bntback1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Show();
            this.Visible = false;

        }

        private void User_Load(object sender, EventArgs e)
        {
            Employee em = new Employee();
            int ide = Convert.ToInt16(Employee.sendtext);
            textBox1.Text = ide + "";
            textBox2.Text = Employee.row+"";
            

            LogIn li = new LogIn();
            string acc = LogIn.acoount;
            button1.Text = acc + "";

            


            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");

                string sql = "select * from Username where eid ='"+ide+"'";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string id = r.GetValue(3) + "";
                    string name = r.GetValue(0) + "";
                    string pass = r.GetValue(1) + "";
                    string type = r.GetValue(2) + "";
                    dataGridView1.Rows.Add(id, name, pass, type);

                    
                }
                r.Close();
                s.Dispose();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            textBox3.Text = dataGridView1.RowCount + "";
            if  (Convert.ToInt16(textBox3.Text) > 1 )
            {
                button4.Enabled = false;
                button7.Enabled = true;
                button6.Enabled = true;
            }
            else if (Convert.ToInt16(textBox3.Text) <= 1)
            {
                button4.Enabled = true;
                button7.Enabled = false;
                button6.Enabled = false;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Employee em = new Employee();
            int ide = Convert.ToInt16(Employee.sendtext);
            textBox1.Text = ide + "";
            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");

                string sqlx = "select username from Username where username = '"+textBox6.Text.Trim()+"'";
                SqlCommand a = new SqlCommand(sqlx, DataCon.DataConnection);
                SqlDataReader r = a.ExecuteReader();
                while (r.Read())
                {
                    string idx = r.GetValue(0) + "";
                    textBox4.Text = idx;
                }
                r.Close();

                if (textBox4.Text != "")
                {
                    MessageBox.Show("Username has already been taken...");
                    textBox6.Text = "";
                    textBox7.Text = "";
                    comboBox1.Text = "";
                }
                else if ((textBox4.Text == ""))
                {
                    string id = textBox1.Text.Trim();
                    string name = textBox6.Text.Trim();
                    string pass = textBox7.Text.Trim();
                    string type = comboBox1.SelectedItem + "";
                    string sql = "insert into Username(eid,username, password, acctype) values ('" + ide + "',N'" + name + "',N'" + pass + "',N'" + type + "')";
                    SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                    s.ExecuteNonQuery();
                    s.Dispose();

                    string message = "Successfully ADD";
                    string title = " Message ";
                    MessageBox.Show(message, title);

                    User u = new User();
                    u.Show();
                    this.Dispose();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.RowCount - 1)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox6.Text = row.Cells[1].Value.ToString();
                textBox7.Text = row.Cells[2].Value.ToString();
                comboBox1.Text = row.Cells[3].Value.ToString();
                button4.Enabled = false;
                button7.Enabled = true;
                button6.Enabled = true;

            }
            else
            {
                button4.Enabled = false;
                button7.Enabled = false;
                button6.Enabled = false;

                textBox6.Text = "";
                textBox7.Text = "";
                comboBox1.Text = "";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");

                int row = Convert.ToInt16(textBox1.Text);
                string id = textBox1.Text.Trim();
                string name = textBox6.Text.Trim();
                string pass = textBox7.Text.Trim();
                string type = comboBox1.SelectedItem + "";
                string sql = "update Username SET username=N'" + name + "', password=N'" + pass + "', acctype=N'" + type + "'Where eid=" + row + " ;";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                s.ExecuteNonQuery();
                s.Dispose();

                string message = "Successfully Updated";
                string title = " Message ";
                MessageBox.Show(message, title);

                textBox6.Text = "";
                textBox7.Text = "";
                comboBox1.SelectedIndex = -1;

                User u = new User();
                u.Show();
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
                string sql = "delete from Username Where eid=" + row + " ;";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                s.ExecuteNonQuery();
                s.Dispose();

                string message = "One Row Deleted";
                string title = " Message ";
                MessageBox.Show(message, title);

                textBox6.Text = "";
                textBox7.Text = "";
                comboBox1.SelectedIndex = -1;

                LogIn em = new LogIn();
                em.Show();
                this.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void User_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
