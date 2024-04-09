namespace WindowsFormsApplication1
{
    partial class frmPurchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchase));
            this.imgRightLogo = new System.Windows.Forms.PictureBox();
            this.gbBillDetails = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cbPNo = new System.Windows.Forms.ComboBox();
            this.cbPInvoiceNo = new System.Windows.Forms.ComboBox();
            this.lblPInvoiceNo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.cbSupplierNo = new System.Windows.Forms.ComboBox();
            this.CbSupplierName = new System.Windows.Forms.ComboBox();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblSupplierNo = new System.Windows.Forms.Label();
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
            this.gvPurchaseMaster = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.gvPurchaseMaster)).BeginInit();
            this.gbControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgRightLogo
            // 
            this.imgRightLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgRightLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgRightLogo.Image")));
            this.imgRightLogo.Location = new System.Drawing.Point(648, 13);
            this.imgRightLogo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.imgRightLogo.Name = "imgRightLogo";
            this.imgRightLogo.Size = new System.Drawing.Size(148, 117);
            this.imgRightLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgRightLogo.TabIndex = 65;
            this.imgRightLogo.TabStop = false;
            // 
            // gbBillDetails
            // 
            this.gbBillDetails.Controls.Add(this.linkLabel1);
            this.gbBillDetails.Controls.Add(this.cbPNo);
            this.gbBillDetails.Controls.Add(this.cbPInvoiceNo);
            this.gbBillDetails.Controls.Add(this.lblPInvoiceNo);
            this.gbBillDetails.Controls.Add(this.lblDate);
            this.gbBillDetails.Controls.Add(this.cbSupplierNo);
            this.gbBillDetails.Controls.Add(this.CbSupplierName);
            this.gbBillDetails.Controls.Add(this.lblSupplierName);
            this.gbBillDetails.Controls.Add(this.dtpDate);
            this.gbBillDetails.Controls.Add(this.lblSupplierNo);
            this.gbBillDetails.Location = new System.Drawing.Point(16, 6);
            this.gbBillDetails.Name = "gbBillDetails";
            this.gbBillDetails.Size = new System.Drawing.Size(626, 126);
            this.gbBillDetails.TabIndex = 58;
            this.gbBillDetails.TabStop = false;
            this.gbBillDetails.Text = "Bill Details";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(35, 90);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(63, 15);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "P Ord No :";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cbPNo
            // 
            this.cbPNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPNo.FormattingEnabled = true;
            this.cbPNo.Location = new System.Drawing.Point(104, 86);
            this.cbPNo.Name = "cbPNo";
            this.cbPNo.Size = new System.Drawing.Size(140, 24);
            this.cbPNo.TabIndex = 8;
            this.cbPNo.SelectedIndexChanged += new System.EventHandler(this.cbPNo_SelectedIndexChanged);
            // 
            // cbPInvoiceNo
            // 
            this.cbPInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPInvoiceNo.FormattingEnabled = true;
            this.cbPInvoiceNo.Location = new System.Drawing.Point(104, 53);
            this.cbPInvoiceNo.Name = "cbPInvoiceNo";
            this.cbPInvoiceNo.Size = new System.Drawing.Size(140, 24);
            this.cbPInvoiceNo.TabIndex = 2;
            this.cbPInvoiceNo.SelectedIndexChanged += new System.EventHandler(this.cbPInvoiceNo_SelectedIndexChanged);
            this.cbPInvoiceNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPInvoiceNo_KeyDown);
            // 
            // lblPInvoiceNo
            // 
            this.lblPInvoiceNo.AutoSize = true;
            this.lblPInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPInvoiceNo.Location = new System.Drawing.Point(11, 57);
            this.lblPInvoiceNo.Name = "lblPInvoiceNo";
            this.lblPInvoiceNo.Size = new System.Drawing.Size(87, 16);
            this.lblPInvoiceNo.TabIndex = 36;
            this.lblPInvoiceNo.Text = "PInvoice No :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(325, 56);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(43, 16);
            this.lblDate.TabIndex = 37;
            this.lblDate.Text = "Date :";
            // 
            // cbSupplierNo
            // 
            this.cbSupplierNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSupplierNo.FormattingEnabled = true;
            this.cbSupplierNo.Location = new System.Drawing.Point(104, 20);
            this.cbSupplierNo.Name = "cbSupplierNo";
            this.cbSupplierNo.Size = new System.Drawing.Size(140, 24);
            this.cbSupplierNo.TabIndex = 0;
            // 
            // CbSupplierName
            // 
            this.CbSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbSupplierName.FormattingEnabled = true;
            this.CbSupplierName.Location = new System.Drawing.Point(374, 21);
            this.CbSupplierName.Name = "CbSupplierName";
            this.CbSupplierName.Size = new System.Drawing.Size(234, 24);
            this.CbSupplierName.TabIndex = 1;
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierName.Location = new System.Drawing.Point(264, 25);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(104, 16);
            this.lblSupplierName.TabIndex = 5;
            this.lblSupplierName.Text = "Supplier Name :";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(374, 53);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(170, 22);
            this.dtpDate.TabIndex = 3;
            // 
            // lblSupplierNo
            // 
            this.lblSupplierNo.AutoSize = true;
            this.lblSupplierNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierNo.Location = new System.Drawing.Point(13, 24);
            this.lblSupplierNo.Name = "lblSupplierNo";
            this.lblSupplierNo.Size = new System.Drawing.Size(85, 16);
            this.lblSupplierNo.TabIndex = 43;
            this.lblSupplierNo.Text = "Supplier No :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Location = new System.Drawing.Point(632, 480);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 107);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Print";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(38, 30);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(82, 32);
            this.btnPrint.TabIndex = 0;
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
            this.gbDiscount.Location = new System.Drawing.Point(435, 480);
            this.gbDiscount.Name = "gbDiscount";
            this.gbDiscount.Size = new System.Drawing.Size(189, 107);
            this.gbDiscount.TabIndex = 61;
            this.gbDiscount.TabStop = false;
            this.gbDiscount.Text = "Discount";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(81, 60);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(98, 23);
            this.cbType.TabIndex = 1;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(32, 63);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(39, 15);
            this.lblType.TabIndex = 11;
            this.lblType.Text = "Type :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Discount :";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(82, 30);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(97, 21);
            this.txtDiscount.TabIndex = 0;
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            // 
            // gbNavigation
            // 
            this.gbNavigation.Controls.Add(this.btnFirst);
            this.gbNavigation.Controls.Add(this.btnLast);
            this.gbNavigation.Controls.Add(this.btnNext);
            this.gbNavigation.Controls.Add(this.btnPervious);
            this.gbNavigation.Location = new System.Drawing.Point(16, 480);
            this.gbNavigation.Name = "gbNavigation";
            this.gbNavigation.Size = new System.Drawing.Size(204, 107);
            this.gbNavigation.TabIndex = 64;
            this.gbNavigation.TabStop = false;
            this.gbNavigation.Text = "Navigation";
            // 
            // btnFirst
            // 
            this.btnFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.Location = new System.Drawing.Point(9, 62);
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
            this.btnLast.Location = new System.Drawing.Point(110, 61);
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
            this.btnNext.Location = new System.Drawing.Point(110, 21);
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
            this.btnPervious.Location = new System.Drawing.Point(9, 21);
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
            this.groupBox2.Location = new System.Drawing.Point(17, 422);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(772, 58);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            // 
            // txtTaxpercent
            // 
            this.txtTaxpercent.Location = new System.Drawing.Point(343, 22);
            this.txtTaxpercent.Name = "txtTaxpercent";
            this.txtTaxpercent.Size = new System.Drawing.Size(67, 21);
            this.txtTaxpercent.TabIndex = 18;
            this.txtTaxpercent.Leave += new System.EventHandler(this.txtTaxpercent_Leave);
            this.txtTaxpercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaxpercent_KeyPress);
            // 
            // cbTaxGroupNo
            // 
            this.cbTaxGroupNo.FormattingEnabled = true;
            this.cbTaxGroupNo.ItemHeight = 15;
            this.cbTaxGroupNo.Location = new System.Drawing.Point(118, 20);
            this.cbTaxGroupNo.Name = "cbTaxGroupNo";
            this.cbTaxGroupNo.Size = new System.Drawing.Size(73, 23);
            this.cbTaxGroupNo.TabIndex = 0;
            this.cbTaxGroupNo.SelectedIndexChanged += new System.EventHandler(this.cbTaxGroupNo_SelectedIndexChanged);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(665, 20);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(96, 22);
            this.txtTotalAmount.TabIndex = 9;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(574, 23);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(85, 15);
            this.lblTotalAmount.TabIndex = 17;
            this.lblTotalAmount.Text = "Total Amount :";
            // 
            // LblDiscount
            // 
            this.LblDiscount.AutoSize = true;
            this.LblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDiscount.Location = new System.Drawing.Point(419, 24);
            this.LblDiscount.Name = "LblDiscount";
            this.LblDiscount.Size = new System.Drawing.Size(61, 15);
            this.LblDiscount.TabIndex = 16;
            this.LblDiscount.Text = "Discount :";
            // 
            // txtDisc
            // 
            this.txtDisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisc.Location = new System.Drawing.Point(487, 21);
            this.txtDisc.Name = "txtDisc";
            this.txtDisc.Size = new System.Drawing.Size(78, 21);
            this.txtDisc.TabIndex = 8;
            // 
            // cbTaxGroupName
            // 
            this.cbTaxGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTaxGroupName.FormattingEnabled = true;
            this.cbTaxGroupName.Location = new System.Drawing.Point(197, 20);
            this.cbTaxGroupName.Name = "cbTaxGroupName";
            this.cbTaxGroupName.Size = new System.Drawing.Size(140, 23);
            this.cbTaxGroupName.TabIndex = 1;
            // 
            // lblTaxGroupName
            // 
            this.lblTaxGroupName.AutoSize = true;
            this.lblTaxGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxGroupName.Location = new System.Drawing.Point(7, 24);
            this.lblTaxGroupName.Name = "lblTaxGroupName";
            this.lblTaxGroupName.Size = new System.Drawing.Size(104, 15);
            this.lblTaxGroupName.TabIndex = 11;
            this.lblTaxGroupName.Text = "TaxGroup Name :";
            // 
            // gbPurchaseDetails
            // 
            this.gbPurchaseDetails.Controls.Add(this.gvPurchaseMaster);
            this.gbPurchaseDetails.Location = new System.Drawing.Point(17, 133);
            this.gbPurchaseDetails.Name = "gbPurchaseDetails";
            this.gbPurchaseDetails.Size = new System.Drawing.Size(784, 293);
            this.gbPurchaseDetails.TabIndex = 59;
            this.gbPurchaseDetails.TabStop = false;
            this.gbPurchaseDetails.Text = "Purchase Details";
            // 
            // gvPurchaseMaster
            // 
            this.gvPurchaseMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPurchaseMaster.Location = new System.Drawing.Point(17, 21);
            this.gvPurchaseMaster.Name = "gvPurchaseMaster";
            this.gvPurchaseMaster.Size = new System.Drawing.Size(755, 258);
            this.gvPurchaseMaster.TabIndex = 0;
            this.gvPurchaseMaster.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPurchaseMaster_CellEndEdit);
            this.gvPurchaseMaster.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvPurchaseMaster_EditingControlShowing);
            this.gvPurchaseMaster.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvPurchaseMaster_DataError);
            this.gvPurchaseMaster.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvPurchaseMaster_KeyDown);
            this.gvPurchaseMaster.Layout += new System.Windows.Forms.LayoutEventHandler(this.gvPurchaseMaster_Layout);
            this.gvPurchaseMaster.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPurchaseMaster_CellContentClick);
            // 
            // gbControls
            // 
            this.gbControls.Controls.Add(this.btnExit);
            this.gbControls.Controls.Add(this.btnDelete);
            this.gbControls.Location = new System.Drawing.Point(227, 480);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(200, 107);
            this.gbControls.TabIndex = 63;
            this.gbControls.TabStop = false;
            this.gbControls.Text = "Controls";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(107, 38);
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
            this.btnDelete.Location = new System.Drawing.Point(9, 38);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 32);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 592);
            this.Controls.Add(this.imgRightLogo);
            this.Controls.Add(this.gbBillDetails);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbDiscount);
            this.Controls.Add(this.gbNavigation);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbPurchaseDetails);
            this.Controls.Add(this.gbControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPurchase";
            this.Text = "Purchase Master";
            this.Load += new System.EventHandler(this.frmPurchase_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.gvPurchaseMaster)).EndInit();
            this.gbControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgRightLogo;
        private System.Windows.Forms.GroupBox gbBillDetails;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox cbPNo;
        private System.Windows.Forms.ComboBox cbPInvoiceNo;
        private System.Windows.Forms.Label lblPInvoiceNo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cbSupplierNo;
        private System.Windows.Forms.ComboBox CbSupplierName;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblSupplierNo;
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
        private System.Windows.Forms.DataGridView gvPurchaseMaster;
        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;

    }
}