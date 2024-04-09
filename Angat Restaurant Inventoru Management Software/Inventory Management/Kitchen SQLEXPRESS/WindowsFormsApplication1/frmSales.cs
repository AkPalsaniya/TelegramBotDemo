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
    public partial class frmSales : CustomForm
    {
        DataSet dsSales;
        DataGridViewComboBoxEditingControl comboControl;
        DataGridViewTextBoxEditingControl textcontrol;
        DataGridViewTextBoxEditingControl textcontrol1;
        string str;
        CrudeNavigationClass cnc;
        //public static int varSelectedBill;
        //public static string varPrefix;
        public frmSales()
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

        private void frmSales_Load(object sender, EventArgs e)
        {
            cnc = new CrudeNavigationClass();
            dsSales = new DataSet();
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "dd-MM-yyyy  hh:MM:ss";

            txtTotalAmount.ReadOnly = true;
            txtDisc.ReadOnly = true;
            cbPrefix.MaxLength = 3;
            cbSInvoiceNo.MaxLength = 6;
            btnDelete.TabStop = false;
            btnExit.TabStop = false;
            btnFirst.TabStop = false;
            btnLast.TabStop = false;
            btnNext.TabStop = false;
            btnPervious.TabStop = false;
            txtDisc.TabStop = false;
            txtTotalAmount.TabStop = false;
            txtTaxpercent.TabStop = false;
            txtDiscount.TabStop = false;
            cbType.TabStop = false;
            txtTaxpercent.ReadOnly = true;

            udfTaxMaster();
            udfCustomerMaster();
            udfPrefix();
            udfSalesBill();
            udfItemMaster();
            udfSalesMaster();
            udfgvSalesMaster();

            cbTaxGroupNo.SelectedIndex = 3;
            groupBox2.Enabled = false;
            gbDiscount.Enabled = false;

            cbType.Items.Add("Percent");
            cbType.Items.Add("Rs");
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.SelectedIndex = 0;
        }
        private void udfPrefix()
        {
            try
            {
                //CrudeNavigationClass.fillCombobox(str, "Select Prefix from PrefixMaster where Status = 'False'", cbPrefix);
                //cbPrefix.SelectedIndex = 0;
                cbPrefix.DropDownStyle = ComboBoxStyle.DropDownList;
                cbPrefix.Items.Add("ABC");
                cbPrefix.SelectedIndex = 0;
            }
            catch (Exception)
            { }
        }
        private void udfSalesBill()
        {
            try
            {
                if (dsSales.Tables.Contains("SalesBill") == true)
                {
                    dsSales.Tables.Remove("SalesBill");
                    dtpDate.DataBindings.Clear();
                    cbCustomerNo.DataBindings.Clear();
                    txtDisc.DataBindings.Clear();
                    cbTaxGroupNo.DataBindings.Clear();
                }
                dsSales.Tables.Add("SalesBill");
                CrudeNavigationClass.FillTable(str, "Select Prefix, SInvoiceNo, CustomerNo, Date, Discount, TaxGroupNo from SalesBill where Prefix = '" + cbPrefix.Text + "' order by SInvoiceNo desc ", dsSales.Tables["SalesBill"]);

                dtpDate.DataBindings.Add("Value", dsSales.Tables["SalesBill"].DefaultView, "Date");

                dsSales.Tables["SalesBill"].DefaultView.Sort = "SInvoiceNo desc";

                cbSInvoiceNo.DisplayMember = "SInvoiceNo";
                cbSInvoiceNo.ValueMember = "SInvoiceNo";
                cbSInvoiceNo.DataSource = dsSales.Tables["SalesBill"].DefaultView;

                cbCustomerNo.DataBindings.Add("Text", dsSales.Tables["SalesBill"].DefaultView, "CustomerNo");
                txtDisc.DataBindings.Add("Text", dsSales.Tables["SalesBill"].DefaultView, "Discount");
                cbTaxGroupNo.DataBindings.Add("Text", dsSales.Tables["SalesBill"].DefaultView, "TaxGroupNo");

                DataColumn[] dc = new DataColumn[2];
                dc[0] = dsSales.Tables["SalesBill"].Columns["Prefix"];
                dc[1] = dsSales.Tables["SalesBill"].Columns["SInvoiceNo"];
                dsSales.Tables["SalesBill"].PrimaryKey = dc;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void udfCustomerMaster()
        {
            try
            {
                if (dsSales.Tables.Contains("CustomerMaster") == true)
                { dsSales.Tables.Remove("CustomerMaster"); }
                dsSales.Tables.Add("CustomerMaster");

                CrudeNavigationClass.FillTable(str, "Select CustomerCode 'CustomerNo', CustomerName from CustomerMaster", dsSales.Tables["CustomerMaster"]);
                //DataRow dr = dsSales.Tables["CustomerMaster"].NewRow();
                //dr["CustomerNo"] = 1;
                //dr["CustomerName"] = "NIL";
                //dsSales.Tables["CustomerMaster"].Rows.Add(dr);
                //dsSales.Tables["CustomerMaster"].AcceptChanges();

                cbCustomerNo.DisplayMember = "CustomerNo";
                cbCustomerNo.ValueMember = "CustomerNo";
                cbCustomerNo.DataSource = dsSales.Tables["CustomerMaster"];
                cbCustomerNo.DropDownStyle = ComboBoxStyle.DropDown;
                cbCustomerNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbCustomerNo.AutoCompleteSource = AutoCompleteSource.ListItems;

                CbCustomerName.DisplayMember = "CustomerName";
                CbCustomerName.ValueMember = "CustomerNo";
                CbCustomerName.DataSource = dsSales.Tables["CustomerMaster"];
                CbCustomerName.DropDownStyle = ComboBoxStyle.DropDown;
                CbCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CbCustomerName.AutoCompleteSource = AutoCompleteSource.ListItems;
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
                if (dsSales.Tables.Contains("StockMaster") == true)
                { dsSales.Tables.Remove("StockMaster"); }
                dsSales.Tables.Add("StockMaster");
                CrudeNavigationClass.FillTable(str, "Select ItemNo, ItemName, Quantity, MRP from StockMaster ", dsSales.Tables["StockMaster"]);
                DataColumn[] dc = new DataColumn[1];
                dc[0] = dsSales.Tables["StockMaster"].Columns["ItemNo"];
                dsSales.Tables["StockMaster"].PrimaryKey = dc;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void udfSalesMaster()
        {
            try
            {
                if (dsSales.Tables.Contains("SalesMaster") == true)
                { dsSales.Tables.Remove("SalesMaster"); }
                dsSales.Tables.Add("SalesMaster");
                if (cbSInvoiceNo.Text == "")
                { cbSInvoiceNo.Text = "0"; }
                CrudeNavigationClass.FillTable(str, "Select Prefix, SInvoiceNo, SerialNo, ItemNo, ItemName, Quantity, MRP, Total from SalesMaster where Prefix = '" + cbPrefix.Text + "' and SInvoiceNo = " + cbSInvoiceNo.Text + "", dsSales.Tables["SalesMaster"]);

                DataColumn[] dc = new DataColumn[3];
                dc[0] = dsSales.Tables["SalesMaster"].Columns["Prefix"];
                dc[1] = dsSales.Tables["SalesMaster"].Columns["SInvoiceNo"];
                dc[2] = dsSales.Tables["SalesMaster"].Columns["SerialNo"];
                dsSales.Tables["SalesMaster"].PrimaryKey = dc;
                udfTotalAmount();
            }
            catch (Exception exp)
            { MessageBox.Show(exp.Message); }
        }
        private void udfTaxMaster()
        {
            try
            {
                dsSales.Tables.Add("TaxGroupMaster");
                CrudeNavigationClass.FillTable(str, "Select TaxGroupNo, TaxGroupName from TaxGroupMaster", dsSales.Tables["TaxGroupMaster"]);
                cbTaxGroupNo.DisplayMember = "TaxGroupNo";
                cbTaxGroupNo.ValueMember = "TaxGroupNo";
                cbTaxGroupNo.DataSource = dsSales.Tables["TaxGroupMaster"];
                cbTaxGroupNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbTaxGroupNo.AutoCompleteSource = AutoCompleteSource.ListItems;

                cbTaxGroupName.DisplayMember = "TaxGroupName";
                cbTaxGroupName.ValueMember = "TaxGroupNo";
                cbTaxGroupName.DataSource = dsSales.Tables["TaxGroupMaster"];
                cbTaxGroupName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbTaxGroupName.AutoCompleteSource = AutoCompleteSource.ListItems;

                dsSales.Tables["TaxGroupMaster"].Columns.Add("Percent");
                int[] percent = new int[4] { 15, 5, 0, 0 };
                for (int i = 0; i <= percent.Length - 1; i++)
                {
                    dsSales.Tables["TaxGroupMaster"].Rows[i]["Percent"] = percent[i];
                    dsSales.Tables["TaxGroupMaster"].AcceptChanges();
                }
                txtTaxpercent.DataBindings.Add("Text", dsSales.Tables["TaxGroupMaster"], "Percent");
            }
            catch (Exception)
            { }
        }

        private void udfgvSalesMaster()
        {
            try
            {
                string[,] Name = new string[10, 2] { { "ItemNo", "No" }, { "ItemName", "Item" }, { "CategoryNo", "CategoryNo" }, { "Barcode", "Barcode" }, { "Quantity", "Quantity" }, { "MRP", "MRP" }, { "Total", "Total" }, { "SerialNo", "SerialNo" }, { "Prefix", "Prefix" }, { "SInvoiceNo", "SInvoiceNo" } };
                bool[] Readonly = new bool[10] { false, false, false, false, false, false, true, true, true, true };
                int[] fillweight = new int[10] { 10, 35, 10, 15, 15, 15, 20, 10, 10, 10 };
                CrudeNavigationClass.DGVTextBoxColumn(Name, fillweight, Name, Readonly, gvSalesMaster, 7, 9);
                gvSalesMaster.Columns["SerialNo"].Visible = false;
                gvSalesMaster.Columns["Prefix"].Visible = false;
                gvSalesMaster.Columns["SInvoiceNo"].Visible = false;
                CrudeNavigationClass.DGVComboBoxColumn(Name, "ItemNo", "ItemNo", fillweight, Name, gvSalesMaster, 0, 0, dsSales.Tables["StockMaster"]);
                CrudeNavigationClass.DGVComboBoxColumn(Name, "ItemName", "ItemNo", fillweight, Name, gvSalesMaster, 1, 1, dsSales.Tables["StockMaster"]);
                CrudeNavigationClass.DGVTextBoxColumn(Name, fillweight, Name, Readonly, gvSalesMaster, 4, 6);
                CrudeNavigationClass.DGVValidation(gvSalesMaster);
                gvSalesMaster.DataSource = dsSales.Tables["SalesMaster"];

                foreach (DataGridViewColumn c in gvSalesMaster.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Cambria", 17F, GraphicsUnit.World);
                }
            }
            catch (Exception exp)
            { MessageBox.Show(exp.Message); }
        }

        void textcontrol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            { e.Handled = true; }
        }

        void textcontrol1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            //{ e.Handled = true; }
            CrudeNavigationClass.EventHandlerFor2DP(textcontrol1, e);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbSInvoiceNo.Text != "" && cbPrefix.Text != "" && cbCustomerNo.Text != "" && gvSalesMaster.Rows.Count > 0)
                {
                    object[] PKSalesBill = new object[2] { cbPrefix.Text, cbSInvoiceNo.Text };
                    if (dsSales.Tables["SalesBill"].Rows.Contains(PKSalesBill) == true)// if Entry has been done in Bill
                    {
                        double discount = 0;
                        string FinalAmount = txtTotalAmount.Text;
                        if (txtDiscount.Text != "")
                        {
                            if (cbType.SelectedIndex == 0)// Percentage
                            {
                                discount = Math.Round(Convert.ToDouble(txtTotalAmount.Text) * Convert.ToDouble(txtDiscount.Text) / 100);
                                FinalAmount = Convert.ToString((Convert.ToDouble(txtTotalAmount.Text) - discount));
                            }
                            else if (cbType.SelectedIndex == 1)
                            {
                                discount = Math.Round(Convert.ToDouble(txtDiscount.Text));
                                FinalAmount = Convert.ToString((Convert.ToDouble(txtTotalAmount.Text) - discount));
                            }
                            //txtDiscount.Text = "";
                            txtDisc.Text = discount.ToString();
                        }

                        double Roundoff = 0;
                        if (txtTaxpercent.Text != "0")
                        {
                            FinalAmount = Convert.ToString(Convert.ToDouble(FinalAmount) + ((Convert.ToDouble(FinalAmount) * Convert.ToDouble(txtTaxpercent.Text) / 100)));
                            double d = Math.Round(Convert.ToDouble(FinalAmount), 2);
                            Roundoff = d - Math.Round(Convert.ToDouble(FinalAmount));
                        }

                        CrudeNavigationClass.CrudeSelect(str, "Update SalesBill  set CustomerNo = " + cbCustomerNo.SelectedValue.ToString() + ", Date = '" + dtpDate.Value.Year + "-" + dtpDate.Value.Month + "-" + dtpDate.Value.Day + " " + dtpDate.Value.Hour + ":" + dtpDate.Value.Minute + ":" + dtpDate.Value.Second + "', TotalAmount = " + txtTotalAmount.Text + ", Discount = " + discount + ", FinalAmount = " + FinalAmount + ", Settle = 'False', TaxGroupNo = " + cbTaxGroupNo.SelectedValue.ToString() + ", Roundoff = " + Roundoff + " where Prefix = '" + cbPrefix.Text + "' and SInvoiceNo = " + cbSInvoiceNo.SelectedValue.ToString() + "");
                        Double SInvoiceno = Convert.ToDouble(cbSInvoiceNo.Text);
                        udfSalesBill();
                        cbSInvoiceNo.SelectedValue = SInvoiceno.ToString();
                        MessageBox.Show("Bill Successfully Created", "Bill Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //DialogResult dr = MessageBox.Show("Do you want to print?", "Bill Stored", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        //if (dr == DialogResult.Yes)
                        //{
                        //    udfbillprint(Convert.ToInt32(cbSInvoiceNo.Text), cbPrefix.Text);
                        //}
                    }
                }
                else if (cbSInvoiceNo.Text != "" || cbPrefix.Text != "" || cbCustomerNo.Text != "" || gvSalesMaster.Rows.Count > 0)
                {
                    MessageBox.Show("Field is Empty", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void udfbillprint(int varBillNo, string varPrefixValue)
        {
            //frmSalesBill.varBillNo = varBillNo;
            //frmSalesBill.varPrefixValue = varPrefixValue;
            //frmSalesBill fsb = new frmSalesBill();
            //fsb.ShowDialog();
            //this.Focus();
        }

        private void udfAddinSalesBill()
        {
            try
            {
                CrudeNavigationClass.CrudeSelect(str, "Insert into SalesBill (prefix, SInvoiceNo, CustomerNo, Date, TotalAmount, Discount, FinalAmount, Settle) Values('" + cbPrefix.Text + "', " + cbSInvoiceNo.Text + "," + cbCustomerNo.SelectedValue.ToString() + ",'" + dtpDate.Value.Year + "-" + dtpDate.Value.Month + "-" + dtpDate.Value.Day + " " + dtpDate.Value.Hour + ":" + dtpDate.Value.Minute + ":" + dtpDate.Value.Second + "', 0, 0, 0,'False')");
                DataRow dr = dsSales.Tables["SalesBill"].NewRow();
                dr["Prefix"] = cbPrefix.Text;
                dr["CustomerNo"] = cbCustomerNo.SelectedValue.ToString();
                dr["SInvoiceNo"] = cbSInvoiceNo.Text;
                dr["Date"] = dtpDate.Value;
                dsSales.Tables["SalesBill"].Rows.Add(dr);
                dsSales.Tables["SalesBill"].AcceptChanges();
            }
            catch (Exception)
            { }
        }

        private void udfCancelBill()
        {
            try
            {
                object[] pkSalesBill = new object[2]{cbPrefix.Text, cbSInvoiceNo.Text};
                if (dsSales.Tables["SalesMaster"].Rows.Contains(pkSalesBill) == false && gvSalesMaster.Rows.Count > 0)
                {
                    foreach (DataRow dr in dsSales.Tables["SalesMaster"].Rows)
                    {
                        CrudeNavigationClass.CrudeSelect(str, "Update ItemMaster set Quantity = Quantity - " + dr["Quantity"] + " where ItemNo = " + dr["ItemNo"] + "");
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
                if (dsSales.Tables["SalesMaster"].Rows.Count > 0)
                {
                    double Total = 0;
                    foreach (DataRow row in dsSales.Tables["SalesMaster"].Rows)
                    {
                        if (row["Total"].ToString() != "")
                            Total = Total + Convert.ToDouble(row["Total"].ToString());
                    }
                    txtTotalAmount.Text = Convert.ToString(Total);
                }
                else if (dsSales.Tables["SalesMaster"].Rows.Count == 0)
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
                if (cbSInvoiceNo.Items.Count > 0 && cbSInvoiceNo.SelectedIndex != 0)
                {
                    cbSInvoiceNo.SelectedIndex = cbSInvoiceNo.SelectedIndex - 1; 
                }
            }
            catch (Exception)
            { }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbSInvoiceNo.Items.Count > 0 && cbSInvoiceNo.SelectedIndex != cbSInvoiceNo.Items.Count - 1)
                {
                    cbSInvoiceNo.SelectedIndex = cbSInvoiceNo.SelectedIndex + 1;
                }
            }
            catch (Exception)
            { }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbSInvoiceNo.Items.Count > 0)
                {
                    cbSInvoiceNo.SelectedIndex = 0;
                }
            }
            catch (Exception)
            { }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbSInvoiceNo.Items.Count > 0)
                {
                    cbSInvoiceNo.SelectedIndex = cbSInvoiceNo.Items.Count - 1;
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
                if (gvSalesMaster.Rows.Count > 1)
                {
                    if (gvSalesMaster.CurrentRow.Cells["Quantity"].Value.ToString() != "")
                    {
                        string[] Qty = new string[1];
                        CrudeNavigationClass.FillNArray(str, "Select Quantity from SalesMaster where Prefix = '" + gvSalesMaster.CurrentRow.Cells["Prefix"].Value.ToString() + "' and SInvoiceNo = " + gvSalesMaster.CurrentRow.Cells["SInvoiceNo"].Value.ToString() + " and SerialNo = " + gvSalesMaster.CurrentRow.Cells["SerialNo"].Value.ToString() + "", Qty, 1);
                        string[] stock = new string[1];
                        CrudeNavigationClass.FillNArray(str, "Select Quantity from StockMaster where ItemNo = " + gvSalesMaster.CurrentRow.Cells["ItemNo"].Value.ToString() + "", stock, 1);

                        string Finalstock = Convert.ToString(Math.Round(Convert.ToDouble(stock[0]) + Convert.ToDouble(Qty[0]), 2));

                        CrudeNavigationClass.CrudeSelect(str, "Update StockMaster set Quantity = " + Finalstock + " where ItemNo = " + gvSalesMaster.CurrentRow.Cells["ItemNo"].Value.ToString() + "");
                    }
                    CrudeNavigationClass.CrudeSelect(str, "Delete From SalesMaster where Prefix = '" + gvSalesMaster.CurrentRow.Cells["Prefix"].Value.ToString() + "' and SInvoiceNo = " + gvSalesMaster.CurrentRow.Cells["SInvoiceNo"].Value.ToString() + " and SerialNo = " + gvSalesMaster.CurrentRow.Cells["SerialNo"].Value.ToString() + "");
                    object[] pkpm = new object[3] { gvSalesMaster.CurrentRow.Cells["Prefix"].Value.ToString(), gvSalesMaster.CurrentRow.Cells["SInvoiceNo"].Value.ToString(), gvSalesMaster.CurrentRow.Cells["SerialNo"].Value.ToString() };
                    dsSales.Tables["SalesMaster"].Rows.Find(pkpm).Delete();
                    dsSales.Tables["SalesMaster"].AcceptChanges();
                    udfTotalAmount();
                }
                else if (gvSalesMaster.Rows.Count == 1)
                {
                    MessageBox.Show("You Can't Delete the Bill Permanently.", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            { }
        }

        private void txtDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            CrudeNavigationClass.EventHandlerOnlyNum(txtDiscount, e, 4);
        }

        private void gvSalesMaster_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            { }
            catch (Exception)
            { }
        }

         private void udfNewBill()
        {
            try
            {
                if (cbSInvoiceNo.Text != "" && cbPrefix.Text != "")
                {
                    object[] PKSalesBill = new object[2] { cbPrefix.Text, cbSInvoiceNo.Text };
                    if (dsSales.Tables["SalesBill"].Rows.Contains(PKSalesBill) == false && cbCustomerNo.SelectedIndex > -1)
                    {
                        //cbTaxGroupName.SelectedIndex = 2;
                        udfAddinSalesBill();
                        cbSInvoiceNo.SelectedIndex = 0;
                        dsSales.Tables["SalesMaster"].Rows.Clear();
                        udfAddrow(1);// First Row in Purchase Master  
                        gvSalesMaster.Focus();
                        gvSalesMaster.CurrentRow.Cells["ItemNo"].Selected = true;
                    }
                }
            }
            catch (Exception)
            { }
        }

        private void udfAddrow(int SerialNo)
        {
            try
            {
                DataRow dr = dsSales.Tables["SalesMaster"].NewRow();
                dr["Prefix"] = cbPrefix.Text;
                dr["SInvoiceNo"] = cbSInvoiceNo.Text;
                dr["SerialNo"] = SerialNo;
                dsSales.Tables["SalesMaster"].Rows.Add(dr);

                CrudeNavigationClass.CrudeSelect(str, "Insert into SalesMaster (Prefix, SInvoiceNo, SerialNo,Date) Values ('" + dr["Prefix"] + "', " + dr["SInvoiceNo"] + "," + dr["SerialNo"] + ",'"+ dtpDate.Value.Date.Year +"-"+dtpDate.Value.Date.Month +"-"+dtpDate.Value.Day +"')");
                dsSales.Tables["SalesMaster"].AcceptChanges();
            }
            catch (Exception)
            { }
        }

        private void udfLoadPM()
        {
            try
            {
                dsSales.Tables["SalesMaster"].Rows.Clear();
                dsSales.Tables["SalesMaster"].Merge(CrudeNavigationClass.GetData(str, "Select Prefix, SInvoiceNo, SerialNo, ItemNo, ItemName, Quantity, MRP, Total from SalesMaster where Prefix = '" + cbPrefix.Text + "' and SInvoiceNo = " + cbSInvoiceNo.Text + ""));
            }
            catch (Exception)
            { }
        }

        private void gvSalesMaster_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (gvSalesMaster.CurrentCell == gvSalesMaster.CurrentRow.Cells["Quantity"] && gvSalesMaster.CurrentRow.Cells["Quantity"].Value.ToString() != "" && gvSalesMaster.CurrentRow.Cells["ItemNo"].Value.ToString() != "" && gvSalesMaster.CurrentRow.Index == gvSalesMaster.Rows.Count - 1)
                    {
                        udfAddrow(Convert.ToInt32(dsSales.Tables["SalesMaster"].Rows[dsSales.Tables["SalesMaster"].Rows.Count - 1]["SerialNo"]) + 1);
                    }
                    else if (gvSalesMaster.CurrentCell == gvSalesMaster.CurrentRow.Cells["ItemNo"] || gvSalesMaster.CurrentCell == gvSalesMaster.CurrentRow.Cells["ItemName"])
                    {
                        if (gvSalesMaster.CurrentCell == gvSalesMaster.CurrentRow.Cells["ItemNo"] && gvSalesMaster.CurrentRow.Cells["ItemNo"].Value.ToString() == "")
                        {
                            gvSalesMaster.CurrentRow.Cells["ItemName"].Selected = true;
                        }
                        else if (gvSalesMaster.CurrentCell == gvSalesMaster.CurrentRow.Cells["ItemName"] && gvSalesMaster.CurrentRow.Cells["ItemName"].Value.ToString() == "")
                        {
                            gvSalesMaster.CurrentRow.Cells["ItemNo"].Selected = true;
                        }
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

        private void gvSalesMaster_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((gvSalesMaster.CurrentCell == gvSalesMaster.CurrentRow.Cells["ItemNo"] && gvSalesMaster.CurrentRow.Cells["ItemNo"].Value.ToString() != "") || (gvSalesMaster.CurrentCell == gvSalesMaster.CurrentRow.Cells["ItemName"] && gvSalesMaster.CurrentRow.Cells["ItemName"].Value.ToString() != ""))
                {
                    object[] pkItemMaster = new object[1] { gvSalesMaster.CurrentCell.Value.ToString() };

                    DataRow dr = dsSales.Tables["SalesMaster"].Rows[gvSalesMaster.CurrentRow.Index];
                    if (gvSalesMaster.CurrentRow.Cells["Quantity"].Value.ToString() != "")
                    {
                        string[] qty = new string[1];
                        CrudeNavigationClass.FillNArray(str, "Select Quantity from StockMaster where ItemNo = (Select ItemNo from SalesMaster where Prefix = '" + dr["Prefix"] + "' and SInvoiceNo = " + dr["SInvoiceNo"] + " and SerialNo = " + dr["SerialNo"] + ") ", qty, 1);
                        string setqty = Convert.ToString(Math.Round(Convert.ToDouble(qty[0]) + Convert.ToDouble(dr["Quantity"]), 2));
                        CrudeNavigationClass.CrudeSelect(str, "Update StockMaster set Quantity = " + setqty + " where ItemNo = (Select ItemNo from SalesMaster where Prefix = '" + dr["Prefix"] + "' and SInvoiceNo = " + dr["SInvoiceNo"] + " and SerialNo = " + dr["SerialNo"] + ")");
                    }
                    dr["ItemNo"] = dsSales.Tables["StockMaster"].Rows.Find(pkItemMaster)["ItemNo"].ToString();
                    //dr["CategoryNo"] = dsSales.Tables["StockMaster"].Rows.Find(pkItemMaster)["CategoryNo"].ToString(); 
                    dr["ItemName"] = dsSales.Tables["StockMaster"].Rows.Find(pkItemMaster)["ItemName"].ToString();
                    dr["Quantity"] = 0.0;
                    dr["MRP"] = dsSales.Tables["StockMaster"].Rows.Find(pkItemMaster)["MRP"].ToString();
                    dr["Total"] = 0;

                    CrudeNavigationClass.CrudeSelect(str, "Update SalesMaster set ItemNo = '" + dr["ItemNo"] + "', ItemName = '" + dr["ItemName"] + "', Quantity = " + dr["Quantity"] + ", MRP = " + dr["MRP"] + ", Total = " + dr["Total"] + " where Prefix = '" + dr["Prefix"] + "' and SInvoiceNo = " + dr["SInvoiceNo"] + " and SerialNo = " + dr["SerialNo"] + "");
                    dsSales.Tables["SalesMaster"].AcceptChanges();
                    udfTotalAmount();// Calculate TotalAmount
                    gvSalesMaster.CurrentRow.Cells["Quantity"].Selected = true;
                }

                else if (gvSalesMaster.CurrentCell == gvSalesMaster.CurrentRow.Cells["Quantity"] || gvSalesMaster.CurrentCell == gvSalesMaster.CurrentRow.Cells["MRP"])
                {
                    if (gvSalesMaster.CurrentRow.Cells["Quantity"].Value.ToString() == "" || gvSalesMaster.CurrentRow.Cells["MRP"].Value.ToString() == "")
                    {
                        dsSales.Tables["SalesMaster"].RejectChanges();
                    }
                    else
                    {
                        DataRow dr = dsSales.Tables["SalesMaster"].Rows[gvSalesMaster.CurrentRow.Index];
                        dr["Quantity"] = gvSalesMaster.CurrentRow.Cells["Quantity"].Value.ToString();
                        dr["MRP"] = gvSalesMaster.CurrentRow.Cells["MRP"].Value.ToString();
                        dr["Total"] = Convert.ToDouble(gvSalesMaster.CurrentRow.Cells["MRP"].Value) * Convert.ToDouble(gvSalesMaster.CurrentRow.Cells["Quantity"].Value);

                        // Select the Old Quantity from PurchaseMaster
                        string[] Oldqty1 = new string[1];
                        string[] Oldqty2 = new string[2];
                      
                        CrudeNavigationClass.FillNArray(str, "Select Quantity from SalesMaster where Prefix = '" + dr["Prefix"] + "' and SInvoiceNo = " + dr["SInvoiceNo"] + " and SerialNo = " + dr["SerialNo"] + "", Oldqty1, 1);
                        CrudeNavigationClass.FillNArray(str, "Select Quantity,MinStock from StockMaster where ItemNo = '" + dr["ItemNo"] + "'", Oldqty2, 2);
                        // CrudeNavigationClass.FillNArray(str, "Select MinStock from StockMaster where ItemNo = '" + dr["ItemNo"] + "'", Oldqty2, 2);
                        
                        string Newqty = Convert.ToString(Math.Round(Convert.ToDouble(Oldqty1[0]) + Convert.ToDouble(Oldqty2[0]) - Convert.ToDouble(dr["Quantity"]), 3));
                        // Update Quantity in ItemMaster
                        /* Commented for not reach less than min quantity*/
                        ////if (Convert.ToDouble(Newqty) > Convert.ToDouble(Oldqty2[1]))
                        if (Convert.ToDouble(Newqty) >= 0.0)
                        {
                            CrudeNavigationClass.CrudeSelect(str, "Update StockMaster set Quantity = " + Newqty + " where ItemNo = '" + dr["ItemNo"] + "'");
                            CrudeNavigationClass.CrudeSelect(str, "Update SalesMaster set Quantity = " + dr["Quantity"] + ", MRP = " + dr["MRP"] + ", Total = " + dr["Total"] + " where Prefix = '" + dr["Prefix"] + "' and SInvoiceNo = " + dr["SInvoiceNo"] + " and SerialNo = " + dr["SerialNo"] + "");
                        }
                        else
                        {
                            ////MessageBox.Show("Available Quantity is="+((Convert.ToDouble(Oldqty1[0]) + Convert.ToDouble(Oldqty2[0]))- Convert.ToDouble(Oldqty2[1])).ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MessageBox.Show("Not Enough Quantity is Available", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        dsSales.Tables["SalesMaster"].AcceptChanges();
                        udfTotalAmount();// Calculate TotalAmount
                        gvSalesMaster.CurrentRow.Cells["Quantity"].Selected = true;
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
                if (textcontrol1 != null)
                { textcontrol1.KeyPress -= new KeyPressEventHandler(textcontrol1_KeyPress); }
                //else if (comboControl != null)
                //{ comboControl.KeyPress -= new KeyPressEventHandler(comboControl_KeyPress); }
            }
        }

        private void gvSalesMaster_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (gvSalesMaster.CurrentCell == gvSalesMaster.CurrentRow.Cells["ItemNo"])
                {
                    comboControl = e.Control as DataGridViewComboBoxEditingControl;
                    comboControl.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboControl.AutoCompleteSource = AutoCompleteSource.ListItems; 
                }
                else if (gvSalesMaster.CurrentCell == gvSalesMaster.CurrentRow.Cells["ItemName"])
                {
                    comboControl = e.Control as DataGridViewComboBoxEditingControl;
                    comboControl.DropDownStyle = ComboBoxStyle.DropDown;
                    comboControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboControl.AutoCompleteSource = AutoCompleteSource.ListItems; 
                }
                else if (gvSalesMaster.CurrentCell == gvSalesMaster.CurrentRow.Cells["MRP"])
                {
                    TextBox textcontrol = e.Control as DataGridViewTextBoxEditingControl;
                    textcontrol.MaxLength = 5; 
                    textcontrol.KeyPress += new KeyPressEventHandler(textcontrol_KeyPress);
                }
                else if (gvSalesMaster.CurrentCell == gvSalesMaster.CurrentRow.Cells["Quantity"])
                {
                    textcontrol1 = e.Control as DataGridViewTextBoxEditingControl;
                    textcontrol1.MaxLength = 6;
                    textcontrol1.KeyPress += new KeyPressEventHandler(textcontrol1_KeyPress);
                }
            }
            catch (Exception)
            { }
        }

        private void gvSalesMaster_Layout(object sender, LayoutEventArgs e)
        {
            try
            {
                gvSalesMaster.RowTemplate.Height = 25;
            }
            catch (Exception)
            { }
        }

        private void lnkInvoiceNo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                dtpDate.Value = System.DateTime.Now;
                if (dsSales.Tables["SalesBill"].Rows.Count > 0)
                {
                    cbSInvoiceNo.Text = Convert.ToString(Convert.ToDouble(dsSales.Tables["SalesBill"].DefaultView[0]["SInvoiceNo"]) + 1);
                    //cbCustomerNo.Focus();
                }
                else if (dsSales.Tables["SalesBill"].Rows.Count == 0)
                {
                    cbSInvoiceNo.Text = "1";
                    //cbCustomerNo.Focus();
                }
                dsSales.Tables["SalesMaster"].Rows.Clear();
                txtTotalAmount.Text = "0";
                udfNewBill();
                //dsSales.Tables["SalesBill"].DefaultView.Sort = "SInvoiceNo desc";
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void cbSInvoiceNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //udfCancelBill();// Delete the Bill information if another Bill is Selected
            udfLoadPM();
            txtDiscount.Text = "";
            udfTotalAmount(); // Calculate Total Amount
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

        private void CbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
