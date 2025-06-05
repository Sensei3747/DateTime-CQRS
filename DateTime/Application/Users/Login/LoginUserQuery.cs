using DateTime.Application.Abstractions.Messaging;

namespace DateTime.Application.Users.Login;

public record LoginUserQuery(string email, string hashPassword) : IQuery<string>;