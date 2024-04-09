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
    public partial class frmMonthlySales : CustomForm
    {
        public frmMonthlySales()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            udfGenerateReport();
        }
        private void udfGenerateReport()
        {
            //conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["salogin"].ToString();
            CRMonthlySales CRMonthlySales1 = new CRMonthlySales();
            ConnectionInfo connectionInfo = new ConnectionInfo();
            TableLogOnInfo logOnInfo = new TableLogOnInfo();
            logOnInfo = CRMonthlySales1.Database.Tables[0].LogOnInfo;
            connectionInfo = logOnInfo.ConnectionInfo;
        
            connectionInfo.ServerName = ".\\Sqlexpress";
            connectionInfo.DatabaseName = "insAHMS";
            //connectionInfo.IntegratedSecurity = true;
            connectionInfo.UserID = "sa";
            connectionInfo.Password = "inspire@2009";
    
            ParameterFields param1Fields = new ParameterFields();

            ParameterField param1Field = new ParameterField();
            ParameterField param2Field = new ParameterField();
            
            ParameterDiscreteValue param1Range = new ParameterDiscreteValue();
            ParameterDiscreteValue param2Range = new ParameterDiscreteValue();
            
            param1Field.ParameterFieldName = "@StartDate"; 
            param1Range.Value = "" + dtpStartDate.Value.Year + "/" + dtpStartDate.Value.Month + "/" + dtpStartDate.Value.Day + " 00:00:00";
            param1Field.CurrentValues.Add(param1Range);
         
            param2Field.ParameterFieldName = "@EndDate";
            param2Range.Value = "" + dtpEndDate.Value.Year + "/" + dtpEndDate.Value.Month + "/" + dtpEndDate.Value.Day + " 23:59:59 ";
            param2Field.CurrentValues.Add(param2Range);

            param1Fields.Insert(0, param1Field);
            param1Fields.Insert(1, param2Field);
           
            CRMonthlySales.ParameterFieldInfo = param1Fields; //to pass parameter inf.to CRV
            CRMonthlySales1.Database.Tables[0].ApplyLogOnInfo(logOnInfo);
            CRMonthlySales.ReportSource = CRMonthlySales1;
            CRMonthlySales.Visible = true;
            //crystalReportViewer1.PrintReport();
        }

        private void frmMonthlySales_Load(object sender, EventArgs e)
        {
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = dtpStartDate.Value.Date.AddDays(-(dtpEndDate.Value.Day) + 1);
        }

        private void frmMonthlySales_Shown(object sender, EventArgs e)
        {
            udfGenerateReport();
        }		
    }
}
