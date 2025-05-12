using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;
using MvcStartApp.Models.Interfaces;

namespace MvcStartApp.Models.Repositories
{
    public class LogRepository(BlogContext context) : ILogRepository
    {
        // Метод-конструктор для инициализации
        public async Task AddLog(Request request)
        {
            var entry = context.Entry(request);
            if (entry.State == EntityState.Detached)
                await context.Requests.AddAsync(request);

            await context.SaveChangesAsync();
        }

        public async Task<Request[]> GetLogs()
        {
            return await context.Requests.OrderByDescending(x=>x.Date).ToArrayAsync();
        }
    }
}
