using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace firstApp
{
    partial class calanderDemo : Form
    {
        public static bool passport, idCard;
        public static string to,from,fName,lName,startTripDate,endTripDate,docNo,docIssuDate,docExpDate;
        public static decimal weight;
        public calanderDemo()
        {
            InitializeComponent();
            //this.Text = String.Format("About {0} {0}", AssemblyTitle);
            //this.labelProductName.Text = AssemblyProduct;
            //this.labelVersion.Text = String.Format("Version {0} {0}", AssemblyVersion);
            //this.labelCopyright.Text = AssemblyCopyright;
            //this.labelCompanyName.Text = AssemblyCompany;
            //this.textBoxDescription.Text = AssemblyDescription;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void calanderDemo_Load(object sender, EventArgs e)
        {
            mcal1.MaxSelectionCount = 50;
            mcal1.ShowToday = true;
        }

        private void rdbPassport_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPassport.Checked)
            {
                lblDocNo.Text = "Passport No:";
                passport = true;
            }
            
        }

        private void rdbId_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbId.Checked)
            {
                lblDocNo.Text = "Id Card No:";
                idCard = true;
            }  
        }

        private void dtpIssuDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dtpIssuDate.Value;
            dtpEndDate.MinDate = dt;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            to = txtTo.Text;
            from = txtFrom.Text;

            startTripDate = mcal1.SelectionStart.ToString("dd MMM yyyy");
            endTripDate = mcal1.SelectionEnd.ToString("dd MMM yyyy");

            fName = txtFName.Text;
            lName = txtLName.Text;

            docIssuDate = dtpIssuDate.Value.ToString("dd MMM yyyy");
            docExpDate= dtpEndDate.Value.ToString("dd MMM yyyy");

            docNo = txtDocNo.Text;
            weight = nudBaggage.Value;

            clearField();
        }

        private void clearField()
        {
            txtTo.Text = "";
            txtFrom.Text = "";
            mcal1.SelectionStart = DateTime.Today; // Set to today's date or any default value you prefer
            mcal1.SelectionEnd = DateTime.Today; // Set to today's date or any default value you prefer
            dtpIssuDate.Value = DateTime.Today; // Set to today's date or any default value you prefer
            dtpEndDate.Value = DateTime.Today; // Set to today's date or any default value you prefer
            txtDocNo.Text = "";
            nudBaggage.Value = 0;
            txtFName.Text = "";
            txtLName.Text = "";

        }


    }
}
