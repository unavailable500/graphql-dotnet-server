using graphql_dotnet_server.Domain.Models.AppConfig;
using graphql_dotnet_server.Domain.Models.DTOs;
using graphql_dotnet_server.Repositories.Interfaces;
using graphql_dotnet_server.Repositories.ModelExtensions;
using graphql_dotnet_server.Repositories.MongoModels;
using HotChocolate.Types.Relay;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace graphql_dotnet_server.Repositories.Implementations
{
    public class TodoRepository : BaseMongoRepository, ITodoRepository
    {
        private readonly MongoTodoProjectDatabaseSettings _databaseConfiguration;
        public TodoRepository(
            IOptions<MongoTodoProjectDatabaseSettings> databaseConfiguration,
            IMongoClient mongo,
            IMongoDatabase db
        ) : base(mongo, db)
        {
            _databaseConfiguration = databaseConfiguration.Value;
        }

        private IMongoCollection<Todo> getTodoList
        {
            get
            {
                return database.GetCollection<Todo>(_databaseConfiguration.TodosCollectionName);
            }
        }

        public async Task<List<Todo>> GetAllTodos()
        {
            List<Todo> todoList = await (await getTodoList.FindAsync(_ => true)).ToListAsync();
            return todoList;
        }

        public async Task<Todo> CreateTodo(TodoCreateDTO todoToCreate)
        {
            Todo todo = todoToCreate.FromDto();
            await getTodoList.InsertOneAsync(todo);
            return todo;
        }

        public async Task UpdateTodo(TodoDTO todoToUpdateDTO)
        {
            Todo todoToUpdate = todoToUpdateDTO.FromDto();
            var filter = Builders<Todo>.Filter.Eq(todo => todo.Id, todoToUpdate.Id);
            await getTodoList.ReplaceOneAsync(filter, todoToUpdate);
        }
        public async Task DeleteTodo(string todoId)
        {

            var filter = Builders<Todo>.Filter.Eq(todo => todo.Id, todoId);
            await getTodoList.DeleteOneAsync(filter);
        }

        public async Task<Todo?> GetTodo(string todoId)
        {

            var filter = Builders<Todo>.Filter.Eq(todo => todo.Id, todoId);
            Todo? todo = (await getTodoList.FindAsync(filter)).FirstOrDefault();
            return todo;
        }
    }
}
