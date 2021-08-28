
namespace HIC
{
    partial class frmHIC
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHIC));
            this.imgLifeRing = new System.Windows.Forms.PictureBox();
            this.lblWelkomText = new System.Windows.Forms.TextBox();
            this.tbxIssueDescription = new System.Windows.Forms.TextBox();
            this.cbxCallMeBack = new System.Windows.Forms.CheckBox();
            this.cbxScreenShot = new System.Windows.Forms.CheckBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tbxContactDetail = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgLifeRing)).BeginInit();
            this.SuspendLayout();
            // 
            // imgLifeRing
            // 
            this.imgLifeRing.Image = ((System.Drawing.Image)(resources.GetObject("imgLifeRing.Image")));
            this.imgLifeRing.Location = new System.Drawing.Point(13, 13);
            this.imgLifeRing.Name = "imgLifeRing";
            this.imgLifeRing.Size = new System.Drawing.Size(52, 55);
            this.imgLifeRing.TabIndex = 0;
            this.imgLifeRing.TabStop = false;
            // 
            // lblWelkomText
            // 
            this.lblWelkomText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblWelkomText.Location = new System.Drawing.Point(71, 13);
            this.lblWelkomText.Multiline = true;
            this.lblWelkomText.Name = "lblWelkomText";
            this.lblWelkomText.ReadOnly = true;
            this.lblWelkomText.Size = new System.Drawing.Size(321, 57);
            this.lblWelkomText.TabIndex = 1;
            this.lblWelkomText.TabStop = false;
            this.lblWelkomText.Text = "Please provide short description of your problem.";
            // 
            // tbxIssueDescription
            // 
            this.tbxIssueDescription.Location = new System.Drawing.Point(10, 78);
            this.tbxIssueDescription.Multiline = true;
            this.tbxIssueDescription.Name = "tbxIssueDescription";
            this.tbxIssueDescription.Size = new System.Drawing.Size(382, 196);
            this.tbxIssueDescription.TabIndex = 0;
            // 
            // cbxCallMeBack
            // 
            this.cbxCallMeBack.AutoSize = true;
            this.cbxCallMeBack.Location = new System.Drawing.Point(9, 281);
            this.cbxCallMeBack.Name = "cbxCallMeBack";
            this.cbxCallMeBack.Size = new System.Drawing.Size(171, 24);
            this.cbxCallMeBack.TabIndex = 1;
            this.cbxCallMeBack.Text = "Please contact me at:";
            this.cbxCallMeBack.UseVisualStyleBackColor = true;
            this.cbxCallMeBack.CheckedChanged += new System.EventHandler(this.cbxCallMeBack_CheckedChanged);
            // 
            // cbxScreenShot
            // 
            this.cbxScreenShot.AutoSize = true;
            this.cbxScreenShot.Location = new System.Drawing.Point(9, 311);
            this.cbxScreenShot.Name = "cbxScreenShot";
            this.cbxScreenShot.Size = new System.Drawing.Size(211, 24);
            this.cbxScreenShot.TabIndex = 3;
            this.cbxScreenShot.Text = "Attach screenshot to report";
            this.cbxScreenShot.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(6, 344);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(386, 48);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // tbxContactDetail
            // 
            this.tbxContactDetail.Enabled = false;
            this.tbxContactDetail.Location = new System.Drawing.Point(270, 280);
            this.tbxContactDetail.Name = "tbxContactDetail";
            this.tbxContactDetail.Size = new System.Drawing.Size(122, 27);
            this.tbxContactDetail.TabIndex = 2;
            this.tbxContactDetail.Text = "(xxx) xxx-xxxx";
            // 
            // frmHIC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 400);
            this.Controls.Add(this.tbxContactDetail);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cbxScreenShot);
            this.Controls.Add(this.cbxCallMeBack);
            this.Controls.Add(this.tbxIssueDescription);
            this.Controls.Add(this.lblWelkomText);
            this.Controls.Add(this.imgLifeRing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHIC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help is comming";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmHIC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLifeRing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgLifeRing;
        private System.Windows.Forms.TextBox lblWelkomText;
        private System.Windows.Forms.TextBox tbxIssueDescription;
        private System.Windows.Forms.CheckBox cbxCallMeBack;
        private System.Windows.Forms.CheckBox cbxScreenShot;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox tbxContactDetail;
    }
}

