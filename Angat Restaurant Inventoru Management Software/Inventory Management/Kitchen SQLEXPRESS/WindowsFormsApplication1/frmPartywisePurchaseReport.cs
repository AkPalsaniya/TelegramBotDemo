using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class frmPartywisePurchaseReport : CustomForm
    {
        public frmPartywisePurchaseReport()
        {
            InitializeComponent();
        }

        private void frmPartywisePurchaseReport_Load(object sender, EventArgs e)
        {
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = dtpStartDate.Value.Date.AddDays(-(dtpEndDate.Value.Day) + 1);

            SqlDataAdapter sda = new SqlDataAdapter("Select SupplierNo, SupplierName from VendorMaster order by SupplierNo", System.Configuration.ConfigurationManager.ConnectionStrings["salogin"].ToString());
            DataSet ds = new DataSet();
            sda.Fill(ds);

            cbSupName.DataSource = ds.Tables[0];
            cbSupNo.DataSource = ds.Tables[0];
            cbSupName.DisplayMember = "SupplierName";
            cbSupNo.DisplayMember = "SupplierNo";
            udfGenerateReport();
            this.CenterToParent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            udfGenerateReport();
        }
        private void udfGenerateReport()
        {
            try
            {
                CrPartywisePurchase CRItemwise = new CrPartywisePurchase();
                ConnectionInfo connectionInfo = new ConnectionInfo();
                TableLogOnInfo logOnInfo = new TableLogOnInfo();

                logOnInfo = CRItemwise.Database.Tables[0].LogOnInfo;

                CrudeNavigationClass.ConnectionInfo(".\\Sqlexpress", "insAHMS", "sa", "inspire@2009", connectionInfo, logOnInfo);
                
                CRItemwise.SetParameterValue("@SupplierNo", cbSupNo.Text);
                CRItemwise.SetParameterValue("@StartDate", "" + dtpStartDate.Value.Year + " / " + dtpStartDate.Value.Month + " / " + dtpStartDate.Value.Day + " 00:00:00");
                CRItemwise.SetParameterValue("@EndDate", "" + dtpEndDate.Value.Year + "/" + dtpEndDate.Value.Month + "/" + dtpEndDate.Value.Day + " 23:59:59");

              
                CRItemwise.Database.Tables[0].ApplyLogOnInfo(logOnInfo);
                crystalReportViewer1.ReportSource = CRItemwise;
                crystalReportViewer1.Visible = true;
               
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Problem displaying locationwise monthly report", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
