namespace DateTime.Domain.Users;
public sealed class User
{
    private User(string email, string passwordHash)
    {
        Email = email;
        PasswordHash = passwordHash;
    }

    private User()
    {
    }

    public long Id { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }

    public static User Create(string email, string passwordHash)
    {
        var user = new User(email, passwordHash);

        return user;
    }
}