namespace firstApp
{
    partial class firstPage
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.chkName = new System.Windows.Forms.CheckBox();
            this.chkPass = new System.Windows.Forms.CheckBox();
            this.lblNameShow = new System.Windows.Forms.Label();
            this.lblPassShow = new System.Windows.Forms.Label();
            this.btnDemo = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnCalDemo = new System.Windows.Forms.Button();
            this.btnClinic = new System.Windows.Forms.Button();
            this.btnListDemo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 29);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(101, 29);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(100, 67);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(100, 20);
            this.txtPass.TabIndex = 3;
            this.txtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass_KeyPress);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(12, 67);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(53, 13);
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "Password";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(12, 159);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(53, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(86, 159);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(57, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.Location = new System.Drawing.Point(71, 103);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(54, 17);
            this.chkName.TabIndex = 6;
            this.chkName.Text = "Name";
            this.chkName.UseVisualStyleBackColor = true;
            this.chkName.CheckedChanged += new System.EventHandler(this.chkName_CheckedChanged);
            // 
            // chkPass
            // 
            this.chkPass.AutoSize = true;
            this.chkPass.Location = new System.Drawing.Point(71, 126);
            this.chkPass.Name = "chkPass";
            this.chkPass.Size = new System.Drawing.Size(49, 17);
            this.chkPass.TabIndex = 7;
            this.chkPass.Text = "Pass";
            this.chkPass.UseVisualStyleBackColor = true;
            this.chkPass.CheckedChanged += new System.EventHandler(this.chkPass_CheckedChanged);
            // 
            // lblNameShow
            // 
            this.lblNameShow.AutoSize = true;
            this.lblNameShow.Location = new System.Drawing.Point(145, 103);
            this.lblNameShow.Name = "lblNameShow";
            this.lblNameShow.Size = new System.Drawing.Size(69, 13);
            this.lblNameShow.TabIndex = 8;
            this.lblNameShow.Text = "Not Selected";
            // 
            // lblPassShow
            // 
            this.lblPassShow.AutoSize = true;
            this.lblPassShow.Location = new System.Drawing.Point(145, 127);
            this.lblPassShow.Name = "lblPassShow";
            this.lblPassShow.Size = new System.Drawing.Size(69, 13);
            this.lblPassShow.TabIndex = 9;
            this.lblPassShow.Text = "Not Selected";
            // 
            // btnDemo
            // 
            this.btnDemo.Location = new System.Drawing.Point(160, 159);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(61, 23);
            this.btnDemo.TabIndex = 10;
            this.btnDemo.Text = "Reset";
            this.btnDemo.UseVisualStyleBackColor = true;
            this.btnDemo.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(13, 192);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(27, 13);
            this.lblMsg.TabIndex = 11;
            this.lblMsg.Text = "Msg";
            // 
            // btnCalDemo
            // 
            this.btnCalDemo.Location = new System.Drawing.Point(116, 214);
            this.btnCalDemo.Name = "btnCalDemo";
            this.btnCalDemo.Size = new System.Drawing.Size(107, 23);
            this.btnCalDemo.TabIndex = 12;
            this.btnCalDemo.Text = "Go to Cal Demo";
            this.btnCalDemo.UseVisualStyleBackColor = true;
            this.btnCalDemo.Click += new System.EventHandler(this.btnCalDemo_Click);
            // 
            // btnClinic
            // 
            this.btnClinic.Location = new System.Drawing.Point(16, 214);
            this.btnClinic.Name = "btnClinic";
            this.btnClinic.Size = new System.Drawing.Size(94, 23);
            this.btnClinic.TabIndex = 13;
            this.btnClinic.Text = "Go to Clinic Demo";
            this.btnClinic.UseVisualStyleBackColor = true;
            this.btnClinic.Click += new System.EventHandler(this.btnClinic_Click);
            // 
            // btnListDemo
            // 
            this.btnListDemo.Location = new System.Drawing.Point(16, 243);
            this.btnListDemo.Name = "btnListDemo";
            this.btnListDemo.Size = new System.Drawing.Size(94, 23);
            this.btnListDemo.TabIndex = 14;
            this.btnListDemo.Text = "Go List Demo";
            this.btnListDemo.UseVisualStyleBackColor = true;
            this.btnListDemo.Click += new System.EventHandler(this.btnListDemo_Click);
            // 
            // firstPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 282);
            this.Controls.Add(this.btnListDemo);
            this.Controls.Add(this.btnClinic);
            this.Controls.Add(this.btnCalDemo);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnDemo);
            this.Controls.Add(this.lblPassShow);
            this.Controls.Add(this.lblNameShow);
            this.Controls.Add(this.chkPass);
            this.Controls.Add(this.chkName);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "firstPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "App 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox chkName;
        private System.Windows.Forms.CheckBox chkPass;
        private System.Windows.Forms.Label lblNameShow;
        private System.Windows.Forms.Label lblPassShow;
        private System.Windows.Forms.Button btnDemo;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnCalDemo;
        private System.Windows.Forms.Button btnClinic;
        private System.Windows.Forms.Button btnListDemo;
    }
}

