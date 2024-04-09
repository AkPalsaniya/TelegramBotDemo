namespace WindowsFormsApplication1
{
    partial class frmSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSales));
            this.imgRightLogo = new System.Windows.Forms.PictureBox();
            this.gbBillDetails = new System.Windows.Forms.GroupBox();
            this.lnkInvoiceNo = new System.Windows.Forms.LinkLabel();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.cbPrefix = new System.Windows.Forms.ComboBox();
            this.cbSInvoiceNo = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.cbCustomerNo = new System.Windows.Forms.ComboBox();
            this.CbCustomerName = new System.Windows.Forms.ComboBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblCustomerNo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.gbDiscount = new System.Windows.Forms.GroupBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.gbNavigation = new System.Windows.Forms.GroupBox();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPervious = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTaxpercent = new System.Windows.Forms.TextBox();
            this.cbTaxGroupNo = new System.Windows.Forms.ComboBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.LblDiscount = new System.Windows.Forms.Label();
            this.txtDisc = new System.Windows.Forms.TextBox();
            this.cbTaxGroupName = new System.Windows.Forms.ComboBox();
            this.lblTaxGroupName = new System.Windows.Forms.Label();
            this.gbPurchaseDetails = new System.Windows.Forms.GroupBox();
            this.gvSalesMaster = new System.Windows.Forms.DataGridView();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgRightLogo)).BeginInit();
            this.gbBillDetails.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbDiscount.SuspendLayout();
            this.gbNavigation.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbPurchaseDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSalesMaster)).BeginInit();
            this.gbControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgRightLogo
            // 
            this.imgRightLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgRightLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgRightLogo.Image")));
            this.imgRightLogo.Location = new System.Drawing.Point(620, 15);
            this.imgRightLogo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.imgRightLogo.Name = "imgRightLogo";
            this.imgRightLogo.Size = new System.Drawing.Size(119, 116);
            this.imgRightLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgRightLogo.TabIndex = 57;
            this.imgRightLogo.TabStop = false;
            // 
            // gbBillDetails
            // 
            this.gbBillDetails.Controls.Add(this.lnkInvoiceNo);
            this.gbBillDetails.Controls.Add(this.lblPrefix);
            this.gbBillDetails.Controls.Add(this.cbPrefix);
            this.gbBillDetails.Controls.Add(this.cbSInvoiceNo);
            this.gbBillDetails.Controls.Add(this.lblDate);
            this.gbBillDetails.Controls.Add(this.cbCustomerNo);
            this.gbBillDetails.Controls.Add(this.CbCustomerName);
            this.gbBillDetails.Controls.Add(this.lblCustomerName);
            this.gbBillDetails.Controls.Add(this.dtpDate);
            this.gbBillDetails.Controls.Add(this.lblCustomerNo);
            this.gbBillDetails.Location = new System.Drawing.Point(14, 7);
            this.gbBillDetails.Name = "gbBillDetails";
            this.gbBillDetails.Size = new System.Drawing.Size(610, 125);
            this.gbBillDetails.TabIndex = 50;
            this.gbBillDetails.TabStop = false;
            this.gbBillDetails.Text = "Bill Details";
            // 
            // lnkInvoiceNo
            // 
            this.lnkInvoiceNo.AutoSize = true;
            this.lnkInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkInvoiceNo.Location = new System.Drawing.Point(18, 89);
            this.lnkInvoiceNo.Name = "lnkInvoiceNo";
            this.lnkInvoiceNo.Size = new System.Drawing.Size(78, 16);
            this.lnkInvoiceNo.TabIndex = 3;
            this.lnkInvoiceNo.TabStop = true;
            this.lnkInvoiceNo.Text = "Invoice No :";
            this.lnkInvoiceNo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkInvoiceNo_LinkClicked);
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrefix.Location = new System.Drawing.Point(49, 56);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(47, 16);
            this.lblPrefix.TabIndex = 46;
            this.lblPrefix.Text = "Prefix :";
            // 
            // cbPrefix
            // 
            this.cbPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPrefix.FormattingEnabled = true;
            this.cbPrefix.Location = new System.Drawing.Point(102, 53);
            this.cbPrefix.Name = "cbPrefix";
            this.cbPrefix.Size = new System.Drawing.Size(140, 24);
            this.cbPrefix.TabIndex = 7;
            // 
            // cbSInvoiceNo
            // 
            this.cbSInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSInvoiceNo.FormattingEnabled = true;
            this.cbSInvoiceNo.Location = new System.Drawing.Point(102, 85);
            this.cbSInvoiceNo.Name = "cbSInvoiceNo";
            this.cbSInvoiceNo.Size = new System.Drawing.Size(140, 24);
            this.cbSInvoiceNo.TabIndex = 4;
            this.cbSInvoiceNo.SelectedIndexChanged += new System.EventHandler(this.cbSInvoiceNo_SelectedIndexChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(329, 59);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(43, 16);
            this.lblDate.TabIndex = 37;
            this.lblDate.Text = "Date :";
            // 
            // cbCustomerNo
            // 
            this.cbCustomerNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomerNo.FormattingEnabled = true;
            this.cbCustomerNo.Location = new System.Drawing.Point(102, 20);
            this.cbCustomerNo.Name = "cbCustomerNo";
            this.cbCustomerNo.Size = new System.Drawing.Size(140, 24);
            this.cbCustomerNo.TabIndex = 0;
            // 
            // CbCustomerName
            // 
            this.CbCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbCustomerName.FormattingEnabled = true;
            this.CbCustomerName.Location = new System.Drawing.Point(378, 20);
            this.CbCustomerName.Name = "CbCustomerName";
            this.CbCustomerName.Size = new System.Drawing.Size(219, 24);
            this.CbCustomerName.TabIndex = 1;
            this.CbCustomerName.SelectedIndexChanged += new System.EventHandler(this.CbCustomerName_SelectedIndexChanged);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(261, 24);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(111, 16);
            this.lblCustomerName.TabIndex = 44;
            this.lblCustomerName.Text = "Customer Name :";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(378, 55);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(164, 22);
            this.dtpDate.TabIndex = 2;
            // 
            // lblCustomerNo
            // 
            this.lblCustomerNo.AutoSize = true;
            this.lblCustomerNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerNo.Location = new System.Drawing.Point(4, 23);
            this.lblCustomerNo.Name = "lblCustomerNo";
            this.lblCustomerNo.Size = new System.Drawing.Size(92, 16);
            this.lblCustomerNo.TabIndex = 43;
            this.lblCustomerNo.Text = "Customer No :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Location = new System.Drawing.Point(616, 465);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 102);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(11, 26);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(82, 32);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "&Save";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gbDiscount
            // 
            this.gbDiscount.Controls.Add(this.cbType);
            this.gbDiscount.Controls.Add(this.lblType);
            this.gbDiscount.Controls.Add(this.label1);
            this.gbDiscount.Controls.Add(this.txtDiscount);
            this.gbDiscount.Location = new System.Drawing.Point(421, 465);
            this.gbDiscount.Name = "gbDiscount";
            this.gbDiscount.Size = new System.Drawing.Size(190, 102);
            this.gbDiscount.TabIndex = 55;
            this.gbDiscount.TabStop = false;
            this.gbDiscount.Text = "Discount";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(78, 58);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(100, 23);
            this.cbType.TabIndex = 12;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(29, 61);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(39, 15);
            this.lblType.TabIndex = 11;
            this.lblType.Text = "Type :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Discount :";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(79, 28);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(99, 21);
            this.txtDiscount.TabIndex = 0;
            // 
            // gbNavigation
            // 
            this.gbNavigation.Controls.Add(this.btnFirst);
            this.gbNavigation.Controls.Add(this.btnLast);
            this.gbNavigation.Controls.Add(this.btnNext);
            this.gbNavigation.Controls.Add(this.btnPervious);
            this.gbNavigation.Location = new System.Drawing.Point(14, 464);
            this.gbNavigation.Name = "gbNavigation";
            this.gbNavigation.Size = new System.Drawing.Size(201, 102);
            this.gbNavigation.TabIndex = 54;
            this.gbNavigation.TabStop = false;
            this.gbNavigation.Text = "Navigation";
            // 
            // btnFirst
            // 
            this.btnFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.Location = new System.Drawing.Point(10, 58);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(82, 32);
            this.btnFirst.TabIndex = 3;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnLast
            // 
            this.btnLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.Location = new System.Drawing.Point(111, 57);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(82, 32);
            this.btnLast.TabIndex = 4;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(111, 20);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(82, 32);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPervious
            // 
            this.btnPervious.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPervious.Location = new System.Drawing.Point(10, 20);
            this.btnPervious.Name = "btnPervious";
            this.btnPervious.Size = new System.Drawing.Size(82, 32);
            this.btnPervious.TabIndex = 1;
            this.btnPervious.Text = "<";
            this.btnPervious.UseVisualStyleBackColor = true;
            this.btnPervious.Click += new System.EventHandler(this.btnPervious_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTaxpercent);
            this.groupBox2.Controls.Add(this.cbTaxGroupNo);
            this.groupBox2.Controls.Add(this.txtTotalAmount);
            this.groupBox2.Controls.Add(this.lblTotalAmount);
            this.groupBox2.Controls.Add(this.LblDiscount);
            this.groupBox2.Controls.Add(this.txtDisc);
            this.groupBox2.Controls.Add(this.cbTaxGroupName);
            this.groupBox2.Controls.Add(this.lblTaxGroupName);
            this.groupBox2.Location = new System.Drawing.Point(14, 412);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(709, 53);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            // 
            // txtTaxpercent
            // 
            this.txtTaxpercent.Location = new System.Drawing.Point(297, 18);
            this.txtTaxpercent.Name = "txtTaxpercent";
            this.txtTaxpercent.Size = new System.Drawing.Size(67, 21);
            this.txtTaxpercent.TabIndex = 19;
            this.txtTaxpercent.Leave += new System.EventHandler(this.txtTaxpercent_Leave);
            this.txtTaxpercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaxpercent_KeyPress);
            // 
            // cbTaxGroupNo
            // 
            this.cbTaxGroupNo.FormattingEnabled = true;
            this.cbTaxGroupNo.ItemHeight = 15;
            this.cbTaxGroupNo.Location = new System.Drawing.Point(118, 17);
            this.cbTaxGroupNo.Name = "cbTaxGroupNo";
            this.cbTaxGroupNo.Size = new System.Drawing.Size(58, 23);
            this.cbTaxGroupNo.TabIndex = 5;
            this.cbTaxGroupNo.SelectedIndexChanged += new System.EventHandler(this.cbTaxGroupNo_SelectedIndexChanged);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(591, 16);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(106, 22);
            this.txtTotalAmount.TabIndex = 9;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(500, 19);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(85, 15);
            this.lblTotalAmount.TabIndex = 17;
            this.lblTotalAmount.Text = "Total Amount :";
            // 
            // LblDiscount
            // 
            this.LblDiscount.AutoSize = true;
            this.LblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDiscount.Location = new System.Drawing.Point(369, 20);
            this.LblDiscount.Name = "LblDiscount";
            this.LblDiscount.Size = new System.Drawing.Size(61, 15);
            this.LblDiscount.TabIndex = 16;
            this.LblDiscount.Text = "Discount :";
            // 
            // txtDisc
            // 
            this.txtDisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisc.Location = new System.Drawing.Point(431, 17);
            this.txtDisc.Name = "txtDisc";
            this.txtDisc.Size = new System.Drawing.Size(64, 21);
            this.txtDisc.TabIndex = 8;
            this.txtDisc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDisc_KeyPress);
            // 
            // cbTaxGroupName
            // 
            this.cbTaxGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTaxGroupName.FormattingEnabled = true;
            this.cbTaxGroupName.Location = new System.Drawing.Point(182, 17);
            this.cbTaxGroupName.Name = "cbTaxGroupName";
            this.cbTaxGroupName.Size = new System.Drawing.Size(109, 23);
            this.cbTaxGroupName.TabIndex = 6;
            // 
            // lblTaxGroupName
            // 
            this.lblTaxGroupName.AutoSize = true;
            this.lblTaxGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxGroupName.Location = new System.Drawing.Point(7, 21);
            this.lblTaxGroupName.Name = "lblTaxGroupName";
            this.lblTaxGroupName.Size = new System.Drawing.Size(104, 15);
            this.lblTaxGroupName.TabIndex = 11;
            this.lblTaxGroupName.Text = "TaxGroup Name :";
            // 
            // gbPurchaseDetails
            // 
            this.gbPurchaseDetails.Controls.Add(this.gvSalesMaster);
            this.gbPurchaseDetails.Location = new System.Drawing.Point(14, 139);
            this.gbPurchaseDetails.Name = "gbPurchaseDetails";
            this.gbPurchaseDetails.Size = new System.Drawing.Size(723, 273);
            this.gbPurchaseDetails.TabIndex = 52;
            this.gbPurchaseDetails.TabStop = false;
            this.gbPurchaseDetails.Text = "Sales Details";
            // 
            // gvSalesMaster
            // 
            this.gvSalesMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSalesMaster.Location = new System.Drawing.Point(17, 18);
            this.gvSalesMaster.Name = "gvSalesMaster";
            this.gvSalesMaster.Size = new System.Drawing.Size(692, 245);
            this.gvSalesMaster.TabIndex = 0;
            this.gvSalesMaster.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSalesMaster_CellEndEdit);
            this.gvSalesMaster.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvSalesMaster_EditingControlShowing);
            this.gvSalesMaster.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvSalesMaster_DataError);
            this.gvSalesMaster.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvSalesMaster_KeyDown);
            this.gvSalesMaster.Layout += new System.Windows.Forms.LayoutEventHandler(this.gvSalesMaster_Layout);
            // 
            // gbControls
            // 
            this.gbControls.Controls.Add(this.btnExit);
            this.gbControls.Controls.Add(this.btnDelete);
            this.gbControls.Location = new System.Drawing.Point(221, 465);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(194, 102);
            this.gbControls.TabIndex = 51;
            this.gbControls.TabStop = false;
            this.gbControls.Text = "Controls";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(106, 35);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 32);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(6, 35);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 32);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 574);
            this.Controls.Add(this.imgRightLogo);
            this.Controls.Add(this.gbBillDetails);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbDiscount);
            this.Controls.Add(this.gbNavigation);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbPurchaseDetails);
            this.Controls.Add(this.gbControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmSales";
            this.Text = "Sales Master";
            this.Load += new System.EventHandler(this.frmSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgRightLogo)).EndInit();
            this.gbBillDetails.ResumeLayout(false);
            this.gbBillDetails.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.gbDiscount.ResumeLayout(false);
            this.gbDiscount.PerformLayout();
            this.gbNavigation.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbPurchaseDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSalesMaster)).EndInit();
            this.gbControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgRightLogo;
        private System.Windows.Forms.GroupBox gbBillDetails;
        private System.Windows.Forms.LinkLabel lnkInvoiceNo;
        private System.Windows.Forms.Label lblPrefix;
        private System.Windows.Forms.ComboBox cbPrefix;
        private System.Windows.Forms.ComboBox cbSInvoiceNo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cbCustomerNo;
        private System.Windows.Forms.ComboBox CbCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblCustomerNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox gbDiscount;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.GroupBox gbNavigation;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPervious;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTaxpercent;
        private System.Windows.Forms.ComboBox cbTaxGroupNo;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label LblDiscount;
        private System.Windows.Forms.TextBox txtDisc;
        private System.Windows.Forms.ComboBox cbTaxGroupName;
        private System.Windows.Forms.Label lblTaxGroupName;
        private System.Windows.Forms.GroupBox gbPurchaseDetails;
        private System.Windows.Forms.DataGridView gvSalesMaster;
        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;

    }
}