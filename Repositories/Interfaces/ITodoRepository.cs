using graphql_dotnet_server.Domain.Models.MongoModels;

namespace graphql_dotnet_server.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<Todos>> GetAllTodos();
    }
}
