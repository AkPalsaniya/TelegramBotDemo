using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class frmCategoryMaster : CustomForm
    {
        string str;
        DataRow dr;
        DataTable dtCategory;

        public frmCategoryMaster()
        {
            InitializeComponent();
            str = System.Configuration.ConfigurationManager.ConnectionStrings["salogin"].ToString();
            CustomUI.customiseMenuForm(this);
        }

        private void frmCategoryMaster_Load(object sender, EventArgs e)
        {
            dtCategory = new DataTable();
            dtCategory.Merge(CrudeNavigationClass.GetData(str, "Select CategoryNo, CategoryName, Status from CategoryMaster"));
            lnkCategoryNo.Focus();
            udffrmCategoryMaster();
            udfMaxLength();
            udfGridDisplay();
        }

        private void udfMaxLength()
        {
            cbCategoryName.MaxLength = 50;
            cbCategoryNo.MaxLength = 3;
        }

        private void udffrmCategoryMaster()
        {
            try
            {
                cbCategoryNo.Items.Clear();
                cbCategoryName.Items.Clear();
                foreach (DataRow row in dtCategory.Rows)
                {
                    cbCategoryNo.Items.Add(row["CategoryNo"].ToString());
                    cbCategoryName.Items.Add(row["CategoryName"].ToString());
                }
            }
            catch (Exception)
            { }
        }

        private void udfGridDisplay()
        {
            try
            {
                string[,] Name = new string[3, 2] { { "Status", "Block" }, { "CategoryNo", "CategoryNo" }, { "CategoryName", "CategoryName" } };
                //bool[] Readonly = new bool[6] { true, false, false,false,true, false };
                bool[] Readonly = new bool[3] { false, true, true };
                //int[] fillweight = new int[6] { 10, 20, 20, 20, 20, 10};
                int[] fillweight = new int[3] { 5, 10, 20 };

                CrudeNavigationClass.DGVCheckBoxColumn(Name, fillweight, Name, gvCategory, 0, 0);
                CrudeNavigationClass.DGVTextBoxColumn(Name, fillweight, Name, Readonly, gvCategory, 1, 2);
                CrudeNavigationClass.DGVValidation(gvCategory);

                foreach (DataGridViewColumn c in gvCategory.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Cambria", 15F, GraphicsUnit.World);
                }
                gvCategory.DataSource = dtCategory;
            }
            catch (Exception)
            { }
        }

        private void udfBlankAll()
        {
            cbCategoryNo.SelectedIndex = -1;
            cbCategoryName.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            udfbtnAdd();
        }

        private void udfbtnAdd()
        {
            try
            {
                if (!cbCategoryName.Items.Contains(cbCategoryName.Text))
                {
                    dr = dtCategory.NewRow();
                    dr["CategoryNo"] = cbCategoryNo.Text;
                    dr["CategoryName"] = cbCategoryName.Text;
                    dr["Status"] = false;
                    dtCategory.Rows.Add(dr);
                    udffrmCategoryMaster();
                    CrudeNavigationClass.Insert(str, "Insert into CategoryMaster (CategoryNo, CategoryName, Status)values(" + cbCategoryNo.Text + ",N'" + cbCategoryName.Text + "','false')");
                    MessageBox.Show("Record Inserted", "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("This Category Name Already exists", "Duplication not Permitted", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    lnkCategoryNo.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Some Values Missing!", "Fields Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                cbCategoryName.Text = "";
                cbCategoryNo.Text = "";
                //udffrmCategoryMaster();
            }
            //udfGridDisplay();
            lnkCategoryNo.Focus();
        }

        private void lnkCategoryNo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                int varintCategoryNo = 0;
                if (cbCategoryNo.Items.Count > 0)
                {
                    varintCategoryNo = Convert.ToInt32(dtCategory.Rows[dtCategory.Rows.Count - 1]["CategoryNo"]) + 1;
                }
                else if (cbCategoryNo.Items.Count == 0)
                {
                    varintCategoryNo = 1;
                }
                udfBlankAll();
                cbCategoryNo.Text = varintCategoryNo.ToString();
                cbCategoryName.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error generating new number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            udbtnEdit();
        }

        private void udbtnEdit()
        {
            try
            {
                if (cbCategoryNo.SelectedIndex > -1)
                {
                    dtCategory.Rows.Find(cbCategoryNo.Text)["CategoryName"] = cbCategoryName.Text;
                    dtCategory.AcceptChanges();
                    CrudeNavigationClass.Insert(str, "Update CategoryMaster set CategoryName=N'" + cbCategoryName.Text + "' where CategoryNo = " + cbCategoryNo.Text + "");
                    //if (sdr.RecordsAffected >= 1)
                    {
                        MessageBox.Show("Category Name [" + cbCategoryName.Text + "] Updated", "Record Updated",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Some Values Missing!", "Fields Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //udfGridDisplay();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            udfbtnDelete();
        }

        private void udfbtnDelete()
        {
            try
            {
                if (cbCategoryNo.SelectedIndex > -1)
                {
                    dtCategory.Rows.Find(cbCategoryNo.Text)["Status"] = true;
                    CrudeNavigationClass.Insert(str, "Delete From CategoryMaster where CategoryNo = " + cbCategoryNo.Text + "");
                    gvCategory.Refresh();
                    //if (sdr.RecordsAffected >= 1)
                    {
                        MessageBox.Show("Category Name [" + cbCategoryName.Text + "] Deleted", "Record Deleted");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Select Category which you want to Delete!", "Fields Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
            }
            //udfGridDisplay();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            cbCategoryNo.SelectedIndex = 0;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            cbCategoryNo.SelectedIndex = cbCategoryNo.Items.Count - 1;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (cbCategoryNo.SelectedIndex > 0)
                cbCategoryNo.SelectedIndex -= 1;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cbCategoryNo.SelectedIndex < cbCategoryNo.Items.Count - 1)
                cbCategoryNo.SelectedIndex += 1;
        }

        private void cbCategoryNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategoryName.Items.Count > 0)
            {
                cbCategoryName.SelectedIndex = cbCategoryNo.SelectedIndex;
            }
        }

        private void cbCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCategoryNo.SelectedIndex = cbCategoryName.SelectedIndex;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmCategoryMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void gvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtCategory.Rows.Count > 0)
                {
                    if (gvCategory.CurrentCell == gvCategory.CurrentRow.Cells["Status"])
                    {
                        if (gvCategory.CurrentRow.Cells["Status"].Value.ToString() == "True")
                        {
                            dtCategory.Rows.Find(gvCategory.CurrentRow.Cells["CategoryNo"].Value)["Status"] = false;
                            CrudeNavigationClass.Insert(str, "Update CategoryMaster set Status= 'False' where CategoryNo = " + gvCategory.CurrentRow.Cells["CategoryNo"].Value + "");
                        }
                        else if (gvCategory.CurrentRow.Cells["Status"].Value.ToString() == "False")
                        {
                            dtCategory.Rows.Find(gvCategory.CurrentRow.Cells["CategoryNo"].Value)["Status"] = true;
                            CrudeNavigationClass.Insert(str, "Update CategoryMaster set Status= 'True' where CategoryNo = " + gvCategory.CurrentRow.Cells["CategoryNo"].Value + "");
                        }
                    }
                }
            }
            catch (Exception)
            { }
        }
    }
}
