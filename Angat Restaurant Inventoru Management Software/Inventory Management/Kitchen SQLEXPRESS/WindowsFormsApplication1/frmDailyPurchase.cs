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
    public partial class frmDailyPurchase : CustomForm
    {
        public frmDailyPurchase()
        {
            InitializeComponent();
        }

        private void frmDailyPurchase_Load(object sender, EventArgs e)
        {
            udfGenerateReport();
        }
        private void udfGenerateReport()
        {
            try
            {
                CRDailyPurchase CRDailyPurchase = new CRDailyPurchase();
                TableLogOnInfo logOnInfo = new TableLogOnInfo();
                logOnInfo = CRDailyPurchase.Database.Tables[0].LogOnInfo;

                ConnectionInfo connectionInfo = new ConnectionInfo();
                connectionInfo = logOnInfo.ConnectionInfo;

                connectionInfo.ServerName = ".\\Sqlexpress";
                connectionInfo.DatabaseName = "insAHMS";
                connectionInfo.UserID = "sa";
                connectionInfo.Password = "inspire@2009";

                //ParameterFields param1Fields = new ParameterFields();
                //ParameterField f1 = new ParameterField();
                //ParameterDiscreteValue v1 = new ParameterDiscreteValue();

                //f1.ParameterFieldName = "@Date";
                //v1.Value = "" + dtpDate.Value.Year + "/" + dtpDate.Value.Month + "/" + dtpDate.Value.Day + "";
                //f1.CurrentValues.Add(v1);
                //param1Fields.Insert(0, f1);

              //  crystalReportViewer1.ParameterFieldInfo = param1Fields;

                CRDailyPurchase.Database.Tables[0].ApplyLogOnInfo(logOnInfo);
                crystalReportViewer1.ReportSource = CRDailyPurchase;
                crystalReportViewer1.Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDailyPurchase_Shown(object sender, EventArgs e)
        {
            udfGenerateReport();
        }
    }
}
