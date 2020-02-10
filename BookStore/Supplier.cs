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
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                if (textBox1.Text == "")
                {
                    textBox1.Focus();
                    MessageBox.Show("Please fill in 'Supplier No.'");
                }
                if (textBox2.Text == "")
                {
                    textBox2.Focus();
                    MessageBox.Show("Please fill in 'Name'");
                }
                if (textBox3.Text == "")
                {
                    textBox3.Focus();
                    MessageBox.Show("Please fill in 'Address'");
                }
                if (textBox4.Text == "")
                {
                    textBox4.Focus();
                    MessageBox.Show("Please fill in 'Contact'");
                }
            }
            else
            {
                try
                {
                    DataCon.ConnectionDB("ENDROX", "BookStore");
                    string id = textBox1.Text.Trim();
                    string name = textBox2.Text.Trim();
                    string contact = textBox3.Text.Trim();
                    string address = textBox4.Text.Trim();
                    string sql = "insert into Supplier(supid,supname, supaddress, supcontact) values ('" + id + "',N'" + name + "',N'" + contact + "',N'" + address + "')";
                    SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                    s.ExecuteNonQuery();
                    s.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Visible = false;
            }
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");
                int index;
                string sql = "select MAX(supid) from Supplier";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string id = r.GetValue(0)+"";
                    index = Convert.ToInt16(id) + 1;
                    textBox1.Text = index.ToString();
                }
                r.Close();
                s.Dispose();

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Supplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Visible = false;
        }
    }
}
