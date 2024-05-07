using MongoDB.Bson;

namespace graphql_dotnet_server.Domain.Models.DTOs
{
    public class TodoCreateDTO
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool Completed { get; set; } = false;
    }
}
