using FluentValidation;

namespace Todolist.WebAPI.Middleware
{
    public sealed class ValidationExceptionMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException exception)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                var erros = exception.Errors.Select(e => new
                {
                    propertyName = e.PropertyName,
                    errorMessage = e.ErrorMessage
                });

                await context.Response.WriteAsJsonAsync(new { Erros = erros });

            }
        }
    }
}
