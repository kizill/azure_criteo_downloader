namespace BlobTransferUI
{
    partial class ctlTransfer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBarDownload = new System.Windows.Forms.ProgressBar();
            this.linklabelCancel = new System.Windows.Forms.LinkLabel();
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(40, 3);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(269, 20);
            this.txtFrom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(40, 29);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(269, 20);
            this.txtTo.TabIndex = 2;
            // 
            // lblSpeed
            // 
            this.lblSpeed.Location = new System.Drawing.Point(584, 32);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(105, 13);
            this.lblSpeed.TabIndex = 14;
            this.lblSpeed.Text = "0";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(372, 10);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(151, 13);
            this.lblProgress.TabIndex = 13;
            this.lblProgress.Text = "0";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(540, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Speed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Progress";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBarDownload
            // 
            this.progressBarDownload.Location = new System.Drawing.Point(543, 6);
            this.progressBarDownload.Name = "progressBarDownload";
            this.progressBarDownload.Size = new System.Drawing.Size(144, 20);
            this.progressBarDownload.TabIndex = 10;
            // 
            // linklabelCancel
            // 
            this.linklabelCancel.AutoSize = true;
            this.linklabelCancel.Location = new System.Drawing.Point(709, 23);
            this.linklabelCancel.Name = "linklabelCancel";
            this.linklabelCancel.Size = new System.Drawing.Size(40, 13);
            this.linklabelCancel.TabIndex = 16;
            this.linklabelCancel.TabStop = true;
            this.linklabelCancel.Text = "Cancel";
            this.linklabelCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabelCancel_LinkClicked);
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.Location = new System.Drawing.Point(404, 32);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(119, 13);
            this.lblTimeRemaining.TabIndex = 18;
            this.lblTimeRemaining.Text = "0";
            this.lblTimeRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Time Remaining";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctlTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblTimeRemaining);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.linklabelCancel);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBarDownload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFrom);
            this.Name = "ctlTransfer";
            this.Size = new System.Drawing.Size(761, 53);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBarDownload;
        private System.Windows.Forms.LinkLabel linklabelCancel;
        private System.Windows.Forms.Label lblTimeRemaining;
        private System.Windows.Forms.Label label6;
    }
}
