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
    public partial class Expense : Form
    {
        public Expense()
        {
            InitializeComponent();
        }

        private void bntback1_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Income ic = new Income();
            ic.Show();
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HistoryExpense he = new HistoryExpense();
            he.Show();
            this.Visible = false;
        }

        private void Expense_Load(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            string acc = LogIn.acoount;
            button1.Text = acc + "";
            textBox3.Text = acc + "";

            DataCon.ConnectionDB("ENDROX", "BookStore");
            int index;
            string sql = "select MAX(expenseid) from Expense";
            SqlCommand a = new SqlCommand(sql, DataCon.DataConnection);
            SqlDataReader r = a.ExecuteReader();
            while (r.Read())
            {
                string id = r.GetValue(0) + "";
                index = Convert.ToInt16(id) + 1;
                textBox1.Text = index + "";
            }
            r.Close();

            sql = "select eid from Username where username='"+acc+"';";
            SqlCommand ai = new SqlCommand(sql, DataCon.DataConnection);
            SqlDataReader ri = ai.ExecuteReader();
            while (ri.Read())
            {
                string eidi = ri.GetValue(0) + "";
                index = Convert.ToInt16(eidi) ;
                textBox4.Text = index + "";


            }
            ri.Close();
            ai.Dispose();

            textBox5.Text = dateTimePicker1.Value.ToString("dd-MM-yyyy");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                if (textBox6.Text == "")
                {
                    textBox6.Focus();
                    MessageBox.Show("Please fill in 'Description'");
                }
                if (textBox7.Text == "")
                {
                    textBox7.Focus();
                    MessageBox.Show("Please fill in 'Price'");
                }
                if (textBox8.Text == "")
                {
                    textBox8.Focus();
                    MessageBox.Show("Please fill in 'Quantity'");
                }
            }
            else
            { 
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (textBox6.Text == dataGridView1["Description", i].Value+"")
                    {
                        MessageBox.Show("Duplicate ....");

                        DataGridViewRow rowa = this.dataGridView1.Rows[i];

                        textBox9.Text = rowa.Cells["Quantity"].Value+"";
                        int x = Convert.ToInt16(textBox9.Text) + Convert.ToInt16(textBox8.Text);

                        textBox10.Text = rowa.Cells["Cost"].Value + "";
                        int y = x * Convert.ToInt16(textBox10.Text);

                        int total = 0;
                        total += y;
                        textBox2.Text = total+"";

                        DataGridViewRow newDataRow = dataGridView1.Rows[i];
                        newDataRow.Cells["Quantity"].Value = x;
                        newDataRow.Cells["Amount"].Value = y;
                        goto x;
                    }
                }
                
                int row = 0;
                dataGridView1.Rows.Add();
                row = dataGridView1.Rows.Count - 2;
                dataGridView1["expense_id", row].Value = textBox1.Text;
                dataGridView1["Quantity", row].Value = textBox8.Text;
                dataGridView1["Description", row].Value = textBox6.Text;
                dataGridView1["Cost", row].Value = textBox7.Text;
                dataGridView1["Amount", row].Value = Convert.ToDouble(textBox7.Text) * Convert.ToDouble(textBox8.Text);


                string message = "Successfully Add";
                string title = " Message ";
                MessageBox.Show(message, title);

                x:
                double total1 = 0, sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    total1 += Convert.ToDouble(dataGridView1.Rows[i].Cells["Amount"].Value);
                }
                sum += total1;
                textBox2.Text = sum + "";

                comboBox1.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";

                textBox8.Enabled = false;
                textBox8.Text = "1";
                textBox8.Visible = false;

                button8.Enabled = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            string acc = LogIn.acoount;
            button1.Text = acc + "";

            
                try
                {
                    DataCon.ConnectionDB("ENDROX", "BookStore");

                    string sql;
                    int indexx = Convert.ToInt16(textBox1.Text);
                    double gtotal = Convert.ToDouble(textBox2.Text);
                    int eid = Convert.ToInt16(textBox4.Text);

                    sql = "insert into Expense(expenseid,expensedate, expensetotal, eid) values ('" + indexx + "',N'" + dateTimePicker1.Text + "','" + gtotal + "','" + eid + "');";
                    SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                    s.ExecuteNonQuery();
                    s.Dispose();

                    int ro = dataGridView1.RowCount - 1;
                    for (int i = 0; i < ro; i++)
                    {
                        sql = "insert into ExpenseDetail(expenseid,qty, description, price, amount) values ('" + Convert.ToInt16(dataGridView1.Rows[i].Cells["expense_id"].Value) + "','" + Convert.ToInt16(dataGridView1.Rows[i].Cells["Quantity"].Value) + "',N'" + dataGridView1.Rows[i].Cells["Description"].Value + "','" + Convert.ToSingle(dataGridView1.Rows[i].Cells["Cost"].Value) + "','" + Convert.ToSingle(dataGridView1.Rows[i].Cells["Amount"].Value) + "');";
                        SqlCommand si = new SqlCommand(sql, DataCon.DataConnection);
                        si.ExecuteNonQuery();

                    }

                    string message = "Successfully Saved";
                    string title = " Message ";
                    MessageBox.Show(message, title);

                    textBox2.Text = "";
                    dateTimePicker1.Value = System.DateTime.Now;
                    dataGridView1.Rows.Clear();
                    comboBox1.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";

                    textBox8.Enabled = false;
                    textBox8.Text = "1";
                    textBox8.Visible = false;

                    Visible = false;
                    Expense ep = new Expense();
                    ep.Show();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex.Equals(0))
            {
                textBox8.Enabled = true;
                textBox8.Text = "";
                textBox8.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                button4.Enabled = true;
            }
            else if (comboBox1.SelectedIndex.Equals(1))
            {
                textBox8.Enabled = false;
                textBox8.Text = "1";
                textBox8.Visible = false;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = false;
                textBox6.Visible = true;
                textBox7.Visible = true;
                button4.Enabled = true;
            }
            else if (comboBox1.SelectedIndex.Equals(2))
            {
                textBox8.Enabled = false;
                textBox8.Text = "1";
                textBox8.Visible = false;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = false;
                textBox6.Visible = true;
                textBox7.Visible = true;
                button4.Enabled = true;
            }
            else
            {
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                textBox8.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                button4.Enabled = false;
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox5.Text = dateTimePicker1.Value.ToString("dd-MM-yyyy");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int indexRow = 0;
            double cut = 0, sumf;
            cut += Convert.ToDouble(dataGridView1.CurrentRow.Cells["Amount"].Value);
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[1].Value = textBox8.Text;
            newDataRow.Cells[2].Value = textBox6.Text;
            newDataRow.Cells[3].Value = textBox7.Text;
            newDataRow.Cells[4].Value = Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox7.Text);

            int selectedRow;
            selectedRow = dataGridView1.CurrentCell.RowIndex;
            double newsum= Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox7.Text);
            sumf = Convert.ToDouble(textBox2.Text) - cut + newsum;
            textBox2.Text = sumf + "";

            string message = "Successfully Updated";
            string title = " Message ";
            MessageBox.Show(message, title);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.RowCount - 1)
            {
                button5.Enabled = true;
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox8.Text = row.Cells[1].Value.ToString();
                textBox6.Text = row.Cells[2].Value.ToString();
                textBox7.Text = row.Cells[3].Value.ToString();
                button4.Enabled = false;
                button7.Enabled = true;
                button6.Enabled = true;

            }
            else { 
                button4.Enabled = true;
                button7.Enabled = false;
                button6.Enabled = false;
                textBox6.Text = "";
                textBox7.Text = "";
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            int selectedRow;
            selectedRow = dataGridView1.CurrentCell.RowIndex;
            double cut = 0, sumf;
            cut += Convert.ToDouble(dataGridView1.CurrentRow.Cells["Amount"].Value);
            dataGridView1.Rows.RemoveAt(selectedRow);
            sumf = Convert.ToDouble(textBox2.Text) - cut;
            textBox2.Text = sumf + "";


            string message = "One Row Deleted";
            string title = " Message ";
            MessageBox.Show(message, title);

            comboBox1.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";

            textBox8.Enabled = false;
            textBox8.Text = "1";
            textBox8.Visible = false;
            button7.Enabled = false;
            button6.Enabled = false;

            if (dataGridView1.Rows.Count<2)
            {
                button8.Enabled = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Expense_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Visible = false;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox7.Text = textBox7.Text.Remove(textBox7.Text.Length - 1);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "[^A-Z],[^a-z]"))
            {
                MessageBox.Show("Please enter only letters.");
                textBox6.Text = textBox6.Text.Remove(textBox6.Text.Length - 1);
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox8.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox8.Text = textBox8.Text.Remove(textBox8.Text.Length - 1);
            }
        }
    }
}
