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
    public partial class frmCustomerMaster : Form
    {
        DataSet ds;
        DataRow dr;
        DataGridViewTextBoxEditingControl textcontrol;
        DataGridViewTextBoxEditingControl textcontrol2;
        string str;
        int i = 0;

        public frmCustomerMaster()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            str = ConfigurationManager.ConnectionStrings["salogin"].ToString();
        }
        private void udfCustomerMaster()
        {
            if (ds.Tables.Contains("CustomerMaster") == true)
            { ds.Tables.Remove("CustomerMaster"); }
            ds.Tables.Add("CustomerMaster");
            CrudeNavigationClass.FillTable(str, "Select * from CustomerMaster", ds.Tables["CustomerMaster"]);
        }

        private void udfgvCustomerMaster()  
        {
            //string[,] Name = new string[12, 2] { { "VendorNo", "No" }, { "VendorName", "Name" }, { "Address1", "Address1" }, { "Address2", "Address2" }, { "Address3", "Address3" }, { "City", "City" }, { "State", "State" }, { "PIN", "PIN" }, { "Phone", "Phone" }, { "Mobile", "Mobile" }, { "EmailId", "EmailId" }, { "Status", "Status" } };
            string[,] Name = new string[8, 2] { { "CustomerCode", "No" }, { "CustomerName", "Name" }, { "Address1", "Address" }, { "City", "City" }, { "State", "State" }, { "Phone", "Phone" }, { "Mobile", "Mobile" }, { "Email", "Email" }};
            bool[] Readonly = new bool[8] { true, false, false, false, false, false, false, false };// Make Price Editable
            int[] fillweight = new int[8] { 10, 25, 15, 15, 15, 15, 25, 25 };
            CrudeNavigationClass.DGVTextBoxColumn(Name, fillweight, Name, Readonly, gvCustomerMaster, 0, 7);
            CrudeNavigationClass.DGVValidation(gvCustomerMaster);
            foreach (DataGridViewColumn c in gvCustomerMaster.Columns)
            {
                //c.DefaultCellStyle.Font = new Font("Times New Roman", 25F, GraphicsUnit.World);
                c.DefaultCellStyle.Font = new Font("Cambria", 15F, GraphicsUnit.World);
            }
            gvCustomerMaster.DataSource = ds.Tables["CustomerMaster"];

        }
        void textcontrol_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            { e.Handled = true; }
        }

        private void frmCustomerMaster_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            udfCustomerMaster();
            udfgvCustomerMaster();
            this.CenterToParent();
        }

        private void gvCustomerMaster_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gvCustomerMaster.CurrentCell.Value.ToString() == "")
                {
                    ds.Tables["CustomerMaster"].RejectChanges();
                }
                else if (gvCustomerMaster.CurrentCell.Value.ToString() != "")
                {
                    ds.Tables["CustomerMaster"].AcceptChanges();
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

        private void gvCustomerMaster_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gvCustomerMaster.CurrentCell == gvCustomerMaster.CurrentRow.Cells["CustomerName"])
                {
                    gvCustomerMaster.BeginEdit(true);
                }
            }
            catch (Exception)
            { }
        }

        private void gvCustomerMaster_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (gvCustomerMaster.CurrentCell == gvCustomerMaster.CurrentRow.Cells["Phone"] || gvCustomerMaster.CurrentCell == gvCustomerMaster.CurrentRow.Cells["Mobile"])// || gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["Pin"])    
            {

                TextBox textcontrol = e.Control as DataGridViewTextBoxEditingControl;
                textcontrol.KeyPress += new KeyPressEventHandler(textcontrol_KeyPress);
                if (gvCustomerMaster.CurrentCell == gvCustomerMaster.CurrentRow.Cells["Phone"])
                { textcontrol.MaxLength = 15; }
                else if (gvCustomerMaster.CurrentCell == gvCustomerMaster.CurrentRow.Cells["Mobile"])
                { textcontrol.MaxLength = 12; }
                //else if (gvVendorMaster.CurrentCell == gvVendorMaster.CurrentRow.Cells["Pin"])
                //{ textcontrol.MaxLength = 10; }
            }
            else if (gvCustomerMaster.CurrentCell == gvCustomerMaster.CurrentRow.Cells["CustomerName"] || gvCustomerMaster.CurrentCell == gvCustomerMaster.CurrentRow.Cells["Address1"] || gvCustomerMaster.CurrentCell == gvCustomerMaster.CurrentRow.Cells["City"] || gvCustomerMaster.CurrentCell == gvCustomerMaster.CurrentRow.Cells["Email"])
            {
                textcontrol2 = e.Control as DataGridViewTextBoxEditingControl;
                if (gvCustomerMaster.CurrentCell == gvCustomerMaster.CurrentRow.Cells["CustomerName"])
                { textcontrol2.MaxLength = 40; }
                else if (gvCustomerMaster.CurrentCell == gvCustomerMaster.CurrentRow.Cells["Address1"])
                { textcontrol2.MaxLength = 20; }
                else if (gvCustomerMaster.CurrentCell == gvCustomerMaster.CurrentRow.Cells["City"])
                { textcontrol2.MaxLength = 20; }
                else if (gvCustomerMaster.CurrentCell == gvCustomerMaster.CurrentRow.Cells["Email"])
                { textcontrol2.MaxLength = 30; }
            }
        }

        private void gvCustomerMaster_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (gvCustomerMaster.CurrentRow.Index == gvCustomerMaster.Rows.Count - 1)
                    {
                        dr = ds.Tables["CustomerMaster"].NewRow();
                        dr["CustomerCode"] = Convert.ToDouble(ds.Tables["CustomerMaster"].Rows[ds.Tables["CustomerMaster"].Rows.Count - 1]["CustomerCode"]) + 1;
                        dr["CustomerName"] = "[Name]";
                        dr["Address1"] = "Nil";
                        //dr["Address2"] = "Nil";
                        //dr["Address3"] = "Nil";
                        dr["City"] = "Nil";
                        dr["State"] = "Nil";
                        //dr["Pin"] = "0";
                        dr["Phone"] = "0";
                        dr["Mobile"] = "0";
                        dr["Email"] = "Nil";
                        ds.Tables["CustomerMaster"].Rows.Add(dr);
                        //CrudeNavigationClass.CrudeInsert(str, "Insert into VendorMaster (VendorNo, VendorName, Address1, Address2, Address3, City, State, Pin, Phone, Mobile, EmailId, Status) values(" + dr["VendorNo"] + ",'" + dr["VendorName"] + "','" + dr["Address1"] + "','" + dr["Address1"] + "','" + dr["Address1"] + "','" + dr["City"] + "','" + dr["State"] + "'," + dr["Pin"] + "," + dr["Phone"] + "," + dr["Mobile"] + ",'" + dr["EmailId"] + "','" + dr["Status"] + "') ");
                        CrudeNavigationClass.CrudeInsert(str, "Insert into CustomerMaster (CustomerCode, CustomerName, Address1, City,State, Phone, Mobile, Email) values(" + dr["CustomerCode"] + ",'" + dr["CustomerName"] + "','" + dr["Address1"] + "','" + dr["City"] + "','" + dr["State"] + "','" + dr["Phone"] + "','" + dr["Mobile"] + "','" + dr["Email"] + "') ");
                        ds.Tables["CustomerMaster"].AcceptChanges();
                        gvCustomerMaster.CurrentCell = gvCustomerMaster.Rows[gvCustomerMaster.Rows.Count - 1].Cells["CustomerName"];
                        //gvVendorMaster.BeginEdit(true);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CrudeNavigationClass.CrudeSelect(str, "Delete from CustomerMaster where CustomerCode = " + gvCustomerMaster.CurrentRow.Cells["CustomerCode"].Value + "");
                ds.Tables["CustomerMaster"].Rows.Find(gvCustomerMaster.CurrentRow.Cells["CustomerCode"].Value).Delete();
                MessageBox.Show("Customer Successfully Deleted", "Deleted...");
                ds.Tables["CustomerMaster"].AcceptChanges();
            }
            catch (Exception)
            {

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ds.Tables["CustomerMaster"].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables["CustomerMaster"].Rows)
                    {
                        //CrudeNavigationClass.CrudeInsert(str, "Update VendorMaster set  VendorName = '" + row["VendorName"] + "', Address1 = '" + row["Address1"] + "', Address2 = '" + row["Address2"] + "', Address3 = '" + row["Address3"] + "', City = '" + row["City"] + "', State = '" + row["State"] + "', Pin = " + row["Pin"] + ", Phone = " + row["Phone"] + ", Mobile = " + row["Mobile"] + ", EmailId = '" + row["EmailId"] + "', Status = '" + row["Status"] + "' where VendorNo = " + row["VendorNo"] + "");
                        CrudeNavigationClass.CrudeInsert(str, "Update CustomerMaster set  CustomerName = '" + row["CustomerName"] + "', Address1 = '" + row["Address1"] + "',City = '" + row["City"] + "', State = '" + row["State"] + "', Phone = '" + row["Phone"] + "', Mobile = '" + row["Mobile"] + "', Email = '" + row["Email"] + "' where CustomerCode = " + row["CustomerCode"] + "");
                    }
                    ds.Tables["CustomerMaster"].AcceptChanges();
                    MessageBox.Show("Information Saved", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvCustomerMaster.Rows.Count > 0)
                {
                    gvCustomerMaster.CurrentCell = gvCustomerMaster.Rows[0].Cells["CustomerCode"];
                }
            }
            catch (Exception)
            { }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvCustomerMaster.Rows.Count > 0 && gvCustomerMaster.CurrentRow.Index != 0)
                {
                    gvCustomerMaster.CurrentCell = gvCustomerMaster.Rows[gvCustomerMaster.CurrentRow.Index - 1].Cells["CustomerCode"];
                }
            }
            catch (Exception)
            { }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {

                if (gvCustomerMaster.Rows.Count > 0 && gvCustomerMaster.CurrentRow.Index != gvCustomerMaster.Rows.Count - 1)
                {
                    gvCustomerMaster.CurrentCell = gvCustomerMaster.Rows[gvCustomerMaster.CurrentRow.Index + 1].Cells["CustomerCode"];
                }
            }
            catch (Exception)
            { }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvCustomerMaster.Rows.Count > 0 && gvCustomerMaster.CurrentRow.Index != gvCustomerMaster.Rows.Count - 1)
                {
                    gvCustomerMaster.CurrentCell = gvCustomerMaster.Rows[gvCustomerMaster.CurrentRow.Index - 1].Cells["CustomerCode"];
                }
            }
            catch (Exception)
            { }
        }
    }
}
