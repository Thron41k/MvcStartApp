using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MvcStartApp.Middlewares;
using MvcStartApp.Models;
using MvcStartApp.Models.Interfaces;
using MvcStartApp.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ILogRepository, LogRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseMiddleware<LoggingMiddleware>();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
