using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Diagnostics;
using System.IO;

namespace BlobTransferUI
{
    public partial class Form1 : Form
    {
        const string CONTAINER = "criteo"; 
        const string BASE_URI = "http://azuremlsampleexperiments.blob.core.windows.net/";

        public delegate void AddFileTransferDelegate(CloudBlockBlob b);
        public delegate void FinishedLoadingFileTransferDelegate();

        private bool boolLoadingFileTransfer = false;

        private static CloudStorageAccount AccountFileTransfer;
        private static CloudBlobClient BlobClientFileTransfer;
        private static CloudBlobContainer ContainerFileTransfer;
        private OperationContext ListCtx;

        // Keep track of active transfers so they can be cancelled when the form is shut down.
        private List<ctlTransfer> ActiveTransfers = new List<ctlTransfer>();

        public Form1()
        {
            // Increase # of simultaneous downloads from the default limit of 2
            // Set this to the (approximate number of simultaneous transfers you expect to perform) * 10 + buffer for other work such as getting blob attributes, getting list of blobs, etc
            // Alternatively, track how many simultanous transfers are being performed and call set this to the appropriate value prior to starting a new transfer.
            System.Net.ServicePointManager.DefaultConnectionLimit = 35;

            InitializeComponent();
            ListCtx = new OperationContext();
        }

        /*
         * CloudStorageAccount storageAccount = CloudStorageAccount.Parse("My connection string");
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("ARCS.TXT");
            using (var fileStream = System.IO.File.OpenWrite(@"c:\a\ARCS.txt"))
            {
                blockBlob.DownloadToStream(fileStream);
            }
*/
        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Refresh();

            /*if (AccountFileTransfer != null)
            {*/
            BlobClientFileTransfer = new CloudBlobClient(new System.Uri(BASE_URI));
            ContainerFileTransfer = BlobClientFileTransfer.GetContainerReference("criteo");
            
            GetFileTransferAsync();
        }

        // Add file entry to the listview
        private void AddFileTransfer(CloudBlockBlob b)
        {
            //string DecodedPath = System.Web.HttpUtility.UrlDecode(b.Uri.AbsolutePath);

            FileTransfer file = new FileTransfer();
            file.Blob = b;
            file.Container = "criteo";
            file.FileName = System.IO.Path.GetFileName(b.Uri.AbsolutePath);

            ListViewItem lvi = lvFileTransfer.Items.Add("");
            lvi.Tag = file;
            lvi.SubItems.Add(file.Container);
            lvi.SubItems.Add(file.FileName);
            lvi.SubItems.Add((b.Properties.Length / 1024).ToString("N0"));
            if (file.Blob.Properties.LastModified.HasValue)
            {
                lvi.SubItems.Add(file.Blob.Properties.LastModified.Value.ToLocalTime().ToString());
            } else
            {
                lvi.SubItems.Add("NOPE");
            }

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
                pictureFileTransferAnimatedLoading.Visible = true;
                lvFileTransfer.Items.Clear();
                boolLoadingFileTransfer = true;
                for (int i = 0; i <= 23; ++i)
                {
                    var fname = String.Format("day_{0}.gz", i);
                    CloudBlockBlob blockBlob = ContainerFileTransfer.GetBlockBlobReference(fname);
                    AddFileTransfer(blockBlob);
                }
                return;
            }
            
            BlobContinuationToken continuation = null;
            BlobRequestOptions options = new BlobRequestOptions();
            ContainerFileTransfer.BeginListBlobsSegmented("", true, BlobListingDetails.All, 5, continuation, options, ListCtx, new AsyncCallback(ListFileTransferCallback), null);
        }

        // Callback for the segmented file listing in order to continue listing segments
        private void ListFileTransferCallback(IAsyncResult result)
        {
            var blobResultSegment = ContainerFileTransfer.EndListBlobsSegmented(result);
            foreach (CloudBlockBlob b in blobResultSegment.Results)
            {
                this.Invoke(new AddFileTransferDelegate(this.AddFileTransfer), new object[] { b });
            }

            if (blobResultSegment.ContinuationToken != null)
            {
                BlobRequestOptions options = new BlobRequestOptions();
                ContainerFileTransfer.BeginListBlobsSegmented("", true, BlobListingDetails.All, 5, blobResultSegment.ContinuationToken, options, ListCtx, new AsyncCallback(ListFileTransferCallback), null);
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
            TransferFile.FileLength = file.Blob.Properties.Length;
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
            /*
            if (txtUploadContainer.Text == "")
            {
                MessageBox.Show("Enter a container (usually your alias)");
                return;
            }

            txtUploadContainer.Text = txtUploadContainer.Text.Replace("\\", "/");

            CloudBlockBlob blob = ContainerFileTransfer.GetBlobReference(txtUploadContainer.Text + "/" + System.IO.Path.GetFileName(File));

            ctlTransfer UploadFile = new ctlTransfer();
            UploadFile.Blob = blob;
            UploadFile.URL = blob.Uri.AbsoluteUri;
            UploadFile.LocalFile = File;
            UploadFile.FileLength = new System.IO.FileInfo(File).Length;
            UploadFile.TransferCompleted += new EventHandler<AsyncCompletedEventArgs>(UploadFile_UploadCompleted);
            flowLayoutPanel1.Controls.Add(UploadFile);
            flowLayoutPanel1.ScrollControlIntoView(UploadFile);
            UploadFile.Upload();
            ActiveTransfers.Add(UploadFile);*/
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
        private CloudBlockBlob m_Blob;
        private System.Windows.Forms.ListViewItem m_lvi;

        public CloudBlockBlob Blob
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
