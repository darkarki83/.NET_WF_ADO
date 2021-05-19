using Azure.Storage.Blobs;

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
            BlobServiceClient serviceClient = new BlobServiceClient(@"DefaultEndpointsProtocol=https;AccountName=artkdev1;AccountKey=iQ2UIgDj6Av8UcANf4lSQqKf64Jp/HcPkJheG9CfYYnx4p6G9wHxEcS8lViPNYGwg58wBCQRSpHF+2uIDu/CtQ==;BlobEndpoint=https://artkdev1.blob.core.windows.net/;QueueEndpoint=https://artkdev1.queue.core.windows.net/;TableEndpoint=https://artkdev1.table.core.windows.net/;FileEndpoint=https://artkdev1.file.core.windows.net/;");
            BlobContainerClient containerClient = serviceClient.GetBlobContainerClient("container1");

            foreach (var blob in containerClient.GetBlobs())
            {    
                var reference = containerClient.GetBlobClient(blob.Name);
                reference.DownloadTo(blob.Name);
            }

            Console.ReadKey();
        }
    }
}
