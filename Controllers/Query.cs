using graphql_dotnet_server.Domain.Exceptions;
using graphql_dotnet_server.Domain.Models.DTOs;
using graphql_dotnet_server.Repositories.MongoModels;
using graphql_dotnet_server.Services;

namespace graphql_dotnet_server.Controllers
{
    public class Query
    {
        public async Task<List<TodoDTO>> GetTodos(TodoService todoService) => await todoService.GetAllTodos();
        
        [Error(typeof(TodoNotFoundException))]
        public async Task<TodoDTO> GetTodo(TodoService todoService, string todoId) => await todoService.GetTodo(todoId);

    }
}
