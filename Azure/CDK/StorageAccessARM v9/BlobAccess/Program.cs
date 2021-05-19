using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(@"DefaultEndpointsProtocol=https;AccountName=itstep1511blob;AccountKey=ucnFo5pw6zUUlxb1cParY2D+qNX7NVgyUmawYX0Sy2TxGli/IydNewcEBui+3EvQHp7pFXxeMaJ6Xt/Zf7ItFw==;BlobEndpoint=https://itstep1511blob.blob.core.windows.net/;");
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("container1");

            foreach (IListBlobItem blob in container.ListBlobs())
            {
                string blobName = Uri.UnescapeDataString(Path.GetFileName(blob.Uri.AbsolutePath));
                var reference = container.GetBlobReferenceFromServer(blobName);
                reference.DownloadToFile(blobName, FileMode.Create);
            }

            Console.ReadKey();
        }
    }
}
