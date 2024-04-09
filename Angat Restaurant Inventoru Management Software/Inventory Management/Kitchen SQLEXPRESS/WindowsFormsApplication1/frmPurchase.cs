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
    public partial class frmPurchase : CustomForm
    {
        DataSet dsPurchase;
        DataGridViewComboBoxEditingControl comboControl;
        DataGridViewTextBoxEditingControl textcontrol;
        string str;
        CrudeNavigationClass cnc;

        public frmPurchase()
        {
            InitializeComponent();
            str = ConfigurationManager.ConnectionStrings["salogin"].ToString();
            CustomUI.customiseMenuForm(this);
        }

        private void udfCustomiseControls()
        {
            this.BackColor = Color.White;
            this.MaximizeBox = false;
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            cnc = new CrudeNavigationClass();
            dsPurchase = new DataSet();
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "dd-MM-yyyy  hh:MM:ss";

            txtTotalAmount.ReadOnly = true;
            txtDisc.ReadOnly = true;

            txtDisc.TabStop = false;
            txtTotalAmount.TabStop = false;
            btnDelete.TabStop = false;
            btnExit.TabStop = false;
            btnFirst.TabStop = false;
            btnPervious.TabStop = false;
            btnLast.TabStop = false;
            txtTaxpercent.TabStop = false;

            txtTaxpercent.ReadOnly = true;

            

            cbPInvoiceNo.MaxLength = 10;
            cbPNo.MaxLength = 7;
            udfTaxMaster();
            udfSupplierMaster();
            udfPurchaseBill();
            udfItemMaster();
            udfPurchaseMaster();
            udfgvPurchaseMaster();

            cbTaxGroupNo.SelectedIndex = 3;
            groupBox2.Enabled = false;

            cbType.Items.Add("Percent");
            cbType.Items.Add("Rs");
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.SelectedIndex = 0;
        }

        private void udfPurchaseBill()
        {
            try
            {
                if (dsPurchase.Tables.Contains("PurchaseBill") == true)
                {
                    dsPurchase.Tables.Remove("PurchaseBill");
                    dtpDate.DataBindings.Clear();
                    cbSupplierNo.DataBindings.Clear();
                    txtDisc.DataBindings.Clear();
                    cbTaxGroupNo.DataBindings.Clear();
                }
                dsPurchase.Tables.Add("PurchaseBill");
                CrudeNavigationClass.FillTable(str, "Select PNo, PInvoiceNo, SupplierNo, Date, Discount, TaxGroupNo from PurchaseBill order by PNo desc ", dsPurchase.Tables["PurchaseBill"]);

                dsPurchase.Tables["PurchaseBill"].DefaultView.Sort = "PNo desc";
                dtpDate.DataBindings.Add("Value", dsPurchase.Tables["PurchaseBill"].DefaultView, "Date");

                cbPNo.DisplayMember = "PNo";
                cbPNo.ValueMember = "PNo";
                cbPNo.DataSource = dsPurchase.Tables["PurchaseBill"].DefaultView;

                cbPInvoiceNo.DisplayMember = "PInvoiceNo";
                cbPInvoiceNo.ValueMember = "PInvoiceNo";
                cbPInvoiceNo.DataSource = dsPurchase.Tables["PurchaseBill"].DefaultView;

                cbSupplierNo.DataBindings.Add("Text", dsPurchase.Tables["PurchaseBill"].DefaultView, "SupplierNo");
                txtDisc.DataBindings.Add("Text", dsPurchase.Tables["PurchaseBill"].DefaultView, "Discount");
                cbTaxGroupNo.DataBindings.Add("Text", dsPurchase.Tables["PurchaseBill"].DefaultView, "TaxGroupNo");

                //cbTaxGroupNo.

                DataColumn[] dc = new DataColumn[1];
                dc[0] = dsPurchase.Tables["PurchaseBill"].Columns["PNo"];
                //dc[1] = dsPurchase.Tables["PurchaseBill"].Columns["PInvoiceNo"];
                dsPurchase.Tables["PurchaseBill"].PrimaryKey = dc;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void udfSupplierMaster()
        {
            try
            {
                if (dsPurchase.Tables.Contains("SupplierMaster") == true)
                {
                    dsPurchase.Tables.Remove("SupplierMaster");
                }
                dsPurchase.Tables.Add("SupplierMaster");
                CrudeNavigationClass.FillTable(str, "Select SupplierNo, SupplierName from VendorMaster", dsPurchase.Tables["SupplierMaster"]);

                cbSupplierNo.DisplayMember = "SupplierNo";
                cbSupplierNo.ValueMember = "SupplierNo";
                cbSupplierNo.DataSource = dsPurchase.Tables["SupplierMaster"];
                cbSupplierNo.DropDownStyle = ComboBoxStyle.DropDown;
                cbSupplierNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbSupplierNo.AutoCompleteSource = AutoCompleteSource.ListItems;

                CbSupplierName.DisplayMember = "SupplierName";
                CbSupplierName.ValueMember = "SuplierNo";
                CbSupplierName.DataSource = dsPurchase.Tables["SupplierMaster"];
                CbSupplierName.DropDownStyle = ComboBoxStyle.DropDown;
                CbSupplierName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CbSupplierName.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void udfItemMaster()
        {
            try
            {
                if (dsPurchase.Tables.Contains("StockMaster") == true)
                {
                    dsPurchase.Tables.Remove("StockMaster");
                }
                dsPurchase.Tables.Add("StockMaster");
                CrudeNavigationClass.FillTable(str, "Select ItemNo, ItemName, Quantity, MRP from StockMaster ", dsPurchase.Tables["StockMaster"]);
                DataColumn[] dc = new DataColumn[1];
                dc[0] = dsPurchase.Tables["StockMaster"].Columns["ItemNo"];
                dsPurchase.Tables["StockMaster"].PrimaryKey = dc;

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void udfPurchaseMaster()
        {
            try
            {
                if (dsPurchase.Tables.Contains("PurchaseMaster") == true)
                { dsPurchase.Tables.Remove("PurchaseMaster"); }
                dsPurchase.Tables.Add("PurchaseMaster");
                if (cbPNo.Text == "")
                { cbPNo.Text = "0"; }
                CrudeNavigationClass.FillTable(str, "Select PNo, SerialNo, ItemNo, ItemName, Quantity, MRP, Total,SupplierNo from PurchaseMaster where PNo = " + cbPNo.Text + "", dsPurchase.Tables["PurchaseMaster"]);

                DataColumn[] dc = new DataColumn[2];
                dc[0] = dsPurchase.Tables["PurchaseMaster"].Columns["PNo"];
                dc[1] = dsPurchase.Tables["PurchaseMaster"].Columns["SerialNo"];
                dsPurchase.Tables["PurchaseMaster"].PrimaryKey = dc;

                udfTotalAmount();
            }
            catch (Exception exp)
            { MessageBox.Show(exp.Message); }
        }

        private void udfTaxMaster()
        {
            try
            {
                dsPurchase.Tables.Add("TaxGroupMaster");
                CrudeNavigationClass.FillTable(str, "Select TaxGroupNo, TaxGroupName from TaxGroupMaster", dsPurchase.Tables["TaxGroupMaster"]);
                cbTaxGroupNo.DisplayMember = "TaxGroupNo";
                cbTaxGroupNo.ValueMember = "TaxGroupNo";
                cbTaxGroupNo.DataSource = dsPurchase.Tables["TaxGroupMaster"];
                cbTaxGroupNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbTaxGroupNo.AutoCompleteSource = AutoCompleteSource.ListItems;

                cbTaxGroupName.DisplayMember = "TaxGroupName";
                cbTaxGroupName.ValueMember = "TaxGroupNo";
                cbTaxGroupName.DataSource = dsPurchase.Tables["TaxGroupMaster"];
                cbTaxGroupName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbTaxGroupName.AutoCompleteSource = AutoCompleteSource.ListItems;

                dsPurchase.Tables["TaxGroupMaster"].Columns.Add("Percent");
                int[] percent = new int[4] { 15, 5, 0, 0 };
                for (int i = 0; i <= percent.Length - 1; i++)
                {
                    dsPurchase.Tables["TaxGroupMaster"].Rows[i]["Percent"] = percent[i];
                    dsPurchase.Tables["TaxGroupMaster"].AcceptChanges();
                }
                txtTaxpercent.DataBindings.Add("Text", dsPurchase.Tables["TaxGroupMaster"], "Percent");
            }
            catch (Exception)
            { }
        }

        private void udfgvPurchaseMaster()
        {
            try
            {
                string[,] Name = new string[10, 2] { { "ItemNo", "No" }, { "ItemName", "Item" }, { "CategoryNo", "CategoryNo" }, { "Barcode", "Barcode" }, { "Quantity", "Quantity" }, { "MRP", "MRP" }, { "Total", "Total" }, { "SerialNo", "SerialNo" }, { "PNo", "PNo" }, { "IsSelected", "Select" } };
                bool[] Readonly = new bool[10] { false, false, false, false, false, false, true, true, true, false };
                int[] fillweight = new int[10] { 10, 35, 10, 15, 15, 15, 20, 10, 10, 5 };

                //CrudeNavigationClass.DGVCheckBoxColumn(Name, fillweight, Name, gvPurchaseMaster, 9, 9);
                CrudeNavigationClass.DGVTextBoxColumn(Name, fillweight, Name, Readonly, gvPurchaseMaster, 7, 8);
                gvPurchaseMaster.Columns["SerialNo"].Visible = false;
                gvPurchaseMaster.Columns["PNo"].Visible = false;

                CrudeNavigationClass.DGVComboBoxColumn(Name, "ItemNo", "ItemNo", fillweight, Name, gvPurchaseMaster, 0, 0, dsPurchase.Tables["StockMaster"]);
                CrudeNavigationClass.DGVComboBoxColumn(Name, "ItemName", "ItemNo", fillweight, Name, gvPurchaseMaster, 1, 1, dsPurchase.Tables["StockMaster"]);
                CrudeNavigationClass.DGVTextBoxColumn(Name, fillweight, Name, Readonly, gvPurchaseMaster, 4, 6);
                CrudeNavigationClass.DGVValidation(gvPurchaseMaster);

                gvPurchaseMaster.DataSource = dsPurchase.Tables["PurchaseMaster"];

                foreach (DataGridViewColumn c in gvPurchaseMaster.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Cambria", 17F, GraphicsUnit.World);
                }
            }
            catch (Exception exp)
            { MessageBox.Show(exp.Message); }
        }

        private void gvPurchaseMaster_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((gvPurchaseMaster.CurrentCell == gvPurchaseMaster.CurrentRow.Cells["ItemNo"] && gvPurchaseMaster.CurrentRow.Cells["ItemNo"].Value.ToString() != "") || (gvPurchaseMaster.CurrentCell == gvPurchaseMaster.CurrentRow.Cells["ItemName"] && gvPurchaseMaster.CurrentRow.Cells["ItemName"].Value.ToString() != ""))
                {
                    object[] pkItemMaster = new object[1] { gvPurchaseMaster.CurrentCell.Value.ToString() };

                    DataRow dr = dsPurchase.Tables["PurchaseMaster"].Rows[gvPurchaseMaster.CurrentRow.Index];
                    if (gvPurchaseMaster.CurrentRow.Cells["Quantity"].Value.ToString() != "")
                    {
                        string[] qty = new string[1];
                        CrudeNavigationClass.FillNArray(str, "Select Quantity from StockMaster where ItemNo = (Select ItemNo from PurchaseMaster where PNo = " + dr["PNo"] + " and SerialNo = " + dr["SerialNo"] + ") ", qty, 1);
                        string setqty = Convert.ToString(Math.Round(Convert.ToDouble(qty[0]) + Convert.ToDouble(dr["Quantity"]),2));
                        CrudeNavigationClass.CrudeSelect(str, "Update StockMaster set Quantity = " + setqty + " where ItemNo = (Select ItemNo from PurchaseMaster where PNo = " + dr["PNo"] + " and SerialNo = " + dr["SerialNo"] + ") ");
                    }
                    //dr["IsSelected"] = false;
                    dr["ItemNo"] = dsPurchase.Tables["StockMaster"].Rows.Find(pkItemMaster)["ItemNo"].ToString();
                    //dr["CategoryNo"] = dsPurchase.Tables["ItemMaster"].Rows.Find(pkItemMaster)["CategoryNo"].ToString(); 
                    dr["ItemName"] = dsPurchase.Tables["StockMaster"].Rows.Find(pkItemMaster)["ItemName"].ToString();
                    dr["Quantity"] = 0;
                    dr["MRP"] = dsPurchase.Tables["StockMaster"].Rows.Find(pkItemMaster)["MRP"].ToString();
                    dr["Total"] = 0;

                    CrudeNavigationClass.CrudeSelect(str, "Update PurchaseMaster set ItemNo = '" + dr["ItemNo"] + "', ItemName = '" + dr["ItemName"] + "', Quantity = " + dr["Quantity"] + ", MRP = " + dr["MRP"] + ", Total = " + dr["Total"] + ",Date='"+ dtpDate.Value.Date.Year+"-"+dtpDate.Value.Date.Month +"-"+dtpDate.Value.Date.Day +"', IsSelected = 'false' where PNo = " + dr["PNo"] + " and SerialNo = " + dr["SerialNo"] + "");
                    dsPurchase.Tables["PurchaseMaster"].AcceptChanges();
                    udfTotalAmount();// Calculate TotalAmount
                    gvPurchaseMaster.CurrentRow.Cells["Quantity"].Selected = true;
                }

                else if (gvPurchaseMaster.CurrentCell == gvPurchaseMaster.CurrentRow.Cells["Quantity"] || gvPurchaseMaster.CurrentCell == gvPurchaseMaster.CurrentRow.Cells["MRP"])
                {
                    if (gvPurchaseMaster.CurrentRow.Cells["Quantity"].Value.ToString() == "" || gvPurchaseMaster.CurrentRow.Cells["MRP"].Value.ToString() == "")
                    {
                        dsPurchase.Tables["PurchaseMaster"].RejectChanges();
                    }
                    else
                    {
                        DataRow dr = dsPurchase.Tables["PurchaseMaster"].Rows[gvPurchaseMaster.CurrentRow.Index];
                        dr["Quantity"] = gvPurchaseMaster.CurrentRow.Cells["Quantity"].Value.ToString();
                        dr["MRP"] = gvPurchaseMaster.CurrentRow.Cells["MRP"].Value.ToString();
                        dr["Total"] = Convert.ToDouble(gvPurchaseMaster.CurrentRow.Cells["MRP"].Value) * Convert.ToDouble(gvPurchaseMaster.CurrentRow.Cells["Quantity"].Value);

                        // Select the Old Quantity from PurchaseMaster
                        //if (gvPurchaseMaster.CurrentRow.Cells["IsSelected"].Value.ToString() == "True")// Update Quantity if IsSelected is True
                        {
                            string[] Oldqty = new string[1];
                            string[] Stock = new string[1];
                            CrudeNavigationClass.FillNArray(str, "Select Quantity from PurchaseMaster where SerialNo = " + dr["SerialNo"] + " and PNo = " + dr["PNo"] + " ", Oldqty, 1);
                            CrudeNavigationClass.FillNArray(str, "Select Quantity from StockMaster where ItemNo = '" + dr["ItemNo"] + "'", Stock, 1);
                            string Newqty = Convert.ToString(Math.Round(Convert.ToDouble(Stock[0]) - Convert.ToDouble(Oldqty[0]) + Convert.ToDouble(dr["Quantity"]), 2));
                            // Update Quantity in ItemMaster
                            CrudeNavigationClass.CrudeSelect(str, "Update StockMaster set Quantity = " + Newqty + " where ItemNo = '" + dr["ItemNo"] + "'");

                        }

                        CrudeNavigationClass.CrudeSelect(str, "Update PurchaseMaster set Quantity = " + dr["Quantity"] + ", MRP = " + dr["MRP"] + ", Total = " + dr["Total"] + " where SerialNo = " + dr["SerialNo"] + " and PNo = " + dr["PNo"] + " ");
                        dsPurchase.Tables["PurchaseMaster"].AcceptChanges();
                        udfTotalAmount();// Calculate TotalAmount
                        gvPurchaseMaster.CurrentRow.Cells["Quantity"].Selected = true;
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                if (textcontrol != null)
                { textcontrol.KeyPress -= new KeyPressEventHandler(textcontrol_KeyPress); }
                //else if (comboControl != null)
                //{ comboControl.KeyPress -= new KeyPressEventHandler(comboControl_KeyPress); }

            }
        }

        private void gvPurchaseMaster_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (gvPurchaseMaster.CurrentCell == gvPurchaseMaster.CurrentRow.Cells["ItemNo"])
                {
                    comboControl = e.Control as DataGridViewComboBoxEditingControl;
                    comboControl.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboControl.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
                else if (gvPurchaseMaster.CurrentCell == gvPurchaseMaster.CurrentRow.Cells["ItemName"])
                {
                    comboControl = e.Control as DataGridViewComboBoxEditingControl;
                    comboControl.DropDownStyle = ComboBoxStyle.DropDown;
                    comboControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboControl.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
                else if (gvPurchaseMaster.CurrentCell == gvPurchaseMaster.CurrentRow.Cells["Quantity"] || gvPurchaseMaster.CurrentCell == gvPurchaseMaster.CurrentRow.Cells["MRP"])
                {
                    TextBox textcontrol = e.Control as DataGridViewTextBoxEditingControl;
                    if (gvPurchaseMaster.CurrentCell == gvPurchaseMaster.CurrentRow.Cells["Quantity"])
                    { textcontrol.MaxLength = 8; }
                    if (gvPurchaseMaster.CurrentCell == gvPurchaseMaster.CurrentRow.Cells["MRP"])
                    { textcontrol.MaxLength = 8; }
                    textcontrol.KeyPress += new KeyPressEventHandler(textcontrol_KeyPress);
                }
            }
            catch (Exception)
            { }
        }

        void textcontrol_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            //{ e.Handled = true; }
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

        private void gvPurchaseMaster_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            { }
            catch (Exception)
            { }
        }

        private void gvPurchaseMaster_Layout(object sender, LayoutEventArgs e)
        {
            try
            {
                gvPurchaseMaster.RowTemplate.Height = 25;
            }
            catch (Exception)
            { }
        }
        private void udfAddrow(int SerialNo)
        {
            try
            {
                DataRow dr = dsPurchase.Tables["PurchaseMaster"].NewRow();
                dr["PNo"] = cbPNo.Text;
                dr["SerialNo"] = SerialNo;
                dr["SupplierNo"] = cbSupplierNo.Text;
                //dr["IsSelected"] = false;
                dsPurchase.Tables["PurchaseMaster"].Rows.Add(dr);

                CrudeNavigationClass.CrudeSelect(str, "Insert into PurchaseMaster (PNo, SerialNo,SupplierNo,Date, IsSelected) Values (" + dr["PNo"] + ", " + dr["SerialNo"] + "," + dr["SupplierNo"] + ",'" + dtpDate.Value.Date.Year + "-" + dtpDate.Value.Date.Month + "-" + dtpDate.Value.Date.Day + "', 'False')");
                dsPurchase.Tables["PurchaseMaster"].AcceptChanges();
                gvPurchaseMaster.CurrentRow.Cells["ItemNo"].Selected = true;
            }
            catch (Exception)
            { }
        }

        private void gvPurchaseMaster_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (gvPurchaseMaster.CurrentCell == gvPurchaseMaster.CurrentRow.Cells["Quantity"] && gvPurchaseMaster.CurrentRow.Cells["Quantity"].Value.ToString() != "" && gvPurchaseMaster.CurrentRow.Cells["ItemNo"].Value.ToString() != "" && gvPurchaseMaster.CurrentRow.Index == gvPurchaseMaster.Rows.Count - 1)
                    {
                        udfAddrow(Convert.ToInt32(dsPurchase.Tables["PurchaseMaster"].Rows[dsPurchase.Tables["PurchaseMaster"].Rows.Count - 1]["SerialNo"]) + 1);
                    }
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    udfDeleteRow();
                }
            }
            catch (Exception)
            { }
        }

        private void cbPNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //udfCancelBill();// Delete the Bill information if another Bill is Selected
            udfLoadPM();
            txtDiscount.Text = "";
            udfTotalAmount(); // Calculate Total Amount
        }

        private void cbPInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbPNo.SelectedIndex = cbPInvoiceNo.SelectedIndex ;
        }
        private void udfLoadPM()
        {
            try
            {
                dsPurchase.Tables["PurchaseMaster"].Rows.Clear();
                dsPurchase.Tables["PurchaseMaster"].Merge(CrudeNavigationClass.GetData(str, "Select PNo, SerialNo, ItemNo, ItemName, Quantity, MRP, Total, IsSelected from PurchaseMaster where PNo = " + cbPNo.Text + ""));
            }
            catch (Exception)
            { }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                dtpDate.Value = System.DateTime.Now;
                if (dsPurchase.Tables["PurchaseBill"].Rows.Count > 0 && cbPInvoiceNo.Text != "")
                {
                    cbPNo.Text = Convert.ToString(Convert.ToDouble(dsPurchase.Tables["PurchaseBill"].DefaultView[0]["PNo"]) + 1);
                    //cbPNo.Text = Convert.ToString(Convert.ToDouble(dsPurchase.Tables["PurchaseBill"].Rows[dsPurchase.Tables["PurchaseBill"].Rows.Count - 1]["PNo"]) + 1);
                    dsPurchase.Tables["PurchaseMaster"].Rows.Clear();
                    txtTotalAmount.Text = "0";
                    //cbPInvoiceNo.Text = "";
                    //cbPInvoiceNo.Focus();
                }
                else if (dsPurchase.Tables["PurchaseBill"].Rows.Count == 0)
                {
                    cbPNo.Text = "1";
                    //cbPInvoiceNo.Text = "";
                    //cbPInvoiceNo.Focus();
                }
                //if (cbPInvoiceNo.Text != "" && cbPNo.Text != "")
                //{
                //    //object[] PKPurchaseBill = new object[2] { cbPNo.Text, cbPInvoiceNo.Text };
                //    object[] PKPurchaseBill = new object[1] { cbPNo.Text };
                //    //if (dsPurchase.Tables["PurchaseBill"].Rows.Contains(PKPurchaseBill) == false && cbSupplierNo.SelectedIndex > -1)
                //    {
                //        //cbTaxGroupName.SelectedIndex = 2;
                //        udfAddinPurchaseBill();
                //        cbPNo.SelectedIndex = 0;
                //        dsPurchase.Tables["PurchaseMaster"].Rows.Clear();
                //        udfAddrow(1);// First Row in Purchase Master
                //        gvPurchaseMaster.Focus();
                //        gvPurchaseMaster.CurrentRow.Cells["ItemNo"].Selected = true;
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("Insert PInvoiceNo first");
                //    cbPInvoiceNo.Focus();
                //}
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbPInvoiceNo.Text != "" && cbPNo.Text != "" && cbSupplierNo.Text != "" && gvPurchaseMaster.Rows.Count > 0)
                {
                    //object[] PKPurchaseBill = new object[2] { cbPNo.Text, cbPInvoiceNo.SelectedValue.ToString() };
                    object[] PKPurchaseBill = new object[1] { cbPNo.Text };
                    if (dsPurchase.Tables["PurchaseBill"].Rows.Contains(PKPurchaseBill) == true)// if Entry has been done in Bill
                    {
                        double discount = 0;
                        string FinalAmount = txtTotalAmount.Text;
                        if (txtDiscount.Text != "")
                        {
                            if (cbType.SelectedIndex == 0)// Percentage
                            {
                                discount = Math.Round(Convert.ToDouble(txtTotalAmount.Text) * Convert.ToDouble(txtDiscount.Text) / 100);
                                //FinalAmount = Convert.ToString(Math.Round(Convert.ToDouble(txtTotalAmount.Text) - discount, 2));
                                FinalAmount = Convert.ToString((Convert.ToDouble(txtTotalAmount.Text) - discount));
                            }
                            else if (cbType.SelectedIndex == 1)
                            {
                                discount = Math.Round(Convert.ToDouble(txtDiscount.Text));
                                //FinalAmount = Convert.ToString(Math.Round(Convert.ToDouble(txtTotalAmount.Text) - discount, 2));
                                FinalAmount = Convert.ToString((Convert.ToDouble(txtTotalAmount.Text) - discount));
                            }
                            //txtDiscount.Text = "";
                            txtDisc.Text = discount.ToString();
                        }
                        double Roundoff = 0;
                        if (txtTaxpercent.Text != "0")
                        {
                            FinalAmount = Convert.ToString(Convert.ToDouble(FinalAmount) + ((Convert.ToDouble(FinalAmount) * Convert.ToDouble(txtTaxpercent.Text) / 100)));
                            Roundoff = Convert.ToDouble(FinalAmount) - Math.Round(Convert.ToDouble(FinalAmount));

                        }
                        //txtTaxpercent.Text

                        CrudeNavigationClass.CrudeSelect(str, "Update PurchaseBill  set SupplierNo = " + cbSupplierNo.SelectedValue.ToString() + ", PInvoiceNo = '" + cbPInvoiceNo.Text + "', Date = '" + dtpDate.Value.Year + "-" + dtpDate.Value.Month + "-" + dtpDate.Value.Day + " " + dtpDate.Value.Hour + ":" + dtpDate.Value.Minute + ":" + dtpDate.Value.Second + "', TotalAmount = " + txtTotalAmount.Text + ", Discount = " + discount + ", FinalAmount = " + FinalAmount + ", Settle = 'False', TaxGroupNo = " + cbTaxGroupNo.SelectedValue.ToString() + ", Roundoff = " + Roundoff + " where PNo = " + cbPNo.Text + "");

                        //DataRow dr = dsPurchase.Tables["PurchaseBill"].Rows.Find(PKPurchaseBill);
                        //dr["PInvoiceNo"] = cbPInvoiceNo.Text;
                        //dr["SupplierNo"] = cbSupplierNo.SelectedValue.ToString();
                        //dr["Discount"] = discount;
                        //dr["TaxGroupNo"] = cbTaxGroupNo.SelectedValue.ToString();
                        //dr["Date"] = dtpDate.Value;
                        //dsPurchase.Tables["PurchaseBill"].AcceptChanges();
                        Double pno = Convert.ToDouble(cbPNo.Text);
                        udfPurchaseBill();
                        cbPNo.SelectedValue = pno.ToString();
                        MessageBox.Show("Bill Successfully Created", "Bill Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        udfPrintPurchaseOrder(Convert.ToInt32(cbPNo.Text));
                    }

                }
                else if (cbPInvoiceNo.Text != "" || cbPNo.Text != "" || cbSupplierNo.Text != "" || gvPurchaseMaster.Rows.Count > 0)
                {
                    MessageBox.Show("Field is Empty", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception)
            { }
        }

        private void udfPrintPurchaseOrder(int pno)
        {
            //frmPurchaseOrderBill.pno = pno;
            //frmPurchaseOrderBill fpob = new frmPurchaseOrderBill();
            //fpob.ShowDialog();
            this.Focus();
        }

        private void udfAddinPurchaseBill()
        {
            try
            {
                CrudeNavigationClass.CrudeSelect(str, "Insert into PurchaseBill (PNo, SupplierNo, PInvoiceNo, Date, TotalAmount, Discount, FinalAmount, Settle, TaxGroupNo) Values(" + cbPNo.Text + "," + cbSupplierNo.SelectedValue.ToString() + ",'" + cbPInvoiceNo.Text + "','" + dtpDate.Value.Year + "-" + dtpDate.Value.Month + "-" + dtpDate.Value.Day + " " + dtpDate.Value.Hour + ":" + dtpDate.Value.Minute + ":" + dtpDate.Value.Second + "', 0, 0, 0,'False', " + cbTaxGroupNo.SelectedValue.ToString() + ")");
                DataRow dr = dsPurchase.Tables["PurchaseBill"].NewRow();
                dr["PNo"] = cbPNo.Text;
                dr["SupplierNo"] = cbSupplierNo.SelectedValue.ToString();
                dr["PInvoiceNo"] = cbPInvoiceNo.Text;
                dr["Date"] = dtpDate.Value;
                dr["TaxGroupNo"] = cbTaxGroupNo.SelectedValue.ToString();
                dsPurchase.Tables["PurchaseBill"].Rows.Add(dr);
                dsPurchase.Tables["PurchaseBill"].AcceptChanges();
            }
            catch (Exception)
            { }
        }

        private void udfCancelBill()
        {
            try
            {
                object[] pkPurchaseBill = new object[2] { cbPNo.Text, cbPInvoiceNo.Text };
                if (dsPurchase.Tables["PurchaseBill"].Rows.Contains(pkPurchaseBill) == false && gvPurchaseMaster.Rows.Count > 0)
                {
                    foreach (DataRow dr in dsPurchase.Tables["PurchaseMaster"].Rows)
                    {
                        CrudeNavigationClass.CrudeSelect(str, "Update ItemMaster set Quantity = Quantity - " + dr["Quantity"] + " where ItemNo = '" + dr["ItemNo"] + "'");
                    }
                }
            }
            catch (Exception)
            { }
        }

        private void udfTotalAmount()
        {
            try
            {
                if (dsPurchase.Tables["PurchaseMaster"].Rows.Count > 0)
                {
                    double Total = 0;
                    foreach (DataRow row in dsPurchase.Tables["PurchaseMaster"].Rows)
                    {
                        if (row["Total"].ToString() != "")
                            Total = Total + Convert.ToDouble(row["Total"].ToString());
                    }
                    txtTotalAmount.Text = Convert.ToString(Total);
                }
                else if (dsPurchase.Tables["PurchaseMaster"].Rows.Count == 0)
                {
                    txtTotalAmount.Text = "0";
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(exp.Message);
            }
        }

        private void btnPervious_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbPNo.Items.Count > 0 && cbPNo.SelectedIndex != 0)
                {
                    cbPNo.SelectedIndex = cbPNo.SelectedIndex - 1;
                }
            }
            catch (Exception)
            { }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbPNo.Items.Count > 0 && cbPNo.SelectedIndex != cbPNo.Items.Count - 1)
                {
                    cbPNo.SelectedIndex = cbPNo.SelectedIndex + 1;
                }
            }
            catch (Exception)
            { }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbPNo.Items.Count > 0)
                {
                    cbPNo.SelectedIndex = 0;
                }
            }
            catch (Exception)
            { }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbPNo.Items.Count > 0)
                {
                    cbPNo.SelectedIndex = cbPNo.Items.Count - 1;
                }
            }
            catch (Exception)
            { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            udfDeleteRow();
        }

        private void udfDeleteRow()
        {
            try
            {
                if (gvPurchaseMaster.Rows.Count > 1)
                {
                    if (gvPurchaseMaster.CurrentRow.Cells["Quantity"].Value.ToString() != "")// && gvPurchaseMaster.CurrentRow.Cells["IsSelected"].Value.ToString() == "True")
                    {
                        string[] Qty = new string[1];
                        CrudeNavigationClass.FillNArray(str, "Select Quantity from PurchaseMaster where PNo = " + gvPurchaseMaster.CurrentRow.Cells["PNo"].Value.ToString() + " and SerialNo = " + gvPurchaseMaster.CurrentRow.Cells["SerialNo"].Value.ToString() + "", Qty, 1);
                        string[] stock = new string[1];
                        CrudeNavigationClass.FillNArray(str, "Select Quantity from StockMaster where ItemNo = " + gvPurchaseMaster.CurrentRow.Cells["ItemNo"].Value.ToString() + "", Qty, 1);

                        string Finalstock = Convert.ToString(Math.Round(Convert.ToDouble(stock[0]) - Convert.ToDouble(Qty[0]), 2));

                        CrudeNavigationClass.CrudeSelect(str, "Update StockMaster set Quantity = " + Finalstock + " where ItemNo = " + gvPurchaseMaster.CurrentRow.Cells["ItemNo"].Value.ToString() + "");
                    }
                    CrudeNavigationClass.CrudeSelect(str, "Delete From PurchaseMaster where PNo = " + gvPurchaseMaster.CurrentRow.Cells["PNo"].Value.ToString() + " and SerialNo = " + gvPurchaseMaster.CurrentRow.Cells["SerialNo"].Value.ToString() + "");
                    object[] pkpm = new object[2] { gvPurchaseMaster.CurrentRow.Cells["PNo"].Value.ToString(), gvPurchaseMaster.CurrentRow.Cells["SerialNo"].Value.ToString() };
                    dsPurchase.Tables["PurchaseMaster"].Rows.Find(pkpm).Delete();
                    dsPurchase.Tables["PurchaseMaster"].AcceptChanges();
                }
                else if (gvPurchaseMaster.Rows.Count == 1)
                {
                    MessageBox.Show("You Can't Delete the Bill Permanently.", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            { }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            CrudeNavigationClass.EventHandlerOnlyNum(txtDiscount, e, 4);
        }

        private void gvPurchaseMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (gvPurchaseMaster.CurrentCell == gvPurchaseMaster.CurrentRow.Cells["IsSelected"])// Third Column of Gridview for Purchase = "PInvoiceNo", for Sales = "SInvoiceNo
            //    {
            //        object[] pkpm = new object[2] { gvPurchaseMaster.CurrentRow.Cells["PNo"].Value.ToString(), gvPurchaseMaster.CurrentRow.Cells["SerialNo"].Value.ToString() };
            //        if (gvPurchaseMaster.CurrentRow.Cells["IsSelected"].Value.ToString() == "True")
            //        {
            //            int Qty = cnc.CrudeLoad(str, "Select Quantity from PurchaseMaster where PNo = " + gvPurchaseMaster.CurrentRow.Cells["PNo"].Value.ToString() + " and SerialNo = " + gvPurchaseMaster.CurrentRow.Cells["SerialNo"].Value.ToString() + "");
            //            CrudeNavigationClass.CrudeSelect(str, "Update ItemMaster set Quantity = Quantity - " + Qty + " where Barcode = '" + gvPurchaseMaster.CurrentRow.Cells["Barcode"].Value.ToString() + "'");
            //            CrudeNavigationClass.CrudeSelect(str, "Update PurchaseMaster set IsSelected = 'False' where PNo = " + gvPurchaseMaster.CurrentRow.Cells["PNo"].Value.ToString() + " and SerialNo = " + gvPurchaseMaster.CurrentRow.Cells["SerialNo"].Value.ToString() + "");
            //            dsPurchase.Tables["PurchaseMaster"].Rows.Find(pkpm)["IsSelected"] = false;
            //        }
            //        else if (gvPurchaseMaster.CurrentRow.Cells["IsSelected"].Value.ToString() == "False")
            //        {
            //            int Qty = cnc.CrudeLoad(str, "Select Quantity from PurchaseMaster where PNo = " + gvPurchaseMaster.CurrentRow.Cells["PNo"].Value.ToString() + " and SerialNo = " + gvPurchaseMaster.CurrentRow.Cells["SerialNo"].Value.ToString() + "");
            //            CrudeNavigationClass.CrudeSelect(str, "Update ItemMaster set Quantity = Quantity + " + Qty + " where Barcode = '" + gvPurchaseMaster.CurrentRow.Cells["Barcode"].Value.ToString() + "'");
            //            CrudeNavigationClass.CrudeSelect(str, "Update PurchaseMaster set IsSelected = 'True' where PNo = " + gvPurchaseMaster.CurrentRow.Cells["PNo"].Value.ToString() + " and SerialNo = " + gvPurchaseMaster.CurrentRow.Cells["SerialNo"].Value.ToString() + "");
            //            dsPurchase.Tables["PurchaseMaster"].Rows.Find(pkpm)["IsSelected"] = true;
            //        }
            //        dsPurchase.Tables["PurchaseMaster"].AcceptChanges();
            //    }
            //}
            //catch (Exception)
            //{ }
        }

        private void cbTaxGroupNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTaxGroupNo.SelectedIndex != 2)
            {
                txtTaxpercent.ReadOnly = true;
            }
            else if (cbTaxGroupNo.SelectedIndex == 2)
            {
                txtTaxpercent.ReadOnly = false;
                txtTaxpercent.Focus();
                txtTaxpercent.SelectAll();
            }
        }

        private void txtTaxpercent_Leave(object sender, EventArgs e)
        {
            if (txtTaxpercent.Text == "")
            {
                txtTaxpercent.Text = "0";
            }
        }

        private void txtTaxpercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            CrudeNavigationClass.EventHandlerOnlyNum(txtTaxpercent, e, 2);
        }

        private void cbPInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbPInvoiceNo.Text != "" && cbPNo.Text != "")
                {
                    //object[] PKPurchaseBill = new object[2] { cbPNo.Text, cbPInvoiceNo.Text };
                    object[] PKPurchaseBill = new object[1] { cbPNo.Text };
                    if (dsPurchase.Tables["PurchaseBill"].Rows.Contains(PKPurchaseBill) == false && cbSupplierNo.SelectedIndex > -1)
                    {
                        cbTaxGroupName.SelectedIndex = 2;
                        udfAddinPurchaseBill();
                        if (cbPNo.Items.Count > 0)
                        { cbPNo.SelectedIndex = 0; }
                        dsPurchase.Tables["PurchaseMaster"].Rows.Clear();
                        udfAddrow(1);// First Row in Purchase Master
                        gvPurchaseMaster.Focus();
                        gvPurchaseMaster.CurrentRow.Cells["ItemNo"].Selected = true;
                    }
                    else if (cbSupplierNo.SelectedIndex == -1)
                    {
                        MessageBox.Show("Fill Supplier in SupplierMaster");
                    }
                }
                else
                {
                    MessageBox.Show("Insert PInvoiceNo first");
                    cbPInvoiceNo.Focus();
                }
            }
        }

    }
}
