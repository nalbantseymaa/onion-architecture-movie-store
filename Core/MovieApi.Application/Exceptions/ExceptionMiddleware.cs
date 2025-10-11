// using System.Net;
// using Microsoft.AspNetCore.Http;

// namespace MovieApi.Application.Exceptions;

// public class ExceptionMiddleware : IMiddleware
// {
//     public async Task InvokeAsync(HttpContext htttpContext, RequestHandlerDelegate next)
//     {
//         try
//         {
//             await next();
//         }
//         catch (Exception ex)
//         {
//             await HandleExceptionAsync(HttpContext httpContext, Exception exception){

//                 int statusCode = GetStatusCode(exception);
//                 HttpListenerContext.Response.ContentType = "application/json";
//                 HttpListenerContext.Response.StatusCode = statusCode;
//                 //excepiton mesaj da eklenir
//                 return

//             }
//         }

//     }

// }