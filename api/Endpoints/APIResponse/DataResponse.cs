namespace api.Endpoints.APIResponse;

public class DataResponse<T>
{
     public int StatusCode { get; set; }
     public string? Message { get; set; }
     public T? Data { get; set; }

     public DataResponse(int statusCode, string message, T data)=>(StatusCode,Message,Data)=(statusCode,message,data);
}
