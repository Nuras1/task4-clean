using Microsoft.EntityFrameworkCore;

namespace task4.Models
{
    public class User
    {
        private User(int id, string name, string passwordHash, string email, string Status, DateTime LastloginTime,DateTime CreatedAt)
        {
            Id = id;
            Name = name;
            PasswordHash = passwordHash;
            Email= email;
            PasswordHash = passwordHash;
            Status = status;
            LastloginTime = lastloginTime;
            CreatedAt = createdAt;
        }

        public int Id { get; set; }

        public string? Name { get; set; }

        public string Email { get; set; } = "";

        public string PasswordHash { get; set; } = "";

        public string Status { get; set; } = "";

        public DateTime LastLoginTime { get; set; }

        public DateTime CreatedAt { get; set; }

        public static User Create(int id, string name, string passwordHash, string email, string status, DateTime  lastloginTime, DateTime createdAt)
        {
            return new User(id,name,passwordHash,email,status,lastloginTime,createdAt)
        }
    }
}