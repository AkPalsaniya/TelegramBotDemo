using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class frmLogin : CustomForm
    {
        string str;
        CrudeNavigationClass cnc;
        public frmLogin()
        {
            InitializeComponent();
            str = System.Configuration.ConfigurationManager.ConnectionStrings["salogin"].ToString();
            CustomUI.customiseMenuForm(this);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                string[] Logininfo = new string[3];

                CrudeNavigationClass.FillNArray(str, "Select Password, UserNo, UserRoleNo from UserMaster where UserId='" + txtuname.Text + "' and Status='false'", Logininfo, 3);

                if (txtpass.Text == Logininfo[0])
                {
                    frmMain rbs = new frmMain();
                    frmMain.varLoggedUserNo = Convert.ToInt32(Logininfo[1]);
                    frmMain.varLoggedUserRoleNo = Convert.ToInt32(Logininfo[2]);
                    rbs.Show();
                    
                    string i = cnc.Returnsting(str, "Select CustomerName from CustomerMaster where CustomerCode = 0");
                    if (i == null)
                    {
                        CrudeNavigationClass.CrudeInsert(str, "Insert into CustomerMaster (CustomerCode, CustomerName,DateofBirth ) values(0, 'Welcome', '1-1-2010')");
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed");
                    txtpass.SelectAll();
                }
            }
            catch (Exception)
            { }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                Application.Exit();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            cnc = new CrudeNavigationClass();
            try
            {
                File.Copy("C:\\Program Files\\Microsoft SQL Server\\MSSQL.1\\MSSQL\\Data\\insAHMS.mdf","E:\\INSPIRE SOFTWARE CO\\Auto Backup\\insAHMS.mdf",true);
                File.Copy("C:\\Program Files\\Microsoft SQL Server\\MSSQL.1\\MSSQL\\Data\\insAHMS_Log.ldf","E:\\INSPIRE SOFTWARE CO\\Auto Backup\\insAHMS_Log.ldf",true);
            }
            catch { }
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            //if (txtpass.Text == "w" && txtuname.Text == "w" && e.KeyCode == Keys.F12)
            //{
            //    frmTxBill tb = new frmTxBill();
            //    tb.BillBook = cnc.Returnsting(str, "Select BillBook from BillBookMaster where Active = 1");
            //    if (tb.BillBook == "")
            //    {
            //        CrudeNavigationClass.CrudeInsert(str, "Insert into BillBookMaster (BillBook, Active) Values(1, 1) ");
            //        tb.BillBook = "1";
            //    }

            //    //// KOTBook
            //    tb.KOTBook = cnc.Returnsting(str, "Select KOTBook from KOTBookMaster where Active = 1");
            //    if (tb.KOTBook == "")
            //    {
            //        CrudeNavigationClass.CrudeInsert(str, "Insert into KOTBookMaster (KOTBook, Active) Values(1, 1) ");
            //        tb.KOTBook = "1";
            //    }

            //    txtuname.Text = "";
            //    txtpass.Text = "";
            //    this.Hide();
            //    tb.ShowDialog();
            //    this.Show();
            //    txtuname.Focus();
            //}
        }
    }

}