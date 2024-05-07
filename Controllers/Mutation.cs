using graphql_dotnet_server.Domain.Exceptions;
using graphql_dotnet_server.Domain.Models.DTOs;
using graphql_dotnet_server.Repositories.MongoModels;
using graphql_dotnet_server.Services;

namespace graphql_dotnet_server.Controllers
{
    public class Mutation
    {
        public async Task<Todo> CreateTodo(TodoService todoService, TodoCreateDTO todoCreateDTO) => await todoService.CreateTodo(todoCreateDTO);

        [Error(typeof(TodoNotFoundException))]
        public async Task<TodoDTO> UpdateTodo(TodoService todoService, TodoDTO todo) =>  await todoService.UpdateTodo(todo);

        [Error(typeof(TodoNotFoundException))]
        public async Task<TodoDTO> DeleteTodo(TodoService todoService, string todoId) => await todoService.DeleteTodo(todoId);
    }
}
