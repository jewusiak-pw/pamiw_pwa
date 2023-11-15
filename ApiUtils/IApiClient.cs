namespace pamiw_pwa.ApiUtils;

public interface IApiClient
{
    Task<List<TodoList>> GetLists();
    Task CreateList(string name);
    Task DeleteList(string id);
    Task CreateItem(string listId, string name);
    Task DeleteItem(string itemId);
    Task ChangeItemStatus(string itemId, bool status);
}