using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class ImportBook : Form
    {
        public ImportBook()
        {
            InitializeComponent();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ImportBook_Load(object sender, EventArgs e)
        {
            button4.Enabled = true;
            LogIn li = new LogIn();
            string acc = LogIn.acoount;
            button1.Text = acc + "";
            textBox3.Text = acc + "";
            
            DataCon.ConnectionDB("ENDROX", "BookStore");
            int index;
            string sql = "select MAX(Importid) from Import";
            SqlCommand a = new SqlCommand(sql, DataCon.DataConnection);
            SqlDataReader r = a.ExecuteReader();
            while (r.Read())
            {
                string id = r.GetValue(0) + "";
                index = Convert.ToInt16(id) + 1;
                textBox1.Text = index + "";
            }
            r.Close();

            sql = "select eid from Username where username='" + acc + "';";
            SqlCommand ai = new SqlCommand(sql, DataCon.DataConnection);
            SqlDataReader ri = ai.ExecuteReader();
            while (ri.Read())
            {
                string eidi = ri.GetValue(0) + "";
                index = Convert.ToInt16(eidi);
                textBox14.Text = index + "";


            }
            ri.Close();
            ai.Dispose();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            HistoryImport hi = new HistoryImport();
            hi.Show();
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Supplier sp = new Supplier();
            sp.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SSupplier ssp = new SSupplier();
            ssp.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            string acc = LogIn.acoount;
            button1.Text = acc + "";

            if (textBox4.Text == "")
            {
                MessageBox.Show("Please Fill in Supplier No.");
            }
            else
            {
                try
                {
                    DataCon.ConnectionDB("ENDROX", "BookStore");

                    int dindex,x;
                    float y;
                    string sql = "select bid, bqty, bprice from Book where bid ='"+textBox21.Text+"'";
                    SqlCommand a = new SqlCommand(sql, DataCon.DataConnection);
                    SqlDataReader r = a.ExecuteReader();
                    while (r.Read())
                    {
                        string id = r.GetValue(0) + "";
                        dindex = Convert.ToInt16(id);
                        textBox18.Text = dindex + "";

                        string idx = r.GetValue(1) + "";
                        x = Convert.ToInt16(idx);
                        textBox19.Text = x + "";

                        string idy = r.GetValue(2) + "";
                        y = Convert.ToSingle(idy);
                        textBox20.Text = y + "";
                    }
                    r.Close();

                    int indexx = Convert.ToInt16(textBox1.Text);
                    double gtotal = Convert.ToDouble(textBox2.Text);
                    int eid = Convert.ToInt16(textBox14.Text);
                    int supid = Convert.ToInt16(textBox4.Text);

                    sql = "insert into Import(Importid,Importdate, total, eid, supid) values ('" + indexx + "','" + dateTimePicker1.Text + "','" + gtotal + "','" + eid + "','" + supid + "');";
                    SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                    s.ExecuteNonQuery();
                    s.Dispose();

                    int ro = dataGridView1.RowCount - 1;
                    for (int i = 0; i < ro; i++)
                    {
                        if (textBox18.Text == "")
                        {
                            sql = "insert into Book(bid, bname, bqty, bprice, catid, author, Year, location, Attachment) values ('" + dataGridView1.Rows[i].Cells["Book_Code"].Value + "','" + dataGridView1.Rows[i].Cells["Title"].Value + "','" + Convert.ToInt16(dataGridView1.Rows[i].Cells["Quantity"].Value) + "','" + Convert.ToSingle(dataGridView1.Rows[i].Cells["Price"].Value) + "','" + Convert.ToInt16(dataGridView1.Rows[i].Cells["Genre"].Value) + "','" + dataGridView1.Rows[i].Cells["Author"].Value + "','" + dataGridView1.Rows[i].Cells["year"].Value + "','" + dataGridView1.Rows[i].Cells["Location"].Value + "',N'" + dataGridView1.Rows[i].Cells["Attachment"].Value + "');";
                            SqlCommand sa = new SqlCommand(sql, DataCon.DataConnection);
                            sa.ExecuteNonQuery();
                        }
                        else
                        {
                            int nbqty = Convert.ToInt16(textBox19.Text) + Convert.ToInt16(dataGridView1.Rows[i].Cells["Quantity"].Value);
                            sql = "update Book set bqty ='"+nbqty+ "' where bid = '"+textBox18.Text+"' ;";
                            SqlCommand sa = new SqlCommand(sql, DataCon.DataConnection);
                            sa.ExecuteNonQuery();
                        }
                        
                        sql = "insert into Importdetail(Importid,iqty, iamout, iprice, bid) values ('" + indexx + "','" + Convert.ToInt16(dataGridView1.Rows[i].Cells["Quantity"].Value) + "','" + Convert.ToSingle(dataGridView1.Rows[i].Cells["Cost"].Value) + "','" + Convert.ToSingle(dataGridView1.Rows[i].Cells["Price"].Value) + "','" + dataGridView1.Rows[i].Cells["Book_Code"].Value + "');";
                        SqlCommand si = new SqlCommand(sql, DataCon.DataConnection);
                        si.ExecuteNonQuery();

                    }

                    string message = "Successfully Saved";
                    string title = " Message ";
                    MessageBox.Show(message, title);

                    textBox2.Text = "";
                    dateTimePicker1.Value = System.DateTime.Now;
                    dataGridView1.Rows.Clear();
                    comboBox1.SelectedIndex = -1;
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";

                    Visible = false;
                    HistoryImport hi = new HistoryImport();
                    hi.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

                
            
        }
        public void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string filename = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                textBox9.Text = filename + "";
                textBox17.Text = textBox9.Text + "";
                pictureBox1.Image = Image.FromFile(textBox9.Text);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "")
            {
                if(textBox5.Text == "")
                {
                    textBox5.Focus();
                    MessageBox.Show("Please fill in 'Cost'");
                }
                if (textBox6.Text == "")
                {
                    textBox6.Focus();
                    MessageBox.Show("Please fill in 'Book Code'");
                }
                if (textBox7.Text == "")
                {
                    textBox7.Focus();
                    MessageBox.Show("Please fill in 'Title'");
                }
                if (textBox8.Text == "")
                {
                    textBox8.Focus();
                    MessageBox.Show("Please fill in 'Author'");
                }
                if (textBox10.Text == "")
                {
                    textBox10.Focus();
                    MessageBox.Show("Please fill in 'Location'");
                }
                if (textBox11.Text == "")
                {
                    textBox11.Focus();
                    MessageBox.Show("Please fill in 'Year of Publish'");
                }
                if (textBox12.Text == "")
                {
                    textBox12.Focus();
                    MessageBox.Show("Please fill in 'Price'");
                }
                if (textBox13.Text == "")
                {
                    textBox13.Focus();
                    MessageBox.Show("Please fill in 'QTY'");
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

                        textBox15.Text = rowa.Cells["Quantity"].Value + "";
                        int x = Convert.ToInt16(textBox13.Text) + Convert.ToInt16(textBox15.Text);

                        textBox16.Text = rowa.Cells["Cost"].Value + "";
                        int y = x * Convert.ToInt16(textBox16.Text);

                        int totalx = 0;
                        totalx += y;
                        textBox2.Text = totalx + "";

                        DataGridViewRow newDataRow = dataGridView1.Rows[i];
                        newDataRow.Cells["Quantity"].Value = x;
                        newDataRow.Cells["Total"].Value = y;
                        goto x;
                    }
                }
                int row = 0;
                textBox18.Text = textBox6.Text;
                dataGridView1.Rows.Add();
                row = dataGridView1.Rows.Count - 2;
                dataGridView1["Book_Code", row].Value = textBox6.Text;
                dataGridView1["Title", row].Value = textBox7.Text;
                dataGridView1["Quantity", row].Value = textBox13.Text;
                dataGridView1["Author", row].Value = textBox8.Text;
                dataGridView1["Year", row].Value = textBox11.Text;
                dataGridView1["Location", row].Value = textBox10.Text;
                dataGridView1["Cost", row].Value = textBox5.Text;
                dataGridView1["Price", row].Value = textBox12.Text;
                dataGridView1["Genre", row].Value = comboBox1.SelectedIndex + 1;
                dataGridView1["Attachment", row].Value = textBox17.Text;
                dataGridView1["Total", row].Value = Convert.ToDouble(textBox5.Text) * Convert.ToDouble(textBox13.Text);
                textBox21.Text = textBox6.Text;

                string message = "Successfully ADD";
                string title = " Message ";
                MessageBox.Show(message, title);

                x:
                double total = 0, sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    total += Convert.ToDouble(dataGridView1.Rows[i].Cells["Total"].Value);
                }
                sum += total;
                textBox2.Text = sum + "";


                textBox6.Text = "";
                textBox7.Text = "";
                textBox13.Text = "";
                textBox8.Text = "";
                textBox11.Text = "";
                textBox10.Text = "";
                textBox5.Text = "";
                textBox12.Text = "";
                comboBox1.SelectedIndex = -1;
                button8.Enabled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.RowCount - 1)
            {


                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox6.Text = row.Cells[0].Value.ToString();
                textBox7.Text = row.Cells[1].Value.ToString();
                textBox13.Text = row.Cells[2].Value.ToString();
                textBox8.Text = row.Cells[3].Value.ToString();
                textBox11.Text = row.Cells[4].Value.ToString();
                textBox10.Text = row.Cells[5].Value.ToString();
                textBox5.Text = row.Cells[6].Value.ToString();
                textBox12.Text = row.Cells[7].Value.ToString();
                comboBox1.SelectedIndex = Convert.ToInt16(row.Cells[8].Value.ToString());
                textBox17.Text = row.Cells[9].Value.ToString();
                pictureBox1.Image = Image.FromFile(textBox17.Text);


                button4.Enabled = false;
                button7.Enabled = true;
                button6.Enabled = true;
                button3.Enabled = true;


            }
            else
            {
                button4.Enabled = true;
                button7.Enabled = false;
                button6.Enabled = false;

                textBox6.Text = "";
                textBox7.Text = "";
                textBox13.Text = "";
                textBox8.Text = "";
                textBox11.Text = "";
                textBox10.Text = "";
                textBox5.Text = "";
                textBox12.Text = "";
                comboBox1.SelectedIndex = -1;

                textBox7.Enabled = true;
                textBox8.Enabled = true;
                comboBox1.Enabled = true;
                textBox11.Enabled = true;
                textBox10.Enabled = true;
                textBox17.Enabled = true;
                textBox12.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int indexRow=0;
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = textBox6.Text;
            newDataRow.Cells[1].Value = textBox7.Text;
            newDataRow.Cells[2].Value = textBox13.Text;
            newDataRow.Cells[3].Value = textBox8.Text;
            newDataRow.Cells[4].Value = textBox11.Text;
            newDataRow.Cells[5].Value = textBox10.Text;
            newDataRow.Cells[6].Value = textBox5.Text;
            newDataRow.Cells[7].Value = textBox12.Text;
            newDataRow.Cells[8].Value = comboBox1.SelectedIndex+1;
            newDataRow.Cells[9].Value = textBox17.Text;

            int selectedRow;
            double cut = 0, sumf;
            cut += Convert.ToDouble(dataGridView1.CurrentRow.Cells["total"].Value);
            selectedRow = dataGridView1.CurrentCell.RowIndex;
            double newsum = Convert.ToDouble(textBox5.Text) * Convert.ToDouble(textBox13.Text);
            sumf = Convert.ToDouble(textBox2.Text) - cut + newsum;
            textBox2.Text = sumf + "";

            string message = "Successfully Updated";
            string title = " Message ";
            MessageBox.Show(message, title);

            textBox6.Text = "";
            textBox7.Text = "";
            textBox13.Text = "";
            textBox8.Text = "";
            textBox11.Text = "";
            textBox10.Text = "";
            textBox5.Text = "";
            textBox12.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        public void button6_Click(object sender, EventArgs e)
        {
            int selectedRow;
            selectedRow = dataGridView1.CurrentCell.RowIndex;
            double cut = 0,sumf;
            cut += Convert.ToDouble(dataGridView1.CurrentRow.Cells["Total"].Value);
            dataGridView1.Rows.RemoveAt(selectedRow);
            sumf = Convert.ToDouble(textBox2.Text)-cut;
            textBox2.Text = sumf + "";


            string message = "One Row Deleted";
            string title = " Message ";
            MessageBox.Show(message, title);

            textBox6.Text = "";
            textBox7.Text = "";
            textBox13.Text = "";
            textBox8.Text = "";
            textBox11.Text = "";
            textBox10.Text = "";
            textBox5.Text = "";
            textBox12.Text = "";
            comboBox1.SelectedIndex = -1;
            button4.Enabled = true;
            button7.Enabled = false;
            button6.Enabled = false;
            if (dataGridView1.Rows.Count < 2)
            {
                button8.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void ImportBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Visible = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox8.Text, "[^A-Z],[^a-z]"))
            {
                MessageBox.Show("Please enter only letters.");
                textBox8.Text = textBox8.Text.Remove(textBox8.Text.Length - 1);
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox11.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox11.Text = textBox11.Text.Remove(textBox11.Text.Length - 1);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox5.Text = textBox5.Text.Remove(textBox5.Text.Length - 1);
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox12.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox12.Text = textBox12.Text.Remove(textBox12.Text.Length - 1);
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox13.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox13.Text = textBox13.Text.Remove(textBox13.Text.Length - 1);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox4.Text = textBox4.Text.Remove(textBox4.Text.Length - 1);
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            textBox22.Text = "";
            textBox7.Text = "";
            textBox13.Text = "";
            textBox8.Text = "";
            textBox11.Text = "";
            textBox10.Text = "";
            textBox5.Text = "";
            textBox12.Text = "";
            comboBox1.SelectedIndex = -1;

            if (textBox6.Text == "")
            {
                textBox6.Focus();
                MessageBox.Show("Please fill in 'Book Code'");
            }
            else
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");
                string sql = "select * from Book where bid ='" + textBox6.Text + "'";
                SqlCommand a = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = a.ExecuteReader();

                while (r.Read())
                {

                    textBox22.Text = r.GetValue(1) + "";
                    textBox7.Text = textBox22.Text;
                    textBox12.Text = r.GetValue(3) + "";
                    textBox8.Text = r.GetValue(5) + "";
                    comboBox1.SelectedIndex = Convert.ToInt32(r.GetValue(4)) - 1;
                    textBox11.Text = r.GetValue(6) + "";
                    textBox10.Text = r.GetValue(7) + "";
                    textBox17.Text = r.GetValue(8) + "";
                    pictureBox1.Image = Image.FromFile(r.GetValue(8) + "");

                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    comboBox1.Enabled = false;
                    textBox11.Enabled = false;
                    textBox10.Enabled = false;
                    textBox17.Enabled = false;
                    textBox12.Enabled = false;
                    button3.Enabled = false;


                }
                r.Close();
                if (textBox22.Text == "")
                {
                    MessageBox.Show("No Record Found...");

                    textBox7.Enabled = true;
                    textBox8.Enabled = true;
                    comboBox1.Enabled = true;
                    textBox11.Enabled = true;
                    textBox10.Enabled = true;
                    textBox17.Enabled = true;
                    textBox12.Enabled = true;
                    button3.Enabled = true;
                }
            }
        }
    }
}
