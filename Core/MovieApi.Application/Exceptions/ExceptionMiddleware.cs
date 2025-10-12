using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using SendGrid.Helpers.Errors.Model;

namespace MovieApi.Application.Exceptions;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        int statusCode = GetStatusCode(exception);
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;

        return httpContext.Response.WriteAsync(new ExceptionModel
        {
            StatusCode = statusCode,
            Message = exception.Message
        }.ToString());
    }

    private static int GetStatusCode(Exception exception) =>
     exception switch
     {
         BadRequestException => StatusCodes.Status400BadRequest,
         NotFoundException => StatusCodes.Status404NotFound,
         ValidationException => StatusCodes.Status422UnprocessableEntity,
         _ => StatusCodes.Status500InternalServerError
     };

}