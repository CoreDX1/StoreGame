namespace Store.Application.Wrappers;

public class Response<T>
{
    public Response() { }

    public Response(T data, string message = null!)
    {
        IsSuccess = true;
        Message = message;
        Data = data;
    }

    public Response(string message)
    {
        IsSuccess = false;
        Message = message;
    }

    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
}
