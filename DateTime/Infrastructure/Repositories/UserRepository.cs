using DateTime.Domain.Models.Users;
using DateTime.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DateTime.Infrastructure.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void Add(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User cannot be null.");
        }
        _context.Set<User>().Add(user);
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
    // public async Task<User?> GetByUsername(string username)
    // {
    //     var user = await _context.Set<User>().Where(user => user.Username == username).FirstOrDefaultAsync();
    //     return user;
    // }
}