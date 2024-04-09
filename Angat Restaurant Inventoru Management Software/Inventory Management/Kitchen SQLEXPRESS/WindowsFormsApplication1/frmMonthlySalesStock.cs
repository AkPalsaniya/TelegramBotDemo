using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace WindowsFormsApplication1
{
    public partial class frmMonthlySalesStock : CustomForm
    {
        public frmMonthlySalesStock()
        {
            InitializeComponent();
        }

        private void frmMonthlySalesStock_Load(object sender, EventArgs e)
        {
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = dtpStartDate.Value.Date.AddDays(-(dtpEndDate.Value.Day) + 1);
            udfGenerateReport();
            this.CenterToParent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            udfGenerateReport();
        }
        private void udfGenerateReport()
        {
            CRMonthlySalesStock  monthlysales = new CRMonthlySalesStock();
            ConnectionInfo connectionInfo = new ConnectionInfo();
            TableLogOnInfo logonInfo = new TableLogOnInfo();
            logonInfo = monthlysales.Database.Tables[0].LogOnInfo;
            connectionInfo = logonInfo.ConnectionInfo;

            connectionInfo.ServerName = ".\\Sqlexpress";
            connectionInfo.DatabaseName = "insAHMS";
            //connectionInfo.IntegratedSecurity=true;
            connectionInfo.UserID = "sa";
            connectionInfo.Password = "inspire@2009";

            ParameterFields param1Fields = new ParameterFields();
            ParameterField f1 = new ParameterField();
            ParameterField f2 = new ParameterField();
            ParameterDiscreteValue v1 = new ParameterDiscreteValue();
            ParameterDiscreteValue v2 = new ParameterDiscreteValue();

            f1.Name = "@StartDate";
            v1.Value = "" + dtpStartDate.Value.Year + "/" + dtpStartDate.Value.Month + "/" + dtpStartDate.Value.Day + " 00:00:00 ";
            f1.CurrentValues.Add(v1);

            f2.Name = "@EndDate";
            v2.Value = "" + dtpEndDate.Value.Year + "/" + dtpEndDate.Value.Month + "/" + dtpEndDate.Value.Day + " 23:59:59 ";
            f2.CurrentValues.Add(v2);

            param1Fields.Insert(0, f1);
            param1Fields.Insert(1, f2);

            crystalReportViewer1.ParameterFieldInfo = param1Fields; //to pass parameter inf.to CRV
            monthlysales.Database.Tables[0].ApplyLogOnInfo(logonInfo);
            crystalReportViewer1.ReportSource = monthlysales;
            crystalReportViewer1.Visible = true;
            //crystalReportViewer1.PrintReport();
        }

    }
}
