using graphql_dotnet_server.Domain.Models.MongoModels;
using graphql_dotnet_server.Services;


public class Query
{
    public async Task<List<Todos>> GetTodos(TodoService todoService) => await todoService.GetAllTodos();
}
