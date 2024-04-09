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
    public partial class frmVendorMaster : CustomForm
    {
        DataSet ds;
        DataRow dr;
        DataGridViewTextBoxEditingControl textcontrol;
        DataGridViewTextBoxEditingControl textcontrol2;
        string str;
        int i = 0;

        public frmVendorMaster()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            str = ConfigurationManager.ConnectionStrings["salogin"].ToString();
        }

        private void udfVendorMaster()
        {
            if (ds.Tables.Contains("VendorMaster") == true)
            { ds.Tables.Remove("VendorMaster"); }
            ds.Tables.Add("VendorMaster");
            CrudeNavigationClass.FillTable(str, "Select * from VendorMaster", ds.Tables["VendorMaster"]);
        }
        private void udfgvVendorMaster()
        {
            //string[,] Name = new string[12, 2] { { "VendorNo", "No" }, { "VendorName", "Name" }, { "Address1", "Address1" }, { "Address2", "Address2" }, { "Address3", "Address3" }, { "City", "City" }, { "State", "State" }, { "PIN", "PIN" }, { "Phone", "Phone" }, { "Mobile", "Mobile" }, { "EmailId", "EmailId" }, { "Status", "Status" } };
            string[,] Name = new string[8, 2] { { "SupplierNo", "No" }, { "SupplierName", "Name" }, { "Address1", "Address" }, { "City", "City" }, { "Phone", "Phone" }, { "Mobile", "Mobile" }, { "EmailId", "EmailId" }, { "Status", "Status" } };
            bool[] Readonly = new bool[8] { true, false, false, false, false, false, false, false };// Make Price Editable
            int[] fillweight = new int[8] { 10, 25, 15, 15, 15, 15, 25, 10 };
            CrudeNavigationClass.DGVTextBoxColumn(Name, fillweight, Name, Readonly, gvVendorMaster, 0, 6);
            CrudeNavigationClass.DGVCheckBoxColumn(Name, fillweight, Name, gvVendorMaster, 7, 7);
            CrudeNavigationClass.DGVValidation(gvVendorMaster);
            foreach (DataGridViewColumn c in gvVendorMaster.Columns)
            {
                //c.DefaultCellStyle.Font = new Font("Times New Roman", 25F, GraphicsUnit.World);
                c.DefaultCellStyle.Font = new Font("Cambria", 15F, GraphicsUnit.World);
            }
            gvVendorMaster.DataSource = ds.Tables["VendorMaster"];

        }


        void textcontrol_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            { e.Handled = true; }
        }

        private void frmVendorMaster_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            udfVendorMaster();
            udfgvVendorMaster();
            this.CenterToParent();
        }

        private void gvVendorMaster_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (gvVendorMaster.CurrentRow.Index == gvVendorMaster.Rows.Count - 1)
                    {
                        dr = ds.Tables["VendorMaster"].NewRow();
                        dr["SupplierNo"] = Convert.ToDouble(ds.Tables["VendorMaster"].Rows[ds.Tables["VendorMaster"].Rows.Count - 1]["SupplierNo"]) + 1;
                        dr["SupplierName"] = "[Name]";
                        dr["Address1"] = "Nil";
                        //dr["Address2"] = "Nil";
                        //dr["Address3"] = "Nil";
                        dr["City"] = "Nil";
                        //dr["State"] = "Nil";
                        //dr["Pin"] = "0";
                        dr["Phone"] = "0";
                        dr["Mobile"] = "0";
                        dr["EmailId"] = "Nil";
                        dr["Status"] = false;
                        dr["CreditAmount"] = 0;
                        dr["DebitAmount"] = 0;
                        ds.Tables["VendorMaster"].Rows.Add(dr);
                        //CrudeNavigationClass.CrudeInsert(str, "Insert into VendorMaster (VendorNo, VendorName, Address1, Address2, Address3, City, State, Pin, Phone, Mobile, EmailId, Status) values(" + dr["VendorNo"] + ",'" + dr["VendorName"] + "','" + dr["Address1"] + "','" + dr["Address1"] + "','" + dr["Address1"] + "','" + dr["City"] + "','" + dr["State"] + "'," + dr["Pin"] + "," + dr["Phone"] + "," + dr["Mobile"] + ",'" + dr["EmailId"] + "','" + dr["Status"] + "') ");
                        CrudeNavigationClass.CrudeInsert(str, "Insert into VendorMaster (SupplierNo, SupplierName, Address1, City, Phone, Mobile, EmailId, Status, CreditAmount, DebitAmount) values(" + dr["SupplierNo"] + ",'" + dr["SupplierName"] + "','" + dr["Address1"] + "','" + dr["City"] + "'," + dr["Phone"] + "," + dr["Mobile"] + ",'" + dr["EmailId"] + "','" + dr["Status"] + "', 0, 0) ");
                        ds.Tables["VendorMaster"].AcceptChanges();
                        gvVendorMaster.CurrentCell = gvVendorMaster.Rows[gvVendorMaster.Rows.Count - 1].Cells["SupplierName"];
                        //gvVendorMaster.BeginEdit(true);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ds.Tables["VendorMaster"].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables["VendorMaster"].Rows)
                    {
                        //CrudeNavigationClass.CrudeInsert(str, "Update VendorMaster set  VendorName = '" + row["VendorName"] + "', Address1 = '" + row["Address1"] + "', Address2 = '" + row["Address2"] + "', Address3 = '" + row["Address3"] + "', City = '" + row["City"] + "', State = '" + row["State"] + "', Pin = " + row["Pin"] + ", Phone = " + row["Phone"] + ", Mobile = " + row["Mobile"] + ", EmailId = '" + row["EmailId"] + "', Status = '" + row["Status"] + "' where VendorNo = " + row["VendorNo"] + "");
                        CrudeNavigationClass.CrudeInsert(str, "Update VendorMaster set  SupplierName = '" + row["SupplierName"] + "', Address1 = '" + row["Address1"] + "',City = '" + row["City"] + "', Phone = " + row["Phone"] + ", Mobile = " + row["Mobile"] + ", EmailId = '" + row["EmailId"] + "', Status = '" + row["Status"] + "' where SupplierNo = " + row["SupplierNo"] + "");
                    }
                    ds.Tables["VendorMaster"].AcceptChanges();
                    MessageBox.Show("Information Saved", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvVendorMaster.Rows.Count > 0)
                {
                    gvVendorMaster.CurrentCell = gvVendorMaster.Rows[0].Cells["SupplierNo"];
                }
            }
            catch (Exception)
            { }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvVendorMaster.Rows.Count > 0 && gvVendorMaster.CurrentRow.Index != 0)
                {
                    gvVendorMaster.CurrentCell = gvVendorMaster.Rows[gvVendorMaster.CurrentRow.Index - 1].Cells["SupplierNo"];
                }
            }
            catch (Exception)
            { }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {

                if (gvVendorMaster.Rows.Count > 0 && gvVendorMaster.CurrentRow.Index != gvVendorMaster.Rows.Count - 1)
                {
                    gvVendorMaster.CurrentCell = gvVendorMaster.Rows[gvVendorMaster.CurrentRow.Index + 1].Cells["SupplierNo"];
                }
            }
            catch (Exception)
            { }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvVendorMaster.Rows.Count > 0 && gvVendorMaster.CurrentRow.Index != gvVendorMaster.Rows.Count - 1)
                {
                    gvVendorMaster.CurrentCell = gvVendorMaster.Rows[gvVendorMaster.CurrentRow.Index - 1].Cells["SupplierNo"];
                }
            }
            catch (Exception)
            { }
        }

        private void gvVendorMaster_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["SupplierName"])
                {
                    gvVendorMaster.BeginEdit(true);
                }
            }
            catch (Exception)
            { }
        }

        private void gvVendorMaster_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gvVendorMaster.CurrentCell.Value.ToString() == "")
                {
                    ds.Tables["VendorMaster"].RejectChanges();
                }
                else if (gvVendorMaster.CurrentCell.Value.ToString() != "")
                {
                    ds.Tables["VendorMaster"].AcceptChanges();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void gvVendorMaster_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["Phone"] || gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["Mobile"])// || gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["Pin"])    
            {

                TextBox textcontrol = e.Control as DataGridViewTextBoxEditingControl;
                textcontrol.KeyPress += new KeyPressEventHandler(textcontrol_KeyPress);
                if (gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["Phone"])
                { textcontrol.MaxLength = 15; }
                else if (gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["Mobile"])
                { textcontrol.MaxLength = 12; }
                //else if (gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["Pin"])
                //{ textcontrol.MaxLength = 10; }
            }
            else if (gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["SupplierName"] || gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["Address1"] || gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["City"] || gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["EmailId"])
            {
                textcontrol2 = e.Control as DataGridViewTextBoxEditingControl;
                if (gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["SupplierName"])
                { textcontrol2.MaxLength = 40; }
                else if (gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["Address1"])
                { textcontrol2.MaxLength = 20; }
                else if (gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["City"])
                { textcontrol2.MaxLength = 20; }
                else if (gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["EmailId"])
                { textcontrol2.MaxLength = 30; }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CrudeNavigationClass.CrudeSelect(str, "Delete from Purchase where VendorNo = " + gvVendorMaster.CurrentRow.Cells["SupplierNo"].Value + "");
                CrudeNavigationClass.CrudeSelect(str, "Delete from VendorMaster where SupplierNo = " + gvVendorMaster.CurrentRow.Cells["SupplierNo"].Value + "");
                ds.Tables["VendorMaster"].Rows.Find(gvVendorMaster.CurrentRow.Cells["SupplierNo"].Value).Delete();
                MessageBox.Show("Vendor Successfully Deleted", "Deleted...");
                ds.Tables["VendorMaster"].AcceptChanges();
            }
            catch (Exception)
            { 
                
            }
        }

        
    }
}
