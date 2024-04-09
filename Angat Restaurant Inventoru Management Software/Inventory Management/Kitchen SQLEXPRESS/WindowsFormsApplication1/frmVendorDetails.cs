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
    public partial class frmVendorDetails : CustomForm
    {
        string str;
        DataSet ds;
        DataRow dr;

        public frmVendorDetails()
        {
            InitializeComponent();
            str = ConfigurationManager.ConnectionStrings["salogin"].ToString();
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void udfVendorMaster()
        {
            try
            {
                ds.Tables.Add("VendorMaster");
                CrudeNavigationClass.FillTable(str, "Select VendorNo, VendorName, DebitAmount, CreditAmount from VendorMaster", ds.Tables["VendorMaster"]);
                cbVendorNo.DisplayMember = "VendorNo";
                cbVendorNo.ValueMember = "VendorNo";
                cbVendorNo.DataSource = ds.Tables["VendorMaster"];

                cbVendorName.DisplayMember = "VendorName";
                cbVendorName.ValueMember = "VendorNo";
                cbVendorName.DataSource = ds.Tables["VendorMaster"];

                txtCreditAmount.DataBindings.Add("Text", ds.Tables["VendorMaster"], "CreditAmount");
                txtDebitAmount.DataBindings.Add("Text", ds.Tables["VendorMaster"], "DebitAmount");
            }
            catch (Exception)
            { }
        }

        private void frmVendorDetails_Load(object sender, EventArgs e)
        {
            try
            {
                txtDebitAmount.ReadOnly = true;
                txtCreditAmount.ReadOnly = true;

                txtCreditAmount.BackColor = Color.LightBlue;
                txtDebitAmount.BackColor = Color.LightBlue;

                txtInputDebit.MaxLength = 7;
                txtInputCredit.MaxLength = 7;

                cbVendorName.DropDownStyle = ComboBoxStyle.DropDown;
                cbVendorNo.DropDownStyle = ComboBoxStyle.DropDown;

                cbVendorNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbVendorName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                cbVendorNo.AutoCompleteSource = AutoCompleteSource.ListItems;
                cbVendorName.AutoCompleteSource = AutoCompleteSource.ListItems;

                txtCreditAmount.TabStop = false;
                txtDebitAmount.TabStop = false;

                ds = new DataSet();
                udfVendorMaster();
            }
            catch (Exception)
            { }
        }

        private void txtInputCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                CrudeNavigationClass.EventHandlerFor2DP(txtInputCredit, e);
            }
            catch (Exception)
            { }
        }

        private void txtInputDebit_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                CrudeNavigationClass.EventHandlerFor2DP(txtInputDebit, e);
            }
            catch (Exception)
            { }
        }

        private void btnCredit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInputCredit.Text != "")
                {
                    double CValue = Convert.ToDouble(txtCreditAmount.Text) + Convert.ToDouble(txtInputCredit.Text);
                    CrudeNavigationClass.CrudeInsert(str, "Update VendorMaster set CreditAmount = " + CValue.ToString() + " where VendorNo = " + cbVendorNo.SelectedValue.ToString() + "");
                    dr = ds.Tables["VendorMaster"].Rows.Find(cbVendorNo.SelectedValue.ToString());
                    dr["CreditAmount"] = CValue;
                    ds.Tables["VendorMaster"].AcceptChanges();
                    txtInputCredit.Text = "0";
                }

            }
            catch (Exception)
            { }
        }

        private void btnDebit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDebitAmount.Text != "")
                {
                    double DValue = Convert.ToDouble(txtDebitAmount.Text) + Convert.ToDouble(txtInputDebit.Text);
                    CrudeNavigationClass.CrudeInsert(str, "Update VendorMaster set DebitAmount = " + DValue.ToString() + "  where VendorNo = " + cbVendorNo.SelectedValue.ToString() + "");
                    dr = ds.Tables["VendorMaster"].Rows.Find(cbVendorNo.SelectedValue.ToString());
                    dr["DebitAmount"] = DValue;
                    ds.Tables["VendorMaster"].AcceptChanges();
                    txtInputDebit.Text = "0";
                }
            }
            catch (Exception)
            { }
        }

        private void txtInputCredit_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtInputCredit.Text != "")
                {
                    txtInputCredit.Text = (Math.Round(Convert.ToDouble(txtInputCredit.Text), 2)).ToString();
                }
            }
            catch (Exception)
            { }
        }

        private void txtInputDebit_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtInputDebit.Text != "")
                {
                    txtInputDebit.Text = (Math.Round(Convert.ToDouble(txtInputDebit.Text), 2)).ToString();
                }
            }
            catch (Exception)
            { }
        }

        private void cbVendorNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtInputCredit.Text = "0";
                txtInputDebit.Text = "0";
                //ds.Tables["VendorMaster"].RejectChanges();
            }
            catch (Exception)
            { }
        }

        private void btnSattle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCreditAmount.Text != "" && txtDebitAmount.Text != "")
                {
                    double FinalValue = Convert.ToDouble(txtCreditAmount.Text) - Convert.ToDouble(txtDebitAmount.Text);
                    dr = ds.Tables["VendorMaster"].Rows.Find(cbVendorNo.SelectedValue.ToString());
                    if (FinalValue >= 0)
                    {
                        dr["CreditAmount"] = FinalValue;
                        dr["DebitAmount"] = 0;
                    }
                    else if (FinalValue < 0)
                    {
                        dr["CreditAmount"] = 0;
                        dr["DebitAmount"] = FinalValue * -1;
                    }
                    CrudeNavigationClass.CrudeInsert(str, "Update VendorMaster set CreditAmount = " + dr["CreditAmount"] + ", DebitAmount = " + dr["DebitAmount"] + " where VendorNo = " + dr["VendorNo"] + "");
                    MessageBox.Show("Account is Sattled", "Settled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ds.Tables["VendorMaster"].AcceptChanges();
                    cbVendorNo.Focus();
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
