using task4.Data;
using task4.Models;
namespace task4.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users
                .OrderByDescending(x => x.LastLoginTime)
                .ToList();
        }

        public async Task Block(List<int> ids)
        {
            var users = _context.Users.Where(u => ids.Contains(u.Id));

            foreach (var u in users)
                u.Status = UserStatus.Blocked;

            await _context.SaveChangesAsync();
        }

        public async Task Unblock(List<int> ids)
        {
            var users = _context.Users.Where(u => ids.Contains(u.Id));

            foreach (var u in users)
                u.Status = UserStatus.Active;

            await _context.SaveChangesAsync();
        }
        
        public async Task Delete(List<int> ids)
        {
            var users = _context.Users.Where(u => ids.Contains(u.Id));

            _context.Users.RemoveRange(users);
            await _context.SaveChangesAsync();
        }
    }
}
