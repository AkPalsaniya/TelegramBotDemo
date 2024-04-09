namespace myChatBot
{
    partial class chatPage
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
            this.lblHeading = new System.Windows.Forms.Label();
            this.rtxtConvHistory = new System.Windows.Forms.RichTextBox();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.lblAskSomthing = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.grpControl = new System.Windows.Forms.GroupBox();
            this.grpControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.BackColor = System.Drawing.Color.White;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(115, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(307, 36);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "LET\'S CHAT WITH ME";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rtxtConvHistory
            // 
            this.rtxtConvHistory.Location = new System.Drawing.Point(12, 68);
            this.rtxtConvHistory.Name = "rtxtConvHistory";
            this.rtxtConvHistory.ReadOnly = true;
            this.rtxtConvHistory.Size = new System.Drawing.Size(535, 262);
            this.rtxtConvHistory.TabIndex = 1;
            this.rtxtConvHistory.Text = "";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuestion.Location = new System.Drawing.Point(149, 18);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(262, 21);
            this.txtQuestion.TabIndex = 2;
            //this.txtQuestion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuestion_KeyPress);
            // 
            // lblAskSomthing
            // 
            this.lblAskSomthing.AutoSize = true;
            this.lblAskSomthing.BackColor = System.Drawing.Color.DarkCyan;
            this.lblAskSomthing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAskSomthing.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblAskSomthing.Location = new System.Drawing.Point(13, 18);
            this.lblAskSomthing.Name = "lblAskSomthing";
            this.lblAskSomthing.Size = new System.Drawing.Size(130, 20);
            this.lblAskSomthing.TabIndex = 3;
            this.lblAskSomthing.Text = "Ask Somthing :";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(417, 17);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(102, 22);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.txtQuestion);
            this.grpControl.Controls.Add(this.btnSubmit);
            this.grpControl.Controls.Add(this.lblAskSomthing);
            this.grpControl.Location = new System.Drawing.Point(12, 336);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(535, 52);
            this.grpControl.TabIndex = 5;
            this.grpControl.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(567, 399);
            this.Controls.Add(this.grpControl);
            this.Controls.Add(this.rtxtConvHistory);
            this.Controls.Add(this.lblHeading);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grpControl.ResumeLayout(false);
            this.grpControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.RichTextBox rtxtConvHistory;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label lblAskSomthing;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox grpControl;
    }
}

