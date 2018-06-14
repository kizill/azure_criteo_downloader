namespace BlobTransferUI
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRefreshFileTransfer = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLocalDownloadPath_FileTransfer = new System.Windows.Forms.TextBox();
            this.pictureFileTransferAnimatedLoading = new System.Windows.Forms.PictureBox();
            this.lvFileTransfer = new System.Windows.Forms.ListView();
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTransferContainer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTransferFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTransferFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTransferFileDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFindUploadFile = new System.Windows.Forms.Button();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUploadFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUploadContainer = new System.Windows.Forms.TextBox();
            this.openFileDialogUploadFile = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFileTransferAnimatedLoading)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRefreshFileTransfer);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtLocalDownloadPath_FileTransfer);
            this.groupBox2.Controls.Add(this.pictureFileTransferAnimatedLoading);
            this.groupBox2.Controls.Add(this.lvFileTransfer);
            this.groupBox2.Location = new System.Drawing.Point(12, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(788, 255);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Download";
            // 
            // btnRefreshFileTransfer
            // 
            this.btnRefreshFileTransfer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefreshFileTransfer.BackgroundImage")));
            this.btnRefreshFileTransfer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshFileTransfer.Location = new System.Drawing.Point(749, 16);
            this.btnRefreshFileTransfer.Name = "btnRefreshFileTransfer";
            this.btnRefreshFileTransfer.Size = new System.Drawing.Size(22, 20);
            this.btnRefreshFileTransfer.TabIndex = 16;
            this.btnRefreshFileTransfer.UseVisualStyleBackColor = true;
            this.btnRefreshFileTransfer.Click += new System.EventHandler(this.btnRefreshFileTransfer_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(284, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Local Download Path";
            // 
            // txtLocalDownloadPath_FileTransfer
            // 
            this.txtLocalDownloadPath_FileTransfer.Location = new System.Drawing.Point(399, 14);
            this.txtLocalDownloadPath_FileTransfer.Name = "txtLocalDownloadPath_FileTransfer";
            this.txtLocalDownloadPath_FileTransfer.Size = new System.Drawing.Size(318, 20);
            this.txtLocalDownloadPath_FileTransfer.TabIndex = 13;
            this.txtLocalDownloadPath_FileTransfer.Text = "C:\\Downloads";
            // 
            // pictureFileTransferAnimatedLoading
            // 
            this.pictureFileTransferAnimatedLoading.Image = ((System.Drawing.Image)(resources.GetObject("pictureFileTransferAnimatedLoading.Image")));
            this.pictureFileTransferAnimatedLoading.Location = new System.Drawing.Point(723, 14);
            this.pictureFileTransferAnimatedLoading.Name = "pictureFileTransferAnimatedLoading";
            this.pictureFileTransferAnimatedLoading.Size = new System.Drawing.Size(20, 20);
            this.pictureFileTransferAnimatedLoading.TabIndex = 7;
            this.pictureFileTransferAnimatedLoading.TabStop = false;
            this.pictureFileTransferAnimatedLoading.Visible = false;
            // 
            // lvFileTransfer
            // 
            this.lvFileTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFileTransfer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnStatus,
            this.columnTransferContainer,
            this.columnTransferFileName,
            this.columnTransferFileSize,
            this.columnTransferFileDate});
            this.lvFileTransfer.FullRowSelect = true;
            this.lvFileTransfer.Location = new System.Drawing.Point(9, 40);
            this.lvFileTransfer.Name = "lvFileTransfer";
            this.lvFileTransfer.Size = new System.Drawing.Size(763, 209);
            this.lvFileTransfer.SmallImageList = this.imageList1;
            this.lvFileTransfer.TabIndex = 1;
            this.lvFileTransfer.UseCompatibleStateImageBehavior = false;
            this.lvFileTransfer.View = System.Windows.Forms.View.Details;
            this.lvFileTransfer.DoubleClick += new System.EventHandler(this.lvFileTransferDownload_DoubleClick);
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            // 
            // columnTransferContainer
            // 
            this.columnTransferContainer.Text = "Container";
            this.columnTransferContainer.Width = 112;
            // 
            // columnTransferFileName
            // 
            this.columnTransferFileName.Text = "File Name";
            this.columnTransferFileName.Width = 307;
            // 
            // columnTransferFileSize
            // 
            this.columnTransferFileSize.Text = "Size (KB)";
            this.columnTransferFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnTransferFileSize.Width = 80;
            // 
            // columnTransferFileDate
            // 
            this.columnTransferFileDate.Text = "Date Uploaded";
            this.columnTransferFileDate.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindUploadFile);
            this.groupBox1.Controls.Add(this.btnUploadFile);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUploadFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUploadContainer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 75);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Upload";
            // 
            // btnFindUploadFile
            // 
            this.btnFindUploadFile.Location = new System.Drawing.Point(750, 19);
            this.btnFindUploadFile.Name = "btnFindUploadFile";
            this.btnFindUploadFile.Size = new System.Drawing.Size(22, 20);
            this.btnFindUploadFile.TabIndex = 1;
            this.btnFindUploadFile.Text = "...";
            this.btnFindUploadFile.UseVisualStyleBackColor = true;
            this.btnFindUploadFile.Click += new System.EventHandler(this.btnFindUploadFile_Click);
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Location = new System.Drawing.Point(693, 47);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(79, 23);
            this.btnUploadFile.TabIndex = 5;
            this.btnUploadFile.Text = "Upload";
            this.btnUploadFile.UseVisualStyleBackColor = true;
            this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "File";
            // 
            // txtUploadFile
            // 
            this.txtUploadFile.Location = new System.Drawing.Point(94, 19);
            this.txtUploadFile.Name = "txtUploadFile";
            this.txtUploadFile.Size = new System.Drawing.Size(650, 20);
            this.txtUploadFile.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Container";
            // 
            // txtUploadContainer
            // 
            this.txtUploadContainer.Location = new System.Drawing.Point(94, 47);
            this.txtUploadContainer.Name = "txtUploadContainer";
            this.txtUploadContainer.Size = new System.Drawing.Size(130, 20);
            this.txtUploadContainer.TabIndex = 2;
            this.txtUploadContainer.Text = "temp";
            // 
            // openFileDialogUploadFile
            // 
            this.openFileDialogUploadFile.FileName = "openFileDialog1";
            this.openFileDialogUploadFile.InitialDirectory = "C:\\";
            this.openFileDialogUploadFile.RestoreDirectory = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(21, 368);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(782, 296);
            this.flowLayoutPanel1.TabIndex = 17;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(802, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Transfer Progress";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Downloading");
            this.imageList1.Images.SetKeyName(1, "Finished");
            this.imageList1.Images.SetKeyName(2, "AnimatedLoading");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 676);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFileTransferAnimatedLoading)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLocalDownloadPath_FileTransfer;
        private System.Windows.Forms.PictureBox pictureFileTransferAnimatedLoading;
        private System.Windows.Forms.ListView lvFileTransfer;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.ColumnHeader columnTransferContainer;
        private System.Windows.Forms.ColumnHeader columnTransferFileName;
        private System.Windows.Forms.ColumnHeader columnTransferFileSize;
        private System.Windows.Forms.ColumnHeader columnTransferFileDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFindUploadFile;
        private System.Windows.Forms.Button btnUploadFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUploadFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUploadContainer;
        private System.Windows.Forms.Button btnRefreshFileTransfer;
        private System.Windows.Forms.OpenFileDialog openFileDialogUploadFile;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
    }
}

