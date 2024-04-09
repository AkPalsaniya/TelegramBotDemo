using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class RptCategorywiseStock : CustomForm
    {
        CRCategorywiseStock crcs;
        public static string str;
        public RptCategorywiseStock()
        {
            InitializeComponent();
            str = System.Configuration.ConfigurationManager.ConnectionStrings["salogin"].ToString();
        }

        private void RptCategorywiseStock_Load(object sender, EventArgs e)
        {
            crcs = new CRCategorywiseStock();
            CrudeNavigationClass.fillCombobox(str, "select CategoryNo from CategoryMaster", cbCategoryNo);
            CrudeNavigationClass.fillCombobox(str, "select CategoryName from CategoryMaster", cbCategoryName);
            this.CenterToScreen();
        }

        private void udfGenerateReport()
        {
            try
            {
                crcs.SetDatabaseLogon("sa", "inspire@2009", ".\\Sqlexpress", "insAHMS");
                crcs.SetParameterValue("@CategoryNo", cbCategoryNo.Text);
                crystalReportViewer1.ReportSource = crcs;
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            udfGenerateReport();
        }

        private void cbCategoryNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCategoryName.SelectedIndex = cbCategoryNo.SelectedIndex;
        }

        private void cbCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCategoryNo.SelectedIndex = cbCategoryName.SelectedIndex;
        }
    }
}
