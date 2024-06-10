using graphql_dotnet_server.Domain.Models.DTOs;
using graphql_dotnet_server.Services;

namespace graphql_dotnet_server.Controllers
{

    [ExtendObjectType(typeof(TodoDTO))]
    public class TodoDTOExtension
    {
        public async Task<List<TodoDTO>> GetLinkedTodos([Parent] TodoDTO todo, TodoService todoCreateDTO) => await todoCreateDTO.GetSimilarTodos(todo);
    }
}
