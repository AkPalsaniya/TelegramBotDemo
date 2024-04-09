using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmUserRights : CustomForm
    {
        string str;
        DataSet ds;

        public frmUserRights()
        {
            InitializeComponent();
            str = ConfigurationManager.ConnectionStrings["salogin"].ToString();
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmUserRights_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            udfUserRights();
            udfgvUserRights();
        }

        private void udfgvUserRights()
        {
            try
            {
                string[,] Name = new string[18, 2] { { "UserNo", "No" }, { "FirstName", "Name" }, { "BillBook", "Bill Book" }, { "KOTBook", "KOT Book" }, { "BillHandle", "Bill Handle" }, { "SetBills", "Set Bills" }, { "Payroll", "Payroll" }, { "Expenditure", "Expenditure" }, { "ItemwiseReport", "Itemwise Report" }, { "Paymentwise", "Payment wise" }, { "LocationwiseMonthly", "Locationwise Monthly" }, { "DailySales", "Daily Sales" }, { "MonthlySales", "Monthly Sales" }, { "Stock", "Stock" }, { "TransferedDetails", "Transfered Details" }, { "UnpaidBills", "Unpaid Bills" }, { "VendorPurchase", "Vendor Purchase" }, { "StockManagement", "Stock Management" } };
                bool[] Readonly = new bool[18] { true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
                int[] fillweight = new int[18] { 5, 15, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

                CrudeNavigationClass.DGVTextBoxColumn(Name, fillweight, Name, Readonly, gvUserRights, 0, 1);
                CrudeNavigationClass.DGVCheckBoxColumn(Name, fillweight, Name, gvUserRights, 2, 5);
                CrudeNavigationClass.DGVCheckBoxColumn(Name, fillweight, Name, gvUserRights, 7, 12);
                CrudeNavigationClass.DGVCheckBoxColumn(Name, fillweight, Name, gvUserRights, 14, 16);

                CrudeNavigationClass.DGVValidation(gvUserRights);
                gvUserRights.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                gvUserRights.AllowUserToResizeColumns = true;
                foreach (DataGridViewColumn c in gvUserRights.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Cambria", 15F, GraphicsUnit.World);
                }
                gvUserRights.DataSource = ds.Tables["UserRights"];
                gvUserRights.AutoResizeColumnHeadersHeight();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void udfUserRights()
        {
            ds.Tables.Add("UserRights");
            CrudeNavigationClass.FillTable(str, "Select * from UserRights", ds.Tables["UserRights"]);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(DataRow dr in ds.Tables["UserRights"].Rows)
                {
                    CrudeNavigationClass.CrudeInsert(str, "Update UserRights set BillBook = '" + dr["BillBook"] + "', KOTBook = '" + dr["KOTBook"] + "' , BillHandle = '" + dr["BillHandle"] + "', SetBills = '" + dr["SetBills"] + "',Payroll = '" + dr["Payroll"] + "', Expenditure = '" + dr["Expenditure"] + "',  ItemwiseReport = '" + dr["ItemwiseReport"] + "', Paymentwise = '" + dr["Paymentwise"] + "', LocationwiseMonthly = '" + dr["LocationwiseMonthly"] + "', DailySales = '" + dr["DailySales"] + "', MonthlySales = '" + dr["MonthlySales"] + "', Stock='" + dr["Stock"] + "', TransferedDetails = '" + dr["TransferedDetails"] + "', UnpaidBills = '" + dr["UnpaidBills"] + "', VendorPurchase = '" + dr["VendorPurchase"] + "', StockManagement = '" + dr["StockManagement"] + "'  where UserNo= " + dr["UserNo"] + "");
                    ds.Tables["UserRights"].AcceptChanges();   
                }
                MessageBox.Show("Item(s) Saved", "Saved......", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvUserRights.Rows.Count > 0)
                {
                    gvUserRights.CurrentCell = gvUserRights.Rows[0].Cells["UserNo"];
                }
            }
            catch (Exception)
            { }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvUserRights.Rows.Count > 0 && gvUserRights.CurrentRow.Index != 0)
                {
                    gvUserRights.CurrentCell = gvUserRights.Rows[gvUserRights.CurrentRow.Index - 1].Cells["UserNo"];
                }
            }
            catch (Exception)
            { }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvUserRights.Rows.Count > 0 && gvUserRights.CurrentRow.Index != gvUserRights.Rows.Count - 1)
                {
                    gvUserRights.CurrentCell = gvUserRights.Rows[gvUserRights.CurrentRow.Index + 1].Cells["UserNo"];
                }
            }
            catch (Exception)
            { }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvUserRights.Rows.Count > 0)
                {
                    gvUserRights.CurrentCell = gvUserRights.Rows[gvUserRights.Rows.Count - 1].Cells["UserNo"];
                }
            }
            catch (Exception)
            { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        
        
    }
}
