using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Data;

namespace firstApp
{
    partial class clinicDemo : Form
    {
        public clinicDemo()
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

        //Datatable for Detail
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();

        private void clinicDemo_Load(object sender, EventArgs e)
        {
            fillClinic();
            fillDrDetail();
            cbClinicName.DataSource = dt;
            cbClinicName.DisplayMember = "clinicName";
        }

        private void fillClinic() {
            dt.Columns.Add("clinicId", typeof(int));
            dt.Columns.Add("clinicName");
            dt.Columns.Add("cAddr");
            dt.Columns.Add("cRatting");

            dt.Rows.Add(1, "cli 1", "sidhpur", "9/10");
            dt.Rows.Add(1, "cli 2", "Kaknd", "5/10");
            dt.Rows.Add(1, "cli 3", "Palanpur", "8/10");
        }

        private void cbClinicName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblClinicName.Text = dt.Rows[cbClinicName.SelectedIndex]["clinicName"].ToString();

            dt3 = dt2.Select("clinicId =" + dt.Rows[cbClinicName.SelectedIndex]["clinicId"]).CopyToDataTable();
            cbDrName.DataSource = dt3;
            cbDrName.DisplayMember="dName";

            //fillDrDetail();
        }

        private void fillDrDetail()
        {
            dt2.Columns.Add("clinicId", typeof(int));
            dt2.Columns.Add("dName");
            dt2.Columns.Add("dAddr");

            dt2.Rows.Add(1, "dr 1", "sidhpur");
            dt2.Rows.Add(1, "dr 1", "sidhpur");
            dt2.Rows.Add(2, "dr 2", "Kaknd");
            dt2.Rows.Add(2, "dr 2", "Kaknd");
            dt2.Rows.Add(3, "dr 3", "Palanpur");
            dt2.Rows.Add(3, "dr 3", "Palanpur");
        }

        private void cbDrName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDrName.Text = dt3.Rows[cbDrName.SelectedIndex]["dName"].ToString();
        } 
    }
}
