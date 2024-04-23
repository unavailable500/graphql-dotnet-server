using graphql_dotnet_server.Domain.Models.MongoModels;
using graphql_dotnet_server.Repositories.Implementations;
using graphql_dotnet_server.Repositories.Interfaces;
using MongoDB.Driver;

namespace graphql_dotnet_server.Services
{
    public class TodoService
    {
        private readonly ITodoRepository _todoRepository;
        public TodoService(ITodoRepository todoRepository) {
            _todoRepository = todoRepository;
        }

        public async Task<List<Todos>> GetAllTodos()
        {

            return await _todoRepository.GetAllTodos();
        }
    }
}
