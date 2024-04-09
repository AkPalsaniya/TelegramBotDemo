using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class csEasyNavigate
    {


        public static void SubstituteTab(KeyEventArgs e,TextBox txtQty, TextBox txtCovers)
        {

            //if (e.KeyCode == Keys.Left)
            //{
                
            //    SendKeys.Send("+{TAB}");
            //    //SendKeys.Send("+{TAB}");
                
            //}
            //else if (e.KeyCode == Keys.Right)
            //{
                
                
            //    SendKeys.Send("{TAB}");
            //    //ProcessTabKey(true);
            //}
            if (txtQty.Focused)
            {



                try
                {
                    if (txtQty.Text != "")
                    {
                        if (Convert.ToInt32(txtQty.Text) >= 0)
                        {
                            if (e.KeyCode == Keys.Up)
                            {
                                if (Convert.ToInt32(txtQty.Text) < 25)
                                {
                                    txtQty.Text = (Convert.ToInt32(txtQty.Text) + 1).ToString();
                                }
                            }
                            else if (e.KeyCode == Keys.Down)
                            {
                                if (Convert.ToInt32(txtQty.Text) > 1)
                                {
                                    txtQty.Text = (Convert.ToInt32(txtQty.Text) - 1).ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        txtQty.Text = "1";
                    }
                }
                catch (Exception)
                {

                    txtQty.Text = "1";
                }
            }
            else if (txtCovers.Focused)
            { 
               try
                {
                    if (txtCovers.Text != "")
                    {
                        if (Convert.ToInt32(txtCovers.Text) >= 0)
                        {
                            if (e.KeyCode == Keys.Up)
                            {
                                if (Convert.ToInt32(txtCovers.Text) < 25)
                                {
                                    txtCovers.Text = (Convert.ToInt32(txtCovers.Text) + 1).ToString();
                                }
                            }
                            else if (e.KeyCode == Keys.Down)
                            {
                                if (Convert.ToInt32(txtCovers.Text) > 1)
                                {
                                    txtCovers.Text = (Convert.ToInt32(txtCovers.Text) - 1).ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        txtCovers.Text = "1";
                    }
                }
                catch (Exception)
                {

                    txtCovers.Text = "1";
                }
            }
            


            
            
            
            
            
            
            //=========
            
            
            
            
            //if (e.KeyCode == Keys.Left)
            //{
            //    (false);
            //}
            //else if (e.KeyCode == Keys.Right)
            //{
            //    ProcessTabKey(true);
            //}
            //if (txtQty.Focused)
            //{



            //    try
            //    {
            //        if (txtQty.Text != "")
            //        {
            //            if (Convert.ToInt32(txtQty.Text) >= 0)
            //            {
            //                if (e.KeyCode == Keys.Up)
            //                {
            //                    if (Convert.ToInt32(txtQty.Text) < 25)
            //                    {
            //                        txtQty.Text = (Convert.ToInt32(txtQty.Text) + 1).ToString();
            //                    }
            //                }
            //                else if (e.KeyCode == Keys.Down)
            //                {
            //                    if (Convert.ToInt32(txtQty.Text) > 1)
            //                    {
            //                        txtQty.Text = (Convert.ToInt32(txtQty.Text) - 1).ToString();
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            txtQty.Text = "1";
            //        }
            //    }
            //    catch (Exception)
            //    {

            //        txtQty.Text = "1";
            //    }
            //}
        }



        //public static string SubstituteButtons(KeyEventArgs e, string adddmethod, string removemethod)
        //{
        //    if (e.KeyCode == Keys.Add)
        //    {
        //        return adddmethod;
        //    }
        //    else if (e.KeyCode == Keys.Subtract)
        //    {
        //        return removemethod;
        //    }
            
        //}



        public static object SubstituteButtons(KeyEventArgs e, object p, object p_3)
        {
            if (e.KeyCode == Keys.Add)
            {
                return p;
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                return p_3;
            }
            else
            {
                return null;
            }
        }

        //internal static void SubstituteButtons(KeyEventArgs e, object p, object p_3)
        //{
        //    throw new NotImplementedException();
        //}

        
    }
}
