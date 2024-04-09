using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class CustomUI
    {

        public static void customiseMenuForm(Form form, Button btnEnter, Button btnEscape)
        {
            form.MaximizeBox = false;
            form.FormBorderStyle = FormBorderStyle.Fixed3D;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.AcceptButton = btnEnter;
            form.CancelButton = btnEscape;


        }
        public static void customiseMenuForm(Form form, Button button, Boolean check)
        {
            form.MaximizeBox = false;
            form.FormBorderStyle = FormBorderStyle.Fixed3D;
            form.StartPosition = FormStartPosition.CenterScreen;
            //form.StartPosition = FormStartPosition.Manual;
            //form.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
            if (check == true)
            {
                form.AcceptButton = button;
            }
            else
            {
                form.CancelButton = button;
            }

        }
        public static void customiseMenuForm(Form form)
        {
            form.MaximizeBox = false;
            form.FormBorderStyle = FormBorderStyle.Fixed3D;
            form.StartPosition = FormStartPosition.CenterScreen;


        }

        public static void customiseMainForm(Form form, Button btnEnter, Button btnEscape)
        {

            form.StartPosition = FormStartPosition.CenterScreen;
            if (Properties.Settings.Default.MainWinState == true)
            { form.WindowState = FormWindowState.Maximized; }
            else { form.WindowState = FormWindowState.Normal; }
            form.AcceptButton = btnEnter;
            form.CancelButton = btnEscape;


        }
        public static void customiseMainForm(Form form, Button button, Boolean check)
        {

            if (Properties.Settings.Default.MainWinState == true)
            { form.WindowState = FormWindowState.Maximized; }
            else { form.WindowState = FormWindowState.Normal; }
            //form.StartPosition = FormStartPosition.Manual;
            //form.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
            if (check == true)
            {
                form.AcceptButton = button;
            }
            else
            {
                form.CancelButton = button;
            }

        }
        public static void customiseMainForm(Form form)
        {

            if (Properties.Settings.Default.MainWinState == true)
            { form.WindowState = FormWindowState.Maximized; }
            else { form.WindowState = FormWindowState.Normal; }


        }



    }
}
