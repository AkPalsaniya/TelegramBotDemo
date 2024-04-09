using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class frmCustomerWiseItemSales : Form
    {
        DataSet dsSales;
        string str;

        public frmCustomerWiseItemSales()
        {
            InitializeComponent();
            str = ConfigurationManager.ConnectionStrings["salogin"].ToString();
        }

        private void frmCustomerWiseItemSales_Load(object sender, EventArgs e)
        {
            dsSales = new DataSet();
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "dd-MM-yyyy";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = "dd-MM-yyyy";
            udfCustomerMaster();

            udfGenerateReport();
        }

        private void udfCustomerMaster()
        {
            try
            {
                if (dsSales.Tables.Contains("CustomerMaster") == true)
                { dsSales.Tables.Remove("CustomerMaster"); }
                dsSales.Tables.Add("CustomerMaster");

                CrudeNavigationClass.FillTable(str, "Select CustomerCode 'CustomerNo', CustomerName from CustomerMaster", dsSales.Tables["CustomerMaster"]);
                //DataRow dr = dsSales.Tables["CustomerMaster"].NewRow();
                //dr["CustomerNo"] = 1;
                //dr["CustomerName"] = "NIL";
                //dsSales.Tables["CustomerMaster"].Rows.Add(dr);
                //dsSales.Tables["CustomerMaster"].AcceptChanges();

                cbCustomerName.DisplayMember = "CustomerName";
                cbCustomerName.ValueMember = "CustomerNo";
                cbCustomerName.DataSource = dsSales.Tables["CustomerMaster"];
                cbCustomerName.DropDownStyle = ComboBoxStyle.DropDown;
                cbCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbCustomerName.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

      
        private void udfGenerateReport()
        {
            crCustomerWiseItemSales crCustomerWiseItemSales = new crCustomerWiseItemSales();
            crCustomerWiseItemSales.SetDatabaseLogon("sa", "inspire@2009", ".\\SQLEXPRESS", "insAHMS");
            crCustomerWiseItemSales.SetParameterValue("@CustomerCode", cbCustomerName.SelectedValue);
            crCustomerWiseItemSales.SetParameterValue("@FromDate", dtpStartDate.Value.ToString("yyyy-MM-dd"));
            crCustomerWiseItemSales.SetParameterValue("@Todate", dtpEndDate.Value.ToString("yyyy-MM-dd"));
            customerWiseItemSales.ReportSource = crCustomerWiseItemSales;

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            udfGenerateReport();

        }
    }
}
