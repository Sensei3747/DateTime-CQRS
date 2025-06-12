
namespace DateTime.Domain.Users;

public interface IUserRepository
{
    void Add(User user);
    Task<User?> GetByName(string name);
    Task<User?> GetById(Guid id);
    //Task<User?> GetByUsername(string username);
}