using Azure.Storage.Queues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageProducer.Services
{
    public class QueueService
    {
        public QueueClient Queue1 { get; set; }

        public QueueService()
        {
            Queue1 = new QueueClient(@"DefaultEndpointsProtocol=https;AccountName=artkdev1;AccountKey=iQ2UIgDj6Av8UcANf4lSQqKf64Jp/HcPkJheG9CfYYnx4p6G9wHxEcS8lViPNYGwg58wBCQRSpHF+2uIDu/CtQ==;BlobEndpoint=https://artkdev1.blob.core.windows.net/;QueueEndpoint=https://artkdev1.queue.core.windows.net/;TableEndpoint=https://artkdev1.table.core.windows.net/;FileEndpoint=https://artkdev1.file.core.windows.net/;", "queue1");

            Queue1.CreateIfNotExistsAsync().Wait();

        }
    }
}
