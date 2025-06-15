

using System.Text.Json;

namespace Library.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        

        public ExceptionMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                string message = "";
                (context.Response.StatusCode,message)= ex switch 
                {
                    KeyNotFoundException => (404,ex.Message),
                    ArgumentNullException => (400,ex.Message),
                    ArgumentException => (400, ex.Message),
                    _ => (500,"Ошибка на сервере")
                };

                context.Response.ContentType = "application/json";

                var response = JsonSerializer.Serialize(new
                {
                    status = context.Response.StatusCode,
                    Error = message
                });

                await context.Response.WriteAsync(response);
            }
            }
        }
    }

