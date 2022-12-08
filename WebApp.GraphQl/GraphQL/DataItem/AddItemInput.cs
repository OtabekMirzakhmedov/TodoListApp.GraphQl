namespace TodoListApp.GraphQl.GraphQL.DataItem
{
    public record AddItemInput(string title, string description, bool isDone, int listId);
}
