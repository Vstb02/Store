using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Store.Application.Common.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Store.WebAPI.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode? statusCode = null)
        {
            var code = HttpStatusCode.InternalServerError;
            string? message = null;
            switch (exception)
            {
                case DuplicateCategoryNameException categoryNameException:
                    code = HttpStatusCode.BadRequest;
                    message = categoryNameException.Message;
                    break;
                case DuplicateProductNameException categoryPorductException:
                    code = HttpStatusCode.BadRequest;
                    message = categoryPorductException.Message;
                    break;
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    message = validationException.Message;
                    break;
            }

            message ??= "Произошла внутренняя ошибка сервера";

            var result = JsonConvert.SerializeObject(new
            {
                ErrorMessage = message
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
