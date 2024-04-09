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
    partial class listDemo : Form
    {
        public listDemo()
        {
            InitializeComponent();
            
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

        private DataTable dtCource = new DataTable();
        private DataTable dtSelectCource = new DataTable();
        
        private void listDemo_Load(object sender, EventArgs e)
        {
            fillCource();
            selectedCource();

            lb1.DataSource = dtCource;
            lb1.DisplayMember = "courceName";

            lb2.DataSource = dtSelectCource;
            lb2.DisplayMember = "courceName";
        }

        private void fillCource()
        {
            dtCource.Columns.Add("courceId", typeof(int));
            dtCource.Columns.Add("courceName");
            dtCource.Columns.Add("courceDuration");

            dtCource.Rows.Add(1, "c", "4 month");
            dtCource.Rows.Add(2, "c#", "12 Month");
            dtCource.Rows.Add(3, "Java", "10 Month");
            dtCource.Rows.Add(4, "Python", "6 Month");
            
        }

        private void selectedCource()
        {
            dtSelectCource.Columns.Add("courceId", typeof(int));
            dtSelectCource.Columns.Add("courceName");
            dtSelectCource.Columns.Add("courceDuration");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lb1.Items.Count > 0)
            {
                dtSelectCource.ImportRow(dtCource.Rows[lb1.SelectedIndex]);
                dtCource.Rows[lb1.SelectedIndex].Delete();

                lb2.DataSource = dtSelectCource;
                lb2.DisplayMember = "courceName";
            }
            else {
                MessageBox.Show("No Value Selected from Listbox 1");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lb2.Items.Count > 0)
            {
                dtCource.ImportRow(dtSelectCource.Rows[lb2.SelectedIndex]);
                dtSelectCource.Rows[lb2.SelectedIndex].Delete();

                lb1.DataSource = dtCource;
                lb1.DisplayMember = "courceName";
            }
            else
            {
                MessageBox.Show("No Value Selected from Listbox 2");
            }
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            if (lb1.Items.Count > 0)
            {
                int count = dtCource.Rows.Count;
                for (int i = count - 1; i >= 0; i--)
                {
                    dtSelectCource.ImportRow(dtCource.Rows[lb1.SelectedIndex]);
                    dtCource.Rows[lb1.SelectedIndex].Delete();

                    lb2.DataSource = dtSelectCource;
                    lb2.DisplayMember = "courceName";
                }
            }
            else
            {
                MessageBox.Show("No Value Selected from Listbox 1");
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (lb2.Items.Count > 0)
            {
                int count = dtSelectCource.Rows.Count;
                for (int i = count - 1; i >= 0; i--)
                {
                    dtCource.ImportRow(dtSelectCource.Rows[lb2.SelectedIndex]);
                    dtSelectCource.Rows[lb2.SelectedIndex].Delete();

                    lb1.DataSource = dtCource;
                    lb1.DisplayMember = "courceName";
                }
            }
            else
            {
                MessageBox.Show("No Value Selected from Listbox 2");
            }
        }

        private void btnFinal_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do You want to final", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                gvDetail.DataSource = dtSelectCource;
                gvDetail.Enabled = false; 
            }
            else {
                MessageBox.Show("ok..?", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
