using lmltfy.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
namespace lmltfy.Database
{
    public class DatabaseRepository
    {
        readonly CloudTableClient TableClient;
        CloudTable Table;
        string TableName;
        public DatabaseRepository(string connectionString, string tableName)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException("connectionString");
            }
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("tableName");
            }
            TableName = tableName;
            TableClient = CloudStorageAccount.Parse(connectionString).CreateCloudTableClient();
            Table = TableClient.GetTableReference(TableName);
            Table.CreateIfNotExists();
        }

        public SearchModel GetModelByKey(string rowKey)
        {
            // Create a retrieve operation that takes a customer entity.
            var retrieveOperation = TableOperation.Retrieve<SearchModel>(SearchModel.ConsPartitionKey, rowKey);

            // Execute the retrieve operation.
            var result = Table.Execute(retrieveOperation);
            if (result.Result == null) return null;

            return result.Result as SearchModel;
        }
        public void Save(IEnumerable<SearchModel> searchModel)
        {
            var batchOperation = SaveBootstrap(searchModel);
            PostProcess(batchOperation);
        }



        public async Task SaveAsync(IEnumerable<SearchModel> searchModel)
        {
            var batchOperation = SaveBootstrap(searchModel);
            await Table.ExecuteBatchAsync(batchOperation);
            PostProcess(batchOperation);
        }

        static TableBatchOperation SaveBootstrap(IEnumerable<SearchModel> searchModel)
        {
            var batchOperation = new TableBatchOperation();
            foreach (var model in searchModel)
            {
                if (string.IsNullOrWhiteSpace(model.Url) || string.IsNullOrWhiteSpace(model.PartitionKey))
                {
                    throw new InvalidOperationException("We require a partition key, and row key");
                }
                batchOperation.InsertOrReplace(model);
            }

            return batchOperation;
        }

        void PostProcess(TableBatchOperation batchOperation)
        {
            foreach (var result in Table.ExecuteBatch(batchOperation))
            {
                if (result.Result == null)
                {
                    throw new Exception("Error saving");
                }
            }
        }
    }
}