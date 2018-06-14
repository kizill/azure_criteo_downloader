using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Threading;
using System.Net;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Core;
using Microsoft.WindowsAzure.Storage.Blob.Protocol;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BlobTransferUI
{
    public partial class ctlTransfer : UserControl
    {
        public event EventHandler<AsyncCompletedEventArgs> TransferCompleted;
        protected virtual void OnTransferCompleted(System.ComponentModel.AsyncCompletedEventArgs e) { if (TransferCompleted != null) TransferCompleted(this, e); }

        private string m_LocalFile;
        private string m_URL;
        private long m_FileLength;
        private CloudBlockBlob m_Blob;
        BlobTransfer blobTransfer = new BlobTransfer();

        DateTime startTime;

        public string LocalFile
        {
            get { return m_LocalFile; }
            set { m_LocalFile = value; }
        }

        public string URL
        {
            get { return m_Blob.Uri.ToString(); }
            set { m_URL = value; }
        }

        public long FileLength
        {
            get { return m_FileLength; }
            set { m_FileLength = value; lblProgress.Text = (value / 1024).ToString("N0") + " KB"; }
        }

        public CloudBlockBlob Blob
        {
            get { return m_Blob; }
            set { m_Blob = value; }
        }

        public ctlTransfer()
        {
            InitializeComponent();

            blobTransfer.TransferCompleted += new AsyncCompletedEventHandler(blobTransfer_TransferCompleted);
            blobTransfer.TransferProgressChanged += new EventHandler<BlobTransfer.BlobTransferProgressChangedEventArgs>(blobTransfer_TransferProgressChanged);
        }

        void blobTransfer_TransferProgressChanged(object sender, BlobTransfer.BlobTransferProgressChangedEventArgs e)
        {
            lblSpeed.Text = (e.Speed / 1024).ToString("N2") + "KB/s";
            lblTimeRemaining.Text = e.TimeRemaining.ToString();
            if (e.ProgressPercentage <= 100)
                progressBarDownload.Value = e.ProgressPercentage;
            else
                progressBarDownload.Value = 100;
            lblProgress.Text = (e.BytesSent / 1024).ToString("N0") + " / " + (e.TotalBytesToSend / 1024).ToString("N0") + " KB";
        }

        void blobTransfer_TransferCompleted(object sender, AsyncCompletedEventArgs e)
        {
            System.DateTime endTime = System.DateTime.Now;
            if (e.Cancelled)
            {
                progressBarDownload.Value = 0;
                lblSpeed.Text = "0";
                linklabelCancel.Text = "Cancelled";
                linklabelCancel.Enabled = false;
            }
            else if (e.Error != null)
            {
                linklabelCancel.Text = "Error";
                linklabelCancel.Enabled = false;
            }
            else
            {
                lblSpeed.Text = (((FileLength) / 1024 / (endTime - startTime).TotalSeconds)).ToString("N0") + " KB/s";
                linklabelCancel.Text = "Done";
                linklabelCancel.Enabled = false;
            }

            AsyncCompletedEventArgs args = new AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState);
            OnTransferCompleted(args);
        }

        public void Upload()
        {
            txtFrom.Text = LocalFile;
            txtTo.Text = URL;
            startTime = DateTime.Now;

            blobTransfer.UploadBlobAsync(Blob, LocalFile);
        }

        public void Download()
        {
            txtFrom.Text = URL;
            txtTo.Text = LocalFile;
            startTime = DateTime.Now;

            string Path = System.IO.Path.GetDirectoryName(LocalFile);
            if (!System.IO.Directory.Exists(Path))
            {
                System.IO.Directory.CreateDirectory(Path);
            }

            blobTransfer.DownloadBlobAsync(Blob, LocalFile);
        }

        public void Cancel()
        {
            linklabelCancel.Enabled = false;
            blobTransfer.CancelAsync();
        }

        public void SetLinkLabelText(string str)
        {
            linklabelCancel.Text = str;
        }

        private void linklabelCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linklabelCancel.Text == "Cancel")
            {
                linklabelCancel.Enabled = false;
                blobTransfer.CancelAsync();
            }
        }
    }

}
