using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace graphql_dotnet_server.Domain.Models.DTOs
{
    public class TodoDTO
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool Completed { get; set; } = false;
    }
}
