namespace pamiw_pwa.ApiUtils;

public class GetListResponse
{
    public TodoList[] content { get; set; }

    public GetListResponse(TodoList[] content)
    {
        this.content = content;
    }
}