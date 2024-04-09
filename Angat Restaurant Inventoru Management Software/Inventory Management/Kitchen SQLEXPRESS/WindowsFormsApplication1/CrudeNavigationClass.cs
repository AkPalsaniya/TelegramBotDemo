using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.Shared;


namespace WindowsFormsApplication1
{

    class CrudeNavigationClass
    {
        SqlCommand cmd;
        SqlConnection conn;
        static SqlCommandBuilder scmd;
        static SqlDataAdapter adapter;
        static DataTable table;
        int number;
        string strng;
        public bool CrudeUpdate(string connectionstring, string commandtext, Form form)
        {
            bool check = false;
            try
            {
                adapter.Update(table);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "", "Failed to Update item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return check;
        }

        public bool CrudeUpdate(string connectionstring, Form form)
        {
            bool check = false;
            try
            {
                adapter.Update(table);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "", "Failed to Update item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return check;
        }

        
        public static void CrudeLoad(string connectionstring, string commandtext, Control cnt)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(commandtext, conn);
            SqlDataReader sdr;
            conn.Open();

            sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                cnt.Text = sdr[0].ToString();
            }
            sdr.Close();
            conn.Close();
        }

        public int CrudeLoad(string connectionstring, string commandtext)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(commandtext, conn);
            SqlDataReader sdr;
            conn.Open();

            sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                number = Convert.ToInt32(sdr[0]);
            }
            sdr.Close();
            conn.Close();
            return number;
        }

        public static bool IsPresent(string connectionstring, string commandtext)
        {
            bool Available = false;
            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(commandtext, con);
            SqlDataReader sdr;
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
           
            sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (sdr.HasRows == true)
            {
                Available = true;
            }
            con.Close();
            return Available;
            
        }

        public string Returnsting(string connectionstring, string commandtext)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(commandtext, conn);
            SqlDataReader sdr;
            conn.Open();

            sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                strng = Convert.ToString(sdr[0]);
            }
            sdr.Close();
            conn.Close();
            return strng;
        }

        public static DataTable GetData(string connectionstring, string commandtext)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionstring;
            SqlCommand cmd = new SqlCommand(commandtext, conn);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.FillSchema(table, SchemaType.Source);
            adapter.Fill(table);
            scmd = new SqlCommandBuilder(adapter);
            return table;
        }

        public static void FillTable(string connectionstring, string commandtext, DataTable dt)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionstring;
            SqlCommand cmd = new SqlCommand(commandtext, conn);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            //table = new DataTable();
            dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.FillSchema(dt, SchemaType.Source);
            adapter.Fill(dt);
            scmd = new SqlCommandBuilder(adapter);
        }

        public static void CrudeInsert(string connectionstring, string commandtext)
        {
            //try
            //{
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand(commandtext, conn);
                SqlDataReader sdr;
                conn.Open();

                sdr = cmd.ExecuteReader();

                sdr.Close();
                conn.Close();
            //}
            //catch (SqlException sqlexception)
            //{
            //    MessageBox.Show(sqlexception.ToString());
            //}


        }

        public static void Insert(string connectionstring, string commandtext)
        {
            //try
            //{
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand(commandtext, conn);
                //SqlDataReader sdr;
                conn.Open();

                cmd.ExecuteNonQuery();

                //sdr.Close();
                conn.Close();
            //}
            //catch (SqlException sqlexception)
            //{
            //    MessageBox.Show(sqlexception.ToString());
            //}
        }

        //public bool CrudeUpdate(string connectionstring, DataTable table)
        //{
        //    bool check = false;
        //    try
        //    {
        //        adapter.Update(table);
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message + "", "Failed to Update item", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return check;
        //}

        public static void fillCombobox(string connectionstring, string commandtext, ComboBox Cbbox)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(commandtext, conn);
            SqlDataReader sdr;
            conn.Open();

            sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                Cbbox.Items.Insert(Cbbox.Items.Count,sdr[0].ToString());
            }
            sdr.Close();
            conn.Close();
        }

        public static void FillArray(string connectionstring, string commandtext, string[] array)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(commandtext, conn);
            SqlDataReader sdr;
            conn.Open();

            sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                for (int i = 0; i <= 3; i++)
                {
                    array[0] = sdr[0].ToString();
                    array[1] = sdr[1].ToString();
                    array[2] = sdr[2].ToString();
                    array[3] = sdr[3].ToString();
                }
            }
            sdr.Close();
            conn.Close();
        }

        public static void FillNArray(string connectionstring, string commandtext, string[] array, int length)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(commandtext, conn);
            SqlDataReader sdr;
            conn.Open();

            sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                for (int i = 0; i <= length -1; i++)
                {
                    array[i] = sdr[i].ToString();
                }

            }
            sdr.Close();
            conn.Close();
        }

        public static void Fill2Array(string connectionstring, string commandtext, string[] array)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(commandtext, conn);
            SqlDataReader sdr;
            conn.Open();

            sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                
                    array[0] = sdr[0].ToString();
                    array[1] = sdr[1].ToString();
                
            }
            sdr.Close();
            conn.Close();
        }

        public static void Array(string connectionstring, string commandtext, Array array)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(commandtext, conn);
            SqlDataReader sdr;
            conn.Open();

            sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                //array = sdr[0].ToString();   
            }
            sdr.Close();
            conn.Close();
        }
        public static void CrudeSelect(string connectionstring, string commandtext)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand(commandtext, conn);
                SqlDataReader sdr;
                conn.Open();

                sdr = cmd.ExecuteReader();

                sdr.Close();
                conn.Close();
            }
            catch (SqlException sqlexception)
            {
                MessageBox.Show(sqlexception.ToString());
            }
        }

        public static void OneString(string connectionstring, string commandtext, string str)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(commandtext, conn);
            SqlDataReader sdr;
            conn.Open();

            sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                str = sdr[0].ToString();
            }
            sdr.Close();
            conn.Close();
        }

        public static void EventHandlerFor2DP(Control textbox, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) == true || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == '.')
            {
                if (e.KeyChar == '.' && string.IsNullOrEmpty(textbox.Text) || (e.KeyChar == '.' && textbox.Text.Contains(".") == true))
                {
                    e.Handled = true;
                }
                else
                { e.Handled = false; }
            }
            else
            {
                e.Handled = true;
            }
        }

        public static void EventHandlerOnlyNum(Control textbox, KeyPressEventArgs e, int Length)
        {
            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
            
            else if (((char.IsNumber(e.KeyChar) == true || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || char.IsDigit(e.KeyChar)) && e.KeyChar != '.') && textbox.Text.Length < Length)
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete) && textbox.Text.Length == Length)
            {
                e.Handled = false;
            }

            else
            { e.Handled = true; }
        }

        public static void EventHandlerForNDP(Control control, KeyPressEventArgs e, uint DecimalDigit)
        {
            if (char.IsNumber(e.KeyChar) == true || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == '.')
            {
                if (DecimalDigit == 0)
                {
                    if (e.KeyChar == '.')
                    {
                        e.Handled = true;
                    }
                }
                else if (DecimalDigit != 0)
                {
                    if (e.KeyChar == '.' && control.Text.Contains(".") == true)
                    {
                        e.Handled = true;
                    }
                    else if (control.Text.Contains(".") == true && char.IsNumber(e.KeyChar) == true)
                    {
                        string[] text = control.Text.Split('.');
                        if ((char.IsNumber(e.KeyChar) == true || e.KeyChar == '.') && text[1].Length > 0)
                        {
                            if (text[1].Length < DecimalDigit)
                                e.Handled = false;
                            else
                            {
                                e.Handled = true;
                            }
                        }
                    }
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        public static void DGVTextBoxColumn(string[,] Name, int[] FW, string[,] HT, bool[] Readonly, DataGridView gv, int Startpoint, int EndPoint)
        {
            for (int i = Startpoint; i <= EndPoint; i++)
            {
                DataGridViewTextBoxColumn tbc = new DataGridViewTextBoxColumn();
                tbc.Name = Name[i, 0];
                tbc.DataPropertyName = Name[i, 0];
                tbc.HeaderText = HT[i, 1];
                tbc.FillWeight = FW[i];
                tbc.ReadOnly = Readonly[i];
                gv.Columns.Add(tbc);
            }
        }

        public static void DGVComboBoxColumn(string[,] Name, string DisMem, string ValMem, int[] FW, string[,] HT, DataGridView gv, int Startpoint, int EndPoint, DataTable table)
        {
            for (int i = Startpoint; i <= EndPoint; i++)
            {
                DataGridViewComboBoxColumn cbc = new DataGridViewComboBoxColumn();
                cbc.Name = Name[i, 0];
                cbc.DataPropertyName = Name[i, 0];
                cbc.DisplayMember = DisMem;
                cbc.ValueMember = ValMem;
                cbc.FillWeight = FW[i];
                cbc.HeaderText = HT[i, 1];
                cbc.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                cbc.DataSource = table;
                gv.Columns.Add(cbc);
            }
        }

        public static void DGVCheckBoxColumn(string[,] Name, int[] FW, string[,] HT, DataGridView gv, int Startpoint, int EndPoint)
        {
            for (int i = Startpoint; i <= EndPoint; i++)
            {
                DataGridViewCheckBoxColumn chbc = new DataGridViewCheckBoxColumn();
                chbc.Name = Name[i, 0];
                chbc.DataPropertyName = Name[i, 0];
                chbc.FillWeight = FW[i];
                chbc.HeaderText = HT[i, 1];
                chbc.ThreeState = false;
                chbc.TrueValue = true;
                chbc.FalseValue = false;
                gv.Columns.Add(chbc);
            }
        }

        public static void DGVValidation(DataGridView gv)
        {
            gv.AutoGenerateColumns = false;
            gv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.RowHeadersVisible = false;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.AllowUserToAddRows = false;
            gv.AllowUserToResizeColumns = false;
            gv.AllowUserToResizeRows = false;
            gv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gv.MultiSelect = false;
        }

        public static void DGVTextBoxColumn(string[,] NCRF, DataGridView gv, int Startpoint, int EndPoint)
        {
            for (int i = Startpoint; i <= EndPoint; i++)
            {
                DataGridViewTextBoxColumn tbc = new DataGridViewTextBoxColumn();
                tbc.Name = tbc.DataPropertyName = NCRF[i, 0];
                tbc.HeaderText = NCRF[i, 1];
                tbc.ReadOnly = Convert.ToBoolean(NCRF[i, 2]);
                tbc.FillWeight = Convert.ToInt32(NCRF[i, 3]);
                gv.Columns.Add(tbc);
            }
        }

        public static void DGVComboBoxColumn(string[,] NCRF, string DisMem, string ValMem, DataGridView gv, int Startpoint, int EndPoint, int Style, DataView dv)
        {
            for (int i = Startpoint; i <= EndPoint; i++)
            {
                DataGridViewComboBoxColumn cbc = new DataGridViewComboBoxColumn();
                cbc.Name = cbc.DataPropertyName = NCRF[i, 0];
                cbc.HeaderText = NCRF[i, 1];
                cbc.FillWeight = Convert.ToInt32(NCRF[i, 3]);
                cbc.DisplayMember = DisMem;
                cbc.ValueMember = ValMem;
                if (Style == 1)
                { cbc.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;}
                else if (Style == 2)
                { cbc.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;}
                else if (Style == 3)
                { cbc.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;}
                cbc.DataSource = dv;
                gv.Columns.Add(cbc);
            }
        }

        public static void DGVCheckBoxColumn(string[, ] NCRF, DataGridView gv, int Startpoint, int EndPoint)
        {
            for (int i = Startpoint; i <= EndPoint; i++)
            {
                DataGridViewCheckBoxColumn chbc = new DataGridViewCheckBoxColumn();
                chbc.Name = chbc.DataPropertyName = NCRF[i, 0];
                chbc.HeaderText = NCRF[i, 1];
                chbc.FillWeight = Convert.ToInt32(NCRF[i, 3]);
                chbc.ThreeState = false;
                chbc.TrueValue = true;
                chbc.FalseValue = false;
                gv.Columns.Add(chbc);
            }
        }

        public static void DGVValidation(DataGridView gv, bool AutoGenCol, bool RowHedVisible, bool AllowUserToAddRow, bool AllowUserToResizecol, bool AllowUserToResizeRow, bool Multiselect)
        {
            gv.AutoGenerateColumns = false;
            gv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.RowHeadersVisible = false;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.AllowUserToAddRows = false;
            gv.AllowUserToResizeColumns = false;
            gv.AllowUserToResizeRows = false;
            gv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gv.MultiSelect = false;
        }

        //public enum ArrivalStatus { Late = -1, OnTime = 0, Early = 1 };
        //public enum ArrivalStatus { Unknown = -3, Late = -1, OnTime = 0, Early = 1 };

        //public class Example
        //{
        //    public static void Main()
        //    {
        //        //int[] values = { -3, -1, 0, 1, 5, Int32.MaxValue };
        //        foreach (var value in values)
        //        {
        //            ArrivalStatus status;
        //            if (Enum.IsDefined(typeof(ArrivalStatus), value))
        //                status = (ArrivalStatus)value;
        //            else
        //                status = ArrivalStatus.Unknown;
        //            //MessageBox.Show("Converted {0:N0} to {1}", value, status);
        //        }
        //    }
        //}

        public static void ConnectionInfo(string ServerName, string Database, string UserId, string Password, ConnectionInfo con, TableLogOnInfo logoninfo)
        {
            con = logoninfo.ConnectionInfo;
            con.ServerName = ServerName;
            con.DatabaseName = Database;
            //connectionInfo.IntegratedSecurity = true;
            con.UserID = UserId;
            con.Password = Password;


            
        }

    }
}
