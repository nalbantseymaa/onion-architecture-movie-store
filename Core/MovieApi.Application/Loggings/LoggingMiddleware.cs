using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace MovieApi.Application.Loggings;

public class LoggingMiddleware
{
    private readonly RequestDelegate next;
    public LoggingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext httpcontext)
    {
        var watch = Stopwatch.StartNew();
        try
        {
            //REQUEST lOGGİNG
            var requestLog = new LoggingModel
            {
                RequestMethod = httpcontext.Request.Method,
                RequestPath = httpcontext.Request.Path
            }.ToString();
            Console.WriteLine("[Request] HTTP " + requestLog);
            await next(httpcontext);
            watch.Stop();

            //RESPONSE LOGGİNG
            var responseLog = new ResponseLoggingModel
            {
                RequestMethod = httpcontext.Request.Method,
                RequestPath = httpcontext.Request.Path,
                ResponseStatusCode = httpcontext.Response.StatusCode,
                ResponseTime = watch.ElapsedMilliseconds
            }.ToString();
            Console.WriteLine("[Response] HTTP " + responseLog);
        }
        catch (Exception ex)
        {
            watch.Stop();
            var errorLog = new ResponseLoggingModel
            {
                RequestMethod = httpcontext.Request.Method,
                RequestPath = httpcontext.Request.Path,
                ResponseStatusCode = 500,
                ResponseTime = watch.ElapsedMilliseconds
            }.ToString();
            Console.WriteLine("[Error] HTTP " + errorLog + " Error Message: " + ex.Message);
        }
    }
}