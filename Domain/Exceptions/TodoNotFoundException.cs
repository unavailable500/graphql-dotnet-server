namespace graphql_dotnet_server.Domain.Exceptions
{
    public class TodoNotFoundException : Exception
    {
        public TodoNotFoundException(string todoId)
        : base($"The todo {todoId} is was not found")
        {
        }
    }
}
