
namespace DateTime.Domain.Users;

public interface IUserRepository
{
    void Add(User user);
    Task<User?> GetByEmail(string email);
    Task<User?> GetById(long id);
    //Task<User?> GetByUsername(string username);
}