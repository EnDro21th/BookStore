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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            
        }
        public static string acoount = "";

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bntlogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataCon.ConnectionDB("ENDROX", "BookStore");
                
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Username WHERE username='" + txtuser.Text + "' AND password='" + txtpass.Text + "'", DataCon.DataConnection);
                    
                DataTable dt = new DataTable();  
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    string message = "Successfully login";
                    string title = " Message ";
                    MessageBox.Show(message, title);

                    acoount = txtuser.Text.ToString();

                    MainForm mf = new MainForm();
                    mf.Show();
                    this.Visible = false;
                }
                else
                {
                    string message = "Incorrect Username or Password";
                    string title = " Message ";
                    MessageBox.Show(message, title);

                    txtuser.Text = "";
                    txtpass.Text = "";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
















        }

        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bntlogin.PerformClick();
            }
        }
    }
}
