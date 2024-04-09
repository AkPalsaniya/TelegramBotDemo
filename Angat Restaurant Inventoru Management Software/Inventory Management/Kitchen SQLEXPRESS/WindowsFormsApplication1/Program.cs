using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmBillManage());
            Application.Run(new frmLogin());
            //Application.Run(new BillHandle());
            //Application.Run(new frmLocationMaster());
            //Application.Run(new frmPurchase());
            //Application.Run(new frmUserRights());
            //Application.Run(new frmPurchase());
            //Application.Run(new frmStockMaster());
        }
    }
}
