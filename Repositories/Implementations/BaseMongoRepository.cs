using MongoDB.Driver;

namespace graphql_dotnet_server.Repositories.Implementations
{

    /// <summary>
    /// Base class for any repository that uses a MongoDb
    /// </summary>
    public abstract class BaseMongoRepository
    {
        protected IMongoClient client;
        protected IMongoDatabase database;

        public BaseMongoRepository(IMongoClient mongo, IMongoDatabase db)
        {
            client = mongo;
            database = db;
        }

        public async Task SaveToCollection<T>(List<UpdateOneModel<T>> documents, string collectionName)
        {
            var userCollection = database.GetCollection<T>(collectionName);
            await userCollection.BulkWriteAsync(documents);
        }

        public IEnumerable<T> GetAllData<T>(string collectionName)
        {
            var collection = database.GetCollection<T>(collectionName);
            return collection.AsQueryable().ToList();
        }
    }
}
