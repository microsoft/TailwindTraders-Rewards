using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tailwind.Traders.Rewards.FuncApp.Extensions
{
    public static class CloudTableExtensions
    {
        public static async Task<TableQuerySegment<T>> GetItemsAsync<T>(this CloudTable table, string id) where T : ITableEntity, new()
        {
            TableQuery<T> rangeQuery = new TableQuery<T>()
                .Where(TableQuery.CombineFilters(
                        TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, TableStorage.CustomerPK),
                        TableOperators.And,
                        TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, id)));

            return await table.ExecuteQuerySegmentedAsync(rangeQuery, null);
        }

        public static async Task DeleteItemAsync<T>(this CloudTable table, T item) where T : ITableEntity, new()
        {                        
            TableOperation deleteOp = TableOperation.Delete(item);
            await table.ExecuteAsync(deleteOp);
        }       
    }
}
