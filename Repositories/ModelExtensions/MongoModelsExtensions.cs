using graphql_dotnet_server.Domain.Models.DTOs;
using graphql_dotnet_server.Repositories.MongoModels;

namespace graphql_dotnet_server.Repositories.ModelExtensions
{
    internal static class MongoModelsExtensions
    {
        public static Todo FromDto(this TodoCreateDTO x) {
            return new()
            {
                Title = x.Title,
                Description = x.Description,
                Completed = x.Completed,
            };
        }

        public static TodoDTO ToDto(this Todo x)
        {
            return new()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Completed = x.Completed,
            };
        }

        public static Todo FromDto(this TodoDTO x)
        {
            return new()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Completed = x.Completed,
            };
        }
    }
}
