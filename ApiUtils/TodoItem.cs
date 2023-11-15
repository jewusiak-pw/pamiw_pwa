using Newtonsoft.Json.Serialization;

namespace pamiw_pwa.ApiUtils;

public class TodoItem
{
    
    public string uuid { get; set; }
    public bool status { get; set; }
    public string name { get; set; }

    public TodoItem(string uuid, bool status, string name)
    {
        this.uuid = uuid;
        this.status = status;
        this.name = name;
    }
}