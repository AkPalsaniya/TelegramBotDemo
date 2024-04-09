namespace firstApp
{
    partial class clinicDemo
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
            this.cbClinicName = new System.Windows.Forms.ComboBox();
            this.lblSelectClinic = new System.Windows.Forms.Label();
            this.lblClinicName = new System.Windows.Forms.Label();
            this.lblclinicId = new System.Windows.Forms.Label();
            this.lblCliRatting = new System.Windows.Forms.Label();
            this.lblCliAdd = new System.Windows.Forms.Label();
            this.lblDrAdd = new System.Windows.Forms.Label();
            this.lblDrId = new System.Windows.Forms.Label();
            this.lblDrName = new System.Windows.Forms.Label();
            this.lblSelectDr = new System.Windows.Forms.Label();
            this.cbDrName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbClinicName
            // 
            this.cbClinicName.FormattingEnabled = true;
            this.cbClinicName.Location = new System.Drawing.Point(39, 29);
            this.cbClinicName.Name = "cbClinicName";
            this.cbClinicName.Size = new System.Drawing.Size(121, 21);
            this.cbClinicName.TabIndex = 0;
            this.cbClinicName.SelectedIndexChanged += new System.EventHandler(this.cbClinicName_SelectedIndexChanged);
            // 
            // lblSelectClinic
            // 
            this.lblSelectClinic.AutoSize = true;
            this.lblSelectClinic.Location = new System.Drawing.Point(39, 10);
            this.lblSelectClinic.Name = "lblSelectClinic";
            this.lblSelectClinic.Size = new System.Drawing.Size(94, 13);
            this.lblSelectClinic.TabIndex = 1;
            this.lblSelectClinic.Text = "Select Cinic Name";
            // 
            // lblClinicName
            // 
            this.lblClinicName.AutoSize = true;
            this.lblClinicName.Location = new System.Drawing.Point(41, 101);
            this.lblClinicName.Name = "lblClinicName";
            this.lblClinicName.Size = new System.Drawing.Size(63, 13);
            this.lblClinicName.TabIndex = 2;
            this.lblClinicName.Text = "Clinic Name";
            // 
            // lblclinicId
            // 
            this.lblclinicId.AutoSize = true;
            this.lblclinicId.Location = new System.Drawing.Point(41, 78);
            this.lblclinicId.Name = "lblclinicId";
            this.lblclinicId.Size = new System.Drawing.Size(43, 13);
            this.lblclinicId.TabIndex = 3;
            this.lblclinicId.Text = "clinic Id";
            // 
            // lblCliRatting
            // 
            this.lblCliRatting.AutoSize = true;
            this.lblCliRatting.Location = new System.Drawing.Point(40, 152);
            this.lblCliRatting.Name = "lblCliRatting";
            this.lblCliRatting.Size = new System.Drawing.Size(69, 13);
            this.lblCliRatting.TabIndex = 5;
            this.lblCliRatting.Text = "Clinic Ratting";
            // 
            // lblCliAdd
            // 
            this.lblCliAdd.AutoSize = true;
            this.lblCliAdd.Location = new System.Drawing.Point(40, 126);
            this.lblCliAdd.Name = "lblCliAdd";
            this.lblCliAdd.Size = new System.Drawing.Size(74, 13);
            this.lblCliAdd.TabIndex = 4;
            this.lblCliAdd.Text = "Clininc Addres";
            // 
            // lblDrAdd
            // 
            this.lblDrAdd.AutoSize = true;
            this.lblDrAdd.Location = new System.Drawing.Point(237, 126);
            this.lblDrAdd.Name = "lblDrAdd";
            this.lblDrAdd.Size = new System.Drawing.Size(74, 13);
            this.lblDrAdd.TabIndex = 10;
            this.lblDrAdd.Text = "Clininc Addres";
            // 
            // lblDrId
            // 
            this.lblDrId.AutoSize = true;
            this.lblDrId.Location = new System.Drawing.Point(238, 78);
            this.lblDrId.Name = "lblDrId";
            this.lblDrId.Size = new System.Drawing.Size(43, 13);
            this.lblDrId.TabIndex = 9;
            this.lblDrId.Text = "clinic Id";
            // 
            // lblDrName
            // 
            this.lblDrName.AutoSize = true;
            this.lblDrName.Location = new System.Drawing.Point(238, 101);
            this.lblDrName.Name = "lblDrName";
            this.lblDrName.Size = new System.Drawing.Size(63, 13);
            this.lblDrName.TabIndex = 8;
            this.lblDrName.Text = "Clinic Name";
            // 
            // lblSelectDr
            // 
            this.lblSelectDr.AutoSize = true;
            this.lblSelectDr.Location = new System.Drawing.Point(236, 10);
            this.lblSelectDr.Name = "lblSelectDr";
            this.lblSelectDr.Size = new System.Drawing.Size(79, 13);
            this.lblSelectDr.TabIndex = 7;
            this.lblSelectDr.Text = "SelectDr Name";
            // 
            // cbDrName
            // 
            this.cbDrName.FormattingEnabled = true;
            this.cbDrName.Location = new System.Drawing.Point(236, 29);
            this.cbDrName.Name = "cbDrName";
            this.cbDrName.Size = new System.Drawing.Size(121, 21);
            this.cbDrName.TabIndex = 6;
            this.cbDrName.SelectedIndexChanged += new System.EventHandler(this.cbDrName_SelectedIndexChanged);
            // 
            // clinicDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 283);
            this.Controls.Add(this.lblDrAdd);
            this.Controls.Add(this.lblDrId);
            this.Controls.Add(this.lblDrName);
            this.Controls.Add(this.lblSelectDr);
            this.Controls.Add(this.cbDrName);
            this.Controls.Add(this.lblCliRatting);
            this.Controls.Add(this.lblCliAdd);
            this.Controls.Add(this.lblclinicId);
            this.Controls.Add(this.lblClinicName);
            this.Controls.Add(this.lblSelectClinic);
            this.Controls.Add(this.cbClinicName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "clinicDemo";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.Load += new System.EventHandler(this.clinicDemo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbClinicName;
        private System.Windows.Forms.Label lblSelectClinic;
        private System.Windows.Forms.Label lblClinicName;
        private System.Windows.Forms.Label lblclinicId;
        private System.Windows.Forms.Label lblCliRatting;
        private System.Windows.Forms.Label lblCliAdd;
        private System.Windows.Forms.Label lblDrAdd;
        private System.Windows.Forms.Label lblDrId;
        private System.Windows.Forms.Label lblDrName;
        private System.Windows.Forms.Label lblSelectDr;
        private System.Windows.Forms.ComboBox cbDrName;

    }
}
