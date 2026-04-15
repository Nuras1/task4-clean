namespace task4.Models;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Email { get; set; } = "";

    public string PasswordHash { get; set; } = "";

    public UserStatus Status { get; set; } = UserStatus.Unverified;

    public DateTime LastLoginTime { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? EmailToken { get; set; }
}

public enum UserStatus
{
    Active,
    Blocked,
    Unverified
}