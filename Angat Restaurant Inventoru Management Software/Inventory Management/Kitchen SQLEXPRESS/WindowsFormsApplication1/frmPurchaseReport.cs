using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace WindowsFormsApplication1
{
    public partial class frmPurchaseReport : WindowsFormsApplication1.CustomForm
    {
        public frmPurchaseReport()
        {
            InitializeComponent();
        }
        private void udfGenerateReport()
        {
            try
            {
                CRPurchase monthlyexp = new CRPurchase();
                TableLogOnInfo logOnInfo = new TableLogOnInfo();
                logOnInfo = monthlyexp.Database.Tables[0].LogOnInfo;

                ConnectionInfo connectionInfo = new ConnectionInfo();
                connectionInfo = logOnInfo.ConnectionInfo;
                ParameterFields param1Fields = new ParameterFields();

                ParameterField param1Field = new ParameterField();
                ParameterField param2Field = new ParameterField();

                ParameterDiscreteValue param1DiscreteValue = new ParameterDiscreteValue();
                ParameterDiscreteValue param2DiscreteValue = new ParameterDiscreteValue();

                param1Field.ParameterFieldName = "@StartDate";
                param1DiscreteValue.Value = "" + dtpStartDate.Value.Year + "/" + dtpStartDate.Value.Month + "/" + dtpStartDate.Value.Day + "";
                param1Field.CurrentValues.Add(param1DiscreteValue);

                param2Field.ParameterFieldName = "@EndDate";
                param2DiscreteValue.Value = "" + dtpEndDate.Value.Year + "/" + dtpEndDate.Value.Month + "/" + dtpEndDate.Value.Day + "";
                param2Field.CurrentValues.Add(param2DiscreteValue);

                param1Fields.Insert(0, param1Field);
                param1Fields.Insert(1, param2Field);

                crystalReportViewer1.ParameterFieldInfo = param1Fields;

                connectionInfo.ServerName = ".\\Sqlexpress";
                connectionInfo.DatabaseName = "insAHMS";
                connectionInfo.UserID = "sa";
                connectionInfo.Password = "inspire@2009";

                monthlyexp.Database.Tables[0].ApplyLogOnInfo(logOnInfo);
                crystalReportViewer1.ReportSource = monthlyexp;
                crystalReportViewer1.Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            dtpEndDate.Value = DateTime.Now.AddDays(1);
            dtpStartDate.Value = dtpStartDate.Value.Date.AddDays(-(dtpEndDate.Value.Day) + 1);
            udfGenerateReport();
        }

        private void frmExpences_Load(object sender, EventArgs e)
        {
            udfGenerateReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            udfGenerateReport();
        }

      
    }
}
