using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;
using MvcStartApp.Models.Interfaces;

namespace MvcStartApp.Models.Repositories
{
    public class BlogRepository(BlogContext context) : IBlogRepository
    {
        // ссылка на контекст

        // Метод-конструктор для инициализации

        public async Task AddUser(User user)
        {
            // Добавление пользователя
            var entry = context.Entry(user);
            if (entry.State == EntityState.Detached)
                await context.Users.AddAsync(user);

            // Сохранение изенений
            await context.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers()
        {
            // Получим всех активных пользователей
            return await context.Users.ToArrayAsync();
        }
    }
}
