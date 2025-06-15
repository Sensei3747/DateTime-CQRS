using DateTime.Domain.Models.Users;
using DateTime.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DateTime.Infrastructure.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _manager;

    public UserRepository(ApplicationDbContext dbContext, UserManager<User> manager)
    {
        _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _manager = manager ?? throw new ArgumentNullException(nameof(manager));
    }

    public async Task Add(User user, string password)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User cannot be null.");
        }
        await _manager.CreateAsync(user, password);
    }

    public async Task<User?> GetByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Email cannot be null or empty.", nameof(name));
        }

        var user = await _context.Set<User>().Where(user => user.UserName == name).FirstOrDefaultAsync();

        return user;
    }
    public async Task<User?> GetById(string id)
    {
        var user = await _context.Set<User>().FindAsync(id);
        return user;
    }
    public async Task<User?> GetByEmail(string email)
    {
        var user = await _manager.FindByEmailAsync(email);
        return user;
    }
}