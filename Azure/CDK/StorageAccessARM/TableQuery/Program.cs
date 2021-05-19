using Microsoft.Azure.Cosmos.Table;
using System;
using System.Linq;
using System.Threading.Tasks;
using TableSearch.Services;

namespace TableSearch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var table = new StorageService().Table1;

            var query = new TableQuery<BadMessage>()
            {
                TakeCount = 5
            }
            .Where(
                TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "BadMessages"),
                    TableOperators.And,
                    TableQuery.CombineFilters(
                        TableQuery.GenerateFilterCondition("Text", QueryComparisons.GreaterThanOrEqual, "a"),
                        TableOperators.And,
                        TableQuery.GenerateFilterCondition("Text", QueryComparisons.LessThan, "r"))));

            TableContinuationToken token = null;

            TableQuerySegment<BadMessage> seg;
            do
            {
                seg = await table.ExecuteQuerySegmentedAsync(query, token);
                token = seg.ContinuationToken;

                foreach (var badMessage in seg.Results)
                {

                    Console.WriteLine(badMessage.Text);

                    ///  Вариант 1
                    ///  Delete from Table
                    ///  Эту запись найденую по фильтру
                    ///   var insertOperation = TableOperation.Delete(badMessage);
                    ///   await table.ExecuteAsync(insertOperation);



                    ///  Вариант 2
                    ///  К тексту добавил 1

                    badMessage.Text = badMessage.Text + '1';

                    var insertOperation = TableOperation.InsertOrMerge(badMessage);

                    await table.ExecuteAsync(insertOperation);

                }

            } while (token != null);

            Console.ReadKey();
        }
    }
}
