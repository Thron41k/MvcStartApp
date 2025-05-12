using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Db;
using MvcStartApp.Models.Interfaces;

namespace MvcStartApp.Controllers
{
    public class UsersController(IBlogRepository repo) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var authors = await repo.GetUsers();
            return View(authors);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await repo.AddUser(newUser);
            return View(newUser);
        }
    }
}
