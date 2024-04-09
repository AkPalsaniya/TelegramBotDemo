namespace WindowsFormsApplication1
{
    partial class frmVendorDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.cbVendorNo = new System.Windows.Forms.ComboBox();
            this.gbDebitDetails = new System.Windows.Forms.GroupBox();
            this.txtDebitAmount = new System.Windows.Forms.TextBox();
            this.btnDebit = new System.Windows.Forms.Button();
            this.txtInputDebit = new System.Windows.Forms.TextBox();
            this.btnSattle = new System.Windows.Forms.Button();
            this.txtCreditAmount = new System.Windows.Forms.TextBox();
            this.cbVendorName = new System.Windows.Forms.ComboBox();
            this.gbCreditDetails = new System.Windows.Forms.GroupBox();
            this.btnCredit = new System.Windows.Forms.Button();
            this.txtInputCredit = new System.Windows.Forms.TextBox();
            this.gbVendorDetails = new System.Windows.Forms.GroupBox();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.lblVendorNo = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.gbDebitDetails.SuspendLayout();
            this.gbCreditDetails.SuspendLayout();
            this.gbVendorDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbVendorNo
            // 
            this.cbVendorNo.FormattingEnabled = true;
            this.cbVendorNo.Location = new System.Drawing.Point(90, 32);
            this.cbVendorNo.Name = "cbVendorNo";
            this.cbVendorNo.Size = new System.Drawing.Size(205, 21);
            this.cbVendorNo.TabIndex = 0;
            this.cbVendorNo.SelectedIndexChanged += new System.EventHandler(this.cbVendorNo_SelectedIndexChanged);
            // 
            // gbDebitDetails
            // 
            this.gbDebitDetails.Controls.Add(this.txtDebitAmount);
            this.gbDebitDetails.Controls.Add(this.btnDebit);
            this.gbDebitDetails.Controls.Add(this.txtInputDebit);
            this.gbDebitDetails.Location = new System.Drawing.Point(12, 216);
            this.gbDebitDetails.Name = "gbDebitDetails";
            this.gbDebitDetails.Size = new System.Drawing.Size(309, 100);
            this.gbDebitDetails.TabIndex = 10;
            this.gbDebitDetails.TabStop = false;
            this.gbDebitDetails.Text = "Debit Details";
            // 
            // txtDebitAmount
            // 
            this.txtDebitAmount.Location = new System.Drawing.Point(23, 32);
            this.txtDebitAmount.Name = "txtDebitAmount";
            this.txtDebitAmount.Size = new System.Drawing.Size(171, 20);
            this.txtDebitAmount.TabIndex = 6;
            // 
            // btnDebit
            // 
            this.btnDebit.Location = new System.Drawing.Point(208, 51);
            this.btnDebit.Name = "btnDebit";
            this.btnDebit.Size = new System.Drawing.Size(84, 32);
            this.btnDebit.TabIndex = 5;
            this.btnDebit.Text = "&Debit";
            this.btnDebit.UseVisualStyleBackColor = true;
            this.btnDebit.Click += new System.EventHandler(this.btnDebit_Click);
            // 
            // txtInputDebit
            // 
            this.txtInputDebit.Location = new System.Drawing.Point(23, 58);
            this.txtInputDebit.Name = "txtInputDebit";
            this.txtInputDebit.Size = new System.Drawing.Size(171, 20);
            this.txtInputDebit.TabIndex = 4;
            this.txtInputDebit.Leave += new System.EventHandler(this.txtInputDebit_Leave);
            this.txtInputDebit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputDebit_KeyPress);
            // 
            // btnSattle
            // 
            this.btnSattle.Location = new System.Drawing.Point(144, 328);
            this.btnSattle.Name = "btnSattle";
            this.btnSattle.Size = new System.Drawing.Size(84, 32);
            this.btnSattle.TabIndex = 11;
            this.btnSattle.Text = "&Settle";
            this.btnSattle.UseVisualStyleBackColor = true;
            this.btnSattle.Click += new System.EventHandler(this.btnSattle_Click);
            // 
            // txtCreditAmount
            // 
            this.txtCreditAmount.Location = new System.Drawing.Point(23, 31);
            this.txtCreditAmount.Name = "txtCreditAmount";
            this.txtCreditAmount.Size = new System.Drawing.Size(171, 20);
            this.txtCreditAmount.TabIndex = 4;
            // 
            // cbVendorName
            // 
            this.cbVendorName.FormattingEnabled = true;
            this.cbVendorName.Location = new System.Drawing.Point(90, 59);
            this.cbVendorName.Name = "cbVendorName";
            this.cbVendorName.Size = new System.Drawing.Size(205, 21);
            this.cbVendorName.TabIndex = 3;
            // 
            // gbCreditDetails
            // 
            this.gbCreditDetails.Controls.Add(this.txtCreditAmount);
            this.gbCreditDetails.Controls.Add(this.btnCredit);
            this.gbCreditDetails.Controls.Add(this.txtInputCredit);
            this.gbCreditDetails.Location = new System.Drawing.Point(12, 110);
            this.gbCreditDetails.Name = "gbCreditDetails";
            this.gbCreditDetails.Size = new System.Drawing.Size(309, 100);
            this.gbCreditDetails.TabIndex = 9;
            this.gbCreditDetails.TabStop = false;
            this.gbCreditDetails.Text = "Credit Details";
            // 
            // btnCredit
            // 
            this.btnCredit.Location = new System.Drawing.Point(208, 50);
            this.btnCredit.Name = "btnCredit";
            this.btnCredit.Size = new System.Drawing.Size(84, 32);
            this.btnCredit.TabIndex = 3;
            this.btnCredit.Text = "&Credit";
            this.btnCredit.UseVisualStyleBackColor = true;
            this.btnCredit.Click += new System.EventHandler(this.btnCredit_Click);
            // 
            // txtInputCredit
            // 
            this.txtInputCredit.Location = new System.Drawing.Point(23, 57);
            this.txtInputCredit.Name = "txtInputCredit";
            this.txtInputCredit.Size = new System.Drawing.Size(171, 20);
            this.txtInputCredit.TabIndex = 2;
            this.txtInputCredit.Leave += new System.EventHandler(this.txtInputCredit_Leave);
            this.txtInputCredit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputCredit_KeyPress);
            // 
            // gbVendorDetails
            // 
            this.gbVendorDetails.Controls.Add(this.cbVendorName);
            this.gbVendorDetails.Controls.Add(this.lblVendorName);
            this.gbVendorDetails.Controls.Add(this.lblVendorNo);
            this.gbVendorDetails.Controls.Add(this.cbVendorNo);
            this.gbVendorDetails.Location = new System.Drawing.Point(12, 7);
            this.gbVendorDetails.Name = "gbVendorDetails";
            this.gbVendorDetails.Size = new System.Drawing.Size(309, 97);
            this.gbVendorDetails.TabIndex = 8;
            this.gbVendorDetails.TabStop = false;
            this.gbVendorDetails.Text = "Vendor Details";
            // 
            // lblVendorName
            // 
            this.lblVendorName.AutoSize = true;
            this.lblVendorName.Location = new System.Drawing.Point(6, 62);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(78, 13);
            this.lblVendorName.TabIndex = 2;
            this.lblVendorName.Text = "Vendor Name :";
            // 
            // lblVendorNo
            // 
            this.lblVendorNo.AutoSize = true;
            this.lblVendorNo.Location = new System.Drawing.Point(20, 35);
            this.lblVendorNo.Name = "lblVendorNo";
            this.lblVendorNo.Size = new System.Drawing.Size(64, 13);
            this.lblVendorNo.TabIndex = 1;
            this.lblVendorNo.Text = "Vendor No :";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(237, 328);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(84, 32);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmVendorDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 369);
            this.Controls.Add(this.gbDebitDetails);
            this.Controls.Add(this.btnSattle);
            this.Controls.Add(this.gbCreditDetails);
            this.Controls.Add(this.gbVendorDetails);
            this.Controls.Add(this.btnExit);
            this.Name = "frmVendorDetails";
            this.Text = "Vendor Details";
            this.Load += new System.EventHandler(this.frmVendorDetails_Load);
            this.gbDebitDetails.ResumeLayout(false);
            this.gbDebitDetails.PerformLayout();
            this.gbCreditDetails.ResumeLayout(false);
            this.gbCreditDetails.PerformLayout();
            this.gbVendorDetails.ResumeLayout(false);
            this.gbVendorDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbVendorNo;
        private System.Windows.Forms.GroupBox gbDebitDetails;
        private System.Windows.Forms.TextBox txtDebitAmount;
        private System.Windows.Forms.Button btnDebit;
        private System.Windows.Forms.TextBox txtInputDebit;
        private System.Windows.Forms.Button btnSattle;
        private System.Windows.Forms.TextBox txtCreditAmount;
        private System.Windows.Forms.ComboBox cbVendorName;
        private System.Windows.Forms.GroupBox gbCreditDetails;
        private System.Windows.Forms.Button btnCredit;
        private System.Windows.Forms.TextBox txtInputCredit;
        private System.Windows.Forms.GroupBox gbVendorDetails;
        private System.Windows.Forms.Label lblVendorName;
        private System.Windows.Forms.Label lblVendorNo;
        private System.Windows.Forms.Button btnExit;


    }
}