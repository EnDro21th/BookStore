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
    public partial class SSupplier : Form
    {
        public SSupplier()
        {
            InitializeComponent();
        }

        private void bntback1_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void SSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");
                
                string sql = "select * from Supplier";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string id = r.GetValue(0) + "";
                    string name = r.GetValue(1) + "";
                    string address = r.GetValue(2) + "";
                    string contact = r.GetValue(3) + "";
                    dataGridView1.Rows.Add(id, name, address, contact);
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
            dataGridView1.Rows.Clear();
            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");

                string sql = "select* from Supplier where supname like '%"+textBox2.Text+"%' ; ";
                SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                SqlDataReader r = s.ExecuteReader();
                while (r.Read())
                {
                    string id = r.GetValue(0) + "";
                    string name = r.GetValue(1) + "";
                    string address = r.GetValue(2) + "";
                    string contact = r.GetValue(3) + "";
                    dataGridView1.Rows.Add(id, name, address, contact);
                }
                r.Close();
                s.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SSupplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            this.Visible = false;
        }
    }
}
