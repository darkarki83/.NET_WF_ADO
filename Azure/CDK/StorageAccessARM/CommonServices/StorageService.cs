using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#if CONSUMER
using Azure.Storage.Queues;

namespace MessageConsumer.Services
#elif QUERY
namespace TableSearch.Services
#endif
{
    public class StorageService
    {
#if CONSUMER
        public QueueClient Queue1 { get; }
#endif
        public CloudTable Table1 { get; }

        public StorageService()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(@"DefaultEndpointsProtocol=https;AccountName=artkdev1;AccountKey=iQ2UIgDj6Av8UcANf4lSQqKf64Jp/HcPkJheG9CfYYnx4p6G9wHxEcS8lViPNYGwg58wBCQRSpHF+2uIDu/CtQ==;BlobEndpoint=https://artkdev1.blob.core.windows.net/;QueueEndpoint=https://artkdev1.queue.core.windows.net/;TableEndpoint=https://artkdev1.table.core.windows.net/;FileEndpoint=https://artkdev1.file.core.windows.net/;");
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(@"DefaultEndpointsProtocol=https;AccountName=itstep1511gen;AccountKey=dRV5C8hAj+QpKYW+7My5xzpd1C5ZLSmWs6Wgnj/sQnaUR670ofKPcOFOXs7EEh0GUyXgrnHgpPFUqKeBBhYkhA==;BlobEndpoint=https://itstep1511gen.blob.core.windows.net/;QueueEndpoint=https://itstep1511gen.queue.core.windows.net/;TableEndpoint=https://itstep1511gen.table.core.windows.net/;FileEndpoint=https://itstep1511gen.file.core.windows.net/;");

#if CONSUMER
            Queue1 = new QueueClient(@"DefaultEndpointsProtocol=https;AccountName=artkdev1;AccountKey=iQ2UIgDj6Av8UcANf4lSQqKf64Jp/HcPkJheG9CfYYnx4p6G9wHxEcS8lViPNYGwg58wBCQRSpHF+2uIDu/CtQ==;BlobEndpoint=https://artkdev1.blob.core.windows.net/;QueueEndpoint=https://artkdev1.queue.core.windows.net/;TableEndpoint=https://artkdev1.table.core.windows.net/;FileEndpoint=https://artkdev1.file.core.windows.net/;", "queue1");
            var queueCreationTask = Queue1.CreateIfNotExistsAsync();
#endif

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            Table1 = tableClient.GetTableReference("table1");
            var tableCreationTask = Table1.CreateIfNotExistsAsync();

            Task.WaitAll(
#if CONSUMER
                queueCreationTask,
#endif
                tableCreationTask);

            ConditionalMethod();
        }

        [System.Diagnostics.Conditional("CONSUMER")]
        private static void ConditionalMethod()
        {
            Console.WriteLine("Conditional method");
        }
    }
}
