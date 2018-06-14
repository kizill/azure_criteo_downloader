using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System.Diagnostics;
using System.IO;

namespace BlobTransferUI
{
    public partial class Form1 : Form
    {
        const string ACCOUNTNAME = "ENTER ACCOUNT NAME";
        const string ACCOUNTKEY = "ENTER ACCOUNT KEY";
        const string CONTAINER = "filetransfer";

        public delegate void AddFileTransferDelegate(CloudBlob b);
        public delegate void FinishedLoadingFileTransferDelegate();

        private bool boolLoadingFileTransfer = false;

        private static CloudStorageAccount AccountFileTransfer;
        private static CloudBlobClient BlobClientFileTransfer;
        private static CloudBlobContainer ContainerFileTransfer;

        // Keep track of active transfers so they can be cancelled when the form is shut down.
        private List<ctlTransfer> ActiveTransfers = new List<ctlTransfer>();

        public Form1()
        {
            // Increase # of simultaneous downloads from the default limit of 2
            // Set this to the (approximate number of simultaneous transfers you expect to perform) * 10 + buffer for other work such as getting blob attributes, getting list of blobs, etc
            // Alternatively, track how many simultanous transfers are being performed and call set this to the appropriate value prior to starting a new transfer.
            System.Net.ServicePointManager.DefaultConnectionLimit = 35;

            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Refresh();

            AccountFileTransfer = CloudStorageAccount.Parse("DefaultEndpointsProtocol=http;AccountName=" + ACCOUNTNAME + ";AccountKey=" + ACCOUNTKEY);
            if (AccountFileTransfer != null)
            {
                BlobClientFileTransfer = AccountFileTransfer.CreateCloudBlobClient();
                ContainerFileTransfer = BlobClientFileTransfer.GetContainerReference(CONTAINER);
                ContainerFileTransfer.CreateIfNotExist();
            }

            GetFileTransferAsync();
        }

        // Add file entry to the listview
        private void AddFileTransfer(CloudBlob b)
        {
            //string DecodedPath = System.Web.HttpUtility.UrlDecode(b.Uri.AbsolutePath);

            FileTransfer file = new FileTransfer();
            file.Blob = b;
            file.Container = b.Parent.Uri.ToString().Substring(b.Container.Uri.ToString().Length + 1).TrimEnd('/');
            file.FileName = System.IO.Path.GetFileName(b.Uri.AbsolutePath);

            ListViewItem lvi = lvFileTransfer.Items.Add("");
            lvi.Tag = file;
            lvi.SubItems.Add(file.Container);
            lvi.SubItems.Add(file.FileName);
            lvi.SubItems.Add((b.Properties.Length / 1024).ToString("N0"));
            lvi.SubItems.Add(file.Blob.Attributes.Properties.LastModifiedUtc.ToLocalTime().ToString());

            file.lvi = lvi;
        }

        // Get a list of all files in the container
        private void GetFileTransferAsync()
        {
            // There are better ways of locking than using a bool, but this is quick and simple for this non-essential scenario and doesn't cause any blocking of the main thread.
            if (boolLoadingFileTransfer)
            {
                return;
            }
            else
            {
                boolLoadingFileTransfer = true;
            }
            pictureFileTransferAnimatedLoading.Visible = true;
            lvFileTransfer.Items.Clear();
            ResultContinuation continuation = null;
            BlobRequestOptions options = new BlobRequestOptions();
            options.UseFlatBlobListing = true;
            ContainerFileTransfer.BeginListBlobsSegmented(5, continuation, options, new AsyncCallback(ListFileTransferCallback), null);
        }

        // Callback for the segmented file listing in order to continue listing segments
        private void ListFileTransferCallback(IAsyncResult result)
        {
            ResultSegment<IListBlobItem> list = ContainerFileTransfer.EndListBlobsSegmented(result);

            foreach (CloudBlob b in list.Results)
            {
                this.Invoke(new AddFileTransferDelegate(this.AddFileTransfer), new object[] { b });
            }

            if (list.ContinuationToken != null)
            {
                BlobRequestOptions options = new BlobRequestOptions();
                options.UseFlatBlobListing = true;
                ContainerFileTransfer.BeginListBlobsSegmented(5, list.ContinuationToken, options, new AsyncCallback(ListFileTransferCallback), null);
            }
            else
            {
                this.Invoke(new FinishedLoadingFileTransferDelegate(FinishedLoadingFileTransfer));
            }
        }

        private void FinishedLoadingFileTransfer()
        {
            boolLoadingFileTransfer = false;
            pictureFileTransferAnimatedLoading.Visible = false;
        }

