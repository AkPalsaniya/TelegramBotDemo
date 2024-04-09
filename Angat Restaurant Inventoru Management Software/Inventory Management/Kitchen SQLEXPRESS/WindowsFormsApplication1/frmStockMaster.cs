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
    public partial class frmStockMaster : CustomForm
    {
        string str;
        DataTable dtItemMaster;
        DataTable dtSubC;
        DataView dv;
        DataRow dr;
        static uint Lindex;
        static uint Hindex;
        uint LItemNo;
        uint HItemNo;
        uint dvCount;

        //DataGridViewComboBoxCell cell;
        static string StoredValue;
        DataGridViewTextBoxEditingControl textcontrol;

        public frmStockMaster()
        {
            InitializeComponent();
            str = System.Configuration.ConfigurationManager.ConnectionStrings["salogin"].ToString();
            CustomUI.customiseMenuForm(this);
        }

        
        private void udfItemMaster()
        {
            try
            {
                dtItemMaster = new DataTable();
                //dtItemMaster.Merge(frmRBS.ds.Tables["ItemMaster"]);
                CrudeNavigationClass.FillTable(str, "Select * from StockMaster",dtItemMaster);
                //DataColumn[] dc = new DataColumn[1];
                //dc[0] = dtItemMaster.Columns["ItemName"];
                //dtItemMaster.PrimaryKey = dc;


                dv = new DataView(dtItemMaster);
                if (dv.Count == 0)
                {
                    udfAddNewRow(1);
                }
                else
                {
                    Lindex = 0;
                    Hindex = 9;
                    if (dtItemMaster.Rows.Count > 0)
                    {
                        LItemNo = Convert.ToUInt32(dv[(int)Lindex]["ItemNo"]);
                        HItemNo = Convert.ToUInt32(dv[(int)Hindex]["ItemNo"]);
                        //dtItemMaster.DefaultView.RowFilter = "ItemNo >= " + LItemNo + " and ItemNo <= " + HItemNo + "";
                        dv.RowFilter = "ItemNo >= " + LItemNo + " and ItemNo <= " + HItemNo + "";
                    }
                }
            }
            catch (Exception)
            { }
            finally
            {
                //udfFinalyClouse();
            }
        }

        private void udfFinalyClouse()
        {
            try
            {
                Lindex = 0;
                Hindex = 9;
                if (dtItemMaster.Rows.Count > 0)
                {
                    LItemNo = Convert.ToUInt32(dv[(int)Lindex]["ItemNo"]);
                    HItemNo = Convert.ToUInt32(dv[(int)Hindex]["ItemNo"]);
                    //dtItemMaster.DefaultView.RowFilter = "ItemNo >= " + LItemNo + " and ItemNo <= " + HItemNo + "";
                    dv.RowFilter = "ItemNo >= " + LItemNo + " and ItemNo <= " + HItemNo + "";
                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message, "Error in udfFinallyClouse", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void udfgvItemMaster()
        {
            try
            {
                string[,] Name = new string[7, 2] { { "Status", "Block" }, { "ItemNo", "ItemNo" }, { "ItemName", "ItemName" }, { "MRP", "MRP" }, { "Quantity", "Quantity" },{"MinStock","MinStock"},{"CategoryNo","CategoryNo"} };
                //bool[] Readonly = new bool[6] { true, false, false,false,true, false };
                bool[] Readonly = new bool[7] { false, true, false, false, false, false, false};
                //int[] fillweight = new int[6] { 10, 20, 20, 20, 20, 10};
                int[] fillweight = new int[7] { 5, 5, 30, 10, 10 ,10,20};

                //CrudeNavigationClass.DGVCheckBoxColumn(Name, fillweight, Name, gvItemMaster, 0, 0);
                CrudeNavigationClass.DGVTextBoxColumn(Name, fillweight, Name, Readonly, gvItemMaster, 1, 5);
                CrudeNavigationClass.DGVComboBoxColumn(Name, "CategoryName", "CategoryNo", fillweight, Name, gvItemMaster, 6, 6, dtSubC);
                CrudeNavigationClass.DGVValidation(gvItemMaster);

                foreach (DataGridViewColumn c in gvItemMaster.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Cambria", 15F, GraphicsUnit.World);
                    cbSearchBy.Items.Add(c.HeaderText);
                }
                gvItemMaster.DataSource = dv;

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void gvItemMaster_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            { }
            catch (Exception)
            { }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                dtItemMaster.RejectChanges();
                if (dtItemMaster.Rows.Count > 0)
                {
                    Lindex = 0;
                    Hindex = 9;
                    dv.RowFilter = null;
                    LItemNo = Convert.ToUInt32(dv[(int)Lindex]["ItemNo"]);
                    HItemNo = Convert.ToUInt32(dv[(int)Hindex]["ItemNo"]);
                    //dtItemMaster.DefaultView.RowFilter = "ItemNo >= " + LItemNo + " and ItemNo <= " + HItemNo + "";
                    dv.RowFilter = "ItemNo >= " + LItemNo + " and ItemNo <= " + HItemNo + "";
                }
            }
            catch (Exception)
            { //MessageBox.Show(exp.Message);
                udfFinalyClouse();
            }
            finally
            {

            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                dtItemMaster.RejectChanges();
                if (dtItemMaster.Rows.Count > 0 && Lindex != 0 && Hindex != 9)
                {
                    Lindex = Lindex - 10;
                    Hindex = Hindex - 10;
                    dv.RowFilter = null;
                    LItemNo = Convert.ToUInt32(dv[(int)Lindex]["ItemNo"]);
                    HItemNo = Convert.ToUInt32(dv[(int)Hindex]["ItemNo"]);
                    //dtItemMaster.DefaultView.RowFilter = "ItemNo >= " + LItemNo + " and ItemNo <= " + HItemNo + "";
                    dv.RowFilter = "ItemNo >= " + LItemNo + " and ItemNo <= " + HItemNo + "";
                }
            }
            catch (Exception)
            { udfFinalyClouse(); }
            finally
            {

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                dtItemMaster.RejectChanges();
                dvCount = (uint)dtItemMaster.Rows.Count;
                uint Lastindex = Convert.ToUInt32(Convert.ToString(dvCount).Substring(dvCount.ToString().Length - 1, 1));

                if (dtItemMaster.Rows.Count > 0 && Lindex != dvCount - Lastindex)
                {
                    if (Hindex != dvCount - Lastindex - 1)
                    {
                        Lindex += 10;
                        Hindex += 10;
                    }
                    else if (Hindex == dvCount - Lastindex - 1)
                    {
                        Lindex = dvCount - Lastindex;
                        Hindex = dvCount - 1;
                    }
                    else
                    { }
                    dv.RowFilter = null;
                    LItemNo = Convert.ToUInt32(dv[(int)Lindex]["ItemNo"]);
                    HItemNo = Convert.ToUInt32(dv[(int)Hindex]["ItemNo"]);

                    //dtItemMaster.DefaultView.RowFilter = "ItemNo >= " + LItemNo + " and ItemNo <= " + HItemNo + "";
                    dv.RowFilter = "ItemNo >= " + LItemNo + " and ItemNo <= " + HItemNo + "";
                    Hindex = Lindex + 9;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(exp.Message);
                udfFinalyClouse();
            }
            finally
            {

            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            udfCallLastPage();
        }
        private void udfCallLastPage()
        {
            try
            {
                dtItemMaster.RejectChanges();
                if (dtItemMaster.Rows.Count > 0)
                {
                    dvCount = (uint)dtItemMaster.Rows.Count;

                    uint Lastindex = Convert.ToUInt32(Convert.ToString(dvCount).Substring(dvCount.ToString().Length - 1, 1));
                    Lindex = dvCount - Lastindex;
                    Hindex = dvCount - 1;
                    if (Lindex > Hindex)
                    {
                        Lindex = dvCount - 10;
                        Hindex = Lindex + 9;
                    }

                    dv.RowFilter = null;
                    LItemNo = Convert.ToUInt32(dv[(int)Lindex]["ItemNo"]);
                    HItemNo = Convert.ToUInt32(dv[(int)Hindex]["ItemNo"]);
                    //dtItemMaster.DefaultView.RowFilter = "ItemNo >= " + LItemNo + " and ItemNo <= " + HItemNo + "";
                    dv.RowFilter = "ItemNo >= " + LItemNo;// +" and ItemNo <= " + HItemNo + "";
                    Hindex = Lindex + 9;
                }
            }
            catch (Exception)
            {
                udfFinalyClouse();
            }
            finally
            {

            }
        }

        private void gvItemMaster_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (gvItemMaster.CurrentCell == gvItemMaster.CurrentRow.Cells["MRP"])
                {
                    textcontrol = e.Control as DataGridViewTextBoxEditingControl;
                    StoredValue = textcontrol.Text;
                    textcontrol.MaxLength = 5;
                    textcontrol.KeyPress += new KeyPressEventHandler(textcontrol_KeyPress);
                }
                else if (gvItemMaster.CurrentCell == gvItemMaster.CurrentRow.Cells["ItemName"])
                {
                    textcontrol = e.Control as DataGridViewTextBoxEditingControl;
                    StoredValue = textcontrol.Text;
                    textcontrol.MaxLength = 30;
                    //textcontrol.KeyPress += new KeyPressEventHandler(textcontrol_KeyPress);
                }
            }
            catch (Exception)
            { }
        }

        void textcontrol_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == '.')
                {
                    if (textcontrol.Text.Contains('.') == true)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
            }
            catch (Exception)
            { }
        }

        private void gvItemMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gvItemMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (gvItemMaster.CurrentCell == gvItemMaster.CurrentRow.Cells["Status"] && gvItemMaster.CurrentRow.Cells["Status"].Value.ToString() == "True")
            //    {
            //        CrudeNavigationClass.CrudeInsert(str, "Update ItemMaster set Status = 'false' where ItemNo = " + gvItemMaster.CurrentRow.Cells["ItemNo"].Value + "");
            //        dtItemMaster.AcceptChanges();
            //    }
            //    else if (gvItemMaster.CurrentCell == gvItemMaster.CurrentRow.Cells["Status"] && gvItemMaster.CurrentRow.Cells["Status"].Value.ToString() == "False")
            //    {
            //        CrudeNavigationClass.CrudeInsert(str, "Update ItemMaster set Status = 'true' where ItemNo = " + gvItemMaster.CurrentRow.Cells["ItemNo"].Value + "");
            //        dtItemMaster.AcceptChanges();
            //    }
            //}
            //catch (Exception)
            //{ }
        }

        private void gvItemMaster_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (gvItemMaster.CurrentRow.Index == gvItemMaster.Rows.Count - 1)// && gvItemMaster.CurrentRow.Cells["ItemNo"].Value == dtItemMaster.Rows[dtItemMaster.Rows.Count - 1]["ItemNo"].ToString())
                    {
                        udfAddNewRow(Convert.ToDouble(dtItemMaster.Rows[dtItemMaster.Rows.Count - 1]["ItemNo"]) + 1);
                        //CrudeNavigationClass.CrudeInsert(str, "Insert into ItemMaster (ItemNo, ItemName, Price, SpecialRate, SpecialRate2, SalesTax, ServiceTax,EntryDate, Status) values (" + dr["ItemNo"] + ",'" + dr["ItemName"] + "'," + dr["Price"] + ", " + dr["SpecialRate"] + ", " + dr["SpecialRate2"] + ", " + dr["SalesTax"] + ", " + dr["ServiceTax"] + ", '" + DateTime.Now.Date.Year + "-" + DateTime.Now.Date.Month + "-" + DateTime.Now.Date.Day + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "','False')");
                        //CrudeNavigationClass.CrudeInsert(str, "Insert into ItemMaster (ItemNo, ItemName, Price, SpecialRate, SpecialRate2, SalesTax, ServiceTax ,Status) values (" + dr["ItemNo"] + ",'" + dr["ItemName"] + "'," + dr["Price"] + ", " + dr["SpecialRate"] + ", " + dr["SpecialRate2"] + ", " + dr["SalesTax"] + ", " + dr["ServiceTax"] + ", 'False')");
                        CrudeNavigationClass.CrudeInsert(str, "Insert into StockMaster (ItemNo, ItemName, MRP, Quantity, MinStock, CategoryNo) values (" + dr["ItemNo"] + ",'" + dr["ItemName"] + "'," + dr["MRP"] + "," + dr["Quantity"] + ","+ dr["MinStock"] +","+ dr["CategoryNo"] +")");
                        dtItemMaster.AcceptChanges();

                        udfCallLastPage();
                        gvItemMaster.CurrentRow.Cells["ItemName"].Selected = true;
                        gvItemMaster.BeginEdit(true);

                        ToolTip tt = new ToolTip();
                        tt.IsBalloon = true;
                        tt.SetToolTip(gvItemMaster, "Enter Item Name");
                    }
                    else if (gvItemMaster.CurrentRow.Index == gvItemMaster.Rows.Count - 1 && gvItemMaster.CurrentRow.Cells["ItemNo"].Value != dtItemMaster.Rows[dtItemMaster.Rows.Count - 1]["ItemNo"].ToString())
                    {

                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void udfAddNewRow(double ItemNo)
        {
            try
            {
                dr = dtItemMaster.NewRow();
                dr["ItemNo"] = ItemNo;
                dr["ItemName"] = "Item [" + ItemNo + "]";
                // dr["EntryDate"] = Convert.ToDateTime(DateTime.Now);
                dr["MRP"] = 0.00;
                //dr["SpecialRate"] = 0.00;
                //dr["SpecialRate2"] = 0.00;
                //dr["SalesTax"] = 0.00;
                //dr["ServiceTax"] = 0.00;
                //dr["Status"] = "False";
                dr["Quantity"] = 0;
                dr["MinStock"] = 0;
                dr["CategoryNo"] = "1";
                dtItemMaster.Rows.Add(dr);
            }
            catch (Exception)
            { }
        }

        private void gvItemMaster_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gvItemMaster.CurrentCell == gvItemMaster.CurrentRow.Cells["ItemName"] && gvItemMaster.CurrentRow.Cells["ItemName"].Value.ToString() == "")
                {
                    dtItemMaster.RejectChanges();
                    MessageBox.Show("ItemName Can't be Null", "Null Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //else if (gvItemMaster.CurrentCell == gvItemMaster.CurrentRow.Cells["ItemName"] && dtItemMaster.Rows.Contains(gvItemMaster.CurrentRow.Cells["ItemName"].Value) == true)

                //{
                //    MessageBox.Show("ItemName '" + gvItemMaster.CurrentCell.Value.ToString() + "' Already Exist.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    dtItemMaster.RejectChanges();
                //}

                else if (gvItemMaster.CurrentCell == gvItemMaster.CurrentRow.Cells["MRP"] && gvItemMaster.CurrentRow.Cells["MRP"].Value.ToString() == "")
                {
                    dtItemMaster.RejectChanges();
                    //bool check = true;
                    //foreach (DataRow Row in dtItemMaster.Rows)
                    //{
                    //    if (gvItemMaster.CurrentRow.Cells["ItemName"].Value.ToString() == Row["ItemName"].ToString())
                    //    {
                    //        check = false;

                    //    }
                    //    if (check == false)
                    //    {
                    //        //MessageBox.Show("ItemName '" + gvItemMaster.CurrentCell.Value.ToString() + "' Already Exist.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //        dtItemMaster.RejectChanges();
                    //        break;
                    //    }
                    //}
                }
            }
            catch (Exception)
            {   // MessageBox.Show(exp.Message); 
            }

            finally
            {
                if
                (textcontrol != null)
                { textcontrol.KeyPress -= new KeyPressEventHandler(textcontrol_KeyPress); }
            }
        }

        private void gvItemMaster_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (gvItemMaster.CurrentCell == gvItemMaster.CurrentRow.Cells["MRP"])
                {
                    double i;
                    if (!double.TryParse(Convert.ToString(e.FormattedValue), out i))
                    {
                        //e.Cancel = true;
                        //if(textcontrol.Text == "")
                        {
                            textcontrol.Text = StoredValue;
                            dtItemMaster.RejectChanges();
                            gvItemMaster.CurrentCell.Selected = true;
                            gvItemMaster.Refresh();
                        }
                    }
                    else if (textcontrol != null)
                    {
                        if (textcontrol.Text.Contains('.') == true)
                        {
                            string[] dec = textcontrol.Text.Split('.');
                            if (dec[1].Length > 2)
                            {
                                dec[1] = dec[1].ToString().Remove(2, dec[1].Length - 2);
                            }
                            textcontrol.Text = String.Join(".", dec);
                        }
                    }
                }
            }
            catch (Exception)
            { }
        }

        private void cbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSearchBy.SelectedIndex > -1 && dtItemMaster.Rows.Count > 0)
                {
                    dv.RowFilter = "Convert(" + cbSearchBy.SelectedItem + ",System.String) like '" + cbSearch.Text + "%'";
                    if (gvItemMaster.Rows.Count == 0)
                    {
                        ToolTip tt = new ToolTip();
                        tt.IsBalloon = true;
                        tt.SetToolTip(cbSearch, "No Item Exist Like '" + cbSearch.Text + "'");
                    }
                    else
                    {
                        gvItemMaster.Rows[0].Cells[cbSearchBy.SelectedItem.ToString()].Selected = true;
                    }
                }
            }
            catch (Exception)
            { udfFinalyClouse(); }
        }

        private void lnkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cbSearch.Text = "";
            cbSearchBy.SelectedIndex = -1;
            udfFinalyClouse();
        }

        private void cbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up && gvItemMaster.CurrentRow.Index > -1)
                {
                    gvItemMaster.Rows[gvItemMaster.CurrentRow.Index - 1].Cells[cbSearchBy.SelectedItem.ToString()].Selected = true;
                }
                else if (e.KeyCode == Keys.Down && gvItemMaster.CurrentRow.Index < gvItemMaster.Rows.Count)
                {
                    gvItemMaster.Rows[gvItemMaster.CurrentRow.Index + 1].Cells[cbSearchBy.SelectedItem.ToString()].Selected = true;
                }
            }
            catch (Exception)
            { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvItemMaster.Rows.Count > 0 && gvItemMaster.CurrentRow.Cells["ItemName"].Value.ToString() != "" )//&& gvItemMaster.CurrentRow.Cells["SubcategoryNo"].Value.ToString() != "")
                {
                    foreach (DataRow row in dtItemMaster.Rows)
                    {
                        //CrudeNavigationClass.CrudeInsert(str, "Update ItemMaster set ItemName = '" + gvItemMaster.CurrentRow.Cells["ItemName"].Value + "', Price = " + gvItemMaster.CurrentRow.Cells["Price"].Value + ", SpecialRate = " + gvItemMaster.CurrentRow.Cells["SpecialRate"].Value + ", SpecialRate2 = " + gvItemMaster.CurrentRow.Cells["SpecialRate2"].Value + ", SalesTax = " + gvItemMaster.CurrentRow.Cells["SalesTax"].Value + ", ServiceTax = " + gvItemMaster.CurrentRow.Cells["ServiceTax"].Value + ",EntryDate = '" + gvItemMaster.CurrentRow.Cells["EntryDate"].Value + "', SubcategoryNo = " + gvItemMaster.CurrentRow.Cells["SubcategoryNo"].Value + ", Status = '" + gvItemMaster.CurrentRow.Cells["Status"].Value + "' where ItemNo = " + gvItemMaster.CurrentRow.Cells["ItemNo"].Value + "");
                        //CrudeNavigationClass.CrudeInsert(str, "Update ItemMaster set ItemName = '" + gvItemMaster.CurrentRow.Cells["ItemName"].Value + "', Price = " + gvItemMaster.CurrentRow.Cells["Price"].Value + ", SpecialRate = " + gvItemMaster.CurrentRow.Cells["SpecialRate"].Value + ", SpecialRate2 = " + gvItemMaster.CurrentRow.Cells["SpecialRate2"].Value + ", SalesTax = " + gvItemMaster.CurrentRow.Cells["SalesTax"].Value + ", ServiceTax = " + gvItemMaster.CurrentRow.Cells["ServiceTax"].Value + ", SubcategoryNo = " + gvItemMaster.CurrentRow.Cells["SubcategoryNo"].Value + ", Status = '" + gvItemMaster.CurrentRow.Cells["Status"].Value + "' where ItemNo = " + gvItemMaster.CurrentRow.Cells["ItemNo"].Value + "");
                        //CrudeNavigationClass.CrudeInsert(str, "Update ItemMaster set ItemName = '" + row["ItemName"] + "', Price = " + row["Price"] + ", SpecialRate = " + row["SpecialRate"] + ", SpecialRate2 = " + row["SpecialRate2"] + ", SalesTax = " + row["SalesTax"] + ", ServiceTax = " + row["ServiceTax"] + ", SubcategoryNo = " + row["SubcategoryNo"] + ", Status = '" + row["Status"] + "' where ItemNo = " + row["ItemNo"] + "");
                        CrudeNavigationClass.CrudeInsert(str, "Update StockMaster set ItemName = '" + row["ItemName"] + "', MRP = " + row["MRP"] + ", Quantity="+ row["Quantity"] +", MinStock=" + row["MinStock"] +", CategoryNo="+ row["CategoryNo"] +" where ItemNo = " + row["ItemNo"] + "");
                    }
                    dtItemMaster.AcceptChanges();
                    MessageBox.Show("Item(s) Saved", "Saved...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (gvItemMaster.CurrentRow.Cells["ItemName"].Value == null)
                {
                    MessageBox.Show("Enter ItemName", "ItemName Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gvItemMaster.CurrentRow.Cells["ItemName"].Selected = true;
                }
            }
            catch (Exception)
            { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvItemMaster.Rows.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("Do yo want to remove " + gvItemMaster.CurrentRow.Cells["ItemName"].Value.ToString() + "?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        CrudeNavigationClass.CrudeInsert(str, "Delete from StockMaster where ItemNo = " + gvItemMaster.CurrentRow.Cells["ItemNo"].Value + "");
                        dtItemMaster.Rows.Find(gvItemMaster.CurrentRow.Cells["ItemNo"].Value).Delete();
                        dtItemMaster.AcceptChanges();
                    }
                }
            }
            catch (Exception)
            { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void cbSearchBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (cbSearchBy.SelectedIndex > -1)
            {
                cbSearch.Focus();
            }
        }

        private void gvItemMaster_Layout(object sender, LayoutEventArgs e)
        {
            gvItemMaster.RowTemplate.Height = 25;
        }

        private void frmStockMaster_Load(object sender, EventArgs e)
        {
            cbSearch.DropDownStyle = ComboBoxStyle.Simple;
            cbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
            udfCategory();
            udfItemMaster();
            udfgvItemMaster();
        }

        private void udfCategory()
        {
            try
            {
                dtSubC = new DataTable();
                dtSubC.Merge(CrudeNavigationClass.GetData(str, "Select CategoryNo, CategoryName from CategoryMaster"));
            }
            catch (Exception)
            { }
        }
    }
}
