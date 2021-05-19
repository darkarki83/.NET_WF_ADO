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
            Queue1 = new QueueClient(@"DefaultEndpointsProtocol=https;AccountName=storage456;AccountKey=ciy8+1wf0HbCmXoI4h9hR8R+Wo6EyN+4TBfLAGiwI1NoUkE/jPR2O7JEVM4TfOd7If4/vzLMOj8BPyDYC09Xpg==;BlobEndpoint=https://storage456.blob.core.windows.net/;QueueEndpoint=https://storage456.queue.core.windows.net/;TableEndpoint=https://storage456.table.core.windows.net/;FileEndpoint=https://storage456.file.core.windows.net/;", "queue1");

            Queue1.CreateIfNotExistsAsync().Wait();

        }
    }
}
