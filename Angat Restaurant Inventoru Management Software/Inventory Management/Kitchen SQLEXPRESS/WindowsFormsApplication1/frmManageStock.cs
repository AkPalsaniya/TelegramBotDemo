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
    public partial class frmManageStock : CustomForm
    {
        string str;
        DataTable dtIM;

        public frmManageStock()
        {
            InitializeComponent();
            str = ConfigurationManager.ConnectionStrings["salogin"].ToString();
            CustomUI.customiseMenuForm(this);
        }

        private void frmManageStock_Load(object sender, EventArgs e)
        {
            udfItemMaster();
            txtTotal.ReadOnly = true;
        }

        private void udfItemMaster()
        {
            try
            {
                dtIM = new DataTable();
                CrudeNavigationClass.FillTable(str, "Select ItemNo, ItemName, Quantity from StockMaster", dtIM);

                DataColumn[] dc = new DataColumn[1];
                dc[0] = dtIM.Columns["ItemNo"];
                dtIM.PrimaryKey = dc;

                cbItemNo.DisplayMember = "ItemNo";
                cbItemNo.ValueMember = "ItemNo";
                cbItemNo.DataSource = dtIM;

                cbItemName.DisplayMember = "ItemName";
                cbItemName.ValueMember = "ItemNo";
                cbItemName.DataSource = dtIM;

                txtTotal.DataBindings.Add("Text", dtIM, "Quantity");
            }
            catch (Exception)
            { }
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "")
            {
                txtQuantity.Text = "0";
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //CrudeNavigationClass.EventHandlerOnlyNum(txtQuantity, e, 5);
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == '.')
                {
                    if (txtQuantity.Text.Contains('.') == true)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtQuantity.Text) != 0)
                {
                    double  AddQty = Convert.ToDouble(txtQuantity.Text);
                    CrudeNavigationClass.CrudeInsert(str, "Update StockMaster set Quantity = Quantity + " + AddQty + " where ItemNo = " + cbItemNo.SelectedValue.ToString() + "");
                    object[] pkim = new object[1] { cbItemNo.SelectedValue.ToString()};
                    DataRow dr = dtIM.Rows.Find(pkim);
                    dr["Quantity"] = Convert.ToDouble(dr["Quantity"]) + AddQty;
                    txtQuantity.Text = "0";
                    MessageBox.Show("Quantity is Successfully Added", "Task Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Convert.ToDouble(txtQuantity.Text) == 0)
                {
                    MessageBox.Show("Fill the Quantity");
                    txtQuantity.Select();
                }
            }
            catch (Exception)
            { }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtQuantity.Text) != 0)
                {
                    double  SubQty = Convert.ToDouble(txtQuantity.Text);
                    CrudeNavigationClass.CrudeInsert(str, "Update StockMaster set Quantity = Quantity - " + SubQty + " where ItemNo = " + cbItemNo.SelectedValue.ToString() + "");
                    object[] pkim = new object[1] { cbItemNo.SelectedValue.ToString() };
                    DataRow dr = dtIM.Rows.Find(pkim);
                    dr["Quantity"] = Convert.ToDouble(dr["Quantity"]) - SubQty;
                    txtQuantity.Text = "0";
                    MessageBox.Show("Quantity is Successfully Subtracted", "Task Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Convert.ToDouble(txtQuantity.Text) == 0)
                {
                    MessageBox.Show("Fill the Quantity");
                    txtQuantity.Select();
                }
            }
            catch (Exception)
            { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantity.Text = "0";
        }
       
    }
}
