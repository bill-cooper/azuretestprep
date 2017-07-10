using System;
using System.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Linq;
using System.Linq.Expressions;
using System.Linq;

namespace webapp
{
    public static class Repository<T> where T : class
    {
        private static readonly string DatabaseId = ConfigurationManager.AppSettings["database"];
        private static readonly string CollectionId = ConfigurationManager.AppSettings["collection"];
        private static DocumentClient _client;

        public static void Initialize()
        {
            _client = new DocumentClient(new Uri(ConfigurationManager.AppSettings["endpoint"]), ConfigurationManager.AppSettings["authKey"]);
            try
            {
                var db = _client.CreateDatabaseIfNotExistsAsync(new Database { Id = DatabaseId }).Result;
                var collection = _client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DatabaseId), new DocumentCollection { Id = CollectionId }).Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static async Task<T> GetItemAsync(string id)
        {
            try
            {
                var document = await _client.ReadDocumentAsync<T>(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
                return document;
            }
            catch (DocumentClientException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public static async Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate)
        {
            var query = _client.CreateDocumentQuery<T>(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), new FeedOptions { MaxItemCount = -1 }).Where(predicate).AsDocumentQuery();
            var results = new List<T>();
            while (query.HasMoreResults)
                results.AddRange(await query.ExecuteNextAsync<T>());
            return results;
        }

        public static async Task<IEnumerable<T>> GetItemsAsync()
        {
            var query = _client.CreateDocumentQuery<T>(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), new FeedOptions { MaxItemCount = -1 }).AsDocumentQuery();
            var results = new List<T>();
            while (query.HasMoreResults)
                results.AddRange(await query.ExecuteNextAsync<T>());
            return results;
        }

        public static async Task<Document> CreateItemAsync(T item) {
            var document = await _client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), item);
            return document;
        }
        public static async Task<Document> UpdateItemAsync(string id, T item) {
            var document = await _client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id), item);
            return document;
        }

        public static async Task Delete(string id) {
            await _client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
        }
    }
}