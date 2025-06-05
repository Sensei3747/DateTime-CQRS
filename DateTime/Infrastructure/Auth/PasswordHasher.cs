using DateTime.Application.Abstractions.Auth;

namespace DateTime.Infrastructure.Auth;

public sealed class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        var passhash = BCrypt.Net.BCrypt.HashPassword(password);

        return passhash;
    }

    public bool Verify(string password, string passhash)
    {
        var verified = BCrypt.Net.BCrypt.Verify(password, passhash);

        return verified; 
    }
}