        // Download a file
        private void DownloadFileTransfer(FileTransfer file)
        {
            string folder;
            ctlTransfer TransferFile;

            TransferFile = new ctlTransfer();
            file.Blob.FetchAttributes();
            folder = txtLocalDownloadPath_FileTransfer.Text;
            folder = System.IO.Path.Combine(folder, file.Container);
            TransferFile.LocalFile = System.IO.Path.Combine(folder, System.IO.Path.GetFileName(file.Blob.Uri.AbsolutePath));
            TransferFile.FileLength = file.Blob.Attributes.Properties.Length;
            TransferFile.TransferCompleted += new EventHandler<AsyncCompletedEventArgs>(FileTransfer_DownloadCompleted);
            TransferFile.Tag = file.lvi;
            TransferFile.Blob = file.Blob;
            flowLayoutPanel1.Controls.Add(TransferFile);
            flowLayoutPanel1.ScrollControlIntoView(TransferFile);
            TransferFile.Download();
            ActiveTransfers.Add(TransferFile);

            file.lvi.ImageKey = "Downloading";
        }

        // Upload a file
        private void UploadFileTransfer(string File)
        {
            if (txtUploadContainer.Text == "")
            {
                MessageBox.Show("Enter a container (usually your alias)");
                return;
            }

            txtUploadContainer.Text = txtUploadContainer.Text.Replace("\\", "/");

            CloudBlob blob = ContainerFileTransfer.GetBlobReference(txtUploadContainer.Text + "/" + System.IO.Path.GetFileName(File));

            ctlTransfer UploadFile = new ctlTransfer();
            UploadFile.Blob = blob;
            UploadFile.URL = blob.Uri.AbsoluteUri;
            UploadFile.LocalFile = File;
            UploadFile.FileLength = new System.IO.FileInfo(File).Length;
            UploadFile.TransferCompleted += new EventHandler<AsyncCompletedEventArgs>(UploadFile_UploadCompleted);
            flowLayoutPanel1.Controls.Add(UploadFile);
            flowLayoutPanel1.ScrollControlIntoView(UploadFile);
            UploadFile.Upload();
            ActiveTransfers.Add(UploadFile);
        }

        void FileTransfer_DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ActiveTransfers.Remove(sender as ctlTransfer);
            if (e.Cancelled)
            {
                return;
            }
            else if (e.Error != null)
            {
                return;
            }
            else
            {
            }

            ListViewItem lvi = (sender as ctlTransfer).Tag as ListViewItem;
            lvi.ImageKey = "Finished";
            lvi.Text = "";
        }

        private void btnRefreshFileTransfer_Click(object sender, EventArgs e)
        {
            GetFileTransferAsync();
        }

        private void btnFindUploadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialogUploadFile.ShowDialog() == DialogResult.OK)
            {
                txtUploadFile.Text = openFileDialogUploadFile.FileName;
                openFileDialogUploadFile.InitialDirectory = System.IO.Path.GetDirectoryName(openFileDialogUploadFile.FileName);
            }
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(txtUploadFile.Text))
            {
                MessageBox.Show("Not a valid file");
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(txtUploadFile.Text, FileMode.Open, FileAccess.Read)) { }
            }
            catch (System.UnauthorizedAccessException)
            {
                MessageBox.Show("UnauthorizedAccessException: Unable to read " + txtUploadFile.Text);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            UploadFileTransfer(txtUploadFile.Text);
        }

        void UploadFile_UploadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ActiveTransfers.Remove(sender as ctlTransfer);

            if (e.Error != null)
            {
            }
            else if (e.Cancelled)
            {
            }
            else
            {
                GetFileTransferAsync();
            }
        }

        private void lvFileTransferDownload_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvFileTransfer.SelectedItems)
            {
                DownloadFileTransfer(lvi.Tag as FileTransfer);
                lvi.ImageKey = "Downloading";
            }
        }

        private void cboStorageLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFileTransferAsync();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (ctlTransfer c in ActiveTransfers)
            {
                c.Cancel();
            }
        }
    }

    public class ItemBase
    {
        private CloudBlob m_Blob;
        private System.Windows.Forms.ListViewItem m_lvi;

        public CloudBlob Blob
        {
            get { return m_Blob; }
            set { m_Blob = value; }
        }

        public System.Windows.Forms.ListViewItem lvi
        {
            get { return m_lvi; }
            set { m_lvi = value; }
        }
    }

    public class FileTransfer : ItemBase
    {
        private string m_FileName;
        private string m_Container;

        public string FileName
        {
            get { return m_FileName; }
            set { m_FileName = value; }
        }

        public string Container
        {
            get { return m_Container; }
            set { m_Container = value; }
        }
    }
}
