
using Microsoft.AspNetCore.Identity;

namespace DateTime.Domain.Models.Users;

public interface IUserRepository
{
    Task<IdentityResult> Add(User user, string password);
    Task<User?> GetByName(string name);
    Task<User?> GetById(string id);
    Task<User?> GetByEmail(string email);
}