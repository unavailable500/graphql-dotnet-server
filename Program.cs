using graphql_dotnet_server.Controllers;
using graphql_dotnet_server.Domain.Models.AppConfig;
using graphql_dotnet_server.Repositories.Implementations;
using graphql_dotnet_server.Repositories.Interfaces;
using graphql_dotnet_server.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoTodoProjectDatabaseSettings>(
    builder.Configuration.GetSection("MongoTodoDatabase")
);


builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    var config = serviceProvider.GetRequiredService<IOptions<MongoTodoProjectDatabaseSettings>>();
    return new MongoClient(config.Value.ConnectionString);
});

builder.Services.AddScoped<IMongoDatabase>(serviceProvider =>
{
    var config = serviceProvider.GetRequiredService<IOptions<MongoTodoProjectDatabaseSettings>>();
    IMongoClient client = serviceProvider.GetRequiredService<IMongoClient>();
    return client.GetDatabase(config.Value.DatabaseName);
});

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<TodoService>();

builder.Services
    .AddGraphQLServer()
    .AddMutationConventions()
    .RegisterService<MongoTodoProjectDatabaseSettings>()
    .RegisterService<IMongoClient>()
    .RegisterService<IMongoDatabase>()
    .RegisterService<ITodoRepository>()
    .RegisterService<TodoService>()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddTypeExtension<TodoDTOExtension>();



var app = builder.Build();

app.MapGraphQL();

app.MapGet("/", () => "The graphQL server is on /graphql !");

app.Run();
