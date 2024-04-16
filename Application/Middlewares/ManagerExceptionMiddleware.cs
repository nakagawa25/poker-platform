using Domain.Exceptions;
using System.Text.Json;

namespace Application.Middlewares
{
    public class ManagerExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ManagerExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (LoginException error)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";

                var errorMessage = error.Message;
                var jsonErrorResponse = JsonSerializer.Serialize(new { error = errorMessage });

                await context.Response.WriteAsync(jsonErrorResponse);
            }
            catch (UserException error)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                var errorMessage = error.Message;
                var jsonErrorResponse = JsonSerializer.Serialize(new { error = errorMessage });

                await context.Response.WriteAsync(jsonErrorResponse);
            }
            catch (Exception error)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var errorMessage = string.Concat("Erro da API. Erro: ", error.Message);
                var jsonErrorResponse = JsonSerializer.Serialize(new { error = errorMessage });

                await context.Response.WriteAsync(jsonErrorResponse);
            }
        }
    }
}
