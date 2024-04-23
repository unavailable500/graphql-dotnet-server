namespace graphql_dotnet_server.Domain.Models.AppConfig
{
    public class MongoTodoProjectDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string TodosCollectionName { get; set; } = null!;
    }
}
