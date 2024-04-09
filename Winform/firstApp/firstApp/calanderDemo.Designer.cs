namespace firstApp
{
    partial class calanderDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblToDate = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.mcal1 = new System.Windows.Forms.MonthCalendar();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.lblLName = new System.Windows.Forms.Label();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.lblFname = new System.Windows.Forms.Label();
            this.lblTravelDoc = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbId = new System.Windows.Forms.RadioButton();
            this.rdbPassport = new System.Windows.Forms.RadioButton();
            this.lblDocNo = new System.Windows.Forms.Label();
            this.txtDocNo = new System.Windows.Forms.TextBox();
            this.lblIssuDate = new System.Windows.Forms.Label();
            this.dtpIssuDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpDate = new System.Windows.Forms.Label();
            this.lblBagage = new System.Windows.Forms.Label();
            this.nudBaggage = new System.Windows.Forms.NumericUpDown();
            this.btnBook = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaggage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(34, 25);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(20, 13);
            this.lblToDate.TabIndex = 0;
            this.lblToDate.Text = "To";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(68, 22);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(100, 20);
            this.txtTo.TabIndex = 1;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(238, 22);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(100, 20);
            this.txtFrom.TabIndex = 3;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(197, 27);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(30, 13);
            this.lblFromDate.TabIndex = 2;
            this.lblFromDate.Text = "From";
            // 
            // mcal1
            // 
            this.mcal1.Location = new System.Drawing.Point(68, 54);
            this.mcal1.Name = "mcal1";
            this.mcal1.TabIndex = 4;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(235, 239);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(100, 20);
            this.txtLName.TabIndex = 8;
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Location = new System.Drawing.Point(189, 243);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(42, 13);
            this.lblLName.TabIndex = 7;
            this.lblLName.Text = "L name";
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(72, 239);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(100, 20);
            this.txtFName.TabIndex = 6;
            // 
            // lblFname
            // 
            this.lblFname.AutoSize = true;
            this.lblFname.Location = new System.Drawing.Point(26, 242);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(44, 13);
            this.lblFname.TabIndex = 5;
            this.lblFname.Text = "F Name";
            // 
            // lblTravelDoc
            // 
            this.lblTravelDoc.AutoSize = true;
            this.lblTravelDoc.Location = new System.Drawing.Point(39, 284);
            this.lblTravelDoc.Name = "lblTravelDoc";
            this.lblTravelDoc.Size = new System.Drawing.Size(63, 13);
            this.lblTravelDoc.TabIndex = 9;
            this.lblTravelDoc.Text = "Travel Doc:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbId);
            this.groupBox1.Controls.Add(this.rdbPassport);
            this.groupBox1.Location = new System.Drawing.Point(108, 276);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 24);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // rdbId
            // 
            this.rdbId.AutoSize = true;
            this.rdbId.Location = new System.Drawing.Point(79, 6);
            this.rdbId.Name = "rdbId";
            this.rdbId.Size = new System.Drawing.Size(36, 17);
            this.rdbId.TabIndex = 1;
            this.rdbId.TabStop = true;
            this.rdbId.Text = "ID";
            this.rdbId.UseVisualStyleBackColor = true;
            this.rdbId.CheckedChanged += new System.EventHandler(this.rdbId_CheckedChanged);
            // 
            // rdbPassport
            // 
            this.rdbPassport.AutoSize = true;
            this.rdbPassport.Location = new System.Drawing.Point(7, 6);
            this.rdbPassport.Name = "rdbPassport";
            this.rdbPassport.Size = new System.Drawing.Size(66, 17);
            this.rdbPassport.TabIndex = 0;
            this.rdbPassport.TabStop = true;
            this.rdbPassport.Text = "Passport";
            this.rdbPassport.UseVisualStyleBackColor = true;
            this.rdbPassport.CheckedChanged += new System.EventHandler(this.rdbPassport_CheckedChanged);
            // 
            // lblDocNo
            // 
            this.lblDocNo.AutoSize = true;
            this.lblDocNo.Location = new System.Drawing.Point(34, 324);
            this.lblDocNo.Name = "lblDocNo";
            this.lblDocNo.Size = new System.Drawing.Size(68, 13);
            this.lblDocNo.TabIndex = 11;
            this.lblDocNo.Text = "Passport No:";
            // 
            // txtDocNo
            // 
            this.txtDocNo.Location = new System.Drawing.Point(103, 321);
            this.txtDocNo.Name = "txtDocNo";
            this.txtDocNo.Size = new System.Drawing.Size(100, 20);
            this.txtDocNo.TabIndex = 12;
            // 
            // lblIssuDate
            // 
            this.lblIssuDate.AutoSize = true;
            this.lblIssuDate.Location = new System.Drawing.Point(15, 365);
            this.lblIssuDate.Name = "lblIssuDate";
            this.lblIssuDate.Size = new System.Drawing.Size(55, 13);
            this.lblIssuDate.TabIndex = 13;
            this.lblIssuDate.Text = "Issu Date:";
            // 
            // dtpIssuDate
            // 
            this.dtpIssuDate.Location = new System.Drawing.Point(73, 361);
            this.dtpIssuDate.Name = "dtpIssuDate";
            this.dtpIssuDate.Size = new System.Drawing.Size(117, 20);
            this.dtpIssuDate.TabIndex = 14;
            this.dtpIssuDate.ValueChanged += new System.EventHandler(this.dtpIssuDate_ValueChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(250, 361);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(117, 20);
            this.dtpEndDate.TabIndex = 16;
            // 
            // lblExpDate
            // 
            this.lblExpDate.AutoSize = true;
            this.lblExpDate.Location = new System.Drawing.Point(196, 365);
            this.lblExpDate.Name = "lblExpDate";
            this.lblExpDate.Size = new System.Drawing.Size(57, 13);
            this.lblExpDate.TabIndex = 15;
            this.lblExpDate.Text = "Exp. Date:";
            // 
            // lblBagage
            // 
            this.lblBagage.AutoSize = true;
            this.lblBagage.Location = new System.Drawing.Point(213, 324);
            this.lblBagage.Name = "lblBagage";
            this.lblBagage.Size = new System.Drawing.Size(53, 13);
            this.lblBagage.TabIndex = 17;
            this.lblBagage.Text = "Baggage:";
            // 
            // nudBaggage
            // 
            this.nudBaggage.Location = new System.Drawing.Point(270, 320);
            this.nudBaggage.Name = "nudBaggage";
            this.nudBaggage.Size = new System.Drawing.Size(42, 20);
            this.nudBaggage.TabIndex = 18;
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(29, 408);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(338, 34);
            this.btnBook.TabIndex = 19;
            this.btnBook.Text = "Book ";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // calanderDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 449);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.nudBaggage);
            this.Controls.Add(this.lblBagage);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblExpDate);
            this.Controls.Add(this.dtpIssuDate);
            this.Controls.Add(this.lblIssuDate);
            this.Controls.Add(this.txtDocNo);
            this.Controls.Add(this.lblDocNo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTravelDoc);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.lblLName);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.lblFname);
            this.Controls.Add(this.mcal1);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.lblToDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "calanderDemo";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New";
            this.Load += new System.EventHandler(this.calanderDemo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaggage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.MonthCalendar mcal1;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Label lblFname;
        private System.Windows.Forms.Label lblTravelDoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbPassport;
        private System.Windows.Forms.RadioButton rdbId;
        private System.Windows.Forms.Label lblDocNo;
        private System.Windows.Forms.TextBox txtDocNo;
        private System.Windows.Forms.Label lblIssuDate;
        private System.Windows.Forms.DateTimePicker dtpIssuDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblExpDate;
        private System.Windows.Forms.Label lblBagage;
        private System.Windows.Forms.NumericUpDown nudBaggage;
        private System.Windows.Forms.Button btnBook;

    }
}
