using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class CrudeNavigation
    {

        static SqlCommandBuilder scmd;
        static SqlDataAdapter adapter;
        static DataTable table;
        public bool CrudeUpdate(string connectionstring, Form form)
        {

            bool check = false;

            try
            {

                adapter.Update(table);


                //conn = new SqlConnection(connectionstring);
                //cmd = new SqlCommand(commandtext, conn);


                //conn.Open();


                //if (cmd.ExecuteNonQuery() > 0)
                //{
                //    check = true;
                //    MessageBox.Show("Updation Successful", "Task Updated");

                //}

                //conn.Close();

                //sdaItemMaster.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                //dsItemMaster.Tables["ItemMaster"].Reset();
                //sdaItemMaster.FillSchema(dsItemMaster, SchemaType.Source, "ItemMaster");

                //        sdaItemMaster.Update(dsItemMaster, "ItemMaster");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "", "Failed to Update item", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //if (conn.State == ConnectionState.Open)
                //{
                //    conn.Close();
                //}
            }


            return check;


        }

        public bool CrudeDelete(string connectionstring, object[] keys, Form form)
        {







            bool check = false;
            try
            {
                table.Rows.Find(keys).Delete();

                //table.Rows.Find(combobox.SelectedValue).Delete();
                //adapter.Update(table);


                //    conn = new SqlConnection(connectionstring);
                //    cmd = new SqlCommand(commandtext, conn);


                //    DialogResult dr = MessageBox.Show("Do you want to delete this log?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //    if (dr == DialogResult.Yes)
                //    {
                //        cmd = new SqlCommand(commandtext, conn);
                //        conn.Open();


                //        if (0 < cmd.ExecuteNonQuery())
                //        {
                //            check = true;
                //            MessageBox.Show("Deletion Successful", "Task Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);




                //        }

                //        conn.Close();
                //    }


            }
            catch (Exception exeception)
            {

                MessageBox.Show(exeception.Message + "Error deleting item. Error Code:" + form.Name + "", "Error encountered in delete operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return check;

        }

        public bool CrudeAdd(DataTable dt, Form form)
        {

            bool check = false; ;


            try
            {



                adapter.Update(dt);

                //conn = new SqlConnection(connectionstring);
                //cmd = new SqlCommand(commandtext, conn);
                //conn.Open();

                //if (!combobox.Items.Contains(combobox.Text))
                //{
                //    if (0 < cmd.ExecuteNonQuery())
                //    {
                //        combobox.Items.Add(combobox.Text);
                //        check = true;
                //        MessageBox.Show("Task Inserted", "Insertion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //    }
                //}
                //else
                //{
                //    MessageBox.Show("Unique Row-Id required Code: " + form.Name + "", "Duplication Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                //conn.Close();


            }
            catch (SqlException sqlexception)
            {
                //2627 for primary key violation
                if (sqlexception.Number == 2627)
                {
                    throw;//MessageBox.Show("Please make sure you add unique values", "Duplicate Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(sqlexception.Message.ToString(), "Error adding item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error adding item", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }






            return check;

        }
        public bool CrudeAdd(string connectionstring, DataRow dr, Form form)
        {

            bool check = false; ;


            try
            {


                table.Rows.Add(dr);
                adapter.Update(table);

                //conn = new SqlConnection(connectionstring);
                //cmd = new SqlCommand(commandtext, conn);
                //conn.Open();

                //if (!combobox.Items.Contains(combobox.Text))
                //{
                //    if (0 < cmd.ExecuteNonQuery())
                //    {
                //        combobox.Items.Add(combobox.Text);
                //        check = true;
                //        MessageBox.Show("Task Inserted", "Insertion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //    }
                //}
                //else
                //{
                //    MessageBox.Show("Unique Row-Id required Code: " + form.Name + "", "Duplication Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                //conn.Close();


            }
            catch (SqlException exception)
            {

                MessageBox.Show(exception.Message + "Please make sure User Number and User Name are unique.", "Duplication detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(exception.Message, "Error adding item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error adding item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return check;









        }

        public static void CrudeLoad(string connectionstring, string commandtext, AutoCompleteStringCollection combobox)
        {


            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(commandtext, conn);
            SqlDataReader sdr;
            conn.Open();

            sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                combobox.Add(sdr[0].ToString());
            }




            sdr.Close();
            conn.Close();


            //ds.AcceptChanges();
            //bindingSource1.DataSource = ds.Tables["BasicLog"];




        }

        public static DataTable GetData(string connectionstring, string commandtext)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionstring;
            SqlCommand cmd = new SqlCommand(commandtext, conn);
            adapter = new SqlDataAdapter();//SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;



            table = new DataTable();//DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.FillSchema(table, SchemaType.Source);
            adapter.Fill(table);
            scmd = new SqlCommandBuilder(adapter);
            return table;
        }

        internal void NavigateNext(BindingSource bindingSource1)
        {
            bindingSource1.MoveNext();

        }
        internal void NavigateFirst(BindingSource bindingSource1)
        {
            bindingSource1.MoveFirst();
        }
        internal void NavigateLast(BindingSource bindingSource1)
        {
            bindingSource1.MoveLast();
        }
        internal void NavigatePrevious(BindingSource bindingSource1)
        {
            bindingSource1.MovePrevious();
        }

    }
}
