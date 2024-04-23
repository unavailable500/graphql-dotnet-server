using graphql_dotnet_server.Domain.Models.AppConfig;
using graphql_dotnet_server.Domain.Models.MongoModels;
using graphql_dotnet_server.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

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

        private IMongoCollection<Todos> getTodoList
        {
            get
            {
                return database.GetCollection<Todos>(_databaseConfiguration.TodosCollectionName);
            }
        }

        public async Task<List<Todos>> GetAllTodos()
        {
            List<Todos> todoList = await (await getTodoList.FindAsync(_ => true)).ToListAsync();
            return todoList;
        }
    }
}
