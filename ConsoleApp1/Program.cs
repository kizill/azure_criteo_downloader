using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Core;
using Microsoft.WindowsAzure.Storage.Blob.Protocol;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ConsoleApp1
{
    class Program
    {
        const string BASE_URI = "http://azuremlsampleexperiments.blob.core.windows.net/";
        static void Main(string[] args)
        {
            CloudBlobClient blobClient = new CloudBlobClient(new System.Uri(BASE_URI));
            CloudBlobContainer container = blobClient.GetContainerReference("criteo");

            var list = container.ListBlobs();
            foreach (IListBlobItem item in list)
            {
                System.Console.WriteLine(item.ToString());
            }

            CloudBlockBlob blockBlob = container.GetBlockBlobReference("day_0.gz");

            using (var fileStream = System.IO.File.OpenWrite(@"c:\OSP\day_0.gz"))
            {
                blockBlob.DownloadToStream(fileStream);
            }
        }
    }
}
