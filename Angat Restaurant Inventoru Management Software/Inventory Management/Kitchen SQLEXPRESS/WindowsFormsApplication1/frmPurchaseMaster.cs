using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class frmPurchaseMaster : CustomForm
    {
        string str;
        DataSet ds;
        DataGridViewTextBoxEditingControl textcontrol;

        public frmPurchaseMaster()
        {
            InitializeComponent();
            str = ConfigurationManager.ConnectionStrings["salogin"].ToString();
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void udfPurchase()
        {
            try
            {
                if (ds.Tables.Contains("Purchase"))
                { ds.Tables.Remove("Purchase"); }
                ds.Tables.Add("Purchase");
                CrudeNavigationClass.FillTable(str, "Select * from Purchase where Date between '" + dtpPurchase.Value.Year + "-" + dtpPurchase.Value.Month + "-" + dtpPurchase.Value.Day + " 00:00:00' and '" + dtpPurchase.Value.Year + "-" + dtpPurchase.Value.Month + "-" + dtpPurchase.Value.Day + " 23:59:59'", ds.Tables["Purchase"]);
                gvPurchase.DataSource = ds.Tables["Purchase"];
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void udfRowFilter()
        {
            //ds.Tables["Purchase"].DefaultView.RowFilter = "Date ='" & dtpPurchase.Value & "'";
            //ds.Tables["Purchase"].DefaultView.RowFilter =  = "Date = #" + dtpPurchase.ToString("u") +
            //ds.Tables["Purchase"].DefaultView.RowFilter = "Date >= " + dtpPurchase.Value.ToString("dd/MM/yyyy") + " AND Date <= " + dtpPurchase.Value.ToString("dd/MM/yyyy") + " ";
            //ds.Tables["Purchase"].DefaultView.RowFilter = CONVERT(" & dtmDateVar & " ,'System.DateTime')"
            //ds.Tables["Purchase"].DefaultView.RowFilter = "FORMAT(Date,'dd') = '" + dtpPurchase.Value.Day + "' and FORMAT(Date,'MM') = '" + dtpPurchase.Value.Day + "' and FORMAT(Date,'yyyy') = '" + dtpPurchase.Value.Year + "'";
            //ds.Tables["Purchase"].DefaultView.RowFilter = "Date in('" + dtpPurchase.Value.Year + "-" + dtpPurchase.Value.Month + "-" + dtpPurchase.Value.Day + " 00:00:00' , '" + dtpPurchase.Value.Year + "-" + dtpPurchase.Value.Month + "-" + dtpPurchase.Value.Day + " 23:59:59' )";
            //ds.Tables["Purchase"].DefaultView.RowFilter = "Date in('" + dtpPurchase.Value.Year + "-" + dtpPurchase.Value.Month + "-" + dtpPurchase.Value.Day + "' , '" + dtpPurchase.Value.Year + "-" + dtpPurchase.Value.Month + "-" + dtpPurchase.Value.Day + " ' )";
            //ds.Tables["Purchase"].DefaultView.RowFilter = "Date = '" + dtpPurchase.Value.Year + "-" + dtpPurchase.Value.Month + "-" + dtpPurchase.Value.Day + "' ";
        }
        private void udfVendorMaster()
        {
            try
            {
                ds.Tables.Add("VendorMaster");
                CrudeNavigationClass.FillTable(str, "Select VendorNo, VendorName from VendorMaster", ds.Tables["VendorMaster"]);
            }
            catch (Exception)
            { }
        }


        private void udfgvPurchase()
        {
            try
            {
                string[,] Name = new string[2, 2] { { "VendorName", "Vendor Name" }, { "Amount", "Amount" } };
                bool[] Readonly = new bool[2] { true, false };
                int[] fillweight = new int[2] { 20, 20 };


                CrudeNavigationClass.DGVTextBoxColumn(Name, fillweight, Name, Readonly, gvPurchase, 0, 1);
                CrudeNavigationClass.DGVValidation(gvPurchase);


                foreach (DataGridViewColumn c in gvPurchase.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Cambria", 15F, GraphicsUnit.World);
                }
                //gvPurchase.DataSource = ds.Tables["Purchase"];
            }
            catch (Exception)
            { }
        }


        void textcontrol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            { e.Handled = true; }
        }


        private void dtpPurchase_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (ds.Tables["Purchase"].Rows.Count > 0)
            //    {
            //        udfRowFilter();
            //    }
            //}
            //catch (Exception exp)
            //{
            //    MessageBox.Show(exp.Message);
            //}
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPurchase.Rows.Count == 0)
                {
                    foreach (DataRow row in ds.Tables["VendorMaster"].Rows)
                    {
                        CrudeNavigationClass.CrudeInsert(str, "Insert into Purchase (VendorNo, VendorName, Date, Amount) values(" + row["VendorNo"] + ", '" + row["VendorName"] + "','" + dtpPurchase.Value.Year + "-" + dtpPurchase.Value.Month + "-" + dtpPurchase.Value.Day + " ',0)");
                    }
                    udfPurchase();
                }
                else if (gvPurchase.Rows.Count != 0)
                {
                    MessageBox.Show("Purchase Details Already Created", "Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void gvPurchase_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (gvPurchase.CurrentCell == gvPurchase.CurrentRow.Cells["Amount"])// || gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["Mobile"])// || gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["Pin"])    
                {
                    TextBox textcontrol = e.Control as DataGridViewTextBoxEditingControl;
                    textcontrol.KeyPress += new KeyPressEventHandler(textcontrol_KeyPress);
                    textcontrol.MaxLength = 7;
                }
            }
            catch (Exception)
            { }
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            dtpPurchase.Format = DateTimePickerFormat.Custom;
            dtpPurchase.CustomFormat = "dd/MM/yyyy";// hh:MM:ss";
            ds = new DataSet();

            udfVendorMaster();
            udfgvPurchase();
            udfPurchase();
        }

        private void gvPurchase_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gvPurchase.CurrentCell.Value.ToString() == "")
                {
                    ds.Tables["Purchase"].RejectChanges();
                }
                else if (gvPurchase.CurrentCell.Value.ToString() != "")
                {
                    ds.Tables["Purchase"].AcceptChanges();
                }
            }
            catch (Exception)
            { }
            finally
            {
                if (textcontrol != null)
                { textcontrol.KeyPress -= new KeyPressEventHandler(textcontrol_KeyPress); }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPurchase.Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables["Purchase"].Rows)
                    {
                        CrudeNavigationClass.CrudeInsert(str, "Update Purchase set Amount = " + row["Amount"] + " where Date = '" + dtpPurchase.Value.Year + "-" + dtpPurchase.Value.Month + "-" + dtpPurchase.Value.Day + " 00:00:00' and VendorNo = " + row["VendorNo"] + "");
                    }
                    MessageBox.Show("Purchase Information Saved", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ds.Tables["Purchase"].AcceptChanges();
                }
            }
            catch (Exception)
            { }
        }

        private void dtpPurchase_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                udfPurchase();
            }
            catch (Exception)
            { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Do You Want to Remove Purchase Inoformation for the\n\nDate [" + dtpPurchase.Value.Day + "-" + dtpPurchase.Value.Month + "-" + dtpPurchase.Value.Year + "] Permanently?", "Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    CrudeNavigationClass.CrudeInsert(str, "Delete from Purchase where Date = '" + dtpPurchase.Value.Year + "-" + dtpPurchase.Value.Month + "-" + dtpPurchase.Value.Day + " 00:00:00'");
                    ds.Tables["Purchase"].Rows.Clear();
                }
                else if (dr == DialogResult.No)
                {
                    dtpPurchase.Focus();
                }
            }
            catch (Exception)
            { }
        }
    }
}
