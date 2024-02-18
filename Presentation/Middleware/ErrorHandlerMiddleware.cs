using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace Presentation.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (TaskCanceledException ex)
            {
                context.Response.StatusCode = 499;
                await context.Response.WriteAsync(ex.Message, Encoding.UTF8);
            }
            catch (FluentValidation.ValidationException error)
            {
                context.Response.Clear();
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(error.Errors.Select(x => new { x.ErrorMessage, x.PropertyName }));
                if(result.Contains("[]"))
                {
                    result = error.Message;
                }
                await context.Response.WriteAsync(result, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro interno na aplicação.");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(ex.Message, Encoding.UTF8);
            }
        }
    }
}
