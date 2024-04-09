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
    public partial class frmMain : CustomForm
    {
        public static int varLoggedUserNo;
        public static int varLoggedUserRoleNo;

        public frmMain()
        {
            InitializeComponent();
        }

        private void stockInHandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDailyStock stock = new frmDailyStock();
            stock.ShowDialog();
            this.Focus();
        }

        private void dailySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonthlySalesStock ss = new frmMonthlySalesStock();
            ss.ShowDialog();
            this.Focus();
        }

        private void dailyPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonthlyPurchase mp = new frmMonthlyPurchase();
            mp.ShowDialog();
            this.Focus();
        }

        private void itemWisePurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemwisePurchaseReport purchasereport = new frmItemwisePurchaseReport();
            purchasereport.ShowDialog();
            this.Focus();
        }

        private void itemWiseSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemwiseSalesReport sales = new frmItemwiseSalesReport();
            sales.ShowDialog();
            this.Focus();
        }

        private void partyWisePurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPartywisePurchaseReport party = new frmPartywisePurchaseReport();
            party.ShowDialog();
            this.Focus();
        }

        private void vendorMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendorMaster fvm = new frmVendorMaster();
            fvm.ShowDialog();
            this.Focus();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserMaster um = new frmUserMaster();
                um.ShowDialog();
                this.Focus();
            }
            catch (Exception)
            {
            }
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchase purchase = new frmPurchase();
            purchase.ShowDialog();
            this.Focus();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSales fsm = new frmSales();
            fsm.ShowDialog();
            this.Focus();
        }

        private void stockMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockMaster fsm = new frmStockMaster();
            fsm.ShowDialog();
            this.Focus();
        }

        private void manageStockToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmManageStock manage = new frmManageStock();
            manage.ShowDialog();
            this.Focus();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void categoryMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoryMaster fcm = new frmCategoryMaster();
            fcm.ShowDialog();
            this.Focus();
        }

        private void departmentWiseStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptCategorywiseStock rcs = new RptCategorywiseStock();
            rcs.ShowDialog();
            this.Focus();
        }

        private void customerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerMaster fcm = new frmCustomerMaster();
            fcm.ShowDialog();
            this.Focus();
        }

        private void customerWiseItemSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerWiseItemSales fcim = new frmCustomerWiseItemSales();
            fcim.ShowDialog();
            this.Focus();
        }

    }
}
