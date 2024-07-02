using System.Net;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Application.DTOs;
using System.Text.Json;
using Newtonsoft.Json;

namespace SchoolUser.Application.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessRuleException businessRuleException)
            {
                await HandleBusinessRuleExceptionAsync(context, businessRuleException);
            }
            catch (Exception exception)
            {
                await HandleGenericExceptionAsync(context, exception);
            }
        }

        private static Task HandleBusinessRuleExceptionAsync(HttpContext context, BusinessRuleException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            ExceptionHandlingDto dto = new ExceptionHandlingDto()
            {
                ErrorType = "BusinessRuleException",
                ErrorMessage = exception.Message
            };

            var result = System.Text.Json.JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
            return context.Response.WriteAsync(result);
        }

        private static Task HandleGenericExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error. " + exception.Message;

            var result = JsonConvert.SerializeObject(new { error = message });
            return context.Response.WriteAsync(result);
        }
    }
}