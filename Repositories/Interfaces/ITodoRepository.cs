using graphql_dotnet_server.Domain.Models.DTOs;
using graphql_dotnet_server.Repositories.MongoModels;

namespace graphql_dotnet_server.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllTodos();
        Task<Todo> CreateTodo(TodoCreateDTO todoToCreate);
        Task UpdateTodo(TodoDTO todoToUpdate);
        Task DeleteTodo(string todoId);
        Task<Todo?> GetTodo(string todoId);
        Task<List<Todo>> GetSimilarTodos(TodoDTO todo);
    }
}
