using MvcStartApp.Models.Db;

namespace MvcStartApp.Models.Interfaces
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
