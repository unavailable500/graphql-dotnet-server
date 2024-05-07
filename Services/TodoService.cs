using graphql_dotnet_server.Domain.Exceptions;
using graphql_dotnet_server.Domain.Models.DTOs;
using graphql_dotnet_server.Repositories.Implementations;
using graphql_dotnet_server.Repositories.Interfaces;
using graphql_dotnet_server.Repositories.ModelExtensions;
using graphql_dotnet_server.Repositories.MongoModels;
using MongoDB.Driver;

namespace graphql_dotnet_server.Services
{
    public class TodoService
    {
        private readonly ITodoRepository _todoRepository;
        public TodoService(ITodoRepository todoRepository) {
            _todoRepository = todoRepository;
        }

        public async Task<List<TodoDTO>> GetAllTodos()
        {

            List<Todo> todos = await _todoRepository.GetAllTodos();
            return todos.Select(t => t.ToDto()).ToList();
        }

        public async Task<TodoDTO> GetTodo(string todoId)
        {
            Todo? todo = await _todoRepository.GetTodo(todoId);
            if (todo == null)
            {
                throw new TodoNotFoundException(todoId);
            }
            return todo.ToDto();
        }

        public async Task<Todo> CreateTodo(TodoCreateDTO todoToCreate)
        {
            return await _todoRepository.CreateTodo(todoToCreate);
        }

        public async Task<TodoDTO> UpdateTodo(TodoDTO todoToCreate)
        {
            _ = await GetTodo(todoToCreate.Id);
            await _todoRepository.UpdateTodo(todoToCreate);
            return todoToCreate;
        }

        public async Task<TodoDTO> DeleteTodo(string todoId)
        {
            TodoDTO todo = await GetTodo(todoId);
            await _todoRepository.DeleteTodo(todoId);
            return todo;
        }


    }
}
