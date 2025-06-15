using DateTime.Application.Abstractions.Messaging;


namespace DateTime.Application.Users.Login;

public record LoginUserRequest(string email, string password) : IQuery<string>;