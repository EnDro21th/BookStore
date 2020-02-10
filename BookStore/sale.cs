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
    public partial class sale : Form
    {
        public sale()
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
            salehistory sh = new salehistory();
            sh.Show();
            this.Visible = false;
        }

        private void sale_Load(object sender, EventArgs e)
        {
            button4.Enabled = true;
            LogIn li = new LogIn();
            string acc = LogIn.acoount;
            button1.Text = acc + "";
            textBox3.Text = acc + "";


            DataCon.ConnectionDB("ENDROX", "BookStore");
            int index;
            string sql = "select MAX(saleid) from Sale";
            SqlCommand a = new SqlCommand(sql, DataCon.DataConnection);
            SqlDataReader r = a.ExecuteReader();
            while (r.Read())
            {
                string id = r.GetValue(0) + "";
                index = Convert.ToInt16(id) + 1;
                textBox1.Text = index + "";
            }
            r.Close();
            a.Dispose();

            sql = "select eid from Username where username='" + acc + "';";
            SqlCommand ai = new SqlCommand(sql, DataCon.DataConnection);
            SqlDataReader ri = ai.ExecuteReader();
            while (ri.Read())
            {
                string eidi = ri.GetValue(0) + "";
                index = Convert.ToInt16(eidi);
                textBox4.Text = index + "";
            }
            ri.Close();
            ai.Dispose();

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox10.Text == "")
            {
                if (textBox6.Text == "")
                {
                    textBox6.Focus();
                    MessageBox.Show("Please fill in 'Book Code'");
                }
                if (textBox10.Text == "")
                {
                    textBox10.Focus();
                    MessageBox.Show("Please fill in 'Quantity'");
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (textBox6.Text == dataGridView1["Book_Code", i].Value + "")
                    {
                        MessageBox.Show("Duplicate ....");

                        DataGridViewRow rowa = this.dataGridView1.Rows[i];

                        textBox12.Text = rowa.Cells["Quantity"].Value + "";
                        int x = Convert.ToInt16(textBox12.Text) + Convert.ToInt16(textBox10.Text);

                        textBox13.Text = rowa.Cells["Price"].Value + "";
                        int y = x * Convert.ToInt16(textBox13.Text);

                        int total = 0;
                        total += y;
                        textBox2.Text = total + "";

                        DataGridViewRow newDataRow = dataGridView1.Rows[i];
                        newDataRow.Cells["Quantity"].Value = x;
                        newDataRow.Cells["totals"].Value = y;
                        goto x;
                    }
                }

                int index;
                string sql;
                DataCon.ConnectionDB("ENDROX", "BookStore");
                sql = "select catid,bprice from Book where bid='" + textBox6.Text + "';";
                SqlCommand ae = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader re = ae.ExecuteReader();
                while (re.Read())
                {
                    string Gid = re.GetValue(0) + "";
                    string Bprice = re.GetValue(1) + "";
                    index = Convert.ToInt16(Gid);
                    textBox5.Text = Gid + "";
                    textBox11.Text = Bprice;
                }
                re.Close();
                ae.Dispose();

                sql = "select cname from Category where catid='" + textBox5.Text + "';";
                SqlCommand ai = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader ri = ai.ExecuteReader();
                while (ri.Read())
                {
                    string cname = ri.GetValue(0) + "";
                    textBox9.Text = cname + "";
                }
                ri.Close();
                ai.Dispose();


                int row = 0;
                dataGridView1.Rows.Add();
                row = dataGridView1.Rows.Count - 2;
                dataGridView1["Book_Code", row].Value = textBox6.Text;
                dataGridView1["Category", row].Value = textBox9.Text;
                dataGridView1["Quantity", row].Value = textBox10.Text;
                dataGridView1["Price", row].Value = textBox11.Text;
                dataGridView1["totals", row].Value = Convert.ToDouble(textBox10.Text) * Convert.ToDouble(textBox11.Text);
                textBox16.Text = textBox6.Text;

                string message = "Successfully Add";
                string title = " Message ";
                MessageBox.Show(message, title);

                x:
                double total1 = 0, sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    total1 += Convert.ToDouble(dataGridView1.Rows[i].Cells["totals"].Value);
                }
                sum += total1;
                textBox2.Text = sum + "";

                if (dataGridView1.RowCount > 1)
                {
                    textBox7.Enabled = true;
                    textBox8.Enabled = true;
                }
                else
                {
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                }
                button2.Enabled = true;
                textBox10.Text = "";
                textBox6.Text = "";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int indexRow = 0;
            double cut = 0, sumf;
            cut += Convert.ToDouble(dataGridView1.CurrentRow.Cells["totals"].Value);
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = textBox6.Text;
            newDataRow.Cells[2].Value = textBox10.Text;
            newDataRow.Cells[3].Value = textBox11.Text;
            newDataRow.Cells[4].Value = Convert.ToDouble(textBox10.Text) * Convert.ToDouble(textBox11.Text);

            int selectedRow;
            selectedRow = dataGridView1.CurrentCell.RowIndex;
            double newsum = Convert.ToDouble(textBox10.Text) * Convert.ToDouble(textBox11.Text);
            sumf = Convert.ToDouble(textBox2.Text) - cut + newsum;
            textBox2.Text = sumf + "";

            string message = "Successfully Updated";
            string title = " Message ";
            MessageBox.Show(message, title);

            textBox16.Text=textBox6.Text;

            textBox10.Text = "";
            textBox6.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.RowCount - 1)
            {
                button5.Enabled = true;
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox6.Text = row.Cells[0].Value.ToString();
                textBox10.Text = row.Cells[2].Value.ToString();
                textBox11.Text = row.Cells[3].Value.ToString();

                button4.Enabled = false;
                button7.Enabled = true;
                button6.Enabled = true;
            }
            else
            {
                button4.Enabled = true;
                button7.Enabled = false;
                button6.Enabled = false;

                textBox6.Text = "";
                textBox10.Text = "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int selectedRow;
            selectedRow = dataGridView1.CurrentCell.RowIndex;
            double cut = 0, sumf;
            cut += Convert.ToDouble(dataGridView1.CurrentRow.Cells["totals"].Value);
            dataGridView1.Rows.RemoveAt(selectedRow);
            sumf = Convert.ToDouble(textBox2.Text) - cut;
            textBox2.Text = sumf + "";


            string message = "One Row Deleted";
            string title = " Message ";
            MessageBox.Show(message, title);

            textBox6.Text = "";
            textBox10.Text = "";
            button4.Enabled = true;
            button7.Enabled = false;
            button6.Enabled = false;
            if (dataGridView1.Rows.Count < 2)
            {
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Please Complete form filling ...");
            }
            else
            {
                double D = 0, kh = 0, cb;
                D += Convert.ToDouble(textBox7.Text);
                kh += Convert.ToDouble(textBox8.Text) / 4000;
                cb = (D + kh) - Convert.ToDouble(textBox2.Text);
                if (cb >= 0)
                {
                    try
                    {
                        DataCon.ConnectionDB("ENDROX", "BookStore");

                        int dindex, x;
                        float y;
                        string sql = "select bid, bqty from Book where bid ='" + textBox16.Text + "'";
                        SqlCommand a = new SqlCommand(sql, DataCon.DataConnection);
                        SqlDataReader r = a.ExecuteReader();
                        while (r.Read())
                        {
                            string id = r.GetValue(0) + "";
                            dindex = Convert.ToInt16(id);
                            textBox14.Text = dindex + "";

                            string idx = r.GetValue(1) + "";
                            x = Convert.ToInt16(idx);
                            textBox15.Text = x + "";
                            
                        }
                        r.Close();
                        
                        int indexx = Convert.ToInt16(textBox1.Text);
                        double gtotal = Convert.ToDouble(textBox2.Text);
                        int eid = Convert.ToInt16(textBox4.Text);
                        sql = "insert into Sale(saleid,saledate, samount, eid) values ('" + indexx + "',N'" + dateTimePicker1.Text + "','" + gtotal + "','" + eid + "');";
                        SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                        s.ExecuteNonQuery();
                        s.Dispose();

                        int ro = dataGridView1.RowCount - 1;
                        for (int i = 0; i < ro; i++)
                        {
                            sql = "insert into SaleDetail(saleid,sdqty, sdprice, sdtotal, bid) values ('" + indexx + "','" + Convert.ToInt16(dataGridView1.Rows[i].Cells["Quantity"].Value) + "','" + Convert.ToSingle(dataGridView1.Rows[i].Cells["Price"].Value) + "','" + Convert.ToSingle(dataGridView1.Rows[i].Cells["totals"].Value) + "','" + dataGridView1.Rows[i].Cells["Book_Code"].Value + "');";
                            SqlCommand si = new SqlCommand(sql, DataCon.DataConnection);
                            si.ExecuteNonQuery();

                            int nbqty = Convert.ToInt16(textBox15.Text) - Convert.ToInt16(dataGridView1.Rows[i].Cells["Quantity"].Value);
                            sql = "update Book set bqty ='" + nbqty + "' where bid = '" + textBox16.Text + "' ;";
                            SqlCommand sa = new SqlCommand(sql, DataCon.DataConnection);
                            sa.ExecuteNonQuery();

                        }
                        string message = "Cashback = " + cb + "";
                        string title = " Message ";
                        MessageBox.Show(message, title);

                        message = "Successfully Saved";
                        title = " Message ";
                        MessageBox.Show(message, title);
                        

                        textBox2.Text = "";
                        dateTimePicker1.Value = System.DateTime.Now;
                        dataGridView1.Rows.Clear();
                        textBox6.Text = "";
                        textBox10.Text = "";
                        textBox11.Text = "";

                        Visible = false;
                        sale sl = new sale();
                        sl.Show();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    string message = "Need " + cb + " to Complete the Payment";
                    string title = " Message ";
                    MessageBox.Show(message, title);
                }
            }

                    
                
            
        }

        private void sale_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Visible = false;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox10.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox10.Text = textBox10.Text.Remove(textBox10.Text.Length - 1);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox7.Text = textBox7.Text.Remove(textBox7.Text.Length - 1);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
