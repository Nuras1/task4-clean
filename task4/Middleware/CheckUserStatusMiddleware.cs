using Microsoft.EntityFrameworkCore;
using task4.Data;
using task4.Models;

namespace task4.Middleware
{
    public class CheckUserMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, AppDbContext db)
        {
            var path = context.Request.Path.Value ?? "";

            if (path.StartsWith("/Account/Login") || path.StartsWith("/Account/Register"))
            {
                await _next(context);
                return;
            }

            var userId = context.Session.GetInt32("UserId");

            if (userId == null)
            {
                context.Response.Redirect("/Account/Login");
                return;
            }

            var user = await db.Users.FindAsync(userId);

            if (user == null || user.Status == UserStatus.Blocked)
            {
                context.Session.Clear();
                context.Response.Redirect("/Account/Login");
                return;
            }

            await _next(context);
        }
    }
}