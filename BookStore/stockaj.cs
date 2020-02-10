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
    public partial class stockaj : Form
    {
        public stockaj()
        {
            InitializeComponent();
        }

        private void stockaj_FormClosing(object sender, FormClosingEventArgs e)
        {
            Visible = false;
            Stock sk = new Stock();
            sk.Show();
        }

        private void stockaj_Load(object sender, EventArgs e)
        {
            Stock sk = new Stock();
            textBox3.Text = Stock.sendtext;
            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");

                string sql = "SELECT * from Book where bid = '" + textBox3.Text.Trim() + "';";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    textBox4.Text = r.GetValue(0) + "";
                    textBox5.Text = r.GetValue(1) + "";
                    textBox6.Text = r.GetValue(2) + "";
                    string Price = r.GetValue(3) + "";
                    textBox2.Text = Price + "";
                    textBox10.Text = r.GetValue(4) + "";
                    textBox7.Text = r.GetValue(5) + "";
                    textBox8.Text = r.GetValue(6) + "";
                    textBox9.Text = r.GetValue(7) + "";
                    textBox11.Text = r.GetValue(8) + "";
                    pictureBox1.Image = Image.FromFile(textBox11.Text) ;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                r.Close();
                s.Dispose();

                string sql1 = "SELECT cname from Category where catid = '" + textBox10.Text.Trim() + "';";
                SqlCommand s1 = new SqlCommand(sql1, DataCon.DataConnection);
                SqlDataReader r1 = s1.ExecuteReader();
                while (r1.Read())
                {
                    comboBox1.Text = r1.GetValue(0) + "";
                }
                r1.Close();
                s1.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" )
            {
                if (textBox1.Text == "")
                {
                    textBox1.Focus();
                    MessageBox.Show("Please fill in 'New Price'");
                }
                if (textBox2.Text == "")
                {
                    textBox2.Focus();
                    MessageBox.Show("Please fill in 'Old Price'");
                }
                if (textBox4.Text == "")
                {
                    textBox4.Focus();
                    MessageBox.Show("Please fill in 'Book Code'");
                }
                if (textBox5.Text == "")
                {
                    textBox5.Focus();
                    MessageBox.Show("Please fill in 'Book Title'");
                }
                if (textBox6.Text == "")
                {
                    textBox6.Focus();
                    MessageBox.Show("Please fill in 'Stock'");
                }
                if (textBox7.Text == "")
                {
                    textBox7.Focus();
                    MessageBox.Show("Please fill in 'Author'");
                }
                if (textBox8.Text == "")
                {
                    textBox8.Focus();
                    MessageBox.Show("Please fill in 'Year of Publish'");
                }
                if (textBox9.Text == "")
                {
                    textBox9.Focus();
                    MessageBox.Show("Please fill in 'Location'");
                }
                if (comboBox1.Text == "")
                {
                    textBox9.Focus();
                    MessageBox.Show("Please Choose 1 'Genre'");
                }
            }
            else
            {
                try
                {
                    float Price =Convert.ToSingle(textBox1.Text.Trim());

                    string sql1 = "SELECT catid from Category where cname = '" + comboBox1.Text.Trim() + "';";
                    SqlCommand s1 = new SqlCommand(sql1, DataCon.DataConnection);
                    SqlDataReader r1 = s1.ExecuteReader();
                    while (r1.Read())
                    {
                        comboBox1.Text = r1.GetValue(0) + "";
                    }
                    r1.Close();
                    s1.Dispose();

                    string catid = comboBox1.Text+"";
                    string sql = "update Book set bprice ='" + Price+ "',bname = '"+textBox5.Text+ "',bqty = '" +Convert.ToInt16(textBox6.Text) + "',catid = '" + catid + "',author = '" + textBox7.Text + "',Year = '" + textBox8.Text + "',location = '" + textBox9.Text + "',Attachment = '" + textBox11.Text + "' where bid = '" + textBox3.Text + "';";
                    SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                    s.ExecuteNonQuery();
                    s.Dispose();

                    Stock sk = new Stock();
                    sk.Show();
                    this.Dispose();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string filename = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                textBox11.Text = filename + "";
                pictureBox1.Image = Image.FromFile(textBox11.Text);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
