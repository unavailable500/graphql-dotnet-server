using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace graphql_dotnet_server.Domain.Models.MongoModels
{
    public class Todos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool Completed { get; set; } = false;
    }
}
