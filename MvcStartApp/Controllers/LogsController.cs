using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models;
using MvcStartApp.Models.Interfaces;

namespace MvcStartApp.Controllers
{
    public class LogsController(ILogRepository repo) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var logs = await repo.GetLogs();
            return View(logs);
        }

        [HttpGet]
        public async Task<IActionResult> GetLogs()
        {
            var logs = await repo.GetLogs();
            return Json(logs);
        }
    }
}
