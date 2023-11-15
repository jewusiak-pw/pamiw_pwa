namespace pamiw_pwa.ApiUtils;

public class TodoList
{
    public string uuid { get; set; }
    public string name { get; set; }
    public List<TodoItem> items { get; }

    public TodoList(string uuid, string name, List<TodoItem> items)
    {
        this.uuid = uuid;
        this.name = name;
        this.items = items;
    }
}