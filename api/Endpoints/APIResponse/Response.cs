namespace api.Endpoints.APIResponse;

public class Response
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }

    public Response(int statusCode, string message)=>(StatusCode,Message)=(statusCode,message);
}
