namespace firstApp
{
    partial class home
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblYourname = new System.Windows.Forms.Label();
            this.lblYourPass = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNameSelected = new System.Windows.Forms.Label();
            this.lblSelectedName = new System.Windows.Forms.Label();
            this.lblPassSelected = new System.Windows.Forms.Label();
            this.lblSelectedPass = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(85, 51);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "Name";
            // 
            // lblYourname
            // 
            this.lblYourname.AutoSize = true;
            this.lblYourname.Location = new System.Drawing.Point(178, 51);
            this.lblYourname.Name = "lblYourname";
            this.lblYourname.Size = new System.Drawing.Size(58, 13);
            this.lblYourname.TabIndex = 12;
            this.lblYourname.Text = "Your name";
            // 
            // lblYourPass
            // 
            this.lblYourPass.AutoSize = true;
            this.lblYourPass.Location = new System.Drawing.Point(178, 88);
            this.lblYourPass.Name = "lblYourPass";
            this.lblYourPass.Size = new System.Drawing.Size(55, 13);
            this.lblYourPass.TabIndex = 14;
            this.lblYourPass.Text = "Your Pass";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(85, 88);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(35, 13);
            this.lblPass.TabIndex = 13;
            this.lblPass.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Selected items";
            // 
            // lblNameSelected
            // 
            this.lblNameSelected.AutoSize = true;
            this.lblNameSelected.Location = new System.Drawing.Point(178, 187);
            this.lblNameSelected.Name = "lblNameSelected";
            this.lblNameSelected.Size = new System.Drawing.Size(14, 13);
            this.lblNameSelected.TabIndex = 17;
            this.lblNameSelected.Text = "X";
            // 
            // lblSelectedName
            // 
            this.lblSelectedName.AutoSize = true;
            this.lblSelectedName.Location = new System.Drawing.Point(85, 187);
            this.lblSelectedName.Name = "lblSelectedName";
            this.lblSelectedName.Size = new System.Drawing.Size(35, 13);
            this.lblSelectedName.TabIndex = 16;
            this.lblSelectedName.Text = "Name";
            // 
            // lblPassSelected
            // 
            this.lblPassSelected.AutoSize = true;
            this.lblPassSelected.Location = new System.Drawing.Point(178, 212);
            this.lblPassSelected.Name = "lblPassSelected";
            this.lblPassSelected.Size = new System.Drawing.Size(14, 13);
            this.lblPassSelected.TabIndex = 19;
            this.lblPassSelected.Text = "X";
            // 
            // lblSelectedPass
            // 
            this.lblSelectedPass.AutoSize = true;
            this.lblSelectedPass.Location = new System.Drawing.Point(85, 212);
            this.lblSelectedPass.Name = "lblSelectedPass";
            this.lblSelectedPass.Size = new System.Drawing.Size(30, 13);
            this.lblSelectedPass.TabIndex = 18;
            this.lblSelectedPass.Text = "Pass";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(90, 6);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(30, 13);
            this.lblTime.TabIndex = 20;
            this.lblTime.Text = "Time";
            // 
            // dtpTime
            // 
            this.dtpTime.Location = new System.Drawing.Point(166, 6);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(200, 20);
            this.dtpTime.TabIndex = 21;
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 283);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblPassSelected);
            this.Controls.Add(this.lblSelectedPass);
            this.Controls.Add(this.lblNameSelected);
            this.Controls.Add(this.lblSelectedName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblYourPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblYourname);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "home";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "home";
            this.Load += new System.EventHandler(this.home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblYourname;
        private System.Windows.Forms.Label lblYourPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNameSelected;
        private System.Windows.Forms.Label lblSelectedName;
        private System.Windows.Forms.Label lblPassSelected;
        private System.Windows.Forms.Label lblSelectedPass;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.DateTimePicker dtpTime;


    }
}
