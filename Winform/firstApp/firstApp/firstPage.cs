using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace firstApp
{
    public partial class firstPage : Form
    {
        public static string name;
        public static string pass;
        public static bool isName;
        public static bool isPass;

        //public static string strCon = @"Data Source=D:\Inspire Software Training\Winform\firstApp\firstApp\myDb.sdf";
        public static string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=ECommerce;Integrated Security=True";
        public firstPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //log();
            
            //using (SqlConnection con = new SqlConnection(strCon))
            //{
            //    try
            //    {
            //        con.Open();
            //        string query = "SELECT * FROM user_master WHERE Name = @Name AND Password = @Pass";
            //        using (SqlCommand cmd = new SqlCommand(query, con))
            //        {
            //            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            //            cmd.Parameters.AddWithValue("@Pass", txtPass.Text);

            //            using (SqlDataReader reader = cmd.ExecuteReader())
            //            {
            //                if (reader.HasRows)
            //                {
            //                    MessageBox.Show("Success");
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Error: Invalid credentials");
            //                }
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error: " + ex.Message);
            //    }
            //}
            DataTable dtLogin = new DataTable();
            String query = "SELECT * FROM user_master WHERE Name = @Name AND Password = @Pass";
            SqlCommand cmdLodin = login(query, dtLogin);
            cmdLodin.Parameters.AddWithValue("@Name", txtName.Text);
            cmdLodin.Parameters.AddWithValue("@Pass", txtPass.Text);
            
            SqlDataReader sdrlogin = cmdLodin.ExecuteReader();
            if(sdrlogin.HasRows)
            {
                MessageBox.Show("Success");
            }
            else{
            MessageBox.Show("Error");}

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblName.Text = "";
            lblPass.Text = "";
        }

        //private void log(){
        //    if (txtName.Text == "123" && txtPass.Text == "123")
        //    {
        //        name = txtName.Text;
        //        pass = txtPass.Text;
        //        home h1 = new home();
        //        h1.Show();
        //        this.Hide();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Incorrect Id Password");
        //    }
        //}

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //log();
            }
        }

        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkName.Checked)
            {
                lblNameShow.Text = txtName.Text;
                isName = true;
            }
            else
            {
                lblNameShow.Text = "Not Selected";
                isName = false;
            }
        }

        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPass.Checked)
            {
                lblPassShow.Text = txtPass.Text;
                isPass = true;
            }
            else
            {
                lblPassShow.Text = "Not Selected";
                isPass = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Reason\n 1.Meri Marji...\n 2.Reson Nh Milega", "Reason", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                lblMsg.Text = "Meri Marji";
            }
            if (dr == DialogResult.No)
            {
                lblMsg.Text = "Nh batana";
            }
        }

        private void btnCalDemo_Click(object sender, EventArgs e)
        {
            calanderDemo cal = new calanderDemo();
            cal.Show();
            this.Hide();
        }

        private void btnClinic_Click(object sender, EventArgs e)
        {
            clinicDemo clinic = new clinicDemo();
            clinic.Show();
            this.Hide();
        }

        private void btnListDemo_Click(object sender, EventArgs e)
        {
            listDemo ls = new listDemo();
            ls.Show();
            this.Hide();
        }


        public SqlCommand login(string query, DataTable dtLogin)
        {
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand(query, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return cmd;
        }
    }
}
