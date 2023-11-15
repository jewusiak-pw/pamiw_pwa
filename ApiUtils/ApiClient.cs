using System.Text;
using Newtonsoft.Json;

namespace pamiw_pwa.ApiUtils;

public class ApiClient : IApiClient
{
    private HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<TodoList>> GetLists()
    {
        var httpResponseMessage = await _httpClient.GetAsync("/list");
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            var lists = JsonConvert.DeserializeObject<GetListResponse>(content);

            return lists?.content.ToList() ?? new List<TodoList>();
        }

        return new List<TodoList>();
    }

    public async Task CreateList(string name)
    {
        await _httpClient.PostAsync("/list",
            new StringContent(JsonConvert.SerializeObject(new TodoList("", name, new List<TodoItem>())), Encoding.UTF8,
                "application/json"));
    }

    public async Task DeleteList(string id)
    {
        await _httpClient.DeleteAsync("/list/" + id);
    }

    public async Task CreateItem(string listId, string name)
    {
        var httpResponseMessage = await _httpClient.PostAsync("/item",
            new StringContent(JsonConvert.SerializeObject(new TodoItem("", false, name)), Encoding.UTF8,
                "application/json"));
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            var createdItem = JsonConvert.DeserializeObject<TodoItem>(content);
            var itemId = createdItem.uuid;

            await _httpClient.PostAsync("/item/" + itemId + "/setlist/" + listId, null);
        }
    }

    public async Task DeleteItem(string itemId)
    {
        await _httpClient.DeleteAsync("/item/" + itemId);
    }

    public async Task ChangeItemStatus(string itemId, bool status)
    {
        await _httpClient.PutAsync("/item/" + itemId, new StringContent(JsonConvert.SerializeObject(
            new Dictionary<string, object>
            {
                { "status", status }
            }), Encoding.UTF8, "application/json"));
    }
}