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
    public partial class frmUserMaster : CustomForm
    {
        string str;
        DataTable dtUMaster;
        DataTable dtRoleNo;
        DataRow dr;
        DataGridViewComboBoxEditingControl comboControl;
        DataGridViewTextBoxEditingControl textcontrol;
        //DataGridViewComboBoxCell cell;

        public frmUserMaster()
        {
            InitializeComponent();
            str = System.Configuration.ConfigurationManager.ConnectionStrings["salogin"].ToString();
            CustomUI.customiseMenuForm(this);
        
        }

        private void frmUserMaster_Load(object sender, EventArgs e)
        {
            try
            {
                cbSearchBy.Items.Add("UserNo");
                cbSearchBy.Items.Add("FirstName");
                cbSearchBy.Items.Add("MiddleName");
                cbSearchBy.Items.Add("LastName");
                cbSearchBy.Items.Add("UserId");
                cbSearchBy.Items.Add("UserRoleNo");
                cbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
                cbSearchBy.SelectedIndex = -1;

                
                //cbRoleNo.Items.Add("3");
                

                //cell = new DataGridViewComboBoxCell();
                //cell.DataSource = cbRoleNo.Items;

                cbSearch.DropDownStyle = ComboBoxStyle.Simple;
                cbSearchBy.SelectedIndex = 0;

                udfUserMaster();
                uddtRoleNo();
                udfgvUMaster();
            }
            catch (Exception)
            { }
        }
        private void udfUserMaster()
        {
            try
            {
                dtUMaster = new DataTable();
                dtUMaster.Merge(CrudeNavigationClass.GetData(str, "Select * from UserMaster"));
                if (dtUMaster.Rows.Count == 0)
                {
                    dr = dtUMaster.NewRow();
                    dr["UserNo"] = "1";
                    dr["CreationDate"] = DateTime.Now;
                    dr["Status"] = false;
                    //dr["UserRoleNo"] = cbRoleNo.SelectedItem;
                    dtUMaster.Rows.Add(dr);
                }
            }
            catch (Exception)
            { }
        }

        private void uddtRoleNo()
        {
            try
            {
                dtRoleNo = new DataTable();
                dtRoleNo.Columns.Add("UserRoleNo");
                for (int i = 0; i <= 1; i++)
                {
                    dr = dtRoleNo.NewRow();
                    dr["UserRoleNo"] = ""+(i+1)+"";
                    dtRoleNo.Rows.Add(dr);
                }
            }
            catch (Exception)
            { }
        }
        private void udfgvUMaster()
        {
            try
            {
                DataGridViewTextBoxColumn[] tbc = new DataGridViewTextBoxColumn[7];
                DataGridViewCheckBoxColumn[] chbc = new DataGridViewCheckBoxColumn[1];
                DataGridViewComboBoxColumn[] cbc = new DataGridViewComboBoxColumn[1];
                

                string[,] Name = new string[9, 2] { { "UserNo", "UserNo" }, { "UserId", "UserId" }, { "Password", "Password" }, { "FirstName", "FirstName" }, { "MiddleName", "MiddleName" }, { "LastName", "LastName" }, { "CreationDate", "CreationDate" }, { "Status", "Status" }, { "UserRoleNo", "RoleNo" } };
                //bool[] Readonly = new bool[9] { false, false, true };// Make Price Editable
                //bool[] Readonly = new bool[3] { true, false, true };
                int[] fillweight = new int[9] { 10, 20, 20, 20, 20, 20, 25, 10, 10};

                
                for (int i = 0; i <= 6; i++)
                {
                    tbc[i] = new DataGridViewTextBoxColumn();
                    tbc[i].Name = tbc[i].DataPropertyName = Name[i, 0];
                    tbc[i].FillWeight = fillweight[i];
                    tbc[i].HeaderText = Name[i, 1];
                    //tbc[i].ReadOnly = Readonly[i];
                    gvUserMaster.Columns.Add(tbc[i]);
                    //j = i;
                }

                for (int i = 0; i <= 0; i++)
                {

                    chbc[i] = new DataGridViewCheckBoxColumn();
                    chbc[i].Name = Name[i + 7, 0];
                    chbc[i].DataPropertyName = Name[i + 7, 0];
                    chbc[i].FillWeight = fillweight[i + 7];
                    chbc[i].HeaderText = Name[i + 7, 1];
                    chbc[i].ThreeState = false;
                    chbc[i].TrueValue = true;
                    chbc[i].FalseValue = false;
                    gvUserMaster.Columns.Add(chbc[i]);
                    
                }
                for (int i = 0 ; i <= 0; i++)
                {
                    
                    cbc[i] = new DataGridViewComboBoxColumn();
                    cbc[i].Name = cbc[i].DisplayMember = Name[i + 8, 0];
                    cbc[i].ValueMember = Name[i + 8, 0];
                    cbc[i].DataPropertyName = Name[i + 8, 0];
                    cbc[i].FillWeight = fillweight[i + 8];
                    cbc[i].HeaderText = Name[i + 8, 1];
                    
                    //ds.Tables["ItemMaster"].DefaultView.RowFilter = "Status = 'false'";

                    cbc[i].DataSource = dtRoleNo.DefaultView;
                    gvUserMaster.Columns.Add(cbc[i]);
                    //cbc[i].DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                }

                foreach (DataGridViewColumn c in gvUserMaster.Columns)
                {
                    //c.DefaultCellStyle.Font = new Font("Times New Roman", 25F, GraphicsUnit.World);
                    c.DefaultCellStyle.Font = new Font("Cambria", 15F, GraphicsUnit.World);
                }
                

                gvUserMaster.Columns["UserNo"].ReadOnly = true;
                gvUserMaster.Columns["CreationDate"].ReadOnly = true;
                //gvUserMaster.Columns["UserRoleNo"].ReadOnly = false;

              

                gvUserMaster.AutoGenerateColumns = false;
                gvUserMaster.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gvUserMaster.RowHeadersVisible = false;
                gvUserMaster.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gvUserMaster.AllowUserToAddRows = false;
                gvUserMaster.AllowUserToResizeColumns = false;
                gvUserMaster.AllowUserToResizeRows = false;
                gvUserMaster.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                gvUserMaster.DataSource = dtUMaster;
            }
            catch (Exception exp)
            { MessageBox.Show(exp.Message); }
        }

        
        private void gvUserMaster_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && gvUserMaster.CurrentRow.Index == gvUserMaster.Rows.Count - 1 && gvUserMaster.CurrentRow.Cells["UserId"].Value.ToString() != "" && gvUserMaster.CurrentRow.Cells["Password"].Value.ToString() != "" && gvUserMaster.CurrentRow.Cells["FirstName"].Value.ToString() != "" && gvUserMaster.CurrentRow.Cells["UserRoleNo"].Value.ToString() != "")
                {
                    dr = dtUMaster.NewRow();
                    dr["UserNo"] = Convert.ToString(Convert.ToDouble(gvUserMaster.Rows[gvUserMaster.Rows.Count - 1].Cells["UserNo"].Value) + 1);
                    dr["Status"] = false;
                    dr["UserRoleNo"] = 1;
                    dr["CreationDate"] = Convert.ToDateTime(DateTime.Now);
                   // dr["UserRoleNo"] = cbRoleNo.SelectedItem;
                    dtUMaster.Rows.Add(dr);
                    gvUserMaster.CurrentCell = gvUserMaster.CurrentRow.Cells["UserId"];

                    CrudeNavigationClass.CrudeInsert(str, "Insert into UserMaster (UserNo, Status, UserRoleNo, CreationDate) values(" + dr["UserNo"] + ", 'false', " + dr["UserRoleNo"] + ", '" + DateTime.Now.Date.Year + "-" + DateTime.Now.Date.Month + "-" + DateTime.Now.Date.Day + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "')");
                    CrudeNavigationClass.CrudeInsert(str, "Insert into UserRights (UserNo) Values(" + dr["UserNo"] + ")");
                }
            }
            catch (Exception exp)
            { //MessageBox.Show(exp.Message); 
            }
        }

        private void lnkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cbSearchBy.SelectedIndex = -1;
            cbSearch.Text = "";
            dtUMaster.DefaultView.RowFilter = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvUserMaster.Rows.Count > 0)
                {
                    CrudeNavigationClass.CrudeInsert(str, "Update UserMaster set UserId = '" + gvUserMaster.CurrentRow.Cells["UserId"].Value + "', Password = '" + gvUserMaster.CurrentRow.Cells["Password"].Value + "', Status = '" + gvUserMaster.CurrentRow.Cells["Status"].Value + "', FirstName = '" + gvUserMaster.CurrentRow.Cells["FirstName"].Value + "', MiddleName = '" + gvUserMaster.CurrentRow.Cells["MiddleName"].Value + "', LastName = '" + gvUserMaster.CurrentRow.Cells["LastName"].Value + "', UserRoleNo = " + gvUserMaster.CurrentRow.Cells["UserRoleNo"].Value + " where UserNo = " + gvUserMaster.CurrentRow.Cells["UserNo"].Value + "");
                    CrudeNavigationClass.CrudeInsert(str, "Update UserRights set FirstName = '" + gvUserMaster.CurrentRow.Cells["FirstName"].Value + "' where UserNo = " + gvUserMaster.CurrentRow.Cells["UserNo"].Value + "");
                    dtUMaster.AcceptChanges();
                    MessageBox.Show("Information Saved","Saved...",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            { }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvUserMaster.Rows.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("Are You Sure to Delete UserNo [" + gvUserMaster.CurrentRow.Cells["UserNo"].Value + "] from List", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        CrudeNavigationClass.CrudeInsert(str, "Delete from UserMaster where UserNo = " + gvUserMaster.CurrentRow.Cells["UserNo"].Value + "");
                        dtUMaster.Rows[gvUserMaster.CurrentRow.Index].Delete();
                    }
                }
            }
            catch (Exception)
            { }
        }

        private void frmUserMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            udfExit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            udfExit();
        }

        private void udfExit()
        {
            try
            {
                //if (gvUserMaster.Rows.Count > 0)
                {
                    //DialogResult dr = MessageBox.Show("Do You Want to Save Changes", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (dr == DialogResult.Yes)
                    //{
                    //    foreach (DataRow row in dtUMaster.Rows)
                    //    {
                    //        CrudeNavigationClass.CrudeInsert(str, "Update UserMaster set UserId = '" + row["UserId"] + "', Password = '" + row["Password"] + "', Status = '" + row["Status"] + "', FirstName = '" + row["FirstName"] + "', MiddleName = '" + row["MiddleName"] + "', LastName = '" + row["LastName"] + "',CreationDate = '" + row["CreationDate"] + "', UserRoleNo = " + row["UserRoleNo"] + " where UserNo = " + row["UserNo"] + "");
                    //        dtUMaster.AcceptChanges();
                    //        MessageBox.Show("Information Updated");
                    //    }
                    //}
                    this.Dispose();
                }
            }
            catch (Exception)
            { }

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvUserMaster.Rows.Count > 0)
                {
                    gvUserMaster.CurrentCell = gvUserMaster.Rows[0].Cells["UserNo"];
                }
            }
            catch (Exception)
            { }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvUserMaster.Rows.Count > 0 && gvUserMaster.CurrentRow.Index != 0)
                {
                    gvUserMaster.CurrentCell = gvUserMaster.Rows[gvUserMaster.CurrentRow.Index - 1].Cells["UserNo"];
                }
            }
            catch (Exception)
            { }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvUserMaster.Rows.Count > 0 && gvUserMaster.CurrentRow.Index != gvUserMaster.Rows.Count - 1)
                {
                    gvUserMaster.CurrentCell = gvUserMaster.Rows[gvUserMaster.CurrentRow.Index + 1].Cells["UserNo"];
                }
            }
            catch (Exception)
            { }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvUserMaster.Rows.Count > 0)
                {
                    gvUserMaster.CurrentCell = gvUserMaster.Rows[gvUserMaster.Rows.Count - 1].Cells["UserNo"];
                }
            }
            catch (Exception)
            { }
        }

        private void cbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtUMaster.Rows.Count > 0)
                {
                    dtUMaster.DefaultView.RowFilter = "Convert(" + cbSearchBy.SelectedItem + ",System.String) Like '" + cbSearch.Text + "%'";
                    if (gvUserMaster.Rows.Count == 0)
                    {
                        ToolTip tt = new ToolTip();
                        tt.IsBalloon = true;
                        tt.SetToolTip(cbSearch, "No User With '" + cbSearchBy.SelectedItem + " = " + cbSearch.Text + "' Exist");
                    }
                }
            }
            catch (Exception) 
            { }
        }

        private void gvUserMaster_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void gvUserMaster_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (gvUserMaster.CurrentCell == gvUserMaster.CurrentRow.Cells["UserRoleNo"])
                {
                    comboControl = e.Control as DataGridViewComboBoxEditingControl;
                    comboControl.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboControl.AutoCompleteSource = AutoCompleteSource.ListItems;
                    comboControl.KeyPress += new KeyPressEventHandler(comboControl_KeyPress);
                }
                else if (gvUserMaster.CurrentCell == gvUserMaster.CurrentRow.Cells["UserId"] || gvUserMaster.CurrentCell == gvUserMaster.CurrentRow.Cells["Password"] || gvUserMaster.CurrentCell == gvUserMaster.CurrentRow.Cells["FirstName"] || gvUserMaster.CurrentCell == gvUserMaster.CurrentRow.Cells["MiddleName"] || gvUserMaster.CurrentCell == gvUserMaster.CurrentRow.Cells["LastName"])
                {
                    TextBox textcontrol = e.Control as DataGridViewTextBoxEditingControl;
                    textcontrol.MaxLength = 20;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }

        void comboControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            { e.Handled = true; }
        }
        private void gvUserMaster_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            { }
            catch (Exception)
            { }
        }

        private void gvUserMaster_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (comboControl != null)
            {
                comboControl.KeyPress -= new KeyPressEventHandler(comboControl_KeyPress);
                //comboControl.Dispose();
            }
        }

        private void gvUserMaster_Layout(object sender, LayoutEventArgs e)
        {
            gvUserMaster.RowTemplate.Height = 25;
        }

        private void gvUserMaster_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gvUserMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvUserMaster.Columns[e.ColumnIndex].Name == "UserRoleNo")
            {
                gvUserMaster.SelectionMode = DataGridViewSelectionMode.CellSelect;
                gvUserMaster.BeginEdit(true);
                DataGridViewComboBoxEditingControl cell = (DataGridViewComboBoxEditingControl)gvUserMaster.EditingControl;
                cell.DroppedDown = true;

            }
        }

       
        

    }
}
