
namespace DateTime.Domain.Models.Users;

public interface IUserRepository
{
    void Add(User user);
    Task<User?> GetByName(string name);
    Task<User?> GetById(string id);
    //Task<User?> GetByUsername(string username);
}