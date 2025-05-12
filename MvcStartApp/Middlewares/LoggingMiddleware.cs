using MvcStartApp.Models.Db;
using MvcStartApp.Models.Interfaces;

namespace MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context, ILogRepository logRepository)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
            await logRepository.AddLog(new Request
            {
                Id =  Guid.NewGuid(),
                Date = DateTime.Now,
                Url = context.Request.Host.Value + context.Request.Path
            });
            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
