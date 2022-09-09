using System.Net;

namespace Domain.CoreServices;

public class OperationResult<T> 
{
    public OperationResult(){}
    public OperationResult(T result, HttpStatusCode statusCode , string message, Exception? exception)
    {
        Result = result;
        Exception = exception;
        Message = message;
        StatusCode = statusCode;
    }

    public OperationResult(T result , HttpStatusCode statusCode)
    {
        Result = result;
        StatusCode = statusCode;
    }

    public OperationResult(T result , HttpStatusCode statusCode,string message = "")
    {
        Result = result;
        StatusCode = statusCode;
        Message = message;
    }

    public T? Result { get; set; }
    public Exception? Exception { get; set; }
    public string Message { get; set; }
    public HttpStatusCode? StatusCode { get; set; }
    
    
}