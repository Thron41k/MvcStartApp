using MvcStartApp.Models.Db;

namespace MvcStartApp.Models.Interfaces
{
    public interface ILogRepository
    {
        Task AddLog(Request request);
        Task<Request[]> GetLogs();
    }
}
