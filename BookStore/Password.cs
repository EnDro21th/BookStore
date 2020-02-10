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
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }

        private void bntreset_Click(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            string acc = LogIn.acoount;

            if (txtpass.Text == txtpass2.Text)
            {
                try
                {
                    DataCon.ConnectionDB("ENDROX", "BookStore");

                    string pass = txtpass.Text.Trim();
                    string pass2 = txtpass2.Text.Trim();
                    string sql = "update Username SET password=N'" + pass + "'Where username=N'" + acc + "' ;";
                    SqlCommand s = new SqlCommand(sql, DataCon.DataConnection);
                    s.ExecuteNonQuery();
                    s.Dispose();

                    string message = "Successfully Updated";
                    string title = " Message ";
                    MessageBox.Show(message, title);
                    MainForm mf = new MainForm();
                    mf.Show();
                    this.Visible = false;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Incorrect Confirm Password...");
            }
            






            
        }

        private void Password_Load(object sender, EventArgs e)
        {
            

        }

        private void Password_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            Visible = false;
        }
    }
}
