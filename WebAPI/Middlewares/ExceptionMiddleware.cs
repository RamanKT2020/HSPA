using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebAPI.Errors;

namespace WebAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IHostEnvironment env;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next
            , IHostEnvironment env
            , ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.env = env;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try 
            {
                await next(context);
            }
            catch (Exception ex)
            {
                ApiError apiError;

                string customMessage;

                var httpStatusCode = HttpStatusCode.InternalServerError;
                var exceptionType  = ex.GetType();

                //ToDo: Code for different exceptions explicitly to customize the messages and show proper status codes
                //switch statment doesn't work until C# 9.0
                if (exceptionType == typeof(UnauthorizedAccessException))
                {
                    httpStatusCode = HttpStatusCode.Forbidden;
                    customMessage = "You are not authorized.";
                }
                else
                {
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    customMessage  = "Some unknown error occured.";
                }

                if (env.IsDevelopment())
                {
                    apiError  = new ApiError((int) httpStatusCode, ex.Message, ex.StackTrace.ToString());
                } else {
                    apiError  = new ApiError((int) httpStatusCode, customMessage);
                }

                logger.LogError(ex, ex.Message); // this shows in the terminal window; can be used for database, file system, support email etc.
                context.Response.StatusCode  = (int) httpStatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(apiError.ToString());
            }
        }
    }
}