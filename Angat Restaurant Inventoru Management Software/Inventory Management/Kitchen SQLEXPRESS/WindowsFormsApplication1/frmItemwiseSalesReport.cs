using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

namespace WindowsFormsApplication1
{
    public partial class frmItemwiseSalesReport : CustomForm
    {
        public frmItemwiseSalesReport()
        {
            InitializeComponent();
        }

        private void frmItemwiseSalesReport_Load(object sender, EventArgs e)
        {
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = dtpStartDate.Value.Date.AddDays(-(dtpEndDate.Value.Day) + 1);

            SqlDataAdapter sda = new SqlDataAdapter("Select ItemNo, ItemName from StockMaster order by ItemNo", System.Configuration.ConfigurationManager.ConnectionStrings["salogin"].ToString());
            DataSet ds = new DataSet();
            sda.Fill(ds);

            cbItemName.DataSource = ds.Tables[0];
            cbItemNo.DataSource = ds.Tables[0];
            cbItemName.DisplayMember = "ItemName";
            cbItemNo.DisplayMember = "ItemNo";
            udfGenerateReport();
            this.CenterToParent();
        }
        private void udfGenerateReport()
        {
            try
            {
                CrItemwiseSales CRItemwise = new CrItemwiseSales();
                ConnectionInfo connectionInfo = new ConnectionInfo();
                TableLogOnInfo logOnInfo = new TableLogOnInfo();

                logOnInfo = CRItemwise.Database.Tables[0].LogOnInfo;
                
                CrudeNavigationClass.ConnectionInfo(".\\Sqlexpress", "insAHMS", "sa", "inspire@2009", connectionInfo, logOnInfo);
                CRItemwise.SetParameterValue("@ItemNo", cbItemNo.Text);
                CRItemwise.SetParameterValue("@StartDate", "" + dtpStartDate.Value.Year + "/" + dtpStartDate.Value.Month + "/" + dtpStartDate.Value.Day + "");
                CRItemwise.SetParameterValue("@EndDate", "" + dtpEndDate.Value.Year + "/" + dtpEndDate.Value.Month + "/" + dtpEndDate.Value.Day + "");
                CRItemwise.Database.Tables[0].ApplyLogOnInfo(logOnInfo);
                crystalReportViewer1.ReportSource = CRItemwise;
                crystalReportViewer1.Visible = true;
                //crystalReportViewer1.PrintReport();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Problem displaying locationwise monthly report", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            udfGenerateReport();
        }

    }
}
