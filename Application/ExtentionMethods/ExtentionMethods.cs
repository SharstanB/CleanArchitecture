using System.Net;
using Domain.CoreServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Application.ExtentionMethods;

public static class ExtentionMethods
{
    public static OperationResult<T?> SuccessResult<T>(this T? data) 
    {
        return new OperationResult<T?>(data, HttpStatusCode.OK);
    }

    public static OperationResult<T> FailedResult<T>(this T data , string message , Exception ex)
        => new OperationResult<T>(data,HttpStatusCode.BadRequest , message , ex);
    public static OperationResult<T> FailedResult<T>(this T data , string message)
        => new OperationResult<T>(data,HttpStatusCode.BadRequest , message);
    public static OperationResult<T> NotFoundResult<T>(this T data , string message)
        => new OperationResult<T>(data, HttpStatusCode.NotFound , message);

    public static OperationResult<T> ForbiddenResult<T>(this T data)
        => new OperationResult<T>(data, HttpStatusCode.Forbidden);
    public static OperationResult<T> OperationResult<T>(this T data , HttpStatusCode statusCode  // custom state
        , string message = "" , Exception? exception = null)
        => new OperationResult<T>(data, statusCode , message , exception);
    public static JsonResult ToJsonResult<T>(this T data) => data is null ? new JsonResult("") : new JsonResult(data);

